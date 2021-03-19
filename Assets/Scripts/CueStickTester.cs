using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CueStickTester : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RController;
    public GameObject LController;
    private ConfigurableJoint LConfigurableJoint;
    private ConfigurableJoint RConfigurableJoint;
    private LookAtConstraint lookAtConstraint;
    private bool hasRJoint;
    private bool hasLJoint;

    void Start()
    {
        lookAtConstraint = RController.GetComponent<LookAtConstraint>();
        lookAtConstraint.constraintActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasRJoint)
        {
            Debug.Log("create RJoint");
            //gameObject.transform.position = ovrInput.spatialPointerPos[1];
            //gameObject.transform.rotation = ovrInput.spatialPointerQuat[1];
            RConfigurableJoint = gameObject.AddComponent<ConfigurableJoint>();
            RConfigurableJoint.connectedBody = RController.GetComponent<Rigidbody>();

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
            JointDrive RYDrive = new JointDrive();
            RYDrive.positionSpring = 1000f;
            RYDrive.positionDamper = 50f;
            JointDrive RZDrive = new JointDrive();
            RZDrive.positionSpring = 1000f;
            RZDrive.positionDamper = 50f;
            JointDrive RAngXDrive = new JointDrive();
            RAngXDrive.positionSpring = 1000f;
            RAngXDrive.positionDamper = 50f;
            JointDrive RAngYZDrive = new JointDrive();
            RAngYZDrive.positionSpring = 1000f;
            RAngYZDrive.positionDamper = 50f;

            RConfigurableJoint.xDrive = RXDrive;
            RConfigurableJoint.yDrive = RYDrive;
            RConfigurableJoint.zDrive = RZDrive;
            RConfigurableJoint.angularXDrive = RAngXDrive;
            RConfigurableJoint.angularYZDrive = RAngYZDrive;

            hasRJoint = true;
        }

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
            LConfigurableJoint.angularYMotion = ConfigurableJointMotion.Free;
            LConfigurableJoint.angularZMotion = ConfigurableJointMotion.Free;

            JointDrive LXDrive = new JointDrive();
            LXDrive.positionSpring = 800f;
            LXDrive.positionDamper = 40f;
            JointDrive LYDrive = new JointDrive();
            LYDrive.positionSpring = 800f;
            LYDrive.positionDamper = 40f;
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
