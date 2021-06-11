using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncing : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Floor"))
        {
            //Debug.Log("Kiss!");
            print("Kiss!");
            rb.AddForce(force);
        }


    }
}
