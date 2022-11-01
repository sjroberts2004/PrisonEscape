using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitcher : MonoBehaviour
{
  public bool enabled;
  public Camera cam1;
  public Camera cam2;
  public GameObject self;
  void OnTriggerEnter2D(Collider2D other)
  {
    if (enabled && other.CompareTag("Player"))
    {
      Destroy(self);
      cam1.enabled = false;
      cam2.enabled = true;
    }
  }
}
