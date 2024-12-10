using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float duration = 120f; // Durée totale du cycle en secondes
    public float minRotation = 4f; // Angle minimum de la rotation (lever de soleil)
    public float maxRotation = 120f; // Angle maximum de la rotation (coucher de soleil)

    private void Update()
    {
        // Calculer la rotation en utilisant PingPong pour osciller entre minRotation et maxRotation sur la durée spécifiée
        float rotationAngle = Mathf.PingPong(Time.time / duration, 1f) * (maxRotation - minRotation) + minRotation;

        // Appliquer la rotation uniquement sur l'axe X
        transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
    }
}
