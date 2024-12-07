using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnigmesGrip : MonoBehaviour
{
    // Références aux contrôleurs gauche et droit
    private XRController leftController;
    private XRController rightController;

    // Le bouton de la manette à détecter (par exemple, le bouton Grip)
    public InputHelpers.Button teleportButton = InputHelpers.Button.Grip;

    // La position cible pour déplacer le joueur
    private Vector3 targetPosition = new Vector3(29.87f, 1f, 34.32f);

    private void Start()
    {
        // Recherche automatique des contrôleurs dans l'XR Origin
        leftController = FindController("LeftHand Controller");
        rightController = FindController("RightHand Controller");

        // Vérifiez si les contrôleurs ont bien été trouvés
        if (leftController == null || rightController == null)
        {
            Debug.LogWarning("Contrôleur gauche ou droit non trouvé. Assurez-vous qu'ils existent dans l'XR Origin.");
        }
    }

    private void Update()
    {
        // Vérifier si le bouton est pressé sur l'un des contrôleurs
        if (IsButtonPressed(leftController) || IsButtonPressed(rightController))
        {
            MovePlayerToSpecificPosition();
        }
    }

    // Fonction pour vérifier si le bouton est pressé
    private bool IsButtonPressed(XRController controller)
    {
        if (controller == null) return false;

        InputHelpers.IsPressed(controller.inputDevice, teleportButton, out bool isPressed);
        return isPressed;
    }

    // Fonction pour déplacer le joueur à la position cible
    void MovePlayerToSpecificPosition()
    {
        // Trouver le joueur via le tag
        GameObject joueur = GameObject.FindWithTag("Player");

        if (joueur != null)
        {
            // Déplacer le joueur à la position spécifiée
            joueur.transform.position = targetPosition;
        }
        else
        {
            Debug.LogWarning("Le joueur avec le tag 'Player' n'a pas été trouvé.");
        }
    }

    // Recherche d'un contrôleur en fonction du nom de l'objet enfant
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