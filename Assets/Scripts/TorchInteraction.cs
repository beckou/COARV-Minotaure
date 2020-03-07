using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{
    public bool enigmaResolved = false;

    private int torch1 = 0;
    private int torch2 = 0;
    private int torch3 = 0;
    private int torch4 = 0;
    private int torch = 0;
    // gameobjects we will need in the script
    
    private GameObject torches;
    private GameObject torche1;
    private GameObject torche2;
    private GameObject torche3;
    private GameObject torche4;
    private GameObject Light1;
    private GameObject Light2;
    private GameObject Light3;
    private GameObject Light4;




    // get the child by its name and its parent gameobject
    static public GameObject getChildGameObject(GameObject go, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = go.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        torches = GameObject.Find("TorchesEnigme"); 
        torche1 = getChildGameObject(torches, "torche1");
        torche2 = getChildGameObject(torches, "torche2");
        torche3 = getChildGameObject(torches, "torche3");
        torche4 = getChildGameObject(torches, "torche4");
        Light1 = getChildGameObject(torche1, "torch_Particle");
        Light2 = getChildGameObject(torche2, "torch_Particle");
        Light3 = getChildGameObject(torche3, "torch_Particle");
        Light4 = getChildGameObject(torche4, "torch_Particle");
        Light1.SetActive(false);
        Light2.SetActive(false);
        Light3.SetActive(false);
        Light4.SetActive(false);


        //Debug.Log(Light2.transform.localPosition);
    
    }
   


    // Update is called once per frame
    void Update()
    {
        // allumer la 1ere torche
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            Light1.SetActive(true);
            torch++;

        }
        // allumer la 2eme torche
        if (Input.GetKeyDown(KeyCode.B))
        {
            
            Light2.SetActive(true);
            torch++;
            //Debug.Log(Light2.activeSelf);
        }
        // allumer la 3eme torche
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            Light3.SetActive(true);
            torch++;
        }
        // allumer la 4eme torche
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            Light4.SetActive(true);
            torch++;
        }
        // eteindre la 1ere torche qui implique l'éteinte de toutes les torches pour refaire l'opération 
        if (Input.GetKeyDown(KeyCode.E))
        {
            enigmaResolved = false;

            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            torch1 = 0;
            torch2 = 0;
            torch3 = 0;
            torch4 = 0;
            torch = 0;
        }
        // eteindre la 2eme torche qui implique l'éteinte de toutes les torches pour refaire l'opération 
        if (Input.GetKeyDown(KeyCode.F))
        {
            enigmaResolved = false;
            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            torch1 = 0;
            torch2 = 0;
            torch3 = 0;
            torch4 = 0;
            torch = 0;
        }
        // eteindre la 3eme torche qui implique l'éteinte de toutes les torches pour refaire l'opération 
        if (Input.GetKeyDown(KeyCode.G))
        {
            enigmaResolved = false;
            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            torch1 = 0;
            torch2 = 0;
            torch3 = 0;
            torch4 = 0;
            torch = 0;
        }
        // eteindre la 4eme torche qui implique l'éteinte de toutes les torches pour refaire l'opération 
        if (Input.GetKeyDown(KeyCode.H))
        {
            enigmaResolved = false;
            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            torch1 = 0;
            torch2 = 0;
            torch3 = 0;
            torch4 = 0;
            torch = 0;
        }
        Debug.Log("torche 1 allumée en : ");
        Debug.Log(torch1);
        Debug.Log("torche 2 allumée en : ");
        Debug.Log(torch2);
        Debug.Log("torche 3 allumée en : ");
        Debug.Log(torch3);
        Debug.Log("torche 4 allumée en : ");
        Debug.Log(torch4);

        if (Light1.activeSelf && !Light2.activeSelf && !Light3.activeSelf && !Light4.activeSelf)
        {
            torch1 = torch; 
        }
        if (Light1.activeSelf && Light2.activeSelf && !Light3.activeSelf && !Light4.activeSelf)
        {
          
            torch2 = torch; 
        }
        if (Light1.activeSelf && Light2.activeSelf && Light3.activeSelf && !Light4.activeSelf)
        {

            torch3 = torch;
        }
        if (Light1.activeSelf && Light2.activeSelf && Light3.activeSelf && Light4.activeSelf)
        {

            torch4 = torch;
        }

        if (torch1 == 1 && torch2 == 2 && torch3 == 3 && torch4 == 4)
        {
            enigmaResolved = true;
        }
        
    }
}
