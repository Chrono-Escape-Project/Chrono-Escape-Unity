using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Teleportation : MonoBehaviour
{
    // Le nom de la sc�ne � charger
    public string sceneToLoad = "PL_Moderne";

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre dans la zone de t�l�portation est le joueur
        if (other.CompareTag("Joueur"))
        {
            // Charge la sc�ne
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
