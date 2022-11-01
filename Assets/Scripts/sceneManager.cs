using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
  public bool enabled;
  public int scene;
  public GameObject self;
  void OnTriggerEnter2D(Collider2D other)
  {
    if (enabled && other.CompareTag("Player"))
    {
      Destroy(self);
      SceneManager.LoadScene(scene);
    }
  }
}
