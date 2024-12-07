using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnigmesGrip : MonoBehaviour
{
    // R�f�rences aux contr�leurs gauche et droit
    private XRController leftController;
    private XRController rightController;

    // Le bouton de la manette � d�tecter (par exemple, le bouton Grip)
    public InputHelpers.Button teleportButton = InputHelpers.Button.Grip;

    // La position cible pour d�placer le joueur
    private Vector3 targetPosition = new Vector3(29.87f, 1f, 34.32f);

    private void Start()
    {
        // Recherche automatique des contr�leurs dans l'XR Origin
        leftController = FindController("LeftHand Controller");
        rightController = FindController("RightHand Controller");

        // V�rifiez si les contr�leurs ont bien �t� trouv�s
        if (leftController == null || rightController == null)
        {
            Debug.LogWarning("Contr�leur gauche ou droit non trouv�. Assurez-vous qu'ils existent dans l'XR Origin.");
        }
    }

    private void Update()
    {
        // V�rifier si le bouton est press� sur l'un des contr�leurs
        if (IsButtonPressed(leftController) || IsButtonPressed(rightController))
        {
            MovePlayerToSpecificPosition();
        }
    }

    // Fonction pour v�rifier si le bouton est press�
    private bool IsButtonPressed(XRController controller)
    {
        if (controller == null) return false;

        InputHelpers.IsPressed(controller.inputDevice, teleportButton, out bool isPressed);
        return isPressed;
    }

    // Fonction pour d�placer le joueur � la position cible
    void MovePlayerToSpecificPosition()
    {
        // Trouver le joueur via le tag
        GameObject joueur = GameObject.FindWithTag("Player");

        if (joueur != null)
        {
            // D�placer le joueur � la position sp�cifi�e
            joueur.transform.position = targetPosition;
        }
        else
        {
            Debug.LogWarning("Le joueur avec le tag 'Player' n'a pas �t� trouv�.");
        }
    }

    // Recherche d'un contr�leur en fonction du nom de l'objet enfant
    private XRController FindController(string controllerName)
    {
        Transform controllerTransform = transform.Find(controllerName);
        if (controllerTransform != null)
        {
            return controllerTransform.GetComponent<XRController>();
        }
        return null;
    }
}