using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingMain : MonoBehaviour
{
  public List <GameObject> popuplist;
  public List<GameObject> enemylist;
  public List<GameObject> playerlist;
  public GameObject loadingsource;
  public int countdown;
  private GameObject playerlead;
  private GameObject enemylead;

  // note: in fight function player goes first. If both player and enemy would deal lethal damage, front enemy is killed and enemy behind it attacks instead.
  // also it looks like second enemy gets hit, this is only because it replaces the first one right away(No animation)
  public void fight(){
    Debug.Log("fight command received");
    if (playerlist.Count >=1 && enemylist.Count>=1){
     enemylead.GetComponent<statblock>().HP -= playerlead.GetComponent<statblock>().ATK;
     enemylead.SendMessage("adjusthealthbar");
     countdown--;
     if (enemylead.GetComponent<statblock>().HP<=0){
       enemylist.Remove(enemylead);
       Destroy(enemylead);
       assignpos(enemylist,true);
     }
     playerlead.GetComponent<statblock>().HP -= enemylead.GetComponent<statblock>().ATK;
     playerlead.SendMessage("adjusthealthbar");
     if (playerlead.GetComponent<statblock>().HP<=0){
       playerlist.Remove(playerlead);
       Destroy(playerlead);
       assignpos(playerlist, false);
     }
   }
   else{
     Debug.Log("At least one side is empty, fighting was skipped.");
   }

  }
  public void swap(){
    Debug.Log("switch command received");
    if (playerlist.Count>1){
    playerlist.Remove(playerlead);
    playerlist.Add(playerlead);
    assignpos(playerlist, false);
  }
  else{
    Debug.Log("One or fewer party members, switch was skipped.");
  }

  }
  public void assignpos(List<GameObject> lineup, bool enemy){
    if (lineup.Count >=1){
    int i = 0;
    foreach (GameObject g in lineup){
      g.GetComponent<statblock>().pos = i;
      i++;
    }
    if (enemy){
      enemylead = enemylist[0];
    }
    else{
      playerlead = playerlist[0];
    }
  }
  else if(enemy){
    Debug.Log("Player beat the encounter");
    popuplist[0].SetActive(true);
    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
  }
  else{
    Debug.Log("Player was defeated");
    popuplist[1].SetActive(true);
    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
  }
}
public void load(){
  playerlist = loadingsource.GetComponent<combatlistholder>().playerlist;
  enemylist = loadingsource.GetComponent<combatlistholder>().enemylist;
  assignpos(playerlist, false);
  assignpos(enemylist, true);

}
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnGUI()
    {
      GUI.Label(new Rect(400,50,400,50), countdown.ToString());


    }
    // Update is called once per frame
    void Update()
    {

    }
}
