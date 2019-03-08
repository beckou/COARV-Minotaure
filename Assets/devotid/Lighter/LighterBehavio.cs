using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterBehavio : MonoBehaviour
{
    public GameObject Lighter;
    public GameObject Flamme;
    bool flammeAllumee=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject flamme;
        if (Input.GetMouseButtonDown(0))
        {

            if (!flammeAllumee)
            {
                Vector3 hauteurFlamme = new Vector3(0, 0.18f, 0);
                Quaternion rotationFlamme = new Quaternion(-0.5f, 0, 0, 0);
                flamme = Instantiate(Flamme, Lighter.transform.position + hauteurFlamme, Lighter.transform.rotation * rotationFlamme);
                flammeAllumee = true;
            }

            else
            {
                Destroy(GameObject.Find("Lighter_Flame(Clone)"));
                flammeAllumee = false;
            }
        }
    }
}
