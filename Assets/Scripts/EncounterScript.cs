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

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }

}
