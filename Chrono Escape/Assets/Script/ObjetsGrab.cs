using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjetsGrab : MonoBehaviour
{
    public EnigmeInteraction enigmeInteraction; // Référence au script EnigmeInteraction (GameManager)

    // Méthode qui sera appelée lorsque l'objet est saisi
    private void OnEnable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();


        grabInteractable.selectEntered.AddListener(OnObjectGrabbed); // Quand l'objet est pris
    }

    private void OnDisable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.RemoveListener(OnObjectGrabbed); // Retirer le listener quand l'objet est désactivé
    }

    // l'objet est saisi par le joueur
    private void OnObjectGrabbed(SelectEnterEventArgs args)
    {
        if (gameObject.name == "PremierObjet")
        {
            enigmeInteraction.OnPremierObjetPris(); // Appeler la méthode dans EnigmeInteraction
        }
        else if (gameObject.name == "DeuxiemeObjet")
        {
            enigmeInteraction.OnDeuxiemeObjetPris(); // Appeler la méthode dans EnigmeInteraction
        }
    }
}
