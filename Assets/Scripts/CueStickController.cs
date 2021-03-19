using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public enum CueStickStates {IDLE, SELECTED, GRABBED, USING};

public class CueStickController : MonoBehaviour
{
    // Start is called before the first frame update

    public OVRControllerInputProvider ovrInput;
    public ObjectManipulator objectManipulator;
    public CueStickStates curState = CueStickStates.IDLE;
    private LookAtConstraint lookAtConstraint;

    public GameObject RController;
    public GameObject LController;
    private bool hasLJoint;
    private bool hasRJoint;
    private ConfigurableJoint LConfigurableJoint;
    private ConfigurableJoint RConfigurableJoint;
    private Transform originalTransform;
    private float maxForce = 1000;

    void Start()
    {
        ovrInput = GameObject.Find("OVRControllerInput").GetComponent<OVRControllerInputProvider>();
        lookAtConstraint = RController.GetComponent<LookAtConstraint>();
        lookAtConstraint.constraintActive = false;
        Destroy(RConfigurableJoint);
        Destroy(LConfigurableJoint);
        hasLJoint = false;
        hasRJoint = false;
        originalTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        StateRecognition();
    }

    public void ManipulationStartedCallback()
    {
        curState = CueStickStates.SELECTED;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    private void StateRecognition()
    {

        if (ovrInput.secondaryButtons[1])
        {
            Debug.Log("Switching back to Selected");
            curState = CueStickStates.SELECTED;
            hasRJoint = false;
            hasLJoint = false;


            if (RConfigurableJoint)
            {
                Destroy(RConfigurableJoint);
            }
            if (LConfigurableJoint)
            {
                Destroy(LConfigurableJoint);

                lookAtConstraint.constraintActive = false;
                objectManipulator.enabled = true;
                //gameObject.transform.position = originalTransform.position;
                //gameObject.transform.rotation = originalTransform.rotation;
            }
        }

        else if (curState == CueStickStates.SELECTED) //works
        {
            if (ovrInput.primaryButtons[1])
            {
                Debug.Log("Selected to Grabbed");
                curState = CueStickStates.GRABBED;
                objectManipulator.enabled = false;
            }
        }

        else if (curState == CueStickStates.GRABBED)
        {
            //error = ovrInput.spatialPointerPos[1] - gameObject.transform.position;
            //cueRigidbody.AddForce(error * kp + (error - pastError) * kd);
            //gameObject.transform.rotation = ovrInput.spatialPointerQuat[1];
            //pastError = error;


            if (!hasRJoint)
            {
                Debug.Log("create RJoint");
                gameObject.transform.position = ovrInput.spatialPointerPos[1];
                gameObject.transform.rotation = ovrInput.spatialPointerQuat[1];
                RConfigurableJoint = gameObject.AddComponent<ConfigurableJoint>();
                RConfigurableJoint.connectedBody = RController.GetComponent<Rigidbody>();
                lookAtConstraint.constraintActive = false;
                //RConfigurableJoint.transform.position = Vector3.zero;
                //RConfigurableJoint.transform.rotation = Quaternion.identity;
                RConfigurableJoint.autoConfigureConnectedAnchor = false;
                RConfigurableJoint.anchor = Vector3.zero;
                RConfigurableJoint.connectedAnchor = Vector3.zero;
                RConfigurableJoint.xMotion = ConfigurableJointMotion.Free;
                RConfigurableJoint.yMotion = ConfigurableJointMotion.Free;
                RConfigurableJoint.zMotion = ConfigurableJointMotion.Free;
                RConfigurableJoint.angularXMotion = ConfigurableJointMotion.Free;
                RConfigurableJoint.angularYMotion = ConfigurableJointMotion.Free;
                RConfigurableJoint.angularZMotion = ConfigurableJointMotion.Free;

                JointDrive RXDrive = new JointDrive();
                RXDrive.positionSpring = 1000f;
                RXDrive.positionDamper = 50f;
                RXDrive.maximumForce = maxForce;
                JointDrive RYDrive = new JointDrive();
                RYDrive.positionSpring = 1000f;
                RYDrive.positionDamper = 50f;
                RYDrive.maximumForce = maxForce;
                JointDrive RZDrive = new JointDrive();
                RZDrive.positionSpring = 1500f;
                RZDrive.positionDamper = 50f;
                RZDrive.maximumForce = maxForce;
                JointDrive RAngXDrive = new JointDrive();
                RAngXDrive.positionSpring = 1000f;
                RAngXDrive.positionDamper = 50f;
                RAngXDrive.maximumForce = maxForce;
                JointDrive RAngYZDrive = new JointDrive();
                RAngYZDrive.positionSpring = 1000f;
                RAngYZDrive.positionDamper = 50f;
                RAngYZDrive.maximumForce = maxForce;

                RConfigurableJoint.xDrive = RXDrive;
                RConfigurableJoint.yDrive = RYDrive;
                RConfigurableJoint.zDrive = RZDrive;
                RConfigurableJoint.angularXDrive = RAngXDrive;
                RConfigurableJoint.angularYZDrive = RAngYZDrive;

                hasRJoint = true;
            }

            if (ovrInput.primaryButtons[0])//(ovrInput.spatialPointerPos[0] - gameObject.transform.position + 1.2f * (gameObject.transform.rotation * Vector3.forward)).magnitude < 0.1f) // ?
            {
                Debug.Log("Grab to using");
                curState = CueStickStates.USING;
            }
        }

        else if (curState == CueStickStates.IDLE) // ?
        {
            if (ovrInput.triggers[1] > 0.7 && (ovrInput.spatialPointerPos[0] - gameObject.transform.position).magnitude < 0.1f)
            {
                Debug.Log("Idle to Grab");
                curState = CueStickStates.GRABBED;
                objectManipulator.enabled = false;
            }
        }

        else if (curState == CueStickStates.USING)
        {


            if (!hasLJoint)
            {
                Debug.Log("Cue stick being used");
                lookAtConstraint.constraintActive = true;

                LConfigurableJoint = gameObject.AddComponent<ConfigurableJoint>();
                LConfigurableJoint.connectedBody = LController.GetComponent<Rigidbody>();

                //LConfigurableJoint.transform.position = Vector3.zero;
                //LConfigurableJoint.transform.rotation = Quaternion.identity;
                LConfigurableJoint.autoConfigureConnectedAnchor = false;
                LConfigurableJoint.anchor = Vector3.zero;
                LConfigurableJoint.connectedAnchor = Vector3.zero;
                LConfigurableJoint.xMotion = ConfigurableJointMotion.Free;
                LConfigurableJoint.yMotion = ConfigurableJointMotion.Free;
                LConfigurableJoint.zMotion = ConfigurableJointMotion.Free;
                LConfigurableJoint.angularXMotion = ConfigurableJointMotion.Free;
                LConfigurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
                LConfigurableJoint.angularZMotion = ConfigurableJointMotion.Free;

                JointDrive LXDrive = new JointDrive();
                LXDrive.positionSpring = 800f;
                LXDrive.positionDamper = 40f;
                LXDrive.maximumForce = maxForce;
                JointDrive LYDrive = new JointDrive();
                LYDrive.positionSpring = 800f;
                LYDrive.positionDamper = 40f;
                LYDrive.maximumForce = maxForce;
                JointDrive LZDrive = new JointDrive();
                LZDrive.positionSpring = 0f;
                LZDrive.positionDamper = 0f;
                JointDrive LAngXDrive = new JointDrive();
                LAngXDrive.positionSpring = 0f;
                LAngXDrive.positionDamper = 0f;
                JointDrive LAngYZDrive = new JointDrive();
                LAngYZDrive.positionSpring = 0f;
                LAngYZDrive.positionDamper = 0f;

                LConfigurableJoint.xDrive = LXDrive;
                LConfigurableJoint.yDrive = LYDrive;
                LConfigurableJoint.zDrive = LZDrive;
                LConfigurableJoint.angularXDrive = LAngXDrive;
                LConfigurableJoint.angularYZDrive = LAngYZDrive;

                hasLJoint = true;
            }
        }
    }
    
}
