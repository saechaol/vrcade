using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject calibrationMarker;
    [SerializeField]
    private GameObject RController;
    [SerializeField]
    private GameObject calibrationTarget;
    private bool isCalibrating;
    private List<GameObject> calibrationMarkers;

    OVRControllerInputProvider ovrInput;


    void Start()
    {
        isCalibrating = false;
        calibrationMarkers = new List<GameObject>();
        ovrInput = GameObject.Find("OVRControllerInput").GetComponent<OVRControllerInputProvider>();
    }

    // Update is called once per frame
    void Update()
    {


        float trigger = ovrInput.triggers[1];
        if (trigger >= 0.9f && isCalibrating)
        {
            Vector3 controllerpos;
            Quaternion controllerquat;

            controllerpos = ovrInput.spatialPointerPos[1];
            controllerquat = ovrInput.spatialPointerQuat[1];

            calibrationMarkers.Add(Instantiate(calibrationMarker, controllerpos, controllerquat));

        }
    }

    public void calibrate()
    {
        isCalibrating = true;
    }

    public void endCalibration()
    {
        Debug.Log("End Calibration------------------------------------------");
        isCalibrating = false;
        if (!(calibrationMarkers == null))
        {
            float xsum = 0;
            float ysum = 0;
            float zsum = 0;
            for (int i = 0; i < calibrationMarkers.Count; i++)
            {

                xsum += calibrationMarkers[i].transform.position.x;
                ysum += calibrationMarkers[i].transform.position.y;
                zsum += calibrationMarkers[i].transform.position.z;
                Destroy(calibrationMarkers[i]);
            }

            float xavg = xsum / calibrationMarkers.Count;
            float yavg = ysum / calibrationMarkers.Count;
            float zavg = zsum / calibrationMarkers.Count;
            Vector3 avgPosn = new Vector3(xavg, yavg, zavg);
            Vector3 tableEdge = new Vector3(calibrationTarget.gameObject.transform.position.x,
                                            calibrationTarget.gameObject.transform.position.y + 0.02f,
                                            calibrationTarget.gameObject.transform.position.z + 0.55f * Math.Sign(zavg - calibrationTarget.gameObject.transform.position.z)); //0.55f is table specific width. fix const for now
            Vector3 toMove = avgPosn - tableEdge;
            calibrationTarget.gameObject.transform.position += toMove; 
            Debug.Log("---------------------");
            Debug.Log(ysum / calibrationMarkers.Count);

        }
    }

}
