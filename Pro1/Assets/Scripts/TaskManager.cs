using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro for UI

public class TaskManager : MonoBehaviour
{
    public GameObject taskPanel; // The UI Panel for the task
    public TMP_Text taskProgressText; // Text to display trash collection progress
    public TMP_Text totalPointsText; // Text to display total points
    public int totalTrashGoal = 10; // How many trash items need to be collected

    private int collectedTrash = 0; // Tracks collected trash count
    private int totalPoints = 0; // Tracks total points

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
       

        if (totalPointsText != null)
        {
            totalPointsText.text = "Points: " + totalPoints;
        }
       
    }

    public void ToggleTaskPanel()
    {
        taskPanel.SetActive(!taskPanel.activeSelf);
    }

    public void CollectTrash()
    {
        collectedTrash++;
        totalPoints += 10; // Add 10 points per trash collected
        UpdateTaskProgress();
    }

    public void DepositTrash()
    {
        
        
        if (collectedTrash >= totalTrashGoal)
        {
            Debug.Log(" Task Completed! +100 Bonus Points");
            totalPoints += 100; // Add bonus points for completion
            collectedTrash = 0; // Reset trash count
            UpdateTaskProgress();
        }
    }
}
