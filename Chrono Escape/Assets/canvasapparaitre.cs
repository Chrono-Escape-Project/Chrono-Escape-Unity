using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    public GameObject canvasok;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "zone clee vert")
        {
            StartCoroutine(DelayActivation());
        }
    }

    private IEnumerator DelayActivation()
    {
        yield return new WaitForSeconds(7f); 
        canvasok.SetActive(true); 
    }
}
