using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjetsGrab : MonoBehaviour
{
    public EnigmeInteraction enigmeInteraction; // R�f�rence au script EnigmeInteraction (GameManager)

    // M�thode qui sera appel�e lorsque l'objet est saisi
    private void OnEnable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();


        grabInteractable.selectEntered.AddListener(OnObjectGrabbed); // Quand l'objet est pris
    }

    private void OnDisable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.RemoveListener(OnObjectGrabbed); // Retirer le listener quand l'objet est d�sactiv�
    }

    // l'objet est saisi par le joueur
    private void OnObjectGrabbed(SelectEnterEventArgs args)
    {
        if (gameObject.name == "PremierObjet")
        {
            enigmeInteraction.OnPremierObjetPris(); // Appeler la m�thode dans EnigmeInteraction
        }
        else if (gameObject.name == "DeuxiemeObjet")
        {
            enigmeInteraction.OnDeuxiemeObjetPris(); // Appeler la m�thode dans EnigmeInteraction
        }
    }
}
