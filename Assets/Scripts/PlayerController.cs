using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private LayerMask groundLayer;

    [Space(5)]
    [SerializeField] private ItemData tempAxe;
    [SerializeField] private ItemData tempPickaxe;
    [SerializeField] private GameObject arm; 

    private Rigidbody2D body;
    private float horizontalMove = 0f;
    private bool isGrounded = false;
    private Transform groundCheck;

    public Inventory inventory { get; private set; }
    private Item itemInHand = null; 

    private void Awake()
    { 
        body = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInParent<Transform>().Find("GroundCheck");

        inventory = new Inventory();
        inventory.Add(tempAxe);
        inventory.Add(tempPickaxe);
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        InventorySelection();
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

    private void InventorySelection()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            itemInHand = inventory.items[0];
            arm.GetComponent<SpriteRenderer>().sprite = inventory.items[0].data.prefab;
        } 
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            itemInHand = inventory.items[1];
            arm.GetComponent<SpriteRenderer>().sprite = inventory.items[1].data.prefab;
        }
    }
}
