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

    DialogueManager dialogueManager;
    EncounterManager encounterManager;
    [SerializeField] GameObject EM;
    [SerializeField] Canvas Canvas_Holding_DM;

    // Start is called before the first frame update
    void Awake() {
        dialogueManager = Canvas_Holding_DM.GetComponent<DialogueManager>();
        encounterManager = EM.GetComponent<EncounterManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        root = position.x;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey("right"))
      {

          position.x = position.x + movementSpeed;

      }
 
      if(Input.GetKey("left") && position.x > 0)
      {

        position.x = position.x+(movementSpeed*-1);

      }

        transform.position = position;

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



  }
