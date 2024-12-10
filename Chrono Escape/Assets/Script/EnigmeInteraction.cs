using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnigmeInteraction : MonoBehaviour
{
    public GameObject premierObjet;        // Premier objet � r�cup�rer
    public GameObject deuxiemeObjet;       // Deuxi�me objet � r�cup�rer
    public GameObject StatueObjet;         // Objet Statue (qui d�clenche le Canvas)
    public GameObject TeleportationArea;   // Zone de t�l�portation
    public GameObject CanvaStatue;         // Canvas � afficher

    private bool premierObjetPris = false;
    private bool deuxiemeObjetPris = false;

    // Fonction Start pour initialiser les objets
    private void Start()
    {
        StatueObjet.SetActive(false);        // Statue cach�e au d�part
        TeleportationArea.SetActive(false);  // Zone de t�l�portation cach�e
        CanvaStatue.SetActive(false);        // Canvas cach� au d�part
    }

    // Appel�e lorsque le premier objet est pris
    public void OnPremierObjetPris()
    {
        premierObjetPris = true;
        Debug.Log("PremierObjet pris : " + premierObjetPris);
        CheckIfBothObjectsTaken();
    }

    // Appel�e lorsque le deuxi�me objet est pris
    public void OnDeuxiemeObjetPris()
    {
        deuxiemeObjetPris = true;
        Debug.Log("DeuxiemeObjet pris : " + deuxiemeObjetPris);
        CheckIfBothObjectsTaken();
    }

    // V�rifie si les deux objets ont �t� pris et active la statue et la zone de t�l�portation
    private void CheckIfBothObjectsTaken()
    {
        if (premierObjetPris && deuxiemeObjetPris)
        {
            StatueObjet.SetActive(true);       // Active la statue
            TeleportationArea.SetActive(true); // Active la zone de t�l�portation
            CanvaStatue.SetActive(true);       // Active le CanvasStatue
            Debug.Log("Les deux objets sont pris, StatueObjet, TeleportationArea, et CanvaStatue activ�s");
        }
        else
        {
            Debug.Log("Les deux objets ne sont pas encore pris. StatueObjet et autres objets non activ�s.");
        }
    }

    // Lorsque le joueur entre dans la zone de la statue
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la StatueObjet est activ�e, on affiche le CanvasStatue pendant 30 secondes
            if (StatueObjet.activeSelf)
            {
                Debug.Log("StatueObjet est actif, affichage du CanvasStatue pour 30 secondes.");
                StartCoroutine(ShowCanvasFor30Seconds());
            }

            // Si la zone de t�l�portation est active, on change la sc�ne
            if (TeleportationArea.activeSelf)
            {
                Debug.Log("TeleportationArea is active. Changing scene...");
                SceneChanger sceneChanger = FindObjectOfType<SceneChanger>();
                if (sceneChanger != null)
                {
                    sceneChanger.TeleportToNextScene(); // Appel de la m�thode pour changer de sc�ne
                }
            }
        }
    }

    // Afficher le CanvasStatue pendant 30 secondes
    private IEnumerator ShowCanvasFor30Seconds()
    {
        CanvaStatue.SetActive(true); // Activer le CanvasStatue
        yield return new WaitForSeconds(30f); // Attendre 30 secondes
        CanvaStatue.SetActive(false); // D�sactiver le CanvasStatue apr�s 30 secondes
    }
}