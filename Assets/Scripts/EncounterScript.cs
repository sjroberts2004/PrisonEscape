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
    EncounterManager encounterManager;
    EncounterTypes type;
    Sprite fieldIcon;
    string encounterDialog;
    int price;
    CharacterBase _base;

    void Start()
    {
        encounterManager = FindObjectOfType<EncounterManager>();

    }
    void Update()
    {

    }

    //define Encounter
    public void Setup(EncounterTypes type, CharacterBase character) {

        if (!character) { Debug.LogError("No valid character given"); }

        this.type = type;

        _base = character;

        if (_base.icon != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = character.icon;
        }
        else { Debug.LogWarning("No sprite found"); }

        switch (type) {

            case EncounterTypes.PAY_ME:
                price = character.pay_me_price;
                break;

            case EncounterTypes.BOUNTY:
                encounterDialog = character.bounty_dialogue;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Diver") {
           Debug.Log("OnCollisionEnter2D");
           GameObject.Find("GameController").SendMessage("switchCams");
          GameObject.Find("combatmanager").SendMessage("SpawnEnemies");
        }
    }

}
