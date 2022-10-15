using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private LayerMask groundLayer; 

    private Rigidbody2D body;
    private float horizontalMove = 0f;
    private bool isGrounded = false;
    private Transform groundCheck;

    private void Awake()
    { 
        body = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInParent<Transform>().Find("GroundCheck");
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        var velocityX = moveSpeed * horizontalMove;
        body.velocity = new Vector2(velocityX, body.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, groundLayer);

        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector2(body.position.x, jumpForce); 
        }
    }
}
