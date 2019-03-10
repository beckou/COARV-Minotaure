using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingEye : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missingEye;
    public bool magnet = false;
    public ConfigurableJoint joint;
    JointDrive drive;
    Vector3 eyeSocket;
    void Start()
    {
        eyeSocket.x = 2;
        eyeSocket.y = (float)0.3;
        eyeSocket.z = (float)4.0;
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


        if (Vector3.Distance(eyeSocket,missingEye.transform.position)<3)//(Input.GetKeyDown("m"))
        {
            magnet = true;
        }
    }
}

