using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    float bouncePower = 400;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
       Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        PlayerController pt = collision.gameObject.GetComponent<PlayerController>();
        Vector3 bounce = Vector3.Reflect(pt.lastVelocity, collision.contacts[0].normal);


        rb.AddForce(bounce * bouncePower);
    }
}
