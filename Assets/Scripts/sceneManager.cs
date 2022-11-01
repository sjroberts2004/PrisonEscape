using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
  public int scene;
  public GameObject self;
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      Destroy(self);
      UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
  }
}
