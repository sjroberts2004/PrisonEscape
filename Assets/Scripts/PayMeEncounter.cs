using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PayMeEncounter", menuName = "Create new Encounter")]

public class PayMeEncounter : ScriptableObject
{


    [SerializeField] CharacterBase newFollower;
    [SerializeField] int cost;
    [SerializeField] int level;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
