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
    int currHP;
    int attack;
    int defence;
    float accuracy;
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

        Hide();

        // Assign stats

        maxHP = _base.GetMaxHP();
<<<<<<< HEAD
        currHP = maxHP;
        attack = _base.GetAttack();
        defence = _base.GetDefence();
        this.accuracy = _base.accuracy; // 95% accuracy
=======
        HP = maxHP;
        ATK = _base.GetAttack();
        DEF = _base.GetDefence();
        ACC = _base.GetAccuracy();
        statblock = new int[] {HP, ATK, DEF, ACC}; // 95% accuracy
>>>>>>> b31f1ff2f1f20077d0cbfccad17776e023571ed7

    }

    void MoveTo(Vector3 newPos) {

        Obj.transform.position = newPos;

    }
    public void Show()
    {

        //Debug.Log("CH.Show is being Called");
        Obj.GetComponent<SpriteRenderer>().enabled = true;
      
    }
    public void Hide()
    {

        Obj.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void CreateHpBar() {

        hpBar = GameObject.Instantiate(GameController.hpBarPrefabStatic, Obj.transform);

        ShowHpBar();

    }
    public void Attack(Character en) {

        int dmg;

        dmg = attack + attackMod;

        en.TakeDamage(dmg);

    }

    public void TakeDamage(int dmg){

        int total = (int)((float)dmg * (1 - (0.4 * Mathf.Log10(defence + defenseMod)))); //find percent damage reduction, max 40%

        currHP -= total;
    
    }
        public void ShowHpBar()
    {

        hpBar.GetComponent<LiveHPBar>().Show(this);

    }
    public void HideHpBar() {

        hpBar.GetComponent<LiveHPBar>().Hide();

    }
    public void FlipSpriteOnX() {

        Obj.GetComponent<SpriteRenderer>().flipX ^= true;

    }
}
