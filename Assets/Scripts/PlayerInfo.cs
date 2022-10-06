using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    [SerializeField] int O2;
    [SerializeField] int FishFood;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addO2(int change) { O2 += change; }
    public void loseO2(int change) { O2 -= change; }
    public void addFF(int change) { FishFood += change; }
    public void loseFF(int change) { FishFood -= change; }


}
