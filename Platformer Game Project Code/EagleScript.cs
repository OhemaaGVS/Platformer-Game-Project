using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EagleScript : EnemyScript// inheriting from the enemy script
{
    private bool IsLeft = true;
    //private static EagleScript EagleInstance;
    //public static EagleScript GetEagleInstance()
    //{
    //    return EagleInstance;

    //}
    [SerializeField] private float RightBoundry;
    [SerializeField] private float FlyingHight;
    [SerializeField] private float LeftBoundry;
    [SerializeField] private float FlyingSpeed = 8f;
    //private Rigidbody2D RB2D;
    private SpriteRenderer SR;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // RB2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        //if (transform.position.y> FlyingHight)
        //{

        //    transform.position = new Vector2(transform.position.x, FlyingHight - 0.1f);

        //}
        if (IsLeft == true)
        {
            if (transform.position.x > LeftBoundry)
            {
                RB2D.velocity = new Vector2(-FlyingSpeed, 0);


                SR.flipX = false;
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
                RB2D.velocity = new Vector2(FlyingSpeed, 0);


                SR.flipX = true;
            }
            else
            {
                IsLeft = true;
            }
        }
    }
}

