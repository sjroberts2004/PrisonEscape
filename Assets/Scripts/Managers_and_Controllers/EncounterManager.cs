using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EncounterManager : MonoBehaviour
{
    // Stores all the Unique enemies data
    private List<CharacterBase> Characters;

    // Stores all the Repeating "Generic Enemies data
    private List<CharacterBase> repeatCharacters;

    public GameObject EncounterPrefab;// phase these out!

    GameObject player;
    MovementScript movementScript;

    public Sprite chestSprite;

    Canvas EncounterCanvas;
    public GameObject encounterCanvasTextObject;
    TMPro.TextMeshProUGUI encounterCanvasText;

    public Encounter active;

    public static int level = 1; // stores the games current Level
    public static EncounterTypes desired_type;

    //For the steps thing probably move this to the Game controller
    int steps = 0;
    int root = 0;
    int range = 1;

    public void step() {

        steps++;
        player.GetComponent<PlayerInfo>().loseO2(Random.Range(1,4)); //random range from 1 - 4 excluding 4

    }
    private void Awake()
    {   

        Characters = new List<CharacterBase>();
        repeatCharacters = new List<CharacterBase>();

        player = GameObject.Find("Player");
        movementScript = player.GetComponent<MovementScript>();

        EncounterCanvas = GameObject.Find("GameController").GetComponent<GameController>().EncounterCanvas;

        encounterCanvasText = encounterCanvasTextObject.GetComponent<TMPro.TextMeshProUGUI>();

        // Put this all in a function somewhere Jesus

        Debug.Log("Attempting to Load characters");
        Object[] chars = Resources.LoadAll("Unique", typeof(CharacterBase));

        foreach (var cbase in chars) {
            if (cbase != null)
            {
                //Debug.Log("Attempting to add " + cbase + "To Unique Character Database");
                Characters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
            }
        }

        Object[] repeat_chars = Resources.LoadAll("Repeating", typeof(CharacterBase));

        foreach (var cbase in repeat_chars)
        {
            if (cbase != null)
            {
                //Debug.Log("Attempting to add " + cbase + "To repeating Character Database");
                repeatCharacters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
            }
        }
    }
    void Update() {
        if (steps > root + range) {

            //Debug.Log("Generating Encounter...");
            root = steps;
            GenerateRandomEncounter();
           

        }
    }
    void GenerateRandomEncounter() {

        Encounter encounter = new Encounter(this, ChooseEncounterType());

        //encounter.Spill();

    }
    private static bool FindCharacterBasedOnLevel(CharacterBase cb)
    {
        return cb.GetLevel() == EncounterManager.level;
    }
    private static bool FindCharacterBasedOnType(CharacterBase cb)
    {
        return cb.IsTypeUsable(desired_type);
    }
    public CharacterBase ChooseEncounterCharacter(EncounterTypes type, bool unique) {

        CharacterBase result;

        List<CharacterBase> sample;

        List<CharacterBase> sample2;

        if (unique)
        {

        sample = Characters.FindAll(FindCharacterBasedOnLevel); // find characters of the right level
            desired_type = type;

        sample2 = sample.FindAll(FindCharacterBasedOnType); // and of the right type

            if (sample2 != null)
            {

                int val = (int)Random.Range(0, sample2.Count);
                result = sample2[val];

            }
            else { return null; }

            Characters.Remove(result);

        }
        else 
        {

        sample2 = repeatCharacters.FindAll(FindCharacterBasedOnLevel);

            if (sample2 != null)
            {
                int val = (int)Random.Range(0, sample2.Count);
                result = repeatCharacters[val];
            }
            else { return null; }

        }
        return result;
    }

    public static int GenerateRandomNumber() {

        //free me, pay me, bounty, chest

        int[] nums = new int[] { 0, 2, };

        int val = (int)Random.Range(0, nums.Length);

        return nums[val];

    }
    public EncounterTypes ChooseEncounterType()
    {
        EncounterTypes chosenType;

        int numEncounterTypes = System.Enum.GetNames(typeof(EncounterTypes)).Length;

        int val = GenerateRandomNumber();

        chosenType = (EncounterTypes)val;

        //print("Type Chosen: " + chosenType);

        return chosenType;

    }
    public int getLevel() { return level; }
    public void DisplayEncounter() {

    EncounterCanvas.enabled = true;

    encounterCanvasText.text = System.Enum.GetNames(typeof(EncounterTypes))[(int)active.type];

    Debug.Log("Display should say :" + active.type);

    }
    public void HideEncounter()
    {

        EncounterCanvas.enabled = false;

    }
    public void AcceptEncounter() {

        EncounterCanvas.enabled = false;

        active.startEncounter();

    }
    public void DeclineEncounter()
    {

        EncounterCanvas.enabled = false;

    }

    //Player makes x steps
    //Generate Encounter Box
    //On collision with Encounter Box
    //  Display options GUI
    //  Do Options

}
