using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// need it for the ui stuff
using UnityEngine.SceneManagement;// to access the scenes in the game
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerScripts : MonoBehaviour
{//[Serializefield] is just use for showing a private variable's value on Inspector. You can easily change the value like public variable. But None can access this value from another script or places
    [SerializeField]
    private bool CheckPointReached;
    [SerializeField]
    private float PlayerSpeed = 6f;// setting the player speed to 5, can be edited in the inspector
    [SerializeField]
    private float PlayerJumpForce = 10f;
    [SerializeField]
    private float PlayerHorizontalHurtForce = 4f;
    [SerializeField]
    private float PlayerVerticalHurtForce = 7f;// setting the player jumpforce to 10, can be edited in the inspector
    //variables
    //[SerializeField] private Text CollectedGemsText;
    private Vector2 CheckPointPosition;
    [SerializeField] private Vector2 OriginalPlayerPosition;
    [SerializeField] private float PlayerLungeForce = 5f;
    //[SerializeField] private int NumberOfGemsCollected = 0;
    [SerializeField] private float PlayerMaxHealth;
    private Animator PlayerAnimator;
    private float DirectionOnXAxis;
    private Rigidbody2D RB2D;
    private bool IsPlayerGrounded = true;
     private bool IsPlayerAttacking = false;
    private enum StateOfPlayer { Idle, RunningLeft, Jumping, RunningRight, IdleLeft, JumpingLeft, Attacking, AttackingLeft, HurtRight, HurtLeft }// enum creates a list with values that the player state can be equal to, it cant be equal to anything else.
    private StateOfPlayer State = StateOfPlayer.Idle;
    public UnityEvent onLongClick;

    private bool IsPlayerLeft = false;
    [SerializeField] private Slider PlayerHealthBar;

    private static PlayerScripts PlayerInstance;
    public static PlayerScripts GetPlayerInstance()
    {

        return PlayerInstance;
    }

    private void Awake()
    {
        PlayerInstance = this;
    }
    public void SetAttackingFalse()
    {

        IsPlayerAttacking = false;
        Debug.Log("stoop");
        ChangePlayerState();
        SwordScript.GetSwordInstance().SetSwordAttackingFalse();

        

    }



    private void ChangePlayerState()
    {

        //Debug.Log(b);

        if (State != StateOfPlayer.HurtRight && State != StateOfPlayer.HurtLeft)
        {

            if (State == StateOfPlayer.Jumping)// if the player state is currently jumping
            {
                if (IsPlayerLeft == true)
                {
                    State = StateOfPlayer.JumpingLeft;
                }
                if (RB2D.velocity.y > 0.1f)// if the player velocity on the y axis has moved upward
                {
                    IsPlayerGrounded = false;// the player is no longer in contact with the ground

                }

                else if (IsPlayerGrounded == true)// if the player is now touching the ground
                {
                     State = StateOfPlayer.Idle;// set the players state to idle 
                }
            }
            else if (State == StateOfPlayer.JumpingLeft)// if the player state is currently jumping
            {
                if (IsPlayerLeft == false)
                {
                    State = StateOfPlayer.Jumping;
                }
                if (RB2D.velocity.y > 0.1f)// if the player velocity on the y axis has moved upward
                {
                    IsPlayerGrounded = false;// the player is no longer in contact with the ground

                }

                else if (IsPlayerGrounded == true)// if the player is now touching the ground
                {
                    State = StateOfPlayer.IdleLeft;// set the players state to idle 
                }
            }

           else if (IsPlayerAttacking == true)
            {
                //Debug.Log("att");

                if (IsPlayerLeft == false)
                {
                    State = StateOfPlayer.Attacking;
                }
                else
                {
                    State = StateOfPlayer.AttackingLeft;
                }

            }


            else if (RB2D.velocity.x > 3f && IsPlayerGrounded == true)//math f returns the absolute value like the modulous function in maths
            {
                // Debug.Log("turn right");
                State = StateOfPlayer.RunningRight;//set player state to running
                IsPlayerLeft = false;
            }
            else if (RB2D.velocity.x < -3f && IsPlayerGrounded == true)//math f returns the absolute value like the modulous function in maths
            {
                // Debug.Log("turn left");

                State = StateOfPlayer.RunningLeft;//set player state to running
                IsPlayerLeft = true;

            }



            else
            {
                if (IsPlayerLeft == true)
                {

                    State = StateOfPlayer.IdleLeft;
                  
                }


                if (IsPlayerLeft != true)
                {

                    State = StateOfPlayer.Idle;// set player to idle
                   // Debug.Log("right");

                }

            }
        }
        else
        {

            if (Mathf.Abs(RB2D.velocity.x) < 0.1f)
     //       {
                if (IsPlayerLeft == false)
                {

                    State = StateOfPlayer.Idle;
                   // Debug.Log("right2");

                }


                else
                {

                    // set player to idle
                    State = StateOfPlayer.IdleLeft;
                    //Debug.Log("left");
                }

            }

        
    }

    private void Start()
    {
        CheckPointReached = false;
        RB2D = GetComponent<Rigidbody2D>();// accessing the rigid body on the player
        PlayerAnimator = GetComponent<Animator>();//accessing the animator on the player( just like how it was when its public)
        PlayerHealthBar.value = PlayerMaxHealth;
    }
    private void Update()
    {








        if (State != StateOfPlayer.HurtRight && State != StateOfPlayer.HurtLeft)
        {
           
            ManagePlayerMovement();
        }//calling the manage movement function
        ChangePlayerState();// calling the change player state function

        PlayerAnimator.SetInteger("PlayerState", (int)State);// setting the state integer to the index of the current state
    }
    public void ManagePlayerMovement()
    {

        DirectionOnXAxis = Input.GetAxis("Horizontal");//Returns the value of the virtual axis identified by axisName., horizontal is the left and right axis (see the project settings to change)
        //The value will be in the range -1...1 for keyboard and joystick input devices.
        //The meaning of this value depends on the type of input control, for example with a joystick's horizontal axis a value of 1 means the stick is pushed all the way to the right and a value of -1 means it's all the way to the left; a value of 0 means the joystick is in its neutral position.

        
        if (DirectionOnXAxis < 0)// this means that the player is going left as anything less than 0 is moving towards the left direction
        {
  
            IsPlayerLeft = true;
           // Debug.Log(IsPlayerLeft);
            PlayerRunLeft();
        }


        if (DirectionOnXAxis > 0)// this means that the player is going right as anything bigger than 0 is moving towards the right direction
        {
            IsPlayerLeft = false;
           // Debug.Log(IsPlayerLeft);
            PlayerRunRight();
        }

        if (Input.GetButtonDown("Jump")) // if space is pressed it will jump
        {

            PlayerJump();
        }
        if (Input.GetButtonDown("Vertical")) // if space is pressed it will jump
        {
            SwordScript.GetSwordInstance().SetSwordAttackingTrue();
            
            IsPlayerAttacking = true;
  
            PlayerAttack();
        }
    
    }
    public void PlayerRunRight()
    {//player runs right

        RB2D.velocity = new Vector2(PlayerSpeed, RB2D.velocity.y);
       //gameObject.GetComponent<SpriteRenderer>().flipX = false;// flips it in the right direction
    }


    public void PlayerRunLeft()
    {// makes player run left
        RB2D.velocity = new Vector2(-PlayerSpeed, RB2D.velocity.y);
        //gameObject.GetComponent<SpriteRenderer>().flipX = true;//flips the player in the left direction
    }

    public void PlayerJump()
    {
        if (IsPlayerGrounded == true)// checks if player is touching the ground
        {
            if (IsPlayerLeft == false)// this means that the player is going left as anything less than 0 is moving towards the left direction
        {
            

                State = StateOfPlayer.Jumping;// set the state to jumping
            }
            else
            {
                State = StateOfPlayer.JumpingLeft;
            }

            RB2D.velocity = new Vector2(RB2D.velocity.x, PlayerJumpForce);// player jumps
        }
    
    }



    public void PlayerAttack()
    {
        {
            
            SwordScript.GetSwordInstance().SetSwordAttackingTrue();

            IsPlayerAttacking = true;

            //PlayerAttack();
            
            if (IsPlayerLeft == false)
            {
                //Debug.Log("SWORd");
                State = StateOfPlayer.Attacking;
                RB2D.velocity = new Vector2(PlayerLungeForce, RB2D.velocity.y);// player jumps
               

            }
            else
            {
                State = StateOfPlayer.AttackingLeft;
                RB2D.velocity = new Vector2(-PlayerLungeForce , RB2D.velocity.y);// player jumps
            }


            //RB2D.velocity = new Vector2(2f, RB2D.velocity.y);// player jumps

        }
    }
  
    private void OnCollisionStay2D(Collision2D col)//detecs collisions
    {


        if (col.gameObject.tag == "Ground") // if touching a sprite with the tag "Ground"
        {

            IsPlayerGrounded = true;// set the boolean to true 
        }
        //if (col.gameObject.tag == "Collectable")
        //{
        //    Destroy(col.gameObject);
        //    NumberOfGemsCollected = NumberOfGemsCollected + 1;
        //    CollectedGemsText.text = NumberOfGemsCollected.ToString();

        //}

        if (col.gameObject.tag == "Enemy")

            if (SwordScript.GetSwordInstance().GetSwordAttacking() == false || SwordScript.GetSwordInstance().GetEnemyAttacked()==false)
        {
            {
               HandlePlayerHealth();
               
                if (col.gameObject.transform.position.x>transform.position.x)
                {
                    // enemy is to the right of the player
                   
                    State = StateOfPlayer.HurtRight;
                    RB2D.velocity = new Vector2(-PlayerHorizontalHurtForce, PlayerVerticalHurtForce);
                   


                }
                if (col.gameObject.transform.position.x < transform.position.x)
                {
                    //    enemy is to the left of the player
            
                    State = StateOfPlayer.HurtLeft;
                    RB2D.velocity = new Vector2(PlayerHorizontalHurtForce, PlayerVerticalHurtForce);
                   

                }

            }


        }
    }

    private void HandlePlayerHealth()
    {

        if (PlayerHealthBar.value > 0.1f)
        {

            PlayerHealthBar.value = PlayerHealthBar.value - 0.1f;
        }


        if (PlayerHealthBar.value < 0.1f)
        {
            print("s");
            //    UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("end gamee");

        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable")
        {
            Destroy(col.gameObject);

            PermenantPlayerUIElementsHandlerScript.GetPermenantPlayerUIInstance().IncrementPlayerGemsCollected();
            //NumberOfGemsCollected = NumberOfGemsCollected + 1;
            //CollectedGemsText.text = NumberOfGemsCollected.ToString();

        }

        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);


           // NumberOfGemsCollected = NumberOfGemsCollected + 1;
            //CollectedGemsText.text = NumberOfGemsCollected.ToString();

        }
        if (col.gameObject.tag == "FallDetector")
        {


          //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);// the scene that we are currently in



            if (CheckPointReached == true)
            {
                this.transform.position = CheckPointPosition;
                
            }
            else
            {
                this.transform.position = OriginalPlayerPosition;
            }
        }
        if (col.gameObject.tag == "CheckPoint")
        {

            CheckPointPosition = col.gameObject.transform.position;
            CheckPointReached = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);// the scene that we are currently in

        }



    }
  
}
    