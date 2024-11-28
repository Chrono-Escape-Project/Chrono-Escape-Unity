using UnityEngine;

public class loopSound : MonoBehaviour
{
    public AudioSource Audio;

    void Start()
    {
        if (Audio != null)
        {
            Audio.loop = true; // Ensure the sound loops
            Audio.Play(); // Start playing the sound
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned!");
        }
    }
}
