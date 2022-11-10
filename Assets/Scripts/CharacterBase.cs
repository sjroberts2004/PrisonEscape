using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Create new character")]
public class CharacterBase : ScriptableObject
{

    [SerializeField] public bool active = true;
    [SerializeField] public string character_name;

    [TextArea]
    [SerializeField] public string description;

    [SerializeField] public int level;
    [SerializeField] public int maxHP;
    
    [SerializeField] public int attack;
    [SerializeField] public int defense;
    [SerializeField] public int accuracy;

    [SerializeField] public Sprite icon;
    [SerializeField] public Sprite character_sprite;

    [SerializeField] public int pay_me_price;
    [TextArea] [SerializeField] public string bounty_dialogue;

    [SerializeField] Dictionary<EncounterTypes, bool> usableTypes = new Dictionary<EncounterTypes, bool>();

    void Start()
    {

    }
    void Update()
    {

    }
    public int getMaxHP(){ return maxHP; }



}
