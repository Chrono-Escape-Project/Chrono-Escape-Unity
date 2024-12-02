using System.Collections.Generic;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<string> collectedCodes = new List<string>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CollectCode(string code)
    {
        collectedCodes.Add(code);
        Debug.Log($"Collected Codes: {string.Join(", ", collectedCodes)}");
    }

    public bool HasCode(string code)
    {
        return collectedCodes.Contains(code);
    }
}
