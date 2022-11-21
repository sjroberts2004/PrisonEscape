using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EncounterManager : MonoBehaviour
{
    private List<CharacterBase> Characters;
    private List<CharacterBase> repeatCharacters;
    public GameObject EncounterPrefab;
    public GameObject CharacterPrefab;
    GameObject player;
    MovementScript movementScript;
    
    public static int level = 1;
    int steps = 0;
    int root = 0;
    int range = 2;
    public void step() {

        steps++;
        player.GetComponent<PlayerInfo>().loseO2(2);

    }
    private void Awake()
    {
        Characters = new List<CharacterBase>();
        repeatCharacters = new List<CharacterBase>();

        player = GameObject.Find("Player");
        movementScript = player.GetComponent<MovementScript>();

        Debug.Log("Attempting to Load characters");
        Object[] chars = Resources.LoadAll("Unique", typeof(CharacterBase));

        foreach (var cbase in chars) {
            if (cbase != null)
            {
                Debug.Log("Attempting to add " + cbase + "To Character Database");
                Characters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
            }
        }

        Object[] repeat_chars = Resources.LoadAll("Repeating", typeof(CharacterBase));

        foreach (var cbase in repeat_chars)
        {
            if (cbase != null)
            {
                Debug.Log("Attempting to add " + cbase + "To repeating Character Database");
                Characters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
            }
        }
    }
    void Update() {
        if (steps > root + range) {
            
            //Debug.Log("Generating Encounter...");
            GenerateRandomEncounter();
            root = steps;

        }
    }
    void GenerateRandomEncounter() {

        GameObject newEncounter;
        EncounterTypes chosenType = chooseEncounterType();
        CharacterBase chosenCharacter;

        newEncounter = Instantiate(EncounterPrefab, new Vector3(movementScript.position.x + 6, -0.88f, 0), Quaternion.identity);

        chosenCharacter = chooseEncounterCharacter(level, chosenType, true);

        //chosenItem = chooseItem(level, etc);

        newEncounter.GetComponent<EncounterScript>().Setup(chosenType, chosenCharacter);
        
    }
    private static bool findCharacter(CharacterBase cb)
    {
        return cb.level == EncounterManager.level;
    }
    CharacterBase chooseEncounterCharacter(int level, EncounterTypes type, bool unique) {

        CharacterBase result;

        List<CharacterBase> sample;

        if (unique)
        {
            sample = Characters.FindAll(findCharacter);
        }
        else 
        {
            sample = repeatCharacters.FindAll(findCharacter);
        }

        int val = (int)Random.Range(0, sample.Count);

        result = sample[val];

        return result;

    }
    EncounterTypes chooseEncounterType()
    {
        EncounterTypes chosenType;

        int numEncounterTypes = System.Enum.GetNames(typeof(EncounterTypes)).Length;

        int val = (int)Random.Range(0, numEncounterTypes);

        chosenType = (EncounterTypes)val;

        return chosenType;

    }

    public int getLevel() { return level; }

    //Player makes x steps
    //Generate Encounter Box
    //On collision with Encounter Box
    //  Display options GUI
    //  Do Options

}

public class Encounter
{ 







}