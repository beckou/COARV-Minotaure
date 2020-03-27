using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ce script est attaché à l'oeil en diamant
public class MissingEye : MonoBehaviour
{
    private bool resolved = false;
    public bool getGoal(){return resolved;}

    private bool magnet = false;
    private ConfigurableJoint joint;
    JointDrive drive;
    private Vector3 eyeSocket;

    void Start()
    {
        eyeSocket = new Vector3(2f, 0.3f, 4f);
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnet)
        {
            drive.maximumForce = 100000000000000000;
            drive.positionSpring = 100;
            joint.angularXDrive = drive;
            joint.angularYZDrive = drive;
            joint.xDrive = drive;
            joint.yDrive = drive;
            joint.zDrive = drive;
        }

        if (Vector3.Distance(eyeSocket,transform.position)<3) //(Input.GetKeyDown("m"))
        {
            magnet = true;
        }
    }
}
