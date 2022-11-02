using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatlistholder : MonoBehaviour
{
  public List<GameObject> allenemies;
  public List<GameObject> enemylist;
  public List<GameObject> playerlist;
  private int randomenemyno;
  private int randomgen;

    // Start is called before the first frame update
    void Start()
    {

      randomenemyno = Random.Range(1,5);
      for (int i = 0; i < randomenemyno; i++){
      randomgen = Random.Range(0,3);
      enemylist.Add(GameObject.Instantiate(allenemies[randomgen]));
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
