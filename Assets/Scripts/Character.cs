using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterBase _base;
    int currHP;
    int attackMod;
    int defenseMod;
    int accuracyMod;
    public Character(CharacterBase cBase) {

        _base = cBase;
        currHP = _base.getMaxHP();

    }

}
