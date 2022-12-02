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

    public Canvas CombatCanvas; // Canvas containing combat GUI
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

        CombatCanvas = this.transform.Find("CombatCanvass").GetComponent<Canvas>();
        EncounterCanvas = this.transform.Find("EncounterCanvas").GetComponent<Canvas>();
        CounterCanvas = this.transform.Find("CounterCanvas").GetComponent<Canvas>();

    }
    void Start()
    {
        CC.Update02Counter();
        CC.UpdateFFCounter();

        EncounterCanvas.enabled = false;

        //Initialize objects
        CM = new CombatManager(gameState, CombatCanvas);
        playerCharacter = new Character(diver);
        playerTeam = new Team(playerCharacter);

    }
    void Update(){}
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
public class CombatManager {

    bool Turn = true; //true = player turn, false = enemy turn
    Vector3 origin; // get center of combat screen
    Canvas canvas;
    GameState state;
    public CombatManager(GameState state, Canvas combatCanvas) {

        origin = GameObject.Find("GameController").GetComponent<GameController>().CombatCanvas.transform.position;

        canvas = combatCanvas;

        this.state = state;

    }

    private void Update() {

    }

    public void startCombat(Team playerTeam, Team EnemyTeam)
    {

        GameController.switchCams();

        state = GameState.PLAYERMOVE;
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