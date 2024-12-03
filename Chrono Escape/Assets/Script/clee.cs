using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clee : MonoBehaviour
{
    public Animator porte;
    public GameObject light;
    public Color couleurBleu;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "zone clee") 
        {
            porte.Play("deplacement");
            light.GetComponent<Renderer>().material.SetVector("_EmissiveColor", couleurBleu * 2.0f);
        }
    }

}
