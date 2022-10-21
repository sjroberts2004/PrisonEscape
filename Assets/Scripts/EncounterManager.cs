using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    [SerializeField] Canvas encounterCanvas;
    DialogueManager dialogueManager;

    List<GameObject> ActiveEncounters;
    [SerializeField] List<CharacterBase> Level1;

    public GameObject EncounterPrefab;
    [SerializeField] GameObject player;

    MovementScript movementScript;

    int EncounterIndex = 0;
    int level = 1;
    int steps = 0;
    int root = 0;
    int range = 3;
    public void step() {
        Debug.Log("step");
        steps++;
    }
    private void Awake()
    {
        dialogueManager = encounterCanvas.GetComponent<DialogueManager>();
        movementScript = player.GetComponent<MovementScript>();
    }

    void Update() {
        if (steps > root + range) {
            
            Debug.Log(root);
            Debug.Log(steps);
            Debug.Log("Gen Encounter");
       
            GenerateEncounter();
            root = steps;
            Debug.Log(root);
            Debug.Log(steps);
        }
    }

    void GenerateEncounter() {

        GameObject LastestEncounter;

        LastestEncounter = Instantiate(EncounterPrefab, new Vector3(movementScript.position.x + 6, -0.88f, 0), Quaternion.identity);

        LastestEncounter.GetComponent<EncounterScript>().Setup(chooseEncounterType(), chooseEncounterCharacter());
        //ActiveEncounters[0].GetComponent<EncounterScript>().Setup(chooseEncounterType(),chooseEncounterCharacter());

    }

    CharacterBase chooseEncounterCharacter() {

        return Level1[(int)Random.Range(0, Level1.Count)];
    
    }
    EncounterScript.EncounterTypes chooseEncounterType()
    {
       int val = (int)Random.Range(0, 1);

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
