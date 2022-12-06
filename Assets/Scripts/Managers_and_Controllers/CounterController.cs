using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    PlayerInfo playerInfo;
    GameObject counterCanvas;

    void Awake()
    {
        counterCanvas = GameObject.Find("CounterCanvas");
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
    }

    public void UpdateFFCounter() {

        int count;

        count = playerInfo.getFF();

        counterCanvas.transform.Find("Fish food counter").GetComponent<TMPro.TMP_Text>().text = count.ToString();

    }
    public void Update02Counter() {

        int count;

        count = playerInfo.get02();

        counterCanvas.transform.Find("O2 counter").GetComponent<TMPro.TMP_Text>().text = count.ToString();

    }
}
