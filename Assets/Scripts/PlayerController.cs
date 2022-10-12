using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Rigidbody2D body;
    private float horizontalMove = 0f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        var velocityX = moveSpeed * horizontalMove;
        body.velocity = new Vector2(velocityX, body.velocity.y); 
    }
}
