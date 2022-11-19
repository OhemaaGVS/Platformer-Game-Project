using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossumScript : EnemyScript
{
    // Start is called before the first frame update

    private SpriteRenderer SR;
    // Start is called before the first frame update
    
       // RB2D = GetComponent<Rigidbody2D>();
       
    [SerializeField] private Transform Player;
    [SerializeField] private Sprite PossumIdle;
    [SerializeField] private float PlayerDistance;
    [SerializeField]
    private float RunSpeed;
    private float Distance;
    protected override void Start()
    {
        base.Start();
        // RB2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Distance = Vector3.Distance(Player.position, transform.position);
     //   print(Distance);

        if (Distance < PlayerDistance)
        {

            EnemyAnimator.SetBool("IsRunning",true);

            if (Player.transform.position.x > transform.position.x)
            {
                RB2D.velocity = new Vector2(RunSpeed, 0);
                SR.flipX = true;
            }

            if (Player.transform.position.x < transform.position.x)
            {
                RB2D.velocity = new Vector2(-RunSpeed, 0);
                SR.flipX = false;
            }
        }
        else 
        {

          //  this.gameObject.GetComponent<SpriteRenderer>().sprite = PossumIdle;
            EnemyAnimator.SetBool("IsRunning",false);


        }
    }

}
