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
  public int pos;
  private int yline = 120;
  private int x;
  private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
      position = new Vector3(0,0.5F,0);
    }
    void Update(){
      if(enemy){
        x = 520+(60*pos);
        position.x = 1.5F+(pos);
      }
      else{
        x = 345-(60*pos);
        position.x = -1.5F-(pos);
      }
      transform.position = position;
    }
    // Update is called once per frame
    void OnGUI()
    {
      GUI.Label(new Rect(x,yline,x,yline), HP.ToString());


    }
}
