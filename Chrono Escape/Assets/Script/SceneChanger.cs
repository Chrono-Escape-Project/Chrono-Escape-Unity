using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    // Appel�e lorsqu'un objet entre dans le trigger de la zone de t�l�portation
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est dans la zone de t�l�portation. Chargement de la sc�ne...");
            TeleportToNextScene();
        }
    }

    // Fonction pour changer de sc�ne
    public void TeleportToNextScene()
    {
        // Charge la sc�ne PL_Moderne
        Debug.Log("Chargement de la sc�ne : PL_Moderne");
        SceneManager.LoadScene("PL_Moderne");
    }
}