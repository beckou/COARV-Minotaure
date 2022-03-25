using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instruction : MonoBehaviour
{
    public GameObject table;
    public GameObject torch;
    public GameObject bullskull;

    public GameObject finalDoor; // pour sortir quand on a fini toutes les énigmes

    TextMeshPro TextMeshProObject;

    private bool isTable = true;
    private bool isTorch = true;
    private bool isSkull = true;
    private bool isChest = false;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProObject = gameObject.GetComponent<TextMeshPro>();
        //TextMeshProObject.text = "Paracaidas";
    }

    // Update is called once per frame
    void Update()
    {
        //Update enigmes
        //Prendre le temps
        time += Time.deltaTime;

        //Le temps est en secondes...
        //Les condition pour les aides
        if (time >= 1)
        {
            time = 0;
            if (!isTable)
            {
                //On ecrit la premiere aide
                TextMeshProObject = gameObject.GetComponent<TextMeshPro>();
                TextMeshProObject.text = "Regardez attentivement la peinture, il y a des similitudes avec quelques chose d'ici?";

            }else if (!isTorch)
            {
                TextMeshProObject = gameObject.GetComponent<TextMeshPro>();
                TextMeshProObject.text = "Faites attention au poème, il pourrait vous donner un indice...";
            }
            else if (!isSkull)
            {
                TextMeshProObject = gameObject.GetComponent<TextMeshPro>();
                TextMeshProObject.text = "Regarde bien, il manque quelque chose dans le crâne.";
            }
            else if (!isChest)
            {
                TextMeshProObject = gameObject.GetComponent<TextMeshPro>();
                TextMeshProObject.text = "Regarde bien, il manque quelque chose la dernière porte.";
            }
        }
    }

    private void updateEnigmas()
    {
        isTable = table.GetComponent<Disposition>().getGoal();
        isTorch = torch.GetComponent<TorchesVR>().getGoal();
        isSkull = bullskull.GetComponent<InsertEye>();
        bool isframe1 = finalDoor.transform.GetChild(0).GetChild(0).GetComponent<FrameColor>().getGoal();
        bool isframe2 = finalDoor.transform.GetChild(0).GetChild(1).GetComponent<FrameColor>().getGoal();
        isChest = isframe1 && isframe2;
    }
}

