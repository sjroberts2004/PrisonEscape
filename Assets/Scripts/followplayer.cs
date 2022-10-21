using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
  public GameObject player;
  public float interpSpeed;
  private Vector3 targetPos;
    // Update is called once per frame
    void LateUpdate()
    {
      targetPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
      transform.position = Vector3.Lerp(transform.position, targetPos, interpSpeed);
    }
}