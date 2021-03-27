using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilEnemy : Enemy
{
    public static bool faceRight;
    public GameObject projectile;
    public GameObject Battrey;
    public GameObject DarkDeathEffect;
    public GameObject StoneDestroyEffect;
    public AudioClip DeathSound; 
    public override void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
    
 
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
            faceRight = true;
        }
        else
        {
            sprite.flipX = false;
            faceRight = false;
        }

        if (transform.position == pointA.position)
        {

            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        
           
        }
        else if (transform.position == pointB.position)
        {

            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
      
           
        }
    
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);





    }
    public void Attack()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("throwable"))
        {
            if (Mathf.Abs(col.gameObject.GetComponent<Rigidbody2D>().velocity.x) > .0001)
            {
                Instantiate(Battrey, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Instantiate(DarkDeathEffect, transform.position, Quaternion.identity);
                Instantiate(StoneDestroyEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(col.gameObject);
                AudioSource.PlayClipAtPoint(DeathSound, transform.position);
                
            }
            
        }
    }

    }


    

