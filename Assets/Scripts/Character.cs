using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character
{
    // A gameobject to be put in the scene.
    public GameObject Obj;

    //Character Base Object to be used for base stats
    CharacterBase _base;

    //stats
    int maxHP;
    int currHP;
    int attack;
    int defence;
    float accuracy;

    // modifiers on stats to be used later in combat
    int attackMod = 0;
    int defenseMod = 0;
    int accuracyMod = 0;

    Sprite character_sprite;
    Sprite Character_Sprite;

    public Character(CharacterBase cBase) {

        //check if there is a valid Character base,
        //then assign the base to this character.

        if (cBase) {
            _base = cBase; 
        } else {
            Debug.LogWarning("No Character Base found");
        }
       
        Debug.Log("Creating new: " + _base.character_name);

        Obj = new GameObject();
        Obj.name = _base.character_name;

        if (_base.character_sprite != null) // make sure there is a Sprite for the Character
        {
            Obj.AddComponent<SpriteRenderer>();
            Obj.GetComponent<SpriteRenderer>().sprite = _base.character_sprite;
        }
        else 
        { 
            Debug.LogWarning("No sprite found"); 
        }

        void Show() {

            Obj.GetComponent<SpriteRenderer>().sprite = _base.character_sprite;

        }

        void Hide() {

            Obj.GetComponent<SpriteRenderer>().sprite = _base.character_sprite;

        }

        // Assign stats
        maxHP = _base.GetMaxHP();
        currHP = maxHP;
        attack = _base.GetAttack();
        defence = _base.GetDefence();
        accuracy = 0.95f; // 95% accuracy

    }
}
