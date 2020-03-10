using System.Collections;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 6f;

    public float checkRadius;

    public LayerMask ground;

    public bool isGrounded;
    private bool isInJump= false;
    private bool IsFacingRight= false;

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
        if (Input.GetButtonDown("Jump") && isGrounded == true && isInJump == false)
        {
            StartCoroutine(JumpFix());
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
           
        }

        

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }
    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        FlipCharacter(movement.x);
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
    }

    private IEnumerator JumpFix()
    {
        isInJump = true;
        yield return new WaitForSeconds(0.7f);
        isInJump = false;
    }

    void FlipCharacter(float movement)
    {
        if (movement > 0 && !IsFacingRight || movement < 0 && IsFacingRight)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }



    
}
