using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Create new character")]
public class CharacterBase : ScriptableObject
{
    //Character name
    [SerializeField] public bool active = true;
    [SerializeField] public string character_name;

    [TextArea]
    [SerializeField] public string description;

    [SerializeField] int level;
    [SerializeField] int max_HP;
    [SerializeField] int base_attack;
    [SerializeField] int defense;
    [SerializeField] int accuracy;

    [SerializeField] public Sprite icon;
    [SerializeField] public Sprite character_sprite;

    [SerializeField] public int pay_me_price;
    [TextArea] [SerializeField] public string bounty_dialogue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getMaxHP(){ return max_HP; }

    public bool isValidEncounterType(EncounterScript.EncounterTypes type) { 
    
        switch (type) { 
        
            case EncounterScript.EncounterTypes.PAY_ME:
                return pay_me_enabled;

            case EncounterScript.EncounterTypes.BOUNTY:
                return bounty_enabled;
        
        }

        return false;
    
    }
}
