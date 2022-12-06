using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Character
{
    // A gameobject to be put in the scene.
    public GameObject Obj;

    //Character Base Object to be used for base stats
    public CharacterBase _base;

    public GameObject hpBar;

    //stats
    int maxHP;
    int HP;
    int ATK;
    int DEF;
    int ACC;
    public int pos;
    public int[] statblock;

    // modifiers on stats to be used later in combat
    int attackMod = 0;
    int defenseMod = 0;
    int accuracyMod = 0;

    public Sprite characterSprite;
    public Character(CharacterBase cBase) {

        // check if there is a valid Character base,
        // then assign the base to this character.

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
            characterSprite = _base.character_sprite;

        }
        else
        {
            Debug.LogWarning("No sprite found");
        }

        hpBar = GameObject.Instantiate(GameController.hpBarPrefabStatic, Obj.transform);

        Hide();

        // Assign stats

        maxHP = _base.GetMaxHP();
        HP = maxHP;
        ATK = _base.GetAttack();
        DEF = _base.GetDefence();
        ACC = _base.GetAccuracy();
        statblock = new int[] {HP, ATK, DEF, ACC}; // 95% accuracy

    }

    void MoveTo(Vector3 newPos) {

        Obj.transform.position = newPos;

    }
    public void Show()
    {

        Obj.GetComponent<SpriteRenderer>().enabled = true;

    }

    public void Hide()
    {

        Obj.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void FlipSpriteOnX() {

        Obj.GetComponent<SpriteRenderer>().flipX ^= true;

    }
}
