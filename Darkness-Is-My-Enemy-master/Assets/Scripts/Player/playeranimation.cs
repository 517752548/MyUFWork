using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();


     }
   public void Move(float move)
    {
        _anim.SetFloat("Move",Mathf.Abs(move));
    }
   public void Jump()
   {
       _anim.SetTrigger("Jump");

   }
}
