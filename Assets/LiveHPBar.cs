using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHPBar : MonoBehaviour
{

    GameObject healthBar;

    float localScale;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.GetChild(0).gameObject;//this is the sprite for the HP bar
        localScale = healthBar.transform.localScale.y;

        Hide();
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

        gameObject.SetActive(true);

        Vector3 pos = ch.Obj.transform.position + new Vector3(0, ch.characterSprite.bounds.size.y + 0.1f, 0);

        this.transform.position = pos;

    }
    public void Hide() {

        gameObject.SetActive(false);

    }


    }
