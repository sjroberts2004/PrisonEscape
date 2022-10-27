using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    DialogueManager DM;
    CounterController CC;
    PlayerInfo playerInfo;
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
}
