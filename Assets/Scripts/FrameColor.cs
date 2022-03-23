using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameColor : MonoBehaviour
{
    public Material MaterialSolution; // Ajouter le materiel qui résout l'énigme

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
        if (GetComponent<Renderer>().material.color == MaterialSolution.color)
        {
            goal = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Sphere")
        {
            other.gameObject.transform.parent = GameObject.Find("Wall Arch").transform;
            other.attachedRigidbody.useGravity = false;
            other.transform.position = GetComponent<Collider>().bounds.center;
            GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Sphere")
        {
            other.attachedRigidbody.useGravity = true;
            GetComponent<Renderer>().material = Defaultmaterial;
        }
    }
}
