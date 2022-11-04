using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EncounterTypes
{
    PAY_ME,
    BOUNTY
};
public class EncounterScript : MonoBehaviour
{

    DialogueManager dialogueManager;
    EncounterManager encounterManager;
   
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
            dialogueManager.ShowDialogue(_base.character_name+": "+_base.description,2);
        }
      
    }

}
