using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ElevatorTransition : MonoBehaviour
{
    // The name of the scene to load
    public string sceneToLoad;

    // Called when the elevator is selected
    public void OnElevatorActivated()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            UnityEngine.Debug.Log("Scene name not set on Elevator prefab!");
        }
    }
}
