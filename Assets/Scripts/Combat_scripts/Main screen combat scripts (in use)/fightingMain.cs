using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightingMain : MonoBehaviour
{
    /*
  public GameObject CharacterPrefab;
  public List <GameObject> popuplist;
  public List <CharacterBase> testenemyinput;
  public List <GameObject> enemylist;
  public List <GameObject> playerlist;
  public int countdown;
  public int bar;
  public List <Camera> cameras;
  public GameObject backbutton;
  private GameObject playerlead;
  private GameObject enemylead;
  private int damage;
  // note: in fight function player goes first. If both player and enemy would deal lethal damage, front enemy is killed and enemy behind it attacks instead.
  // also it looks like second enemy gets hit, this is only because it replaces the first one right away(No animation)
  public void fight(){
    Debug.Log("fight command received");
    bar = Random.Range(1,101);

    if (playerlist.Count >=1 && enemylist.Count>=1){

      if (bar >= 100- enemylead.GetComponent<statblockMain>().ACC){
        damage = playerlead.GetComponent<statblockMain>().ATK-enemylead.GetComponent<statblockMain>().DEF;
        if (damage<1){damage = 1;}
     enemylead.GetComponent<statblockMain>().HP -= damage;
     enemylead.SendMessage("adjusthealthbar");
      }
     countdown--;
     if (enemylead.GetComponent<statblockMain>().HP<=0){
       enemylist.Remove(enemylead);
       Destroy(enemylead);
       assignpos(enemylist,true);
     }
     if (bar >= 100-enemylead.GetComponent<statblockMain>().ACC){
       damage =  enemylead.GetComponent<statblockMain>().ATK-playerlead.GetComponent<statblockMain>().DEF;
       if (damage<1){damage = 1;}
     playerlead.GetComponent<statblockMain>().HP -= damage;
     playerlead.SendMessage("adjusthealthbar");
      }
     if (playerlead.GetComponent<statblockMain>().HP<=0){
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
  public void backout(){
    backbutton.SetActive(false);
    cameras[1].enabled = false;
    cameras[0].enabled = true;
    GameObject.Find("Player").GetComponent<MovementScript>().frozen = false;
  }
  public void assignpos(List<GameObject> lineup, bool enemy){
    if (lineup.Count >=1){
    int i = 0;
    foreach (GameObject g in lineup){
      g.GetComponent<statblockMain>().healthbarenabled = true;
      g.GetComponent<statblockMain>().pos = i;
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
    backbutton.SetActive(true);
  }
  else{
    Debug.Log("Player was defeated");
    popuplist[1].SetActive(true);
    backbutton.SetActive(true);

  }
}
public void load(){
  foreach (CharacterBase _base in testenemyinput)
  {

    GameObject newCharacter = Instantiate(CharacterPrefab, new Vector3(0, 0, 0), Quaternion.identity);

    newCharacter.GetComponent<Character>().Setup(_base);

    enemylist.Add(newCharacter);
  }
  assignpos(playerlist, false);
  assignpos(enemylist, true);

}

    // Start is called before the first frame update
    void Start()
    {
      //cameras[0].enabled = false;
      //cameras[1].enabled = true;
    }
    void OnGUI()
    {
      // this is to display o2 counter, not yet necessary
      // GUI.Label(new Rect(400,50,400,50), countdown.ToString());


    }
    // Update is called once per frame
    void Update()
    {

    }
    */
}
