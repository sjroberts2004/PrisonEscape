using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character
{
    // A gameobject to be put in the scene.
    public GameObject Obj;

    //Character Base Object to be used for base stats
    public CharacterBase _base;

    public GameObject hpBar;

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

        CreateHpBar();
        Hide();

        // Assign stats

        maxHP = _base.GetMaxHP();
        currHP = maxHP;
        attack = _base.GetAttack();
        defence = _base.GetDefence();
        accuracy = 0.95f; // 95% accuracy

    }

    void MoveTo(Vector3 newPos) {

        Obj.transform.position = newPos;
    
    }

    public void CreateHpBar() {

        hpBar = GameObject.Instantiate(GameController.hpBarPrefabStatic, Obj.transform);

    }
    public void ShowHpBar() {

        hpBar.GetComponent<LiveHPBar>().Show();

    }
    public void HideHpBar() {

        hpBar.GetComponent<LiveHPBar>().Hide();

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
