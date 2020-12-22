using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCode : MonoBehaviour
{
    public int projectileSpeed;
    private Rigidbody2D _rb2D;
    // Start is called before the first frame update
    void Start()
    {

        _rb2D = GetComponent<Rigidbody2D>();
        if (DevilEnemy.faceRight)
        {
            _rb2D.velocity = transform.right * projectileSpeed;
        }
        else
        {
            _rb2D.velocity = -transform.right * projectileSpeed;
        }

        Destroy(this.gameObject, 5f);
    }


}
