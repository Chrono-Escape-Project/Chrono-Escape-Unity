using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Teleportation : MonoBehaviour
{
    // Le nom de la scène à charger
    public string sceneToLoad = "PL_Moderne";

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre dans la zone de téléportation est le joueur
        if (other.CompareTag("Joueur"))
        {
            // Charge la scène
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
