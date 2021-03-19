using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerSwitcher : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftController;
    public GameObject RightController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.Controller activeController = OVRInput.GetActiveController();

        switch (activeController)
        {
            case OVRInput.Controller.LTouch:
                LeftHand.SetActive(false);
                RightHand.SetActive(false);
                LeftController.SetActive(true);
                RightController.SetActive(false);
                break;
            case OVRInput.Controller.RTouch:
                LeftHand.SetActive(false);
                RightHand.SetActive(false);
                LeftController.SetActive(false);
                RightController.SetActive(true);
                break;
            case OVRInput.Controller.Touch:
                LeftHand.SetActive(false);
                RightHand.SetActive(false);
                LeftController.SetActive(true);
                RightController.SetActive(true);
                break;
            case OVRInput.Controller.LHand:
                LeftHand.SetActive(true);
                RightHand.SetActive(false);
                LeftController.SetActive(false);
                RightController.SetActive(false);
                break;
            case OVRInput.Controller.RHand:
                LeftHand.SetActive(false);
                RightHand.SetActive(true);
                LeftController.SetActive(false);
                RightController.SetActive(false);
                break;
            case OVRInput.Controller.Hands:
                LeftHand.SetActive(true);
                RightHand.SetActive(true);
                LeftController.SetActive(false);
                RightController.SetActive(false);
                break;
        }
    }
}
