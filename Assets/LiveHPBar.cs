using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveHPBar : MonoBehaviour
{

    GameObject healthBar; //this is the sprite for the HP bar

    GameObject healthBarBG; //this is the sprite for the HP bar's background

    float localScale;

    // Start is called before the first frame update
    void Awake()
    {
        //find relevant objects
        healthBar = transform.GetChild(0).gameObject;
        healthBarBG = transform.GetChild(1).gameObject;

        //set x scale
        localScale = healthBar.transform.localScale.x;

        Hide();

    }
    public void AdjustHealthBar(int currHP, int MaxHP)
    {
       
        float percentHP = (float)currHP / (float)MaxHP;

        Vector3 newScale = new Vector3(localScale * percentHP, 0.7f, 0.7f);

        healthBar.transform.localScale = newScale;

    }
    public void Set(Character ch) {

        Vector3 pos = ch.Obj.transform.position + new Vector3(0, ch.characterSprite.bounds.size.y + 0.1f, 0);

        this.transform.position = pos;

    }
    public void Show() {

        healthBar.GetComponent<SpriteRenderer>().enabled = true;

        healthBarBG.GetComponent<SpriteRenderer>().enabled = true;

    }
    public void Hide()
    {

        healthBar.GetComponent<SpriteRenderer>().enabled = false;

        healthBarBG.GetComponent<SpriteRenderer>().enabled = false;

    }

}
