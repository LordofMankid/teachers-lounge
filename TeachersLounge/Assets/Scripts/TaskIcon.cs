using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskIcon : MonoBehaviour
{
    private TaskManager.Task associatedTask;

    public void SetTask(TaskManager.Task task)
    {
        associatedTask = task;
    }

    public TaskManager.Task GetTask()
    {
        return associatedTask;
    }

    public void completeTask(GameObject toBeDestroyed)
    {
        if(FindAnyObjectByType<GameInventory>().InventoryRemove(associatedTask.cost) == true)
        {
            FindAnyObjectByType<GameHandler>().AddPoints(associatedTask.points);
            Destroy(toBeDestroyed);
        }



    }
}