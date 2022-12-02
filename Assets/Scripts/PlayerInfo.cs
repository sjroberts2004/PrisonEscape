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

        //if oxygen reaches 0 and the player still has FishFood, FishFood will decrease by 1 and give 10 - 15 O2
        if(O2 <=0 & FishFood > 0){
            FishFood -= 1;
            O2 = Random.Range(10,16);
            CC.Update02Counter();
            CC.UpdateFFCounter();
        }
        
        //if 02 is going to go under 0 it will stay at 0 rather than be negative
        //not neccessary but looks less bad
        if(O2 <=0){
            O2 = 0;
            CC.Update02Counter();
        }
        CC.Update02Counter();
    }

    public void addFF(int change) { 
        FishFood += change;
        CC.UpdateFFCounter();
    }

    public void loseFF(int change) { 
        FishFood -= change;

        //if FishFood is going to go under 0 it will stay at 0 rather than be negative
        //not neccessary but looks less bad
        if(FishFood <=0){
            FishFood = 0;
            CC.UpdateFFCounter();
        }
        CC.UpdateFFCounter();
    }

    public int getFF() { return FishFood; }
    public int get02() { return O2; }
}
