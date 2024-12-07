using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumeeSon : MonoBehaviour
{
    // R�f�rence � l'AudioSource attach� � l'objet
    public AudioSource audioSource;

    // D�clenche le son quand un autre objet entre dans la zone de trigger
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            audioSource.Play(); // Joue le son
        }
    }
}
