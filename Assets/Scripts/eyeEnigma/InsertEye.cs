using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            MissingEye.transform.localPosition = new Vector3(-x, y, z);
            MissingEye.transform.localRotation = FixedEye.transform.localRotation;
            MissingEye.transform.localScale = FixedEye.transform.localScale;
            //Eye.transform.RotateAround(Relique.transform.position, Vector3.up, 180);
            MissingEye.transform.SetParent(this.transform); // il retrouve son père d'origine
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            goal = true;
        }
    }
}
