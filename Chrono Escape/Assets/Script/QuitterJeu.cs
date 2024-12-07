using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuitterGame : MonoBehaviour
{
    // Cette m�thode sera appel�e lorsque le bouton Quitter sera cliqu�
    public void QuitterApplication()
    {
        // Si nous sommes dans l'�diteur, on arr�te le jeu
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Sinon, on quitte le jeu dans la version compil�e
            Application.Quit();
#endif

        // Affiche un message dans la console (uniquement en mode �dition)
        Debug.Log("Le jeu est maintenant quitt�.");
    }
}
