using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Indique si les objets enfants (les nb premiers) sont bien placés par rapport à l'objet qui porte ce script

public class Disposition : MonoBehaviour
{
    private Vector3[] goalPos = new Vector3[4];
    private GameObject[] items = new GameObject[4];
    public float tolerance = 0.08f;  //Marge d'erreur pour le placement des objets

    public GameObject MainD;
    public GameObject MainG;
    public GameObject vaseGoal;
    public GameObject discoboleGoal;
    public GameObject swordGoal;
    public GameObject skullGoal;

    [SerializeField]
    private bool goal = false;  //Réussite de l'énigme
    public bool getGoal(){return goal;}

    private void Start()
    {
        goalPos[0] = vaseGoal.transform.localPosition;   //vase
        goalPos[1] = discoboleGoal.transform.localPosition;      //discobole
        goalPos[2] = swordGoal.transform.localPosition;       //sword
        goalPos[3] = skullGoal.transform.localPosition;     //skull
        for (int i = 0; i < 4; i++)
        {
            items[i] = gameObject.transform.GetChild(i).gameObject;
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
                    //Debug.Log((items[i].transform.localPosition - goalPos[i]).magnitude);
                    if ((items[i].transform.localPosition - goalPos[i]).magnitude > tolerance)
                    {
                        goal = false;
                    }
                }
            }
        }
    }
}
