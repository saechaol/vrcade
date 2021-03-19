using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillardBallController : MonoBehaviour
{
    // Start is called before the first frame update

    public  BallType ballType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sink()
    {
        gameObject.SetActive(false);
    }
}
