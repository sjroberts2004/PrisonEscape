using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 position;
    public float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame


    void Update()
    {
      if (Input.GetKey("right"))
      {
          position.x = position.x+movementSpeed;

       }
       if (Input.GetKey("left"))
       {
           position.x = position.x+(movementSpeed*-1);

        }
        transform.position = position;
    }

  }
