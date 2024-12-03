using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class VRKeypad : MonoBehaviour
{
    public Text displayText; // Reference to the display
    private string enteredCode = ""; // Current entered code
    private string correctCode = "1234"; // The correct code

    public void ButtonPressed(string number)
    {
        enteredCode += number;
        displayText.text = enteredCode; // Update the display with the current code

        // Check if the entered code matches the correct code
        if (enteredCode.Length == correctCode.Length)
        {
            if (enteredCode == correctCode)
            {
                UnlockDoor(); // If the code is correct, unlock the door
            }
            else
            {
                // Optionally, clear the code if incorrect
                enteredCode = "";
                displayText.text = "Try Again!";
            }
        }
    }

    void UnlockDoor()
    {
        // Example: Trigger door unlocking (door opens, etc.)
        Debug.Log("Door Unlocked!");
        // You can add an animation or action here to open the door.
    }
}