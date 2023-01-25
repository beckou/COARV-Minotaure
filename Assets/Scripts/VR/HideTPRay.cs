using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HideTPRay : MonoBehaviour
{
    public float taille = 0.05f;
    public float zPos = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //Cr�er le collider
        gameObject.AddComponent<BoxCollider>();
        BoxCollider c = gameObject.GetComponent<BoxCollider>();
        c.isTrigger = true;
        c.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider c = gameObject.GetComponent<BoxCollider>();
        c.size = new Vector3(taille, taille, taille);
        XRController manette = gameObject.GetComponent<XRController>();

        if (manette.selectInteractionState.active)
        {
            c.center = new Vector3(0, 0, 0);
        } 
        else
        {
            c.center = new Vector3(0, 0, zPos);
        }
    }
}
