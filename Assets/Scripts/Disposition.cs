using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Indique si les objets enfants (les nb premiers) sont bien placés par rapport à l'objet qui porte ce script

public class Disposition : MonoBehaviour
{
    private Vector3[] goalPos = new Vector3[4];
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
    }
    void Update()
    {
        if (!goal){
            goal = true;
            XRController manetteD = MainD.GetComponent<XRController>();
            XRController manetteG = MainG.GetComponent<XRController>();
            if (!manetteD.selectInteractionState.active && !manetteG.selectInteractionState.active)
            {
                for (int i = 0; i < goalPos.Length; i++)
                {
                    if (gameObject.transform.GetChild(i).localPosition != goalPos[i])
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
