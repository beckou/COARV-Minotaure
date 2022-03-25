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
            float x = FixedEye.transform.localPosition.x;
            float y = FixedEye.transform.localPosition.y;
            float z = FixedEye.transform.localPosition.z;

            Debug.Log(FixedEye.transform.localPosition);

            Vector3 posEye = new Vector3(-x, y, z);

            MissingEye.transform.localRotation = FixedEye.transform.localRotation;
            //MissingEye.transform.localScale = FixedEye.transform.localScale;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            col.gameObject.transform.position = gameObject.transform.TransformPoint(posEye);
            goal = true;
            XRGrabInteractable grabEye = MissingEye.GetComponent<XRGrabInteractable>();
            grabEye.enabled = false;
        }
    }
}
