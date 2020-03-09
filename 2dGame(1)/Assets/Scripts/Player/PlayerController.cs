using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 6f;


    public float checkRadius;
    public float wallCheckDistance;

    public LayerMask ground;


    public bool isTouchingWall;
    public bool isGrounded;
    private bool isInAir;

    public Transform wallCheck;
    public Transform groundCheck;

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
        IsInAir();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true && isTouchingWall == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
           
        }

        

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, ground);
    }
    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void IsInAir()
    {
        if (isGrounded != true)
        {
            moveSpeed = 12f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
    
}
