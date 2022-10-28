using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterScript : MonoBehaviour
{

    DialogueManager dialogueManager;
    EncounterManager encounterManager;
    public enum EncounterTypes { 
    PAY_ME,
    BOUNTY
    };

    EncounterTypes type;
    Sprite fieldIcon;
    string encounterDialog;
    int price;
    CharacterBase _base;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        encounterManager = FindObjectOfType<EncounterManager>();

    }
    void Update()
    {

    }

    //define Encounter
    public void Setup(EncounterTypes type, CharacterBase character) {

        this.type = type;

        _base = character;

        if (character.icon)
        {

            this.GetComponent<SpriteRenderer>().sprite = character.icon;

        }
        else {

            Debug.LogWarning("No sprite found");
        
        }

        

        if (type == EncounterTypes.PAY_ME) {

            price = character.pay_me_price;
        
        }

        if (type == EncounterTypes.BOUNTY)
        {
            encounterDialog = character.bounty_dialogue;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Diver") { 
           Debug.Log("OnCollisionEnter2D");
            dialogueManager.ShowDialogue("We couldnt implement a working combat system in time so instead here are the enemies you wouldve faced "+_base.character_name+": "+_base.description,2);
        }
      
    }

}
