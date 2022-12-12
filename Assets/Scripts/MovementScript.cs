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
    public Sprite moving;
    public Sprite idle;
    public RuntimeAnimatorController movinganim;
    public RuntimeAnimatorController idleanim;

    private float root; // keeps track of the players position
    private float range = 5; // range the player can moove from the root until the player makes a 'step'

    EncounterManager encounterManager;

    // Start is called before the first frame update
    void Awake() {

        encounterManager = GameObject.Find("GameController").GetComponent<EncounterManager>();

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
            gameObject.GetComponent<SpriteRenderer>().sprite = moving;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = movinganim;
            if (!facingRight) { Flip(); }
            position.x = position.x + movementSpeed;


        }

        else if (Input.GetKey("left") && position.x > root )
        {
          gameObject.GetComponent<SpriteRenderer>().sprite = moving;
          gameObject.GetComponent<Animator>().runtimeAnimatorController = movinganim;
            if (facingRight) { Flip(); }
            position.x = position.x + (movementSpeed * -1);

        }
        else{
          gameObject.GetComponent<SpriteRenderer>().sprite = idle;
          gameObject.GetComponent<Animator>().runtimeAnimatorController = idleanim;
        }

          


        transform.position = position;

      }


        if (frozen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = idle;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = idleanim;

        }
    }
    // Update is called once per frame
    void Update()
    {

        if (GameController.gameState != GameState.OVERWORLD)
        {

            frozen = true;

        }
        if (GameController.gameState == GameState.OVERWORLD)
        {

            frozen = false;

        }

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

        facingRight = !facingRight;// this line might be causing problems

    }

  }
