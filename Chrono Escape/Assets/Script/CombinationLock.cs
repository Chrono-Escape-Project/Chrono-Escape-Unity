using System.Diagnostics;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    public string requiredCode; // Code to unlock
    private string enteredCode = "";

    public void EnterDigit(string digit)
    {
        enteredCode += digit;
        UnityEngine.Debug.Log($"Entered Code: {enteredCode}");

        if (enteredCode.Length >= requiredCode.Length)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (enteredCode == requiredCode)
        {
            UnityEngine.Debug.Log("Correct Code! Unlocking...");
            UnlockNextLevel();
        }
        else
        {
            UnityEngine.Debug.Log("Incorrect Code. Try Again.");
            enteredCode = ""; // Reset input
        }
    }

    private void UnlockNextLevel()
    {
        UnityEngine.Debug.Log("Loading Next Level...");
    }
}
