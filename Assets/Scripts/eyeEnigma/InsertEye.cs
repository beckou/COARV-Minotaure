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
            float x = FixedEye.transform.position.x;
            float y = FixedEye.transform.position.y;
            float z = FixedEye.transform.position.z;
            MissingEye.transform.position = new Vector3(-x, y, z);
            MissingEye.transform.rotation = FixedEye.transform.rotation;
            MissingEye.transform.localScale = FixedEye.transform.localScale;
            //Eye.transform.RotateAround(Relique.transform.position, Vector3.up, 180);
            MissingEye.transform.SetParent(this.transform); // il retrouve son père d'origine
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            goal = true;
            XRGrabInteractable grabEye = MissingEye.GetComponent<XRGrabInteractable>();
            grabEye.enabled = false;
        }
    }
}
