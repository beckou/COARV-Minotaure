using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPointAnywhere : MonoBehaviour
{
    public GameObject main;

    private void OnTriggerEnter(Collider other)
    {
        if (other == main.GetComponent<SphereCollider>())
        {
            GameObject fils = gameObject.transform.GetChild(0).gameObject;
            Vector3 positionMainRefObjet = fils.transform.InverseTransformPoint(main.transform.position);
            Debug.Log(positionMainRefObjet);
            fils.transform.localPosition = positionMainRefObjet;
        }
    }
}
