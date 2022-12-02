using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Encounter
{

    GameObject me;

    GameController GC;

    EncounterManager manager;

    public EncounterTypes type;

    Sprite fieldIcon;

    string encounterDialog;

    public bool characterEncounter; //tracks if the enconter needs a character base or not.

    int price; // price for whatever type of encounter this is

    public CharacterBase _base;

    public Encounter(EncounterManager manager, EncounterTypes type) {

        this.manager = manager;

        GC = manager.gameObject.GetComponent<GameController>();

        me = GameObject.Instantiate(manager.EncounterPrefab, new Vector3(GC.playerObj.transform.position.x + 6, -0.88f, 0), Quaternion.identity);

        this.type = manager.ChooseEncounterType();

        characterEncounter = true;

            switch (type)
            {
                case EncounterTypes.CHEST:
                characterEncounter = false;

                break;

                case EncounterTypes.BOUNTY:
                _base = manager.ChooseEncounterCharacter(type, true);
                break;

                case EncounterTypes.FREE_ME:
                _base = manager.ChooseEncounterCharacter(type, true);
                price = _base.free_me_price;

                break;

                case EncounterTypes.PAY_ME:
                _base = manager.ChooseEncounterCharacter(type, true);
                price = _base.pay_me_price;

                break;

            }

        me.GetComponent<EncounterScript>().Setup(type, this);

    }
    public void startEncounter() {

        switch (type)
        {

            case EncounterTypes.PAY_ME:
                Debug.Log("Pay me encounter");
                FightPlayer();
                break;

            case EncounterTypes.BOUNTY:
                Debug.Log("Bounty encounter");
                FightPlayer();
                break;

            case EncounterTypes.FREE_ME:
                Debug.Log("Bounty encounter");
                FightPlayer();
                break;

            case EncounterTypes.CHEST:
                Debug.Log("Bounty encounter");

                break;
        }

    }
    void FightPlayer() {

        //creates a new character based on the selected Character
        Character newChar;
        newChar = new Character(_base);

        //Loads that Character into a new team
        Team enemy;
        enemy = new Team(newChar);

        //find the players team
        Team playersTeam = GC.playerTeam;

        GC.CM.startCombat(playersTeam, enemy);

    }

}
public enum EncounterTypes
{
    FREE_ME,
    PAY_ME,
    BOUNTY,
    CHEST
};