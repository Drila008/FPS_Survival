using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody rb;

    [SerializeField]
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = transform.forward;
        Destroy(this.gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = movement * speed;
        
    }

    private void OnTriggerEnter(Collider other) //If hits a zombie, deal damage
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Zombie>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
