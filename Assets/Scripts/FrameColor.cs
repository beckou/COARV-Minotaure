using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FrameColor : MonoBehaviour
{
    public Material[] MaterialSolution; // Ajouter les materiel qui résout l'énigme
    public GameObject PortalPlane;
    public GameObject mainD;
    public GameObject mainG;

    private Material FrameDefaultmaterial;
    private Color PortalDefaultmaterialColor;
    private float Intensity;
    [SerializeField]
    private bool goal;  //Réussite de l'énigme
    public bool getGoal() { return goal; }

    // Start is called before the first frame update
    void Start()
    {
        Intensity = 8;
        FrameDefaultmaterial = GetComponent<Renderer>().material;
        PortalDefaultmaterialColor = PortalPlane.GetComponent<MeshRenderer>().sharedMaterial.GetColor("_PortalColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().material.color == MaterialSolution[0].color || GetComponent<Renderer>().material.color == MaterialSolution[1].color)
        {
            XRController manetteD = mainD.GetComponent<XRController>();
            XRController manetteG = mainG.GetComponent<XRController>();
            if(!manetteD.selectInteractionState.active && !manetteG.selectInteractionState.active)
                goal = true;
        }
        GameObject[] t = GameObject.FindGameObjectsWithTag("Sphere");
        foreach (GameObject go in t)
        {
            go.GetComponent<Rigidbody>().isKinematic = false;
            go.GetComponent<Rigidbody>().useGravity = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            
            other.attachedRigidbody.isKinematic = true;
            other.attachedRigidbody.useGravity = false;
            other.transform.position = gameObject.transform.TransformPoint(GetComponent<BoxCollider>().center);
            other.gameObject.tag = "FixedSphere";
            GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
            PortalPlane.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_PortalColor", other.gameObject.GetComponent<Renderer>().material.color * Intensity);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Sphere" || other.gameObject.tag == "FixedSphere")
        {
            GetComponent<Renderer>().material = FrameDefaultmaterial;
            PortalPlane.GetComponent<MeshRenderer>().sharedMaterial.SetVector("_PortalColor", PortalDefaultmaterialColor);
        }
        if (other.gameObject.tag == "FixedSphere")
        {
            other.gameObject.tag = "Sphere";
        }
        goal = false;
    }
}
