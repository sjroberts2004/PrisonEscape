using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   
    CharacterBase _base;
    bool player;
    int currHP;
    int maxHP;
    int baseAttack;
    int baseDefence;
    int accuracy;
    int attackMod = 0;
    int defenseMod = 0;
    int accuracyMod = 0;

    Sprite Character_Sprite;
    public void Setup(CharacterBase cBase) {

        _base = cBase;
        currHP = _base.getMaxHP();
        maxHP = _base.getMaxHP();
        baseAttack = _base.base_attack;
        baseDefence = _base.defense;
        accuracy = _base.accuracy;

        Character_Sprite = cBase.character_sprite;

    }

}
