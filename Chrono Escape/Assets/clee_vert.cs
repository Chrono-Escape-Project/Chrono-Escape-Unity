using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class clee_vert : MonoBehaviour
{
    public Animator liquid1;
    public Animator liquid2;
    public Animator liquid3;
    public Animator liquid4;
    public Animator liquid5;
    public Animator liquid6;
    public AudioSource sonBizz;
 
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "zone clee vert")
        {
            liquid1.Play("liquid1");
            liquid2.Play("liquid2");
            liquid3.Play("liquid3");
            liquid4.Play("liquid4");
            liquid5.Play("liquid5");
            liquid6.Play("liquid6");
            sonBizz.Play();    
        }
    }
}





