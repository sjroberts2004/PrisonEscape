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

    public Encounter active;

    public static int level = 1; // stores the games current Level
    public static EncounterTypes desired_type;

    //For the steps thing probably move this to the Game controller
    int steps = 0;
    int root = 0;
    int range = 2;

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

        // put this all in a function somewhere Jesus

        Debug.Log("Attempting to Load characters");
        Object[] chars = Resources.LoadAll("Unique", typeof(CharacterBase));

        foreach (var cbase in chars) {
            if (cbase != null)
            {
                //Debug.Log("Attempting to add " + cbase + "To Character Database");
                Characters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
            }
        }

        Object[] repeat_chars = Resources.LoadAll("Repeating", typeof(CharacterBase));

        foreach (var cbase in repeat_chars)
        {
            if (cbase != null)
            {
                //Debug.Log("Attempting to add " + cbase + "To repeating Character Database");
                Characters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
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

        Encounter encounter;

        encounter = new Encounter(this, ChooseEncounterType());

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

        if (unique)
        {

        sample = Characters.FindAll(FindCharacterBasedOnLevel); // find characters of the right level
            desired_type = type;

        sample = sample.FindAll(FindCharacterBasedOnType); // and of the right type

            if (sample != null)
            {

                int val = (int)Random.Range(0, sample.Count);
                result = sample[val];

            }
            else { return null; }

        }
        else 
        {

        sample = repeatCharacters.FindAll(FindCharacterBasedOnLevel);

            if (sample != null)
            {
                int val = (int)Random.Range(0, sample.Count);
                result = repeatCharacters[val];
            }
            else { return null; }

        }
        return result;
    }
    public EncounterTypes ChooseEncounterType()
    {
        EncounterTypes chosenType;

        int numEncounterTypes = System.Enum.GetNames(typeof(EncounterTypes)).Length;

        int val = (int)Random.Range(0, numEncounterTypes);

        chosenType = (EncounterTypes)val;

        return chosenType;

    }
    public int getLevel() { return level; }
    public void DisplayEncounter() {

        EncounterCanvas.enabled = true;
        

        //re write immediately loll
        GameObject.Find("GameController").gameObject.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TMPro.TMP_Text>().text 
            = System.Enum.GetNames(typeof(EncounterTypes))[(int)active.type];

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
