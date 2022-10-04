using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statblock : MonoBehaviour
{
  public int HP;
  public int ATK;
  public int DEF;
  public int ACC;
  public bool enemy;
  
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update(){

    }
    // Update is called once per frame
    void OnGUI()
    {
      if(!enemy){
        GUI.Label(new Rect(225,200,475,330), HP.ToString());
      }
      else{
        GUI.Label(new Rect(325,200,600,330), HP.ToString());
      }

    }
}
