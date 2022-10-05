using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Create new character")]
public class CharacterBase : ScriptableObject
{


    //Character name
    [SerializeField] string character_name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int max_HP;

    [SerializeField] int base_attack;

    [SerializeField] int defense;

    [SerializeField] int accuracy;

    [SerializeField] Sprite icon;

    [SerializeField] Sprite character_sprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
