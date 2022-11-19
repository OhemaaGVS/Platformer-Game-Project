using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    private bool SwordIsAttacking = false;
    private bool EnemyAttacked = false;
    private static SwordScript SwordInstance;
    public static SwordScript GetSwordInstance()
    {

        return SwordInstance;
    }

    public bool GetSwordAttacking()
    {

        return SwordIsAttacking;
    }
    public bool GetEnemyAttacked()
    {

        return EnemyAttacked;
    }
    private void Awake()
    {
        SwordInstance = this;
    }
    public void SetSwordAttackingFalse()
    {
        SwordIsAttacking = false;
        
    }

    public void SetSwordAttackingTrue()
    {
        SwordIsAttacking = true;
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        
        
            if (col.gameObject.tag == "Enemy")
            {
                if (SwordIsAttacking == true)
                {
                    Debug.Log("hit");
                    EnemyAttacked = true;
                   EnemyScript Enemy = col.gameObject.GetComponent<EnemyScript>();
                  //  Enemy.Attacked();
                   Enemy.EnemyHurt();



                    //  EagleScript.GetEagleInstance().Attacked();
                    //Destroy(col.gameObject);
                }

                else
                {
                    EnemyAttacked = false;

                }
        }
    }
}
 
    
   