using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigmeManager : MonoBehaviour
{
    public GameObject table; // pour avoir référence au script énigme Disposition
    public GameObject torch; // pour avoir référence au script énigme TorchInteraction
    public GameObject skull; // pour avoir référence au script énigme TorchInteraction

    public GameObject doorStatue; // pour pouvoir l'ouvrir
    public GameObject wallSkull; // pour pouvoir le détruire

    private bool isTable = false; //enigme de la table
    private bool isTorch = false; //énigme lumières
    private bool isSkull = false; //énigme crâne

    void Update()
    {
        updateEnigmas();
        if (isTable && doorStatue.activeSelf){
            // énigme de la table réussie on ouvre la porte de la statue
            // destruction du mur (je ne sais pas faire donc je le désactive juste)
            doorStatue.SetActive(false);
            Debug.Log("énigme de la table réussie");
        }
        if (isTorch && wallSkull.activeSelf){
            // énigme des statues réussie, on détruit wallSkull
            wallSkull.SetActive(false);
            Debug.Log("énigme des torches réussie");
        }
        if (isTable && isTorch && isSkull){
            // les trois énigmes ont été réussies !
            // on ouvre la porte finale
            Debug.Log("énigme du crâne réussie");
            Debug.Log("niveau 1 fini")
        }
    }

    private void updateEnigmas(){
        isTable = table.GetComponent<Disposition>().getGoal();
        isTorch = torch.GetComponent<TorchInteraction>().getGoal();
        isTorch = skull.GetComponent<MissingEye>().getGoal();
    }
}
