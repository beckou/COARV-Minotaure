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

    [SerializeField]
    private bool goal;  //Réussite de l'énigme
    public bool GetGoal() { return goal; }


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
        }
        goal = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool goalStatus = true;
        for (int i = 0; i < n; i++)
        {
            //On vérifie, pour chaque objet, s'il est proche de la position visée à la tolérance près
            accomplishments[i] = ((items[i].localPosition - objectifs[i]).magnitude < tolerance);
            if (!accomplishments[i])
            {
                goalStatus = false;
            }
        }

        goal = goalStatus;
    }


}
