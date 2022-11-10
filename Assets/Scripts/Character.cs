using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    CharacterBase _base;
    bool player;
    int maxHP;
    int attack;
    int defense;
    int accuracy;
    //int attackMod = 0;
    //int defenseMod = 0;
  //  int accuracyMod = 0;
    Sprite character_sprite;


    Sprite Character_Sprite;
    public void Setup(CharacterBase cBase) {

        _base = cBase;
        this.GetComponent<SpriteRenderer>().sprite = _base.character_sprite;
        this.GetComponent<statblockMain>().HP = _base.maxHP;
        this.GetComponent<statblockMain>().maxHP = _base.maxHP;
        this.GetComponent<statblockMain>().ATK = _base.attack;
        this.GetComponent<statblockMain>().DEF = _base.defense;
        this.GetComponent<statblockMain>().ACC = _base.accuracy;
        this.GetComponent<statblockMain>().enemy = true;

    }

}
