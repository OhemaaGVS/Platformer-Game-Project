using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{


[SerializeField]  private Slider EnemyHealthBar;

[SerializeField] private float MaximumHealth; 
    protected Rigidbody2D RB2D;
    protected Animator EnemyAnimator;// protected so its children can use it
    protected virtual void Start()
    {
        //health = maxhealth;
        //slider.value = h();
        EnemyHealthBar.value = MaximumHealth;
        EnemyAnimator = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
    }
    private void Died()
    {
       
       Destroy(this.gameObject);
     
    }

    public void Attacked()
    {
        EnemyAnimator.SetTrigger("Died");
       
    }

    public void EnemyHurt ()
    {
        if (EnemyHealthBar.value > 0.1f)
        {

            EnemyHealthBar.value = EnemyHealthBar.value - 0.1f;
        }
        else 
        {
            Attacked();

        }

    }
    }
}
