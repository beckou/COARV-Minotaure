using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Indique si les objets enfants (les nb premiers) sont bien placés par rapport à l'objet qui porte ce script

public class Disposition : MonoBehaviour
{
    public int nbItems;  //Nombre de bibelots à considérer pour le puzzle
    public List<Vector3> objectifs;   //Positions à atteindre
    public float tolerance;  //Marge d'erreur pour le placement des objets

    private int n;  //Nombre d'items effectivement considérés

    private List<Transform> items = new List<Transform>();  //Liste des transforms des enfants de la table
    private List<bool> accomplishments = new List<bool>();  //Indique, pour chaque item, si l'objectif est atteint
    private List<bool> itemSelected = new List<bool>(); //Indique quel item est sélectionné
    [SerializeField]
    private bool goal;  //Réussite de l'énigme
    public bool getGoal(){return goal;}

    // Start is called before the first frame update

    void Start()
    {
        n = Mathf.Min(nbItems, this.gameObject.transform.childCount);
        for (int i = 0; i < n; i++)
        {
            //Remplissage de la liste des enfants de la table
            Transform tr = this.gameObject.transform.GetChild(i);
            items.Add(tr);
            accomplishments.Add(false);
            itemSelected.Add(false);
        }
        objectifs.Add(new Vector3(6.9f,1.1f,6.7f));
        objectifs.Add(new Vector3(6.7f, 1.1f, 6.1f));
        objectifs.Add(new Vector3(7.0f, 1.1f, 6.4f));
        objectifs.Add(new Vector3(7.0f, 1.1f, 6.0f));
        goal = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool goalStatus = true;
        for (int i = 0; i < n; i++)
        {
            //On vérifie, pour chaque objet, s'il est proche de la position visée à la tolérance près
            accomplishments[i] = (Vector3.Distance(items[i].localPosition,objectifs[i]) < tolerance);
            if (!accomplishments[i])
            {
                goalStatus = false;
            }
        }

        goal = goalStatus;

        if(!goal){
            MoveObjectsOnTable();
        }
    }


    void MoveObjectsOnTable(){
        if(Input.GetMouseButton(0)){
            bool itemAlreadySelected = false;
            //On détermine si un objet est déjà sélectionné ou non
            for(int i = 0; i < n; i++){
                itemAlreadySelected = itemAlreadySelected || itemSelected[i];
            }


            for(int i = 0; i < n; i++){
                //Si le raycast renvoie un objet et qu'aucun autre n'est sélectionné alors on sélectionne cet item
                if (RayTracing.GetObject(items[i].gameObject.tag) != null && !itemAlreadySelected)
                {
                    itemSelected[i] = true;
                }
            }
        }else{
            //Lorsque la souris est relachée on déselectionne tous les objets
            for (int i = 0; i < n; i++)
            {
                itemSelected[i] = false;
            }
        }


        Vector3 newPosition = RayTracing.GetHitPosition("table");

        if(Vector3.Distance(newPosition, new Vector3(0,0,0)) != 0){
            //On est bien sur la table
            for (int i = 0; i < n; i++)
            {
                if (itemSelected[i])
                {
                    Debug.Log("hey");
                    items[i].position = newPosition;
                }
            }
        }
    }
}
