using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_declanche : MonoBehaviour
{
    public AudioSource sonBizz;
    public AudioClip sonBizzClip;
 
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "zone clee vert")
        {
            sonBizz.PlayOneShot(sonBizzClip);
        }
    }
}
