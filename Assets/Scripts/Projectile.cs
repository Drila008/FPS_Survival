using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    [SerializeField]
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = transform.forward;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movement * speed;
        
    }
}
