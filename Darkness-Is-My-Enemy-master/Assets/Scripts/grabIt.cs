using UnityEngine;
using System.Collections;
public class grabIt : MonoBehaviour
{
    public bool grabbed;
    public Transform holdpoint;
    public float GrabableThrowForce;
    public float ThrowableThrowForce;
    public LayerMask WhatIsCrate;
    public float CircleRadius;

    private Player _player;
    private Collider2D _isHit;
    private float _force;
    private float _yValue;
    public AudioClip grabSound , throwSound;
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

            _isHit = Physics2D.OverlapCircle(transform.position, CircleRadius, WhatIsCrate);

            if (!grabbed)
            {
                if (_isHit.gameObject.CompareTag("grabbable"))
                {
                    AudioSource.PlayClipAtPoint(grabSound, transform.position);
                    grabbed = true;
                    _force = GrabableThrowForce;
                    _yValue = 1;

                }
                else if (_isHit.gameObject.CompareTag("throwable"))
                {
                    AudioSource.PlayClipAtPoint(grabSound, transform.position);
                    grabbed = true;
                    _force = ThrowableThrowForce;
                    _yValue = 0;
                }

            }
            else
            {
                grabbed = false;
                if (_isHit.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                  
                    _isHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_player._isFacingRight ? transform.localScale.x : -transform.localScale.x, _yValue) * _force;
                    AudioSource.PlayClipAtPoint(throwSound, transform.position);
                 
                }
            }
        


        }

        if (grabbed){
            _isHit.gameObject.transform.position = holdpoint.position;
            _isHit.gameObject.transform.GetChild(0).gameObject.SetActive(true);
           
        }
            


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, CircleRadius);
    }






















}