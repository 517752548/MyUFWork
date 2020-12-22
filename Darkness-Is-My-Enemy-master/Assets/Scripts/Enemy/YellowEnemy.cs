using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : Enemy
{
    private float _oldSpeed;
    private Transform _lastTarget;

    public float NewSpeed;
    public GameObject Player;
    public GameObject Battrey;
    public GameObject YellowDeathEffect;
    public AudioClip DeathSound;
    public override void Init()
    {
        base.Init();
        _oldSpeed = speed;
    }

    public override void Update()
    {
        base.Update();

        if (Player.transform.position.x <= pointA.position.x && Player.transform.position.x >= pointB.position.x)
        {
            speed = NewSpeed;
            currentTarget = new Vector2(Player.transform.position.x, pointA.position.y);
            if (transform.position.x < currentTarget.x && !IsFacingRight)
            {
                sprite.flipX = true;
                IsFacingRight = true;
            }
            else if (transform.position.x > currentTarget.x && IsFacingRight)
            {
                sprite.flipX = true;
                IsFacingRight = false;
            }
            anim.SetBool("InCombat", true);
        }
        else
        {
            speed = _oldSpeed;
            anim.SetBool("InCombat", false);
            //currentTarget = pointB.position;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("throwable"))
        {
            if (Mathf.Abs(col.gameObject.GetComponent<Rigidbody2D>().velocity.x) > .0001)
            {
                Instantiate(Battrey, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Instantiate(YellowDeathEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(col.gameObject);
                AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            }

        }
    }

}


