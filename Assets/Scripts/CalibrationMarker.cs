using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationMarker : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(1, 1, 1) * gameObject.transform.rotation;
    }
}
