using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{    
    
    private Rigidbody rb;

/*    public void OnCollisionEnter(Collision other) {
        var force = other.contacts[0].point - transform.position;
        force.Normalize();

        if (other.gameObject.tag != "Table" || (other.gameObject.tag != "TennisSideOne" || other.gameObject.tag != "TennisSideOTwo")) {
            Debug.Log("Awaken");
            rb.WakeUp();
        }

        if (other.gameObject.tag != "PlayerRacquet") {
            Debug.Log("Racquet");
            GetComponent<Rigidbody>().AddForce(force * magnitude);
        } else {
            Debug.Log("Table");
            
        }

        Debug.Log(force * magnitude);

    }*/

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
