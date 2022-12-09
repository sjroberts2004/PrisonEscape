using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EncounterScript : MonoBehaviour
{
    Encounter encounter;
    EncounterTypes type;
    Sprite fieldIcon;
    string encounterDialog;
    CharacterBase _base;

    GameController GC;
    EncounterManager EM;

    private void Awake()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        EM = GameObject.Find("GameController").GetComponent(typeof(EncounterManager)) as EncounterManager;
    }
    void Start(){
        
    }
    void Update(){
    
    }

    //define Encounter
    //change this so that this function only sets sprite handle all other things in another OBJ (lol)
    public void Setup(EncounterTypes type, Encounter encounter) {

        this.encounter = encounter;

        if (encounter._base == null && encounter.characterEncounter == true) {
            
            Debug.LogError("no base found");

            return;

        } else if (this.EM == null) {

            Debug.LogError("Couldn't find EM");

            return;

        }
       
        switch (type) {

            case EncounterTypes.CHEST:
                this.GetComponent<SpriteRenderer>().sprite = GC.transform.GetComponent<EncounterManager>().chestSprite; //good god
                break;

            default:
                this.GetComponent<SpriteRenderer>().sprite = encounter._base.character_sprite;
                break;
        }

        //encounter.Spill();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        EM.active = this.encounter; 

        if (collision.gameObject.name == "Player") {
           //Debug.Log("OnCollisionEnter2D");

            EM.DisplayEncounter();

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("OnCollisionEnter2D");

            EM.HideEncounter();

        }
    }
 
}
