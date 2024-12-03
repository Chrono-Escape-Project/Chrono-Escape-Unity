using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceManager : MonoBehaviour
{
    public GameObject indice1;
    public GameObject indice2;
    public GameObject indice3;

    private int objetsRamasses = 0;

    public void RamasserObjet(GameObject objet)
    {
        if (objet == indice1 || objet == indice2)
        {
            objetsRamasses++;

            // D�sactiver l'objet ramass�
            objet.SetActive(false);

            // Activer l'indice 3 si les deux objets sont ramass�s
            if (objetsRamasses == 2)
            {
                indice3.SetActive(true);
            }
        }
    }
}
