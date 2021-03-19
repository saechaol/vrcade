using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillardHole : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        if (other.CompareTag("Billard"))
        {
            other.GetComponent<BillardBallController>().sink();
            Debug.Log("Sink: " + other.GetComponent<BillardBallController>().ballType.ToString());

        }
    }
}
