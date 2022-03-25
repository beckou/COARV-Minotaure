using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabPointAnywhere : MonoBehaviour
{
    public GameObject mainD;
    public GameObject mainG;
    public GameObject table;
    //private bool alreadyGrabD = false;
    //private bool alreadyGrabG = false;
    //private Collider cD;
    //private Collider cG;
    //private Collider c;
    //private int choix = 0;

    //private void Start()
    //{
    //    cD = mainD.GetComponent<Collider>();
    //    cG = mainG.GetComponent<Collider>();
    //    c = gameObject.GetComponent<Collider>();
    //}
    private void OnTriggerEnter(Collider other)
    {
        XRController manetteD = mainD.GetComponent<XRController>();
        XRController manetteG = mainG.GetComponent<XRController>();
        XRGrabInteractable g = gameObject.GetComponent<XRGrabInteractable>();
        
        Transform t = gameObject.transform;
        if (g.interactorsSelecting.Count != 0) {
            IXRSelectInteractor interactor = g.interactorsSelecting[0];
            t = interactor.transform; 
        }

        //placement des grab points
        if (other == mainD.GetComponent<SphereCollider>() && t != mainG.transform)
        {
            //Debug.Log("Détecté");
            GameObject fils = gameObject.transform.GetChild(0).gameObject;
            Vector3 positionMainRefObjet = gameObject.transform.InverseTransformPoint(mainD.transform.position);
            Quaternion RotationMain = mainD.transform.rotation;
            Debug.Log(positionMainRefObjet);
            fils.transform.localPosition = positionMainRefObjet;
            fils.transform.rotation = RotationMain;
        }
        if (other == mainG.GetComponent<SphereCollider>() && t != mainD.transform)
        {
            GameObject fils = gameObject.transform.GetChild(0).gameObject;
            Vector3 positionMainRefObjet = gameObject.transform.InverseTransformPoint(mainG.transform.position);
            Quaternion RotationMain = mainG.transform.rotation;
            Debug.Log(positionMainRefObjet);
            fils.transform.localPosition = positionMainRefObjet;
            fils.transform.rotation = RotationMain;
        }

        //Choix entre les deux grab points
        
        //if (grabD && !grabG)
        //{
        //    choix = 0;
        //    alreadyGrabD = true;
        //    //alreadyGrabG = false;
        //}
        //else if (!grabD && grabG)
        //{
        //    choix = 1;
        //    alreadyGrabD = false;
        //    //alreadyGrabG = true;
        //}
        //else if (grabD && grabG && c.bounds.Intersects(cD.bounds) && c.bounds.Intersects(cG.bounds))
        //{
        //    if (alreadyGrabD)
        //    {
        //        choix = 1;
        //        alreadyGrabD = false;
        //        //alreadyGrabG = true;
        //    }
        //    else
        //    {
        //        choix = 0;
        //        alreadyGrabD = true;
        //        //alreadyGrabG = false;
        //    }
        //}

        //XRGrabInteractable grab = gameObject.GetComponent<XRGrabInteractable>();
        //grab.attachTransform = gameObject.transform.GetChild(choix);
    }
}
