using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FrameColor : MonoBehaviour
{
    public Material[] MaterialSolution; // Ajouter les materiel qui résout l'énigme
    public GameObject mainD;
    public GameObject mainG;

    private Material Defaultmaterial;
    [SerializeField]
    private bool goal;  //Réussite de l'énigme
    public bool getGoal() { return goal; }

    // Start is called before the first frame update
    void Start()
    {
        Defaultmaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().material.color == MaterialSolution[0].color || GetComponent<Renderer>().material.color == MaterialSolution[1].color)
        {
            goal = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Sphere")
        {
            XRController manetteD = mainD.GetComponent<XRController>();
            XRController manetteG = mainG.GetComponent<XRController>();
            if (!manetteG.selectInteractionState.active && !manetteD.selectInteractionState.active)
            {
                Transform go = GameObject.Find("Wall Arch").transform;
                other.gameObject.transform.parent = go;
                other.attachedRigidbody.isKinematic = true;
                other.transform.position = gameObject.transform.TransformPoint(GetComponent<BoxCollider>().center);
                other.transform.localScale = new Vector3(0.1f / go.localScale.x, 0.1f / go.localScale.y, 0.1f / go.localScale.z);
            }
            GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.transform.tag == "Sphere")
        {
            XRController manetteD = mainD.GetComponent<XRController>();
            XRController manetteG = mainG.GetComponent<XRController>();
            if (manetteG.selectInteractionState.active || manetteD.selectInteractionState.active)
                other.attachedRigidbody.isKinematic = false;
            GetComponent<Renderer>().material = Defaultmaterial;
        }
    }
}
