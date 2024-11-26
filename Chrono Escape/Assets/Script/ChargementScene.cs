using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargementScene : MonoBehaviour
{
   
   public Animator canvas;

   public void onPress()
   {
    StartCoroutine("chargerNiveau");
   }

   IEnumerator chargerNiveau()
   {
    canvas.SetTrigger("Debut");
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(3);

    yield break;
   }
}
