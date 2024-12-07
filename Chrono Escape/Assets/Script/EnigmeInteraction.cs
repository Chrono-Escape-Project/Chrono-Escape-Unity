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
        StatueObjet.SetActive(false); // StatueObjet caché au départ
        TeleportationArea.SetActive(false); // TeleportationArea cachée au départ
        canvas.gameObject.SetActive(false); // Canvas caché au départ
    }

    // Appelée lorsque PremierObjet est pris
    public void OnPremierObjetPris()
    {
        premierObjetPris = true;
        CheckIfBothObjectsTaken();
    }

    // Appelée lorsque DeuxiemeObjet est pris
    public void OnDeuxiemeObjetPris()
    {
        deuxiemeObjetPris = true;
        CheckIfBothObjectsTaken();
    }

    // Vérifier si les deux objets ont été pris
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
        canvas.gameObject.SetActive(false); // Désactiver le canvas après 30 secondes
    }

    // Téléportation vers la prochaine scène
    private void TeleportToNextScene()
    {
        SceneManager.LoadScene("PL_Moderne"); 
    }
}
