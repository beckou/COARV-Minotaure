using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TorchesVR : MonoBehaviour
{
    public GameObject torchesEnigme;
    public GameObject rayG;
    public bool complete = false;

    private GameObject[] torches;
    private GameObject[] tousLesTrucsADesactiver;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            torches[i] = torchesEnigme.transform.GetChild(i).gameObject;
            tousLesTrucsADesactiver[2 * i] = torches[i].transform.GetChild(0).gameObject;
            tousLesTrucsADesactiver[2 * i + 1] = torches[i].transform.GetChild(1).gameObject;
        }
        for (int i = 0; i < 8; i++)
        {
            tousLesTrucsADesactiver[i].SetActive(false); //ça marche pas pour l'instant ?
        }
    }

    // Update is called once per frame
    void Update()
    {
        rayG.GetComponent<XRRayInteractor>().TryGetHitInfo(out Vector3 v, out Vector3 n, out int i, out bool valid);
        Debug.Log(v);
        Debug.Log(valid);
        //On calcule le vecteur torche - player et le vecteur ray hit - player, produit scalaire avec une valeur minimale d'acceptation
    }
}
