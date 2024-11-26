using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargementScene : MonoBehaviour
{
   
   public Animator canvas;
   public int telScene;

   public void onPress(int i)
   {
    telScene = i;
    StartCoroutine("chargerNiveau");
   }

   IEnumerator chargerNiveau()
   {
    canvas.SetTrigger("Debut");
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(telScene);

    yield break;
   }
}
