using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EncounterManager : MonoBehaviour
{
    [SerializeField] List<CharacterBase> Characters;
    public GameObject EncounterPrefab;
    [SerializeField] GameObject player;
    MovementScript movementScript;
    
    int level = 1;
    int steps = 0;
    int root = 0;
    int range = 2;
    public void step() {
        steps++;
        player.GetComponent<PlayerInfo>().loseO2(2);
    }

    private void Awake()
    {

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

        newEncounter.GetComponent<EncounterScript>().Setup(chosenType, chosenCharacter);
        
    }
    CharacterBase chooseEncounterCharacter(int level, EncounterTypes type) {

        CharacterBase result;

        List<CharacterBase> sample = Characters.FindAll(
               delegate (CharacterBase ch)
               {

                   return ch.level == level;

               });

        int val = (int)Random.Range(0, sample.Count);

        result = sample[val];

        return null;

    }
    EncounterTypes chooseEncounterType()
    {
        EncounterTypes chosenType;

        int numEncounterTypes = System.Enum.GetNames(typeof(EncounterTypes)).Length;

        int val = (int)Random.Range(0, numEncounterTypes);

        chosenType = (EncounterTypes)val;

        return chosenType;

    }

    //Player makes x steps
    //Generate Encounter Box
    //On collision with Encounter Box
    //  Display options GUI
    //  Do Options

}
