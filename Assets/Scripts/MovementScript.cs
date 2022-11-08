using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 position;
    public float movementSpeed;
    public bool frozen;
    bool facingRight = true;

    private float root; // keeps track of the players position
    private float range = 5; // range the player can moove from the root until the player makes a 'step'

    EncounterManager encounterManager;

    // Start is called before the first frame update
    void Awake() {

        encounterManager = this.GetComponent<EncounterManager>();

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        root = position.x;

    }

    private void FixedUpdate()
    {
      if (!frozen){
        if (Input.GetKey("right"))
        {
            if (!facingRight) { Flip(); }
            position.x = position.x + movementSpeed;

        }

        if (Input.GetKey("left") && position.x > root )
        {
            if (facingRight) { Flip(); }
            position.x = position.x + (movementSpeed * -1);
        }

        transform.position = position;
      }

    }
    // Update is called once per frame
    void Update()
    {
        if (position.x > root + range) //steping right
        {
            root = position.x;
            encounterManager.step();
        }

        if (position.x < root - range) //stepping left
        {
            root = position.x;
        }
    }

    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;

    }
  }
