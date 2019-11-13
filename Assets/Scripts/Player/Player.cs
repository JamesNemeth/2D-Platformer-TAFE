using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed = 5f;
    public float jumpPower;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public Vector2 size;
    public CapsuleDirection2D direction;
    public LayerMask whatIsGround;

    public Animator animator;

	void Awake ()
	{
		animator = GetComponent<Animator> ();

	}



    // Update is called once per frame
    void Update()
    {
    
        //Get input axis from player
       //float inputH = Input.GetAxisRaw("Horizontal");
       // Vector2 direction = new Vector2(inputH);
        //rigid.AddForce(direction * speed);

        float moveInput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(moveInput * speed, rigid.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //isGrounded = Physics2D.OverlapCapsule(feetPos.position, size, direction, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius , whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.up * jumpPower;
        }
		
		animator.SetBool("isJumping", rigid.velocity.y > 3.9);
		animator.SetBool("isLanding", rigid.velocity.y < 3);
		animator.SetBool("isFalling", rigid.velocity.y < -2);
		animator.SetBool("onGround", isGrounded);
        //animator.SetBool("isJumping", false);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }
}