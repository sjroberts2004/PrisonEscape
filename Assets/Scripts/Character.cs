using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character
{
    // A gameobject to be put in the scene.
    public GameObject Obj;

    //Character Base Object to be used for base stats
    CharacterBase _base;

    //boolean that decides if this Character is the Player
    bool player;
    bool enemy;

    //stats
    int maxHP;
    int attack;
    int defense;
    int accuracy;

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


        if (_base.character_sprite != null)
        {
            Obj.AddComponent<SpriteRenderer>();
            Obj.GetComponent<SpriteRenderer>().sprite = _base.character_sprite;
        }
        else 
        { 
            Debug.LogWarning("No sprite found"); 
        }

    }
    public void Setup() {

      

        /*
        this.GetComponent<SpriteRenderer>().sprite = _base.character_sprite;
        this.GetComponent<statblockMain>().HP = _base.maxHP;
        this.GetComponent<statblockMain>().maxHP = _base.maxHP;
        this.GetComponent<statblockMain>().ATK = _base.attack;
        this.GetComponent<statblockMain>().DEF = _base.defense;
        this.GetComponent<statblockMain>().ACC = _base.accuracy;
        this.GetComponent<statblockMain>().enemy = true;
        */



    }

}
