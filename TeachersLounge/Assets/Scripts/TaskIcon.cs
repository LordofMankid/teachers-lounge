using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskIcon : MonoBehaviour
{
    private TaskManager.Task associatedTask;
    private bool available;
    private int len;
    private TaskManager taskManager;

    public void SetTask(TaskManager.Task task)
    {
        associatedTask = task;
        available = true;
        len = associatedTask.cost.Count;
    }

    public TaskManager.Task GetTask()
    {
        return associatedTask;
    }

    public void completeTask(GameObject toBeDestroyed)
    {    
        for(int i = 0; i < len; i++){
            if(FindAnyObjectByType<GameInventory>().InventoryRemove(associatedTask.cost[i]) == false){
                available = false;
            }
        }
        if(available == true){
            FindAnyObjectByType<GameHandler>().AddPoints(associatedTask.points);
            Destroy(toBeDestroyed);
            FindObjectOfType<TaskManager>().CompleteAndGenerateNewTask();
            // taskManager.GenerateRandomTask();
        }
    }
}