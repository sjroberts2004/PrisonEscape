using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfloor : MonoBehaviour
{

  public GameObject floortile;
  public Vector3 nextposition;
  public GameObject player;
  private Vector3 frontofplayer;
  private float radius = 0.05F;

    // Update is called once per frame
    void Update()
    {
      frontofplayer = new Vector3(player.transform.position.x+1, player.transform.position.y-1, 0);
      if(Physics2D.OverlapCircle(frontofplayer,radius))
      {
        Debug.Log("Not extending floor!");
      }
      else{
        Debug.Log("Floor extending!");
        GameObject spawnedFloor = GameObject.Instantiate(floortile, nextposition, Quaternion.identity) as GameObject;
        nextposition = new Vector3(nextposition.x +1, nextposition.y, nextposition.z);
      }
    }
}
