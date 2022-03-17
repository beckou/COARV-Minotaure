using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Indique si les objets enfants (les nb premiers) sont bien placés par rapport à l'objet qui porte ce script

public class Disposition : MonoBehaviour
{
    private Vector3[] goalPos = new Vector3[4];
    private GameObject[] children = new GameObject[4];
    public float tolerance = 0.08f;  //Marge d'erreur pour le placement des objets

    public GameObject MainD;
    public GameObject MainG;

    [SerializeField]
    private bool goal = false;  //Réussite de l'énigme
    public bool getGoal(){return goal;}

    private void Start()
    {
        goalPos[0] = new Vector3(0.3f, 0.7f, -0.2f);    //vase
        goalPos[1] = new Vector3(0.1f, 0.7f, 0.2f);     //discobole
        goalPos[2] = new Vector3(-0.1f, 0.7f, 0f);      //sword
        goalPos[3] = new Vector3(-0.4f, 0.7f, 0.1f);    //skull

        for (int i = 0; i < 4; i++)
        {
            children[i] = gameObject.transform.GetChild(i).gameObject;
        }

    }
    void Update()
    {
        if (!goal){
            
            XRController manetteD = MainD.GetComponent<XRController>();
            XRController manetteG = MainG.GetComponent<XRController>();
            if (!manetteD.selectInteractionState.active && !manetteG.selectInteractionState.active)
            {
                goal = true;
                for (int i = 0; i < goalPos.Length; i++)
                {
                    Debug.Log((children[i].transform.localPosition - goalPos[i]).magnitude);
                    if ((gameObject.transform.GetChild(i).localPosition - goalPos[i]).magnitude > tolerance)
                    {
                        goal = false;
                    }
                }
            }

            if (goal){
                Debug.Log("énigme table réussie !");
            }
        }
    }
}
