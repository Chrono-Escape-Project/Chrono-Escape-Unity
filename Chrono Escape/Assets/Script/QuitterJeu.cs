using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuitterGame : MonoBehaviour
{
    // Cette méthode sera appelée lorsque le bouton Quitter sera cliqué
    public void QuitterApplication()
    {
        // Si nous sommes dans l'éditeur, on arrête le jeu
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Sinon, on quitte le jeu dans la version compilée
            Application.Quit();
#endif

        // Affiche un message dans la console (uniquement en mode édition)
        Debug.Log("Le jeu est maintenant quitté.");
    }
}
