using System.Diagnostics;
using UnityEngine;  // This is required to use MonoBehaviour

public class Ticket : MonoBehaviour
{
    public string code;

    public void Collect()
    {
        UnityEngine.Debug.Log($"Ticket Collected: {code}");
        // Logic to store the code (e.g., in a global list or inventory)
        GameManager.Instance.CollectCode(code);
        Destroy(gameObject); // Remove the ticket
    }
}
