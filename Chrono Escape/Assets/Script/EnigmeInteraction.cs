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
    public GameObject CanvaStatue; 

    private bool premierObjetPris = false;
    private bool deuxiemeObjetPris = false;

    private void Start()
    {
        // Initialiser les objets
        StatueObjet.SetActive(false); // StatueObjet caché au départ
        TeleportationArea.SetActive(false); // TeleportationArea cachée au départ
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
            CanvaStatue.SetActive(true);
        }
    }

    // Lorsque le joueur entre dans la zone de la statue
    private void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre dans la zone de la statue et que StatueObjet est actif
        if (other.CompareTag("Player") && StatueObjet.activeSelf)
        {
            // Afficher le CanvasStatue pendant 30 secondes
            StartCoroutine(ShowCanvasFor30Seconds());
        }

        // Si le joueur entre dans la zone de l'ascenseur et que TeleportationArea est actif
        if (other.CompareTag("Player") && TeleportationArea.activeSelf)
        {
            TeleportToNextScene();
        }
    }

    // Afficher le CanvasStatue pendant 30 secondes
    private IEnumerator ShowCanvasFor30Seconds()
    {
        CanvaStatue.SetActive(true); // Activer le CanvasStatue
        yield return new WaitForSeconds(30f); // Attendre 30 secondes
        CanvaStatue.SetActive(false); // Désactiver le CanvasStatue après 30 secondes
    }

    // Téléportation vers la prochaine scène
    private void TeleportToNextScene()
    {
        SceneManager.LoadScene("PL_Moderne"); 
    }
}