using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ce script est attaché à l'oeil en diamant
public class MissingEye : MonoBehaviour
{
    private bool goal = false;
    public bool getGoal(){return goal;}  //Permet de gérer la réussite de l'énigme
    private GameObject skull;

    private bool magnet = false;
    private Vector3 eyeSocket = new Vector3(2f, 2f, 1.4f);  //Position souhaitée de l'oeil (repérée dans la scène, à modifier potentiellement)
    private float threshold = 1f;
    private float armLength = 2f; // correspond a la distance a laquelle on manipule le diamant

    void Start(){
        skull = transform.parent.gameObject;
    }

    void Update()
    {
        if (!goal){
            if (magnet)
            {
                transform.SetParent(skull.transform);
                transform.localRotation = Quaternion.Euler(45, 0, 0);
                transform.localPosition = eyeSocket;
                GetComponent<Rigidbody>().useGravity = false;
                goal = true;    //Permet de gérer la réussite de l'énigme
            }

            if (Vector3.Distance(eyeSocket,transform.position)<threshold)
            {
                magnet = true;
            }

            MoveEye();
        }
    }

    void MoveEye(){
        if (Input.GetMouseButtonDown(0) && RayTracing.GetObject(gameObject.tag) == gameObject){
            // si le diamant est sélectionné
            GetComponent<Rigidbody>().useGravity = false;
            transform.SetParent(Camera.main.transform);
        }
        if (Input.GetMouseButtonUp(0)){
            transform.SetParent(skull.transform); // il retrouve son père d'origine
            GetComponent<Rigidbody>().useGravity = true;
        }

    }
}
