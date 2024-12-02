using System.Diagnostics;

public class Ticket : MonoBehaviour
{
    public string code;

    public void Collect()
    {
        Debug.Log($"Ticket Collected: {code}");
        // Logic to store the code (e.g., in a global list or inventory)
        GameManager.Instance.CollectCode(code);
        Destroy(gameObject); // Remove the ticket
    }
}
