using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class vrdetection : MonoBehaviour
{
    public bool activVR = true;
    public GameObject sourisClavier;

    // Start is called before the first frame update
    void Start()
    {
        if(activVR == true)
        {
            var xrParametres = XRGeneralSettings.Instance;
            if (xrParametres == null)
            {
                return;
            }
            var xrManager = xrParametres.Manager;
            if (xrManager == null)
            {
                return;
            }
            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                sourisClavier.SetActive(true);
                return;
            }
            sourisClavier.SetActive(false);
        }
        else
        {
            sourisClavier.SetActive(true);
        }


    }

   
}
