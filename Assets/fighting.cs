using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighting : MonoBehaviour
{
  public GameObject enemy;
  public GameObject player;
  

    // Start is called before the first frame update
    void Start()
    {
      ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
          enemy.GetComponent<statblock>().HP = enemy.GetComponent<statblock>().HP-5;
        }
    }
}
