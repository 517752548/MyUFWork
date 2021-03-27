using UnityEngine;
using System.Collections;
public class throwIt : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 10f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    public float speed;
    public LayerMask WhatIsThrowable;
    public float CircleRadius;

    private Player _player;
    private Collider2D _isHit;

    // Use this for initialization
    void Start()
    {
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {

            _isHit = Physics2D.OverlapCircle(transform.position, CircleRadius, WhatIsThrowable);

            if (!grabbed)
            {
                if (_isHit.gameObject.CompareTag("throwable"))
                {
                    grabbed = true;
                }
            }
            else
            {
                grabbed = false;
                if (_isHit.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    _isHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_player._isFacingRight ? transform.localScale.x : -transform.localScale.x, 0) * speed;
                }
            }


            //if (!grabbed)
            //{
            //    Physics2D.queriesStartInColliders = false;

            //    hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

            //    if (hit.collider != null && hit.collider.tag == "throwable")
            //    {
            //        grabbed = true;

            //    }

            //    else
            //    {
            //    }
            //    //grab
            //}
            //else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            //{
            //    grabbed = false;

            //    if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            //    {
            //        Debug.Log("Valocity results");

            //        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right *speed;
              
              
            //    }


            //    //throw
            //}


        }

        if (grabbed)
            _isHit.gameObject.transform.position = holdpoint.position;
        //hit.collider.gameObject.transform.position = holdpoint.position;


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }






















}