using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HideTPRayTorches : MonoBehaviour
{
    public GameObject enigmemanager;
    public float taille = 0.05f;
    public float zPos = 0.05f;
    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Créer le collider
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

        if (manette.selectInteractionState.active && timer > 0 && enigmemanager.GetComponent<enigmeManager>().isSkull)
        {
            c.center = new Vector3(0, 0, 0);
            timer -= 1;
        } 
        else 
        {
            c.center = new Vector3(0, 0, zPos);
            if (!manette.selectInteractionState.active)
                timer = 30;
        }
    }
}