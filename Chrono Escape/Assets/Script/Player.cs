using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource audioSource; // Drag and drop the Audio Source component here
    public string targetZoneName = "Tunnel"; // Name of the collider zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == targetZoneName) // Check if the player entered the "Tunnel" zone
        {
            if (!audioSource.isPlaying) // Avoid restarting the sound if it's already playing
            {
                audioSource.Play();
                Debug.Log("Sound played in the Tunnel zone.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == targetZoneName) // Check if the player exited the "Tunnel" zone
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                Debug.Log("Sound stopped after leaving the Tunnel zone.");
            }
        }
    }
}