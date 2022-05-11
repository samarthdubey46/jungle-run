using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public LayerMask ground;
    public LayerMask Death;
    public float speed;
    public AudioSource jump;
    public AudioSource DeadSound;
    public float jumpSpeed;
    private Collider2D playerCollider;
    public float MileStone = 500;
    private float MileStoneCount;
    public float SpeedMultiplier = 1.1f;
    public GameManager gamemanager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        MileStoneCount = MileStone;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > MileStoneCount)
        {
            MileStoneCount += MileStone;
            speed *= SpeedMultiplier;
            MileStone *= 2;
            Debug.Log(MileStoneCount + "  " + speed);
        }
        bool IsDead = Physics2D.IsTouchingLayers(playerCollider, Death);
        if (IsDead)
        {
            gamemanager.GameOver();
            DeadSound.Play();
            Console.WriteLine("Is Dead");
        }
        bool Grounded = Physics2D.IsTouchingLayers(playerCollider, ground);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (Grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jump.Play();
        }
    }
}
