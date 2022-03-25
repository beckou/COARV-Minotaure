using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TorchesVR : MonoBehaviour
{
    public GameObject torchesEnigme;
    public GameObject rayG;
    public bool complete = false;
    public float tolerance = 0.01f;

    private GameObject[] torches = new GameObject[4];
    private GameObject[] tousLesTrucsADesactiver = new GameObject[8];
    [SerializeField]
    private int[] ordreAllumage = { -1,-1,-1,-1};
    private int indiceAllumage = 0;
    private int[] ordreAttendu = { 0, 1, 2, 3 };

    public bool getGoal() { return complete; }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            torches[i] = torchesEnigme.transform.GetChild(i).gameObject;
            tousLesTrucsADesactiver[2 * i] = torches[i].transform.GetChild(0).gameObject;
            tousLesTrucsADesactiver[2 * i + 1] = torches[i].transform.GetChild(1).gameObject;
            
        }
        for (int i = 0; i < 4; i++)
        {
            tousLesTrucsADesactiver[2*i].SetActive(false);
            tousLesTrucsADesactiver[2*i + 1].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Condition pour savoir si le rayon sort
        XRController manette = rayG.GetComponent<XRController>();
        if (manette.selectInteractionState.activatedThisFrame && !complete)
        {
            //On récupère le point d'impact
            rayG.GetComponent<XRRayInteractor>().TryGetHitInfo(out Vector3 v, out Vector3 n, out int i, out bool valid);

            Vector3[] playertoColliders = new Vector3[4];

            //On calcule le vecteur qui va du joueur au point d'impact
            Vector3 playertov = v - rayG.transform.position;

            //On calcule les vecteurs qui vont du joueur aux points d'impacts
            for (int j = 0; j < 4; j++)
            {
                playertoColliders[j] = torches[j].transform.TransformPoint(torches[j].GetComponent<SphereCollider>().center) - rayG.transform.position;
            }

            for (int j = 0; j < 4; j++)
            {
                //Produit scalaire entre les deux vecteurs pour chaque collider puis on récupère le cosinus de l'angle entre les deux vecteurs
                float scalar = Vector3.Dot(playertov, playertoColliders[j]);
                float cos = scalar / (Vector3.Magnitude(playertov) * Vector3.Magnitude(playertoColliders[j]));

                //Activation ou désactivation des torches si on considère qu'on Hit
                if (Mathf.Abs(cos - 1) < tolerance)
                {
                    bool jInTableau = false;
                    for (int k = 0; k < 4; k++)
                    {
                        if (ordreAllumage[k] == j)
                            jInTableau = true;
                    }
                    if (!jInTableau)
                    {
                        tousLesTrucsADesactiver[2 * j].SetActive(true);
                        tousLesTrucsADesactiver[2 * j + 1].SetActive(true);
                        ordreAllumage[indiceAllumage] = j;
                        indiceAllumage++;
                    }
                }
            }
        }
        //Check de l'ordre d'allumage
        bool fake_complete = true;
        for (int k = 0; k < 4; k++)
        {
            if (ordreAllumage[k] != ordreAttendu[k])
                fake_complete = false;
        }
        complete = fake_complete;
        if (indiceAllumage >= 4 && !complete)
        {
            indiceAllumage = 0;
            for (int i = 0; i < 4; i++)
            {
                ordreAllumage[i] = -1;
                tousLesTrucsADesactiver[2 * i].SetActive(false);
                tousLesTrucsADesactiver[2 * i + 1].SetActive(false);
            }
        }
    }
}
