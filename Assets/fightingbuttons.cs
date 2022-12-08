using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingbuttons : MonoBehaviour
{
  public List <GameObject> popuplist;
  public List <Character> enemylist;
  public List <Character> playerlist;
  public int bar;
  public GameObject backbutton;
  public GameObject fightbutton;
  private Character plead;
  private Character elead;
  private int damage;

  // note: in fight function player goes first. If both player and enemy would deal lethal damage, front enemy is killed and enemy behind it attacks instead.
// also it looks like second enemy gets hit, this is only because it replaces the first one right away(No animation)
  IEnumerator fight(){
    Debug.Log("fight command received");
    bar = Random.Range(1,101);
    elead = enemylist[0];
    plead = playerlist[0];

    if (playerlist.Count >=1 && enemylist.Count>=1){
      Debug.Log("fightstep");

      if (bar >= 100- elead.statblock[3]){
        damage = plead.statblock[1] - elead.statblock[2];
        if (damage<1){damage = 1;}
        elead.statblock[0] -= damage;
        //elead.SendMessage("adjusthealthbar");
        //elead.SendMessage("hit");
      }
     //fightbutton.GetComponent<Button>().interactable =false;
     if(elead.statblock[0]<0){elead.statblock[0] = 0;}
     yield return new WaitForSeconds(1f);
     if (elead.statblock[0]<=0){
       enemylist.Remove(elead);
       //should be destroyed here
       elead.Hide();
       assignpos(enemylist,true);
     }
     if (enemylist.Count > 0 && bar >= 100 - elead.statblock[3]){
       damage =  elead.statblock[1] - plead.statblock[2];
       if (damage<1){damage = 1;}
       plead.statblock[0] -= damage;
       //plead.SendMessage("adjusthealthbar");
      // plead.SendMessage("hit");
       if (plead.statblock[0]<=0){
         playerlist.Remove(plead);
         //should be destroyed here
         plead.Hide();
         assignpos(playerlist, false);
       }
      }
     //fightbutton.GetComponent<Button>().interactable =true;
   }
   else{
     Debug.Log("At least one side is empty, fighting was skipped.");
   }

  }
  public void swap(){
    Debug.Log("switch command received");
    if (playerlist.Count>1){
    playerlist.Remove(plead);
    playerlist.Add(plead);
    assignpos(playerlist, false);
  }
  else{
    Debug.Log("One or fewer party members, switch was skipped.");
  }

  }
  public void backout(){
    backbutton.SetActive(false);
    GameController.switchCams();
    GameObject.Find("Player").GetComponent<MovementScript>().frozen = false;
  }
  public void assignpos(List<Character> lineup, bool enemy){
    if (lineup.Count >=1){
    int i = 0;
    foreach (Character g in lineup){
      //statblockMain gstat = g.GetComponent<statblockMain>();
      //gstat.healthbarenabled = true;
      g.pos = i;
      i++;
    }
    if (enemy){
      elead = enemylist[0];
    }
    else{
      plead = playerlist[0];
    }
  }
  else if(enemy){
    Debug.Log("Player beat the encounter");
    popuplist[0].SetActive(true);
    backbutton.SetActive(true);
  }
  else{
    Debug.Log("Player was defeated");
    foreach(Character e in enemylist){
      //statblockMain estat = e.GetComponent<statblockMain>();
      //estat.healthbarenabled = false;
    }
    popuplist[1].SetActive(true);
    backbutton.SetActive(true);

  }
}
public void load(){
  assignpos(playerlist, false);
  assignpos(enemylist, true);

}
}
