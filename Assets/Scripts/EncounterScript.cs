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
    GameObject CharacterPrefab;
    GameController GC;

    void Start()
    {
        encounterManager = FindObjectOfType<EncounterManager>();
        CharacterPrefab = encounterManager.CharacterPrefab;
        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {

    }

    //define Encounter
    public void Setup(EncounterTypes type, CharacterBase character) {

        if (!character) { Debug.LogError("No valid character given"); }

        this.type = type;

        _base = character;

        if (_base.character_sprite != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = character.character_sprite;
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
        if (collision.gameObject.name == "Player") {
           Debug.Log("OnCollisionEnter2D");

            switch (type)
            {
                case EncounterTypes.PAY_ME:
                    //GC.switchCams();
                    Debug.Log("Pay me encounter");
                    break;

                case EncounterTypes.BOUNTY:
                    //just for testing
                    //creates a new character based on the selected Character
                    Character newChar;
                    newChar = new Character(_base);

                    //Loads that Character into a new team
                    Team enemy;
                    enemy = new Team(newChar);

                    //find the players team
                    Team playersTeam = GC.playerTeam;

                    //and start combat
                    GC.switchCams();
                    GC.CM.startCombat(playersTeam, enemy);

                    break;
            }


        }
    }

}
