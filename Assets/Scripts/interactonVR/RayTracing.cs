using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTracing : MonoBehaviour
{
    public static GameObject GetObject(string tag)
    {
        //Retourne l'objet avec le tag correspondant lors du click gauche
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == tag)
            {
                return hit.transform.gameObject;
            }
            else
            {
                return null;
            }
        }
        return null;
    }


    void Update()
    {
        //Test
        
        //Fin Test
    }
}
