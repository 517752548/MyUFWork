using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    public GameObject Blast;
    public GameObject BlastCollider;
    public float RepetitionTime;

    private float _startRepetitionTime;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _startRepetitionTime = RepetitionTime;
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_startRepetitionTime) < .01)
        {
            Instantiate(Blast, transform.position, Quaternion.Euler(new Vector3(-90f, 0f, 0f)));
            Instantiate(BlastCollider, transform.position, Quaternion.identity);
            _anim.SetTrigger("IsBurst");
            _startRepetitionTime = RepetitionTime;
        }
        else
        {
            _startRepetitionTime -= Time.deltaTime;
        }
    }
}
