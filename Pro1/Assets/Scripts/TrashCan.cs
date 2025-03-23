using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour  
{
    public static TrashCan instance;
    public GameObject taskPanel;  // Reference to Task Panel


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (taskPanel != null)
            taskPanel.SetActive(false); // Hide panel initially
    }

    public void ToggleTaskPanel()
    {
        if (taskPanel != null)
        {
            taskPanel.SetActive(!taskPanel.activeSelf); // Toggle visibility
        }
    }
}
