using UnityEngine;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    public TextMeshProUGUI uiTextName; 
    private SaveManager saveManager;
    void Awake()
    {
        saveManager = FindFirstObjectByType<SaveManager>();
    }

    void Start()
    {
        saveManager.FileLoaded += OnLoad; 
    }

    public void OnLoad(SaveSetup setup)
    {
        uiTextName.text = "Play" + (setup.lastLevel + 1);
    }

    void OnDestroy()
    {
        saveManager.FileLoaded -= OnLoad;
    }
}
