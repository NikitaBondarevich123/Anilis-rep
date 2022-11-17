using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.U2D;

public class Playermovement : MonoBehaviour
{
    // Функция выполняемая при запуске
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Функция выполняемая каждый кадр
    void Update()
    {
        Walk();
        Jump();
        Flip();
        CheckingGround();
    }

    public float speed = 2f;
    public Vector2 movevector;
    public float jumpforce = 7f;

    void Walk()
    {
        movevector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movevector.x * speed, rb.velocity.y);
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) & onGround)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpforce);
        }
    }

    void Flip()
    {
        if (movevector.x > 0)
        {
            sr.flipX = false;
        }
        else if (movevector.x < 0)
        {
            sr.flipX=true;
        }
    }


    public bool onGround;
    public Transform GroundChecker;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundChecker.position, checkRadius, Ground);
    }
}
