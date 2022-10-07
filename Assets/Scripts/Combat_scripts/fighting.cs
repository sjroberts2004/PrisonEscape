using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighting : MonoBehaviour
{
  public GameObject enemylead;
  public GameObject playerlead;

  public void fight(){
     enemylead.GetComponent<statblock>().HP -= playerlead.GetComponent<statblock>().ATK;
     if (enemylead.GetComponent<statblock>().HP<=0){
       Destroy(enemylead);
     }
     playerlead.GetComponent<statblock>().HP -= enemylead.GetComponent<statblock>().ATK;
     if (playerlead.GetComponent<statblock>().HP<=0){
       Destroy(playerlead);
     }

  }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){

        }
    }
}
