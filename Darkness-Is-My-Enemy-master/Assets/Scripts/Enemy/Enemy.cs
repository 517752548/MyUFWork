using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int collectableLight;
    [SerializeField]

    protected Transform pointA, pointB;
    protected bool IsFacingRight = false;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Init();

    }
    public virtual void Update()
    {
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        //{
        //    return;
        //}
        Movement();
    }
    public virtual void Movement()
    {
        if (Vector2.Distance(currentTarget, pointA.position) < .1)
        {
            sprite.flipX = true;
            IsFacingRight = true;
        }
        else if(Vector2.Distance(currentTarget, pointB.position) < .1)
        {
            sprite.flipX = false;
            IsFacingRight = false;
        }

        if (Vector2.Distance(transform.position, pointA.position) < .1)
        {
            anim.SetTrigger("Idle");
            currentTarget = pointB.position;

        }
        else if (Vector2.Distance(transform.position, pointB.position) < .1)
        {
            anim.SetTrigger("Idle");
            currentTarget = pointA.position;
        }


        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

    }





}
