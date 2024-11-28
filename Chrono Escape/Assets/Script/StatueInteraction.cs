using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatueInteraction : MonoBehaviour
{
    public GameObject questionUI; // UI element for the question
    public TextMeshProUGUI questionText; // The text component for the question
    public string question = "Insert Question here";
    public string correctAnswer = "test";
    public GameObject reward; // Optional: Reward to appear after answering

    private bool playerIsNear = false;

    void Update()
    {
        // Check for player input
        if (playerIsNear && Input.GetButtonDown("Interact")) // Replace "Interact" with your VR input
        {
            ShowQuestion();
        }
    }

    private void ShowQuestion()
    {
        questionUI.SetActive(true);
        questionText.text = question;
    }

    public void CheckAnswer(string playerAnswer)
    {
        if (playerAnswer.Trim().Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Correct Answer!");
            questionUI.SetActive(false);
            if (reward) reward.SetActive(true); // Show the reward if applicable
        }
        else
        {
            Debug.Log("Mauvaise Réponse, essaie encore.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            questionUI.SetActive(false);
        }
    }
}