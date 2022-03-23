using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigmeManager : MonoBehaviour
{
    public GameObject table; // pour avoir référence au script énigme Disposition
    public GameObject torch; // pour avoir référence au script énigme TorchInteraction
    public GameObject diamondEye; // pour avoir référence au script énigme MissingEye

    public GameObject doorStatue; // pour pouvoir l'ouvrir
    public GameObject wallSkull; // pour pouvoir le détruire
    public GameObject particles; // pour quand wallSkull explose
    public GameObject ChestLid; // pour pouvoir ouvrir le coffre
    public GameObject finalDoor; // pour sortir quand on a fini toutes les énigmes :

    private bool isTable = true; //enigme de la table
    private bool isTorch = true; //énigme lumières
    private bool isSkull = true; //énigme crâne
    private bool isChest = false; // enigme de coffre

    // Variable pour ouvrir le coffre
    private float rotationSpeed = 30f;
    private Vector3 anglerotation = new Vector3(0.0f,0.0f,0.0f);
    private float limitRotationX = -120f;

    // variable pour ouvrir la dernière porte
    private float translationSpeed = 1f;
    private float positiontranslationY = 0.0f;
    private float limitTranslationY = 3.0f;

    void Update()
    {
        updateEnigmas();
        if (isTable && wallSkull.activeSelf)
        {
            // énigme de la table réussie, on détruit wallSkull
            wallSkull.SetActive(false);
            particles.SetActive(true);
        }
        if (isSkull && doorStatue.activeSelf)
        {
            // énigme du crâne réussie, on ouvre la porte de la statue pour accéeder au poème
            doorStatue.GetComponent<Animator>().SetTrigger("DoorATrigger");
        }
        if (isTable && isSkull &&isTorch){
            // énigme de la table, crâne et du torche réussis
            // on ouvre le coffre avec une animation
            if (anglerotation.x >= limitRotationX )
            {
                anglerotation += new Vector3(-1, 0, 0) * Time.deltaTime * rotationSpeed;
                ChestLid.transform.localEulerAngles = anglerotation;
                rotationSpeed += 0.1f;
            }
        }
        if (isTable && isSkull && isTorch && isChest)
        {
            // on ouvre la dernière porte en la translatant vers le haut
            if (finalDoor.transform.localPosition.y <= limitTranslationY)
            {
                positiontranslationY = Time.deltaTime * translationSpeed;
                finalDoor.transform.localPosition = new Vector3(finalDoor.transform.localPosition.x, finalDoor.transform.localPosition.y + positiontranslationY, finalDoor.transform.localPosition.z);
            }
        }
    }

    private void updateEnigmas(){
        isTable = table.GetComponent<Disposition>().getGoal();
        isSkull = diamondEye.GetComponent<MissingEye>().getGoal();
        isTorch = torch.GetComponent<TorchInteraction>().getGoal();
        bool isframe1 = finalDoor.transform.GetChild(0).GetChild(0).GetComponent<FrameColor>().getGoal();
        bool isframe2 = finalDoor.transform.GetChild(0).GetChild(1).GetComponent<FrameColor>().getGoal();
        isChest = isframe1 && isframe2;
    }
}
