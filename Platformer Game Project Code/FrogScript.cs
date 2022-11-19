using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : EnemyScript
{
    private bool IsLeft = true;
    private bool IsFrogGrounded = true;
    [SerializeField]
    private float RightBoundry;
    [SerializeField]
    private float LeftBoundry;
    [SerializeField]
    private float JumpHight =5f;
    [SerializeField]
    private float JumpLength = 5f;
    private SpriteRenderer SR;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //FrogMovement();
        if (RB2D.velocity.y > 0.1f)
        if (RB2D.velocity.y > 0.1f)
        {
            IsFrogGrounded = false;

        }
        if (EnemyAnimator.GetBool("IsJumping") == true)
        {


            if (RB2D.velocity.y < 0.1f)
            {
                EnemyAnimator.SetBool("IsFalling", true);
                EnemyAnimator.SetBool("IsJumping", false);
                ;
            }
          
            
        }
       
    }


    private void FrogMovement()
    {
        if (IsLeft == true)
        {


            if (transform.position.x > LeftBoundry)
            {
                if (IsFrogGrounded == true)
                {
                    RB2D.velocity = new Vector2(-JumpLength, JumpHight);

                    EnemyAnimator.SetBool("IsJumping", true);
                    SR.flipX = false;

                }

            }
            else
            {

                IsLeft = false;
            }
        }
        else
        {
            if (transform.position.x < RightBoundry)
            {
                if (IsFrogGrounded == true)
                {
                    RB2D.velocity = new Vector2(JumpLength, JumpHight);
                    EnemyAnimator.SetBool("IsJumping",true);

                    SR.flipX = true;

                }

            }
            else
            {

                IsLeft = true;
            }
        }


    }

    private void OnCollisionStay2D(Collision2D col)//detects collisions
    {


        if (col.gameObject.tag == "Ground") // if touching a sprite with the tag "Ground"
        {
            if (EnemyAnimator.GetBool("IsFalling") == true)
            {
               
                IsFrogGrounded = true;// set the boolean to true 
                EnemyAnimator.SetBool("IsFalling", false);
               
               
            }
        }
    }
}
