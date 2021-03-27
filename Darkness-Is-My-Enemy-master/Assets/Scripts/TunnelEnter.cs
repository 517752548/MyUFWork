using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelEnter : MonoBehaviour
{
    public GameObject TunnelDoor;
    private Animator _anim;


    private void Start()
    {
        _anim = TunnelDoor.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _anim.SetTrigger("DoorClose");
        }
    }
}
