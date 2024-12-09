using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float rotationSpeed = 3f; // Vitesse de la rotation (degrés par seconde)

    private void Update()
    {
        // Calculer la rotation autour de l'axe X en fonction du temps
        float rotationAngle = rotationSpeed * Time.time;

        // Appliquer la rotation sur l'axe X uniquement
        transform.rotation = Quaternion.Euler(rotationAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}