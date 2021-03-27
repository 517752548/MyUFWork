using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour

{
    private Rigidbody2D _rb2D;
    public bool _isFacingRight = true;
    private bool _isGrounded;
    private playeranimation _anim;
    private SpriteRenderer _sprite;
    private GameObject _flashLight;

    public float move;
    public float Speed;
    public Transform GroundCheckPoint;
    public float CircleRadius;
    public LayerMask WhatIsGround;
    public float JumpSpeed;
    public int health;
    public int BatteryNum = 0;
    public TextMeshProUGUI BatteryText;
    public AudioClip JumpSound ,DeathSound;
    public GameObject PlayerDeathEffect;
    public GameObject DeathFlashLight;
    public AudioClip BatterySound;

    public GameObject GameOver;
  
    // Start is called before the first frame update
    void Start()
    {
        _flashLight = transform.GetChild(0).gameObject.transform.GetChild(3).gameObject; 
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<playeranimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        BatteryText.text = BatteryNum.ToString();

        move = Input.GetAxisRaw("Horizontal");
    
        Flip(move);
        if (  (Mathf.Abs(move) > 0 || Mathf.Abs(move)  < 0) && _isGrounded)
        {
            GetComponent<AudioSource>().UnPause();
        }
        else
        {

            GetComponent<AudioSource>().Pause();
        }

        _isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, CircleRadius, WhatIsGround);

        if (_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb2D.velocity = new Vector2(_rb2D.velocity.x, JumpSpeed);
                _anim.Jump();
                AudioSource.PlayClipAtPoint(JumpSound, transform.position);
             
            }
        }
        _rb2D.velocity = new Vector2(move * Speed, _rb2D.velocity.y);

        _anim.Move(move);
    }

    void Flip(float horizontalInput)
    {
        if (_isFacingRight && horizontalInput < 0)
        {

            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _isFacingRight = !_isFacingRight;
        }
        else if (!_isFacingRight && horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            _isFacingRight = !_isFacingRight;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Start"))
        {
            transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(false);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("FlashLight"))
        {
            _flashLight.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Blast")||other.CompareTag("Spike")||other.CompareTag("Sword"))
        {
            if (!GameObject.FindGameObjectWithTag("LastFlash"))
            {
                Instantiate(DeathFlashLight, transform.position, Quaternion.identity);
            }
            Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);

            GameOver.SetActive(true);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        }

        if (other.CompareTag("Projectile"))
        {
            health -= 1;

            if (health <= 0)
            {
                Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);
                Instantiate(DeathFlashLight, transform.position, Quaternion.identity);
                GameOver.SetActive(true);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            }

            if (other.CompareTag("Projectile"))
            {
                Destroy(other.gameObject);
            }

        }

        if (other.CompareTag("Battery"))
        {
            AudioSource.PlayClipAtPoint(BatterySound, transform.position);
            BatteryNum += 1;
            Destroy(other.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        //Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
        Gizmos.DrawWireSphere(GroundCheckPoint.position, CircleRadius);
    }

}
