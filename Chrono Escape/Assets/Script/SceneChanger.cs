using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    // Appelée lorsqu'un objet entre dans le trigger de la zone de téléportation
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est dans la zone de téléportation. Chargement de la scène...");
            TeleportToNextScene();
        }
    }

    // Fonction pour changer de scène
    public void TeleportToNextScene()
    {
        // Charge la scène PL_Moderne
        Debug.Log("Chargement de la scène : PL_Moderne");
        SceneManager.LoadScene("PL_Moderne");
    }
}