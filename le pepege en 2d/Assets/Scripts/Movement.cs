using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerBody;
    private Vector2 moveVelocity;
    private bool DirRight;
    private bool isGrounded;
    private bool jump;
    public float jumpHeight;
    public LayerMask groundLayer; 

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f,transform.position.y - 0.5f),
        new Vector2(transform.position.x + 0.5f,transform.position.y + 0.5f),
        groundLayer);

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveVelocity = moveInput * speed;

        jump = Input.GetKey("space");
        
        if (isGrounded && jump)
        {
            moveVelocity = new Vector2(moveVelocity.x, jumpHeight);
        }


    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + moveVelocity * Time.fixedDeltaTime);

        if((moveVelocity.x > 0 && DirRight) || (moveVelocity.x < 0 && !DirRight))
        {
		    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            DirRight = !DirRight;
        }
    }
}
