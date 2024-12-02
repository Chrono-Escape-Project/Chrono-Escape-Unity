using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Ensure the audio doesn't play automatically
        audioSource.playOnAwake = false;
    }

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player") && !hasPlayed)
    {
        audioSource.Play();
        hasPlayed = true;
    }
}

}