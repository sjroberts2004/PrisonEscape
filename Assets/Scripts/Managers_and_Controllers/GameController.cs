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
    public GameState gameState;

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
        CM = new CombatManager(gameState, combatCanvasObject);
        playerCharacter = new Character(diver);
        playerTeam = new Team(playerCharacter);

    }
    void Update() {

        if (gameState == GameState.ENEMYMOVE) {

            CM.enemies.Attack(playerTeam);
        
        
        }

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

    public void Attack(){

        playerTeam.Attack(CM.enemies);

        gameState = GameState.ENEMYMOVE;

    }
    public void Swap() {

        gameState = GameState.ENEMYMOVE;
    }

    public void Escape() {

        
    }

}
public class Team
{
    public List<Character> Characters;
    public Team(Character initalChar) {

        Characters = new List<Character>();

        Characters.Add(initalChar);

        Debug.Log(Characters[0].Obj.name + ": Joined the team!");

    }
    public void AddCharacter(Character ch) {

        Characters.Add(ch);

    }
    public void SwapCharacters(){ }

    public void Attack(Team Enemy)
    {

        Characters[0].Attack(Enemy.Characters[0]);

    }
}
public class CombatManager {

    bool Turn = true; //true = player turn, false = enemy turn
    Vector3 origin; // get center of combat screen
    Canvas canvas;
    GameState state;

    public Team enemies;
    public CombatManager(GameState state, GameObject combatCanvasObject) {

        canvas = combatCanvasObject.GetComponent<Canvas>();

        origin = canvas.transform.position;

        this.state = state;

    }

    private void Update() {

    }

    public void startCombat(Team playerTeam, Team EnemyTeam)
    {

        enemies = EnemyTeam;

        GameController.switchCams();

        state = GameState.PLAYERMOVE;

        displayTeams(playerTeam, enemies);


    }
    private void displayTeams(Team playerTeam, Team EnemyTeam) {

        //displays the sprites for each team on screen
        // Player team : 1st (-13.5, 11.5) 2nd (-14.5, 11.5) 3rd (-15.5, 11.5) 4th (16.5, 11.5)
        // Enemy team : 1st (-10.5, 11.5) 2nd (-9.5, 11.5) 3rd (-8.5, 11.5) 4th (-7.5, 11.5)

        float order = 0f;

        foreach (Character ch in playerTeam.Characters) {

          GameObject.Find("GameController").GetComponent<fightingbuttons>().playerlist.Add(ch);

            float width = ch.Obj.GetComponent<SpriteRenderer>().size.x;

            ch.Obj.transform.position = origin + new Vector3(-1.5f - (1f * order), 0f, 0f);

            if (!ch._base.isRightFacing) {

               // ch.FlipSpriteOnX();

            }

            ch.Show();
            ch.CreateHpBar();

            order++;
        }

        order = 0;

        foreach (Character ch in EnemyTeam.Characters)
        {
          GameObject.Find("GameController").GetComponent<fightingbuttons>().enemylist.Add(ch);
            float width = ch.Obj.GetComponent<SpriteRenderer>().size.x;

            ch.Obj.transform.position = origin + new Vector3(1.5f + (1f * order), 0f, 0f);

            ch.Show();
            ch.CreateHpBar();

            order++;
        }
    }

<<<<<<< HEAD

=======
>>>>>>> b31f1ff2f1f20077d0cbfccad17776e023571ed7
}
