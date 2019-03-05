using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    public GameObject missingEye;
    public bool openSkull = false;
    public HingeJoint joint;
    JointLimits limits;
    Vector3 eyeSocket;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        limits = joint.limits;
        eyeSocket.x = 2;
        eyeSocket.y = (float)0.3;
        eyeSocket.z = (float)4.0;
    }

    // Update is called once per frame
    void Update()
    {
        if (openSkull)
        {
            limits.max = 45;
            joint.limits = limits;
        }
        if (Vector3.Distance(eyeSocket, missingEye.transform.position) < 1)//(Input.GetKeyDown("space"))
        {
            openSkull = true;
        }
    }
}
