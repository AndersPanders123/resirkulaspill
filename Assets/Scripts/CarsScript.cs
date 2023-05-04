using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsScript : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 15);
    }
    void OnCollisionEnter(Collision Man){
        if(Man.transform.tag == "Building"){
            Destroy(gameObject);
        }
    }
}
