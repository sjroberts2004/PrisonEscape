using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class statblock : MonoBehaviour
{

  public int HP;
  public int maxHP;
  public int ATK;
  public int DEF;
  public int ACC;
  public bool enemy;
  public int pos;
  private int yline = 110;
  private int x;
  private Vector3 position;
  private Texture2D texture;

    // Start is called before the first frame update
    public void adjusthealthbar(){
      Debug.Log("adjust received");
      Debug.Log(HP);
      float percentHP = (float)HP/(float)maxHP;
      int ratio = (int)Mathf.Round(percentHP*50);
      Debug.Log(ratio);
      texture.Reinitialize(ratio, 3);
      for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
              Color color;
              if (percentHP>0.5){
                color = ((x & y) != 0 ? Color.white : Color.green);
              }
              else if (percentHP>0.2){
                color = ((x & y) != 0 ? Color.white : Color.yellow);
              }
              else{
                color = ((x & y) != 0 ? Color.white : Color.red);
              }
                texture.SetPixel(x, y, color);
            }
        }
      texture.Apply();

    }
    void Start()
    {
      position = new Vector3(0,0.5F,0);
      texture = new Texture2D(50, 3);
      for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = ((x & y) != 0 ? Color.white : Color.green);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
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
      GUI.Label(new Rect(x-15,yline+20, x-15, yline+20),texture);

    }
}
