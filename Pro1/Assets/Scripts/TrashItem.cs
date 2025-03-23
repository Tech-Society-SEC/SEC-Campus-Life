using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{
    private TaskManager taskManager;

    void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();

        if (taskManager == null)
        {
            Debug.LogError("TaskManager not found! Make sure it's in the scene.");
        }
        else
        {
            Debug.Log(" Trash item spawned successfully: " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trash Collected: " + gameObject.name);
            taskManager.CollectTrash();  // Ensure TaskManager exists before calling
            Destroy(gameObject);
        }
    }
}
