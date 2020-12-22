using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityCalculation : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public GameObject obj;

    void Start()
    {
        //_rb2D = GetComponent<Rigidbody2D>();
 
    }
    void Update()
    {
       

    }

  
    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.tag == "Enemy")
        //{
        //    if(Mathf.Abs(_rb2D.velocity.x) > 5)
        //    {
        //        Destroy(col.gameObject);
                
        //        Destroy(obj);
        //    }
            
            
        //}
    }

    
}