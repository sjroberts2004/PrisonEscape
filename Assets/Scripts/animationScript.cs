using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    float originalY;

    public float floatStrength = 0.5f; //changable float strength
                                    //number indicates speed. and height of both directions

    void Start()
    {
        this.originalY = this.transform.position.y; //initialize yposition
    }

    void Update()
    {
        //fancy way to make a "bobbing" animation using a vector.
        transform.position = new Vector3(transform.position.x, 
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
                transform.position.z);
    }
}
