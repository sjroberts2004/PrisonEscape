using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character
{
    // A gameobject to be put in the scene.
    public GameObject Obj;

    //Character Base Object to be used for base stats
    public CharacterBase _base;

    public GameObject hpBar;

    Team myTeam;

    //stats
    int maxHP;
    public int currHP;
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
    public void UpdateHpBar() {

        hpBar.GetComponent<LiveHPBar>().AdjustHealthBar(currHP, maxHP);

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
    public void Attack(Character en)
    {
        int dmg;
        dmg = attack + attackMod;
        en.TakeDamage(dmg);
    }
    public void TakeDamage(int dmg)
    {

        int total;
        float reduction = 0.4f * Mathf.Log10(defence + defenseMod); //find percent damage reduction, max 40%
        float remainder = 1f - reduction; // 1 - reduction = remainder

        total = (int) ((float)dmg * remainder); // incoming * remainder = new value

        if (total < 0 || total > 500) { // checking to make sure negative or infinity damage is never assigned

            total = 0;

            Debug.LogWarning("Crazy number generated for damage, check math. \n");
        
        }

        LoseHp(total);

        Debug.Log(_base.character_name + " is assigned " + dmg + " damage!! \n");

        Debug.Log(_base.character_name + " defence of " + defence + " reduced incoming damage by" + reduction * 100 + "%.\n");

        Debug.Log(_base.character_name + " is taking " + total + " damage.");

        UpdateHpBar();

    }
    public void LoseHp(int hp) {

        if (hp >= currHP)
        {

            Die();

        }

        currHP -= hp;
    
    }
    public void JoinTeam(Team team) {

        myTeam = team;

        myTeam.Log();

    }
    public void Die() {

        HideHpBar();
        Hide();

        myTeam.reward += _base.pay_me_price_food;

        myTeam.RemoveCharacter(this);

        if (_base.character_name == "Diver") {

            SceneManager.LoadScene(0);

        }
    
    }

}
