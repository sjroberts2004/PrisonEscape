using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    [SerializeField] int O2;
    [SerializeField] int FishFood;

    CounterController CC;

    void Start()
    {
        CC = GameObject.Find("CounterCanvas").GetComponent<CounterController>();
    }
    void Update()
    {
        
    }

    public void addO2(int change) { 
        O2 += change;
        CC.Update02Counter();
    }
    public void loseO2(int change) { 
        O2 -= change;
        CC.Update02Counter();
    }
    public void addFF(int change) { 
        FishFood += change;
        CC.UpdateFFCounter();
    }
    public void loseFF(int change) { 
        FishFood -= change;
        CC.UpdateFFCounter();
    }
    public int getFF() { return FishFood; }
    public int get02() { return O2; }
}
