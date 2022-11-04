using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EncounterManager : MonoBehaviour
{
    [SerializeField] Canvas encounterDialogueCanvas;
    DialogueManager dialogueManager; 

    List<GameObject> ActiveEncounters;
    [SerializeField] List<CharacterBase> Characters;

    public GameObject EncounterPrefab;
    [SerializeField] GameObject player;

    MovementScript movementScript;

    int EncounterIndex = 0;
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
        dialogueManager = encounterDialogueCanvas.GetComponent<DialogueManager>();
        movementScript = player.GetComponent<MovementScript>();
    }

    void Update() {
        if (steps > root + range) {
            
            Debug.Log("Generating Encounter...");
            GenerateRandomEncounter();
            root = steps;

        }
    }
    void GenerateRandomEncounter() {

        GameObject LastestEncounter;
        EncounterScript.EncounterTypes chosenType;
        CharacterBase chosenCharacter;

        LastestEncounter = Instantiate(EncounterPrefab, new Vector3(movementScript.position.x + 6, -0.88f, 0), Quaternion.identity);

        chosenType = chooseEncounterType();

        LastestEncounter.GetComponent<EncounterScript>().Setup(chosenType, chosenCharacter);
        
    }
    CharacterBase chooseEncounterCharacter(int level) {

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
    EncounterScript.EncounterTypes chooseEncounterType()
    {

        int numEncounterTypes = System.Enum.GetNames(typeof(EncounterScript.EncounterTypes)).Length;

        int val = (int)Random.Range(0, numEncounterTypes);

        switch (val) {

            case 0:
                return EncounterScript.EncounterTypes.BOUNTY;

            case 1:
                return EncounterScript.EncounterTypes.PAY_ME;
        }

        return EncounterScript.EncounterTypes.PAY_ME; // incase this proccess messes up

    }

    //Player makes x steps
    //Generate Encounter Box
    //On collision with Encounter Box
    //  Display options GUI
    //  Do Options

}
