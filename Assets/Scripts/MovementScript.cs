using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 position;
    public float movementSpeed;

    private float root; // keeps track of the players position 
    private float range = 5; // range the player can moove from the root until the player makes a 'step'

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        root = position.x;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey("right")){
          position.x = position.x + movementSpeed;
        }
      else if(position.x > 0 && Input.GetKey("left")){
        position.x = position.x+(movementSpeed*-1);
      }

        transform.position = position;

        if (position.x > root + range) 
        {
            Debug.Log("Player took a step forwards");

            root = position.x;
        }

        if (position.x < root - range)
        {
            Debug.Log("Player took a step backwards");

            root = position.x;
        }
    }



  }
