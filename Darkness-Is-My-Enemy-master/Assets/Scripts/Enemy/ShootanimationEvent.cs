using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootanimationEvent : MonoBehaviour
{
    private DevilEnemy _enemy;
    // Start is called before the first frame update
    public void Start()
    {
        _enemy = transform.parent.GetComponent<DevilEnemy>();
    }
    public void fire()
    {
        _enemy.Attack();

    }
}
