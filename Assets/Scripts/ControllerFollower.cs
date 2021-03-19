using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { LEFT, RIGHT };

public class ControllerFollower : MonoBehaviour
{
    OVRControllerInputProvider ovrInput;
    public Side side;
    // Start is called before the first frame update
    void Start()
    {
        ovrInput = GameObject.Find("OVRControllerInput").GetComponent<OVRControllerInputProvider>();
    }

    // Update is called once per frame
    void Update() 
    {
        gameObject.transform.position = ovrInput.spatialPointerPos[(int) side];
        gameObject.transform.rotation = ovrInput.spatialPointerQuat[(int) side];
    }
}
