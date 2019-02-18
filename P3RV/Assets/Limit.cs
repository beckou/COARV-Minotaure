using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    public HingeJoint joint;
    JointLimits limits;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        limits = joint.limits;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            limits.max = 45;
            joint.limits = limits;
        }
    }
}
