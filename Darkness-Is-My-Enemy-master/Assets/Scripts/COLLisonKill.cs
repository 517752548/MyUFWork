using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLLisonKill : MonoBehaviour
{
    RaycastHit2D hit;
    public float distance = 10f;
    public bool isGrounded;
    void Update()
    {

        hit = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.x, distance);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
    

    // Start is called before the first frame update
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}




    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * transform.localScale.x * distance);
    }

}
