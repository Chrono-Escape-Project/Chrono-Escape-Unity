using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumeeSon : MonoBehaviour
{
    // Référence à l'AudioSource attaché à l'objet
    public AudioSource audioSource;

    // Déclenche le son quand un autre objet entre dans la zone de trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            audioSource.Play(); // Joue le son
        }
    }
}
