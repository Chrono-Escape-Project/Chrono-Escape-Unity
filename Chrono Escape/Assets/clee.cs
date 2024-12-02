using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clee : MonoBehaviour
{
    public Animator porte;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "zone clee") 
        {
            porte.Play("deplacement");
        }
    }

}
