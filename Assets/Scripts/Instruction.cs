using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instruction : MonoBehaviour
{
    public GameObject table;
    public GameObject torch;
    public GameObject diamondEye;

    TextMeshPro TextMeshProObject;

    private bool isTable = false;
    private bool isTorch = false;
    private bool isSkull = false;
    private bool lastEni = false;
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
        updateEnigmas();
        //Prendre le temps
        time += Time.deltaTime;
        //Le temps est en secondes...
        //Les condition pour les aides
        if (time >= 5)
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
            else if (!lastEni)
            {
                TextMeshProObject = gameObject.GetComponent<TextMeshPro>();
                TextMeshProObject.text = "Regarde bien, il manque quelque chose dans le crâne.";
            }
        }
    }

    private void updateEnigmas()
    {
        //Comme je sais que l'enigme est fait?
        isTable = table.GetComponent<Disposition>().getGoal();
        isTorch = torch.GetComponent<TorchInteraction>().getGoal();
        //isSkull = diamondEye.GetComponent<MissingReferenceException>();
    }
}

