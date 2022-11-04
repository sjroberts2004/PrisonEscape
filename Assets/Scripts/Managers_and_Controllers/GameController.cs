using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    DialogueManager DM;
    CounterController CC;
    PlayerInfo playerInfo;
    public Camera[] cams;
    private void Awake()
    {
        Physics2D.gravity.Set(0, 0);
        DM = GameObject.Find("DialogueCanvas").GetComponent<DialogueManager>();
        CC = GameObject.Find("CounterCanvas").GetComponent<CounterController>();
        playerInfo = GameObject.Find("Diver").GetComponent<PlayerInfo>();
    }
    void Start()
    {
        CC.Update02Counter();
        CC.UpdateFFCounter();
    }
    void Update()
    {

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
        if (combatCamera.enabled == true)
        {

            mainCamera.enabled = true;
            combatCamera.enabled = false;

        }
    }
}
