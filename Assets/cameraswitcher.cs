using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitcher : MonoBehaviour
{
  public bool enabled;
  private GameObject control;

  void Start()
  {
  control = GameObject.Find("GameController");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (enabled && other.CompareTag("Player"))
    {
      GameObject.Find("Diver").GetComponent<MovementScript>().frozen = true;
      Destroy(gameObject);
      control.GetComponent<GameController>().cams[0].enabled = false;
      control.GetComponent<GameController>().cams[1].enabled = true;

    }
  }
}
