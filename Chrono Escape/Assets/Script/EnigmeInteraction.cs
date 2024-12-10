using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnigmeInteraction : MonoBehaviour
{
    public GameObject premierObjet;        // Premier objet à récupérer
    public GameObject deuxiemeObjet;       // Deuxième objet à récupérer
    public GameObject StatueObjet;         // Objet Statue (qui déclenche le Canvas)
    public GameObject TeleportationArea;   // Zone de téléportation
    public GameObject CanvaStatue;         // Canvas à afficher

    private bool premierObjetPris = false;
    private bool deuxiemeObjetPris = false;

    // Fonction Start pour initialiser les objets
    private void Start()
    {
        StatueObjet.SetActive(false);        // Statue cachée au départ
        TeleportationArea.SetActive(false);  // Zone de téléportation cachée
        CanvaStatue.SetActive(false);        // Canvas caché au départ
    }

    // Appelée lorsque le premier objet est pris
    public void OnPremierObjetPris()
    {
        premierObjetPris = true;
        Debug.Log("PremierObjet pris : " + premierObjetPris);
        CheckIfBothObjectsTaken();
    }

    // Appelée lorsque le deuxième objet est pris
    public void OnDeuxiemeObjetPris()
    {
        deuxiemeObjetPris = true;
        Debug.Log("DeuxiemeObjet pris : " + deuxiemeObjetPris);
        CheckIfBothObjectsTaken();
    }

    // Vérifie si les deux objets ont été pris et active la statue et la zone de téléportation
    private void CheckIfBothObjectsTaken()
    {
        if (premierObjetPris && deuxiemeObjetPris)
        {
            StatueObjet.SetActive(true);       // Active la statue
            TeleportationArea.SetActive(true); // Active la zone de téléportation
            CanvaStatue.SetActive(true);       // Active le CanvasStatue
            Debug.Log("Les deux objets sont pris, StatueObjet, TeleportationArea, et CanvaStatue activés");
        }
        else
        {
            Debug.Log("Les deux objets ne sont pas encore pris. StatueObjet et autres objets non activés.");
        }
    }

    // Lorsque le joueur entre dans la zone de la statue
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la StatueObjet est activée, on affiche le CanvasStatue pendant 30 secondes
            if (StatueObjet.activeSelf)
            {
                Debug.Log("StatueObjet est actif, affichage du CanvasStatue pour 30 secondes.");
                StartCoroutine(ShowCanvasFor30Seconds());
            }

            // Si la zone de téléportation est active, on change la scène
            if (TeleportationArea.activeSelf)
            {
                Debug.Log("TeleportationArea is active. Changing scene...");
                SceneChanger sceneChanger = FindObjectOfType<SceneChanger>();
                if (sceneChanger != null)
                {
                    sceneChanger.TeleportToNextScene(); // Appel de la méthode pour changer de scène
                }
            }
        }
    }

    // Afficher le CanvasStatue pendant 30 secondes
    private IEnumerator ShowCanvasFor30Seconds()
    {
        CanvaStatue.SetActive(true); // Activer le CanvasStatue
        yield return new WaitForSeconds(30f); // Attendre 30 secondes
        CanvaStatue.SetActive(false); // Désactiver le CanvasStatue après 30 secondes
    }
}