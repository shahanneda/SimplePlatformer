using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour {
    public float speed;
    public float jumpPower = 2;
    private Animator animator;
    public bool isJumping;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
       
    }
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<Rigidbody2D>().velocity.y < -0.1)
        {

            animator.SetBool("Jumping", true);
        }
        if(Input.GetAxis("Jump") > 0)
        {
            if (!isJumping)
            {
                isJumping = true;
                animator.SetBool("Jumping", true);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * jumpPower), ForceMode2D.Impulse);
            }
           
        }
		if(Input.GetAxis("Horizontal") > 0  )
        {

            animator.SetBool("Facing Left", false);
            animator.SetFloat("Walking", 1f);
            
               transform.Translate(new Vector3(1*speed, 0, 0));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Facing Left", true);
            animator.SetFloat("Walking", -1f);
            
            transform.Translate(new Vector3(-1 * speed, 0, 0));
        }
        else
        {
            animator.SetFloat("Walking", 0f);
        }
        
        if(transform.position.y < -25)
        {
            LevelManager.Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<TileManager>().isGround)
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }
    }


}
