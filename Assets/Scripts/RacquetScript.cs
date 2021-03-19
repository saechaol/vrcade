using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacquetScript : MonoBehaviour
{
    private Rigidbody rb;
    
    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "TennisBall" || other.gameObject.tag == "PingPongBall"){
            var magnitude = 10;
            if (other.gameObject.tag == "TennisBall") {
                magnitude = 500;
            } else {
                magnitude = 30;
                
            }
            var force =  other.transform.position - transform.position;
                force.Normalize();
                other.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
        Debug.Log("Start up, sleeping");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
