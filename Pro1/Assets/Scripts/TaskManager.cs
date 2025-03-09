using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro for UI

public class TaskManager : MonoBehaviour
{
    public GameObject taskPanel; // The UI Panel for the task
    public TMP_Text taskProgressText; // Text to display trash collection progress
    public int totalTrashGoal = 10; // How many trash items need to be collected
    private int collectedTrash = 0; // Tracks collected trash count

    public TrashSpawner trashSpawner; // Reference to Trash Spawner
    public GameObject trashCan; // Reference to the Trash Can

    void Start()
    {
        taskPanel.SetActive(false); // Hide the panel initially
        UpdateTaskProgress();
    }

    void UpdateTaskProgress()
    {
        if (taskProgressText != null)
        {
            taskProgressText.text = "Trash Collected: " + collectedTrash + "/" + totalTrashGoal;
        }
        else
        {
            Debug.LogError("taskProgressText is NOT assigned in TaskManager!");
        }
    }

    public void ToggleTaskPanel()
    {
        taskPanel.SetActive(!taskPanel.activeSelf);
    }

    public void CollectTrash()
    {
        collectedTrash++;
        UpdateTaskProgress();
    }

    public void DepositTrash()
    {
        Debug.Log("Trash Deposited! Progress Updated.");
        UpdateTaskProgress();

        if (collectedTrash >= totalTrashGoal)
        {
            Debug.Log("Task Completed!");
        }
    }
}
