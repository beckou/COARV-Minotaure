using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InsertEye : MonoBehaviour
{

    public GameObject MissingEye;
    public GameObject FixedEye;
    private bool goal = false;

    public bool getGoal() { return goal; }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == MissingEye)
        {
            MissingEye.transform.localRotation = FixedEye.transform.localRotation;
            MissingEye.transform.localScale = FixedEye.transform.localScale;
            //Eye.transform.RotateAround(Relique.transform.position, Vector3.up, 180);
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            col.gameObject.transform.position = gameObject.transform.TransformPoint(gameObject.GetComponent<SphereCollider>().center);
            goal = true;
            XRGrabInteractable grabEye = MissingEye.GetComponent<XRGrabInteractable>();
            grabEye.enabled = false;
        }
    }
}
