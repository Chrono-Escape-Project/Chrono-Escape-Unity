using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumeeSon : MonoBehaviour
{
    public AudioSource audioSource; // Reference AudioSource
    public string playerTag = "Player"; // le joueur

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Play the sound
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
