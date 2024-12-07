using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnigmeInteraction : MonoBehaviour
{
    public GameObject premierObjet;
    public GameObject deuxiemeObjet;

    public GameObject StatueObjet;
    public GameObject TeleportationArea;
    public Canvas canvas;

    private bool premierObjetPris = false;
    private bool deuxiemeObjetPris = false;

    private void Start()
    {
        // Initialiser les objets
        StatueObjet.SetActive(false); // StatueObjet cach� au d�part
        TeleportationArea.SetActive(false); // TeleportationArea cach�e au d�part
        canvas.gameObject.SetActive(false); // Canvas cach� au d�part
    }

    // Appel�e lorsque PremierObjet est pris
    public void OnPremierObjetPris()
    {
        premierObjetPris = true;
        CheckIfBothObjectsTaken();
    }

    // Appel�e lorsque DeuxiemeObjet est pris
    public void OnDeuxiemeObjetPris()
    {
        deuxiemeObjetPris = true;
        CheckIfBothObjectsTaken();
    }

    // V�rifier si les deux objets ont �t� pris
    private void CheckIfBothObjectsTaken()
    {
        if (premierObjetPris && deuxiemeObjetPris)
        {
            // Activer StatueObjet et TeleportationArea
            StatueObjet.SetActive(true);
            TeleportationArea.SetActive(true);
        }
    }

    // Lorsque le joueur entre dans la zone de la statue
    private void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre dans la zone de la statue
        if (other.CompareTag("Player") && StatueObjet.activeSelf)
        {
            // Afficher le Canvas pendant 30 secondes
            StartCoroutine(ShowCanvasFor30Seconds());
        }

        // Si le joueur entre dans la zone de l'ascenseur
        if (other.CompareTag("Player") && TeleportationArea.activeSelf)
        {
            TeleportToNextScene();
        }
    }

    // Afficher le canvas pendant 30 secondes
    private IEnumerator ShowCanvasFor30Seconds()
    {
        canvas.gameObject.SetActive(true);
        Text canvasText = canvas.GetComponentInChildren<Text>();
        canvasText.text = "Dirigez-vous vers l'ascenseur pour continuer...";

        yield return new WaitForSeconds(30f); // Attendre 30 secondes
        canvas.gameObject.SetActive(false); // D�sactiver le canvas apr�s 30 secondes
    }

    // T�l�portation vers la prochaine sc�ne
    private void TeleportToNextScene()
    {
        SceneManager.LoadScene("PL_Moderne"); 
    }
}
