using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { 
    OVERWORLD,
    PLAYERMOVE,
    ENEMYMOVE,
    BUSY
}
public class GameController : MonoBehaviour
{
    public Canvas Combat;
    CounterController CC;
    PlayerInfo playerInfo;
    public CombatManager CM;

    [SerializeField] CharacterBase diver;
    Character player;
    public Team playerTeam;
    
    private void Awake()
    {
        Physics2D.gravity.Set(0, 0);
        CC = GameObject.Find("CounterCanvas").GetComponent<CounterController>();
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        Combat = GameObject.Find("CombatCanvass").GetComponent<Canvas>();
    }
    void Start()
    {
        CC.Update02Counter();
        CC.UpdateFFCounter();

        CM = new CombatManager();
        player = new Character(diver);
        playerTeam = new Team(player);

    }
    void Update(){}
    public void switchCams()
    {
        Camera mainCamera;
        Camera combatCamera;

        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        combatCamera = GameObject.Find("Combat Camera").GetComponent<Camera>();

        if (mainCamera.enabled == true)
        {

            mainCamera.enabled = false;
            combatCamera.enabled = true;

        }
        else if (combatCamera.enabled == true)
        {

            mainCamera.enabled = true;
            combatCamera.enabled = false;

        }
    }

}
public class Team
{
    public List<Character> Characters;
    public Team(Character initalChar) {

        Characters = new List<Character>();

        Characters.Add(initalChar);

        //Debug.Log(Characters[0].Obj.name + ": Joined the team!");

    }
}
public class CombatManager{

    bool Turn = true; //true = player turn, false = enemy turn
    Vector3 origin; // get center of combat screen
    public CombatManager() {

       origin = GameObject.Find("GameController").GetComponent<GameController>().Combat.transform.position;

    }
    
    public void startCombat(Team playerTeam, Team EnemyTeam)
    {

        displayTeams(playerTeam, EnemyTeam);

    }

    private void displayTeams(Team playerTeam, Team EnemyTeam) {
        //displays the sprites for each team on screen
        float order = 0f;
       
        foreach (Character ch in playerTeam.Characters) {

            float width = ch.Obj.GetComponent<SpriteRenderer>().size.x;

            ch.Obj.transform.position = origin + new Vector3(-1f - width - (order * 1.5f), 0.5f, 0f);

            order--;
        }

        order = 0;

        foreach (Character ch in EnemyTeam.Characters)
        {

            float width = ch.Obj.GetComponent<SpriteRenderer>().size.x;

            ch.Obj.transform.position = origin + new Vector3(1f + width + (order * 1.5f), 0.5f, 0f);

            order++;
        }
    }
}