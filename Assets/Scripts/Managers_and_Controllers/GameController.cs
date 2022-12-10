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
    public static GameState gameState;

    public GameObject hpBarPrefab;
    public static GameObject hpBarPrefabStatic;

    public GameObject combatCanvasObject; // Canvas containing combat GUI
    public Canvas EncounterCanvas; // Canvas Showing options at time of encounter
    public Canvas CounterCanvas; // Canvas displaying O2 and Fish food

    CounterController CC; // Class controlling the Players O2 and Fish food GUI

    public CombatManager CM; // Class that manages combat

    public GameObject playerObj;
    [SerializeField] CharacterBase diver; // The Character base for the Player
    Character playerCharacter; // Character Object to manage player in Combat
    public Team playerTeam; // Team object to store the players team

    public static int bounty = 10;

    private void Awake()
    {
        gameState = GameState.OVERWORLD;
        Physics2D.gravity.Set(0, 0);

        //find and store relevant gameObjects and classes
        CC = GameObject.Find("CounterCanvas").GetComponent<CounterController>();

        EncounterCanvas = this.transform.Find("EncounterCanvas").GetComponent<Canvas>();
        CounterCanvas = this.transform.Find("CounterCanvas").GetComponent<Canvas>();

        hpBarPrefabStatic = hpBarPrefab;

    }
    void Start()
    {
        CC.Update02Counter();
        CC.UpdateFFCounter();

        EncounterCanvas.enabled = false;

        //Initialize objects
        CM = new CombatManager(this, combatCanvasObject);
        playerCharacter = new Character(diver);
        playerTeam = new Team(playerCharacter);

    }
    public static void switchCams()
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
    void Update() {

        if (gameState != GameState.OVERWORLD)
        {
        
           // CM.Update(playerTeam);

        }

        if (gameState == GameState.ENEMYMOVE)
        {
            gameState = GameState.PLAYERMOVE;

            CM.Update(playerTeam);

            if (CM.enemies != null) { 
            
                CM.enemies.Attack(playerTeam);
            
            }

            

        }

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))// for combat information
        {

            playerTeam.Log();

            CM.enemies.Log();

        }

    }
    public void AttackEnemies()
    {

        playerTeam.Attack(CM.enemies);
        gameState = GameState.ENEMYMOVE;

    }
    public void Swap()
    {
        gameState = GameState.ENEMYMOVE;
    }
}
public class Team
{
    public List<Character> Characters;

    public bool defeated = false;
    public Team(Character initalChar) {

        Characters = new List<Character>();

        AddCharacter(initalChar);

        //Debug.Log(Characters[0].Obj.name + ": Joined the team!");

    }
    public void AddCharacter(Character ch) {

        Characters.Add(ch);

        ch.JoinTeam(this);
    
    }
    public void RemoveCharacter(Character ch)
    {

        Debug.Log(ch._base.character_name + " died... Removing from Team \n");

        Characters.Remove(ch);

        if (Characters.Count == 0) {

            defeated = true;

        }

    }
    public void Attack(Team Enemy)
    {

        Debug.Log("Attacking Enemy\n");

        Characters[0].Attack(Enemy.Characters[0]);

    }
    public void SwapByCharacter(Character ch1, Character ch2) 
    {
        
        int index1 = Characters.FindIndex(ch1.Equals);

        int index2 = Characters.FindIndex(ch2.Equals);

        SwapByIndex(index1, index2);

    }
    public void SwapByIndex(int index1, int index2)
    {
        Character temp;

        temp = Characters[index1];

        Characters[index1] = Characters[index2];

        Characters[index2] = temp;

    }
    public void Log() {

        Debug.Log("Team Data: \n");

        foreach (Character ch in Characters) {

            Debug.Log(ch._base.character_name + ": \n" +
                "HP: " + ch.currHP + "\n\n"
                
                );
        
        
        }
    }

}
public class CombatManager {

    Vector3 origin; // get center of combat screen

    Canvas canvas; //combat canvas

    GameController GC;

    EncounterManager EM;

    public Team enemies;
    public CombatManager(GameController gc, GameObject combatCanvasObject) {

        GC = gc;

        EM = GC.gameObject.GetComponent<EncounterManager>();

        canvas = combatCanvasObject.GetComponent<Canvas>(); 

        origin = canvas.transform.position;



    }
    public void startCombat(Team playerTeam, Team EnemyTeam)
    {
        // do not set the Gamestate from Overworld until all combat variables are initialized

        enemies = EnemyTeam;

        GameController.switchCams();

        GameController.gameState = GameState.PLAYERMOVE;

        displayTeams(playerTeam, enemies);

    }
    public void EndCombat() {

        enemies = null;

        GameController.switchCams();

        EM.active.EndEncounter();

    }
    private void displayTeams(Team playerTeam, Team EnemyTeam) {

        //displays the sprites for each team on screen
        // Player team : 1st (-13.5, 11.5) 2nd (-14.5, 11.5) 3rd (-15.5, 11.5) 4th (16.5, 11.5)
        // Enemy team : 1st (-10.5, 11.5) 2nd (-9.5, 11.5) 3rd (-8.5, 11.5) 4th (-7.5, 11.5)

        float order = 0f;

        foreach (Character ch in playerTeam.Characters) {

            float width = ch.Obj.GetComponent<SpriteRenderer>().size.x;

            ch.Obj.transform.position = origin + new Vector3(-0.5f - width - (order * 1.5f), 0.5f, 0f);

            if (!ch._base.isRightFacing) {

               // ch.FlipSpriteOnX();
            
            }

            ch.Show();
            ch.hpBar.GetComponent<LiveHPBar>().Set(ch);
            ch.ShowHpBar();

            order++;
        }

        order = 0;

        foreach (Character ch in EnemyTeam.Characters)
        {

            float width = ch.Obj.GetComponent<SpriteRenderer>().size.x;

            ch.Obj.transform.position = origin + new Vector3(0.5f + width + (order * 0.3f), 0.5f, 0f);

            ch.Show();
            ch.hpBar.GetComponent<LiveHPBar>().Set(ch);
            ch.ShowHpBar();

            order++;
        }
    
    }
    public void Update(Team playerTeam) {

        if (enemies.defeated == true) {

            enemies = null;

            EndCombat();

        }

        if (playerTeam.Characters[0] == null)
        {

            EndCombat();

        }
    }

}
