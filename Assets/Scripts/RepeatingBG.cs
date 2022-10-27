using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    float width;
    public GameObject player;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = boxCollider.size.x;
    }

    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().position.x >= 
            rb.position.x + width) {
            Vector2 vector = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + vector;
        }
    }
}
