// timer should start and only stop when it reaches 0

// sprites at 
// at 100% full tank
// at 75% tank
// at 50% tank
// at 25% tank
// at 10%? tank
// at 0% tank








// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class TimerController: MonoBehaviour
// {
//     public static TimerController instance;

//     public Text timeCounter;

//     private TimeSpan timePlaying;
//     private bool timerGoing;

//     private float elapsedTime;


//     public class followplayer : MonoBehaviour
// {   
//     public GameObject player;
//     public float interpSpeed;
//     private Vector3 targetPos;
//     // Update is called once per frame
//     void LateUpdate()
//     {
//       targetPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
//       transform.position = Vector3.Lerp(transform.position, targetPos, interpSpeed);
//     }
// }



//     private void Awake()
//     {
//         instance = this;
//     }

//     private void Start()
//     {
//         timeCounter.text = "Time: 00.00.00 ";
//         timerGoing = false;
//     }

//     public void BeginTimer()
//     {
//         timerGoing = true;
//         startTime = Time.time;
//         elapsedTime = 0f;

//         StartCoroutine(UpdateTimer());
//     }

//     public void BeginGame()
//     {
//         gamePlaying = true;
//         TimerController.instance.BeginTimer();
//     }

//     public void EndTimer()
//     {
//         timerGoing = false;
//     }

//     private IEnumerator UpdateTimer()
//     {
//         while (timerGoing)
        
//             elapsedTime += Time.deltaTime;
//             timePlaying = TimeSpan.FromSeconds(elapsedTime);
//             string timePlayingStr = "Time: " + timePlaying.toString("mm:' 'ss'. 'ff ");

//             yield return null;
//     }
// }