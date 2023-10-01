using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<Task> potentialTasks = new List<Task>();
    public float taskGenerationInterval = 30.0f; // Time between generating tasks in seconds
    public float taskDuration = 60.0f; // Time a task remains on the screen in seconds

    private float timeSinceLastTask = 0.0f;
    private List<Task> activeTasks = new List<Task>(); // Store active tasks

        public class Task {
        public string description;
        public string taskDetail;
        public int points;
        // public float timeRemaining;

        public Task(string desc, string detail, int pts) {
            description = desc;
            taskDetail = detail;
            points = pts;
            // timeRemaining = taskDuration;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add tasks to the list ***LATER ADD WHICH RESOURCES
        potentialTasks.Add(new Task("Grading", "Grade assignments in classroom", 10));
        potentialTasks.Add(new Task("Lesson Planning", "Plan the next lesson", 15));
        potentialTasks.Add(new Task("Management", "Handle administrative tasks", 20));

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTask += Time.deltaTime;

        // Check if it's time to generate a new task
        if (timeSinceLastTask >= taskGenerationInterval) {
            GenerateRandomTask();
            timeSinceLastTask = 0.0f;
        }

        // // Check if it's time to remove tasks
        // for (int i = activeTasks.Count - 1; i >= 0; i--) {
        //     Task curr_task = activeTasks[i];
        //     // curr_task.timeRemaining -= Time.deltaTime;
        //     if (curr_task.timeRemaining <= 0) {
        //         RemoveTask(curr_task);
        //         activeTasks.RemoveAt(i);
        //     }
        // }
    }

    private void GenerateRandomTask() {
        // Randomly select a task from the potentialTasks list
        if (potentialTasks.Count > 0) {
            int randomIndex = Random.Range(0, potentialTasks.Count);
            Task randomTask = potentialTasks[randomIndex];
            // randomTask.timeRemaining = 60.0f; // Set the initial timeRemaining *** FIX THIS
            Debug.Log("New task: " + randomTask.description); // ADD MORE INFO WHEN TASKS POP UP
            activeTasks.Add(randomTask); // Add the task to the active tasks list

            // Set timer for removing tasks
            StartCoroutine(RemoveTaskAfterDelay(randomTask));
        }
    }

    // private void RemoveTask(Task task) {
    //     // Remove task
    //     Debug.Log("Task removed: " + task.description); // DIFFERENTIATE BETWEEN COMPLETING AND LOSING TASKS
    // }

    private IEnumerator RemoveTaskAfterDelay(Task task) {
        yield return new WaitForSeconds(taskDuration);

        // Remove the task
        Debug.Log("Task removed: " + task.description);
    }
}