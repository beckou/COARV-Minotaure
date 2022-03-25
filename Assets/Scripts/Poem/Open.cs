using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject mainDroite;
    public GameObject mainGauche;
    public bool MainDetected = false;
    private bool FirstDetect = true;
    private bool open = false;
    private float depla = 0;
    private float pas = 0.01f;
    private float delay = 0.025f;
    private float time_update = 0f;
    private bool FirstMove = true;

    public bool getOpen() { return open; }

    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject == mainDroite || col.gameObject == mainGauche) && FirstDetect)
        {
            gameObject.transform.GetChild(4).localPosition = new Vector3(0,0.1f,0);
            MainDetected = true;
            FirstDetect = false;
        }
    }

    private void Start()
    {
        time_update = delay;
    }

    void Update()
    {
        float time = Time.time;
        if (MainDetected && !open)
        {
            gameObject.transform.GetChild(4).localPosition = new Vector3(0, 0.1f, 0);

            if (time > time_update)
            {
                deplacement();
                time_update = Time.time + delay;
            }
            if (depla == 0.5f && !FirstMove)
            {
                open = true;
            }
            
        }
    }

    void deplacement()
    {
        if (FirstMove)
        {
            if (depla < 0.5f)
            {
                gameObject.transform.GetChild(0).transform.GetChild(0).transform.localPosition += new Vector3(-pas, 0, pas);
                gameObject.transform.GetChild(1).transform.GetChild(0).transform.localPosition += new Vector3(-pas, 0, pas);
                gameObject.transform.GetChild(2).transform.GetChild(0).transform.localPosition += new Vector3(-pas, 0, pas);
                gameObject.transform.GetChild(3).transform.GetChild(0).transform.localPosition += new Vector3(-pas, 0, pas);
                depla += pas;
            }
            else
            {
                FirstMove = false;
                depla = 0.0f;
            }
        }
        else
        {
            if (depla <= 0.5f)
            {
                gameObject.transform.GetChild(0).transform.GetChild(1).transform.localPosition += new Vector3(-pas, 0, pas);
                gameObject.transform.GetChild(1).transform.GetChild(1).transform.localPosition += new Vector3(-pas, 0, pas);
                gameObject.transform.GetChild(2).transform.GetChild(1).transform.localPosition += new Vector3(-pas, 0, pas);
                gameObject.transform.GetChild(3).transform.GetChild(1).transform.localPosition += new Vector3(-pas, 0, pas);
                depla += pas;
            }
        }

    }

}
