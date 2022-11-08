using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EncounterManager : MonoBehaviour
{
    List<CharacterBase> Characters;
    public GameObject EncounterPrefab;
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
        player = GameObject.Find("Player");
        movementScript = player.GetComponent<MovementScript>();

        Debug.Log("Attempting to Load characters");

        Object[] chars = Resources.LoadAll("", typeof(CharacterBase));

        foreach (var cbase in chars) {

            Debug.Log("Attempting to add " + cbase + "To Character Database");
            Characters.Add(cbase as CharacterBase); // Load all CharacterBases into a list
            
        }
    }
    void Update() {
        if (steps > root + range) {
            
            Debug.Log("Generating Encounter...");
            GenerateRandomEncounter();
            root = steps;

        }
    }
    void GenerateRandomEncounter() {

        GameObject newEncounter;
        EncounterTypes chosenType = chooseEncounterType();
        CharacterBase chosenCharacter;

        newEncounter = Instantiate(EncounterPrefab, new Vector3(movementScript.position.x + 6, -0.88f, 0), Quaternion.identity);

        chosenCharacter = chooseEncounterCharacter(level, chosenType);

        //chosenItem = chooseItem(level, etc);

        newEncounter.GetComponent<EncounterScript>().Setup(chosenType, chosenCharacter);
        
    }
    private static bool findCharacter(CharacterBase cb)
    {
        return cb.level == EncounterManager.level;
    }
    CharacterBase chooseEncounterCharacter(int level, EncounterTypes type) {

        CharacterBase result;

        List<CharacterBase> sample = Characters.FindAll(findCharacter);

        int val = (int)Random.Range(0, sample.Count);

        Debug.Log("val: " + val);
        Debug.Log("count: " + sample.Count);

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
