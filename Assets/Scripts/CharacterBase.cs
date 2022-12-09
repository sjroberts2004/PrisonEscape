using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Create new character")]
public class CharacterBase : ScriptableObject
{
   // public bool active = true;
    [SerializeField] public string character_name;

    [TextArea]
    [SerializeField] public string description;

    [SerializeField] int level;
    [SerializeField] int maxHP;

    [SerializeField] int attack;
    [SerializeField] int defence = 1;
    [SerializeField] float accuracy;

    public Sprite icon;
    public Sprite character_sprite;
    public bool isRightFacing = false;

    [SerializeField] bool pay_me_enabled = true;
    [SerializeField] bool free_me_enabled = true;
    [SerializeField] bool bounty_enabled = true;

    [SerializeField] public int pay_me_price_food;
    [SerializeField] public int free_me_price_O2;
    [TextArea] [SerializeField] public string bounty_dialogue;
    [TextArea] [SerializeField] public string payme_dialogue;
    [TextArea] [SerializeField] public string freeme_dialogue;

    public int GetLevel(){ return level; }
    public int GetMaxHP() { return maxHP; }
    public int GetAttack() { return attack; }
    public int GetDefence() { return defence; }
    public bool IsTypeUsable(EncounterTypes type) {

        switch (type){

            case EncounterTypes.FREE_ME:
                return free_me_enabled;

            case EncounterTypes.PAY_ME:
                return pay_me_enabled;

            case EncounterTypes.BOUNTY:
                return bounty_enabled;

        }
        return false;
    }
}
