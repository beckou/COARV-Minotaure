using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPointAnywhere : MonoBehaviour
{
    public GameObject mainD;
    public GameObject mainG;

    private void OnTriggerEnter(Collider other)
    {
        if (other == mainD.GetComponent<SphereCollider>())
        {
            Debug.Log("Détecté");
            GameObject fils = gameObject.transform.GetChild(0).gameObject;
            Vector3 positionMainRefObjet = gameObject.transform.InverseTransformPoint(mainD.transform.position);
            Quaternion RotationMain = mainD.transform.rotation;
            Debug.Log(positionMainRefObjet);
            fils.transform.localPosition = positionMainRefObjet;
            fils.transform.rotation = RotationMain;
        }
        if (other == mainG.GetComponent<SphereCollider>())
        {
            Debug.Log("Détecté");
            GameObject fils = gameObject.transform.GetChild(0).gameObject;
            Vector3 positionMainRefObjet = gameObject.transform.InverseTransformPoint(mainG.transform.position);
            Quaternion RotationMain = mainG.transform.rotation;
            Debug.Log(positionMainRefObjet);
            fils.transform.localPosition = positionMainRefObjet;
            fils.transform.rotation = RotationMain;
        }
    }
}
