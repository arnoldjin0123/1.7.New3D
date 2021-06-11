using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayHi : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hi");
        //rb.AddForce(force);

        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("Hi");
            rb.AddForce(force);
        }
    }

}
