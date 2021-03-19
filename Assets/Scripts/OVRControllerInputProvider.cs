using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class OVRControllerInputProvider : MonoBehaviour
{
    // Start is called before the first frame update


    public float[] triggers;
    public Vector3[] spatialGripPos;
    public Quaternion[] spatialGripQuat;
    public Vector3[] spatialPointerPos;
    public Quaternion[] spatialPointerQuat;
    public float[] gripPresses;
    public Vector2[] thumbSticks;
    public bool[] secondaryButtons;
    public bool[] primaryButtons;

    void Start()
    {
        triggers = new float[2];
        spatialPointerPos = new Vector3[2];
        spatialPointerQuat = new Quaternion[2];
        spatialGripPos = new Vector3[2];
        spatialGripQuat = new Quaternion[2];
        gripPresses = new float[2];
        thumbSticks = new Vector2[2];
        secondaryButtons = new bool[2];
        primaryButtons = new bool[2];

}

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (var controller in CoreServices.InputSystem.DetectedControllers)
        {
            // Interactions for a controller is the list of inputs that this controller exposes
            //Debug.Log("Controller " + i);
            foreach (MixedRealityInteractionMapping inputMapping in controller.Interactions)
            {
                // 6DOF controllers support the "SpatialPointer" type (pointing direction)
                // or "GripPointer" type (direction of the 6DOF controller)
                //Debug.Log(inputMapping.InputType.ToString());
                if (inputMapping.InputType == DeviceInputType.SpatialPointer)
                {
                    spatialPointerPos[i] = inputMapping.PositionData;
                    spatialPointerQuat[i] = inputMapping.RotationData;
                    //Debug.Log("spatial pointer PositionData: " + inputMapping.PositionData);
                    //Debug.Log("spatial pointer RotationData: " + inputMapping.RotationData);
                }

                if (inputMapping.InputType == DeviceInputType.SpatialGrip)
                {
                    spatialGripPos[i] = inputMapping.PositionData;
                    spatialGripQuat[i] = inputMapping.RotationData;
                    //Debug.Log("spatial grip PositionData: " + inputMapping.PositionData);
                    //Debug.Log("spatial grip RotationData: " + inputMapping.RotationData);
                }

                if (inputMapping.InputType == DeviceInputType.Trigger)
                {
                    triggers[i] = inputMapping.FloatData;
                    //Debug.Log("Trigger: " + inputMapping.FloatData);
                }

                if (inputMapping.InputType == DeviceInputType.GripPress)
                {
                    gripPresses[i] = inputMapping.FloatData;
                    //Debug.Log("Grip: " + inputMapping.FloatData);
                }

                if (inputMapping.InputType == DeviceInputType.Select)
                {
                    //Debug.Log("Select: " + inputMapping.BoolData);
                }

                if (inputMapping.InputType == DeviceInputType.ThumbStick)
                {
                    thumbSticks[i] = inputMapping.Vector2Data;
                    //Debug.Log("ThumbStick: " + inputMapping.Vector2Data);
                }

                if (inputMapping.InputType == DeviceInputType.SecondaryButtonPress)
                {
                    secondaryButtons[i] = inputMapping.BoolData;
                    //Debug.Log("ThumbStick: " + inputMapping.Vector2Data);
                }

                if (inputMapping.InputType == DeviceInputType.PrimaryButtonPress)
                {
                    primaryButtons[i] = inputMapping.BoolData;
                    //Debug.Log("ThumbStick: " + inputMapping.Vector2Data);
                }
            }
            i += 1;
            if (i >= 2)
            {
                break;
            }
        }
    }
}
