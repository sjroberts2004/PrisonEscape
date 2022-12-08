using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHPBar : MonoBehaviour
{

    GameObject healthBar;
    GameObject healthBarBG;

    float localScale;

    private void Awake()
    {
        healthBar = transform.GetChild(0).gameObject; //this is the sprite for the HP bar
        healthBarBG = transform.GetChild(1).gameObject; //this is for it's BG
    }

    // Start is called before the first frame update
    void Start()
    {
        localScale = healthBar.transform.localScale.y;
    }
    void Update()
    {
        
    }
    public void adjusthealthbar(int currHP, int MaxHP)
    {
       
        float percentHP = (float)currHP / (float)MaxHP;

        Vector3 newScale = new Vector3(2.8f, localScale * percentHP, 0.7f);

        healthBar.transform.localScale = newScale;

    }

    public void Show(Character ch) {

        // print("HealthBar.Show is being Called");

        healthBar.SetActive(true);
        healthBarBG.SetActive(true);

        Vector3 pos = ch.Obj.transform.position + new Vector3(0, ch.characterSprite.bounds.size.y + 0.1f, 0);

        this.transform.position = pos;

    }
    public void Hide() {

        print("HealthBar.hide is being Called");
        healthBar.SetActive(false);
        healthBarBG.SetActive(false);
        print("HealthBar.hide is finished being Called");

    }


    }
