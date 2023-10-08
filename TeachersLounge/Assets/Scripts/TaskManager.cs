using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject taskIconPrefab;
    public Text taskDescriptionText;
    public List<Task> potentialTasks = new List<Task>();
    public float taskGenerationInterval = 5.0f; // Time between generating tasks in seconds
    public float taskDuration = 3.0f; // Time a task remains on the screen in seconds

    private float timeSinceLastTask = 0.0f;
    private List<Task> activeTasks = new List<Task>(); // Store active tasks

        public class Task {
        public string description;
        public string taskDetail;
        public int points;
        public string cost;
        // public float timeRemaining;

        public Task(string desc, string detail, int pts, string taskCost) {
            description = desc;
            taskDetail = detail;
            points = pts;
            cost = taskCost;
            // timeRemaining = taskDuration;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add tasks to the list ***LATER ADD WHICH RESOURCES
        potentialTasks.Add(new Task("Grading", "Grade assignments in classroom", 10, "Paper"));
        potentialTasks.Add(new Task("Update Software", "Update software in the computer lab", 15, "Computer"));
        potentialTasks.Add(new Task("Lesson Planning", "Plan the next lesson in the library", 20, "Book"));
        potentialTasks.Add(new Task("Handle an Injury", "Grab a first-aid kit from the nurse's office", 20, "First Aid Kit"));

        GenerateRandomTask();

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



private void GenerateRandomTask()
{
    // Check if potentialTasks is not empty
    if (potentialTasks.Count > 0)
    {
        int randomIndex = Random.Range(0, potentialTasks.Count);
        Task randomTask = potentialTasks[randomIndex];

        // Enable the task icon GameObject before instantiating
        taskIconPrefab.SetActive(true);

        // Instantiate the task icon prefab at the task position
        Vector2 taskPosition = GetTaskPositionForTask(randomTask);
        GameObject newTask = Instantiate(taskIconPrefab, taskPosition, Quaternion.identity);
            newTask.GetComponent<TaskIcon>().SetTask(randomTask);
        // Find the Task Description Text GameObject by tag
        GameObject taskDescriptionTextObject = GameObject.FindGameObjectWithTag("TaskDescriptionText");

        // Check if the GameObject is found
        if (taskDescriptionTextObject != null)
        {
            // Get the Text component from the found GameObject
            Text taskDescriptionText = taskDescriptionTextObject.GetComponent<Text>();

            // Update the text component
            taskDescriptionText.text = "Task: " + randomTask.description + "\nDetails: " + randomTask.taskDetail;
        }
        else
        {
            Debug.LogError("TaskDescriptionText GameObject not found or not tagged!");
        }

        // Set timer for removing tasks
        StartCoroutine(RemoveTaskAfterDelay(randomTask, newTask));
    }
    else
    {
        Debug.LogError("potentialTasks is empty! Add tasks to the list.");
    }
}


    // private void RemoveTask(Task task) {
    //     // Remove task
    //     Debug.Log("Task removed: " + task.description); // DIFFERENTIATE BETWEEN COMPLETING AND LOSING TASKS
    // }

    private IEnumerator RemoveTaskAfterDelay(Task task, GameObject toBeRemoved) {
        yield return new WaitForSeconds(taskDuration);

        // Remove the task
        Debug.Log("Task removed: " + task.description);
        Destroy(toBeRemoved);
    }


    // Define a method to get the position associated with a task
    private Vector2 GetTaskPositionForTask(Task task)
    {
        // You can implement a logic here to return the position based on the task.
        // For example, you can use a dictionary to map tasks to positions.
        // Here's a simplified example assuming you have predefined positions:

        if (task.description == "Grading")
        {
            return new Vector2(14f, 7f); // Example position for "Grading" task
        }
        else if (task.description == "Update Software")
        {
            return new Vector2(-14f, 7f); // Example position for "Update Software" task
        }
        else if (task.description == "Handle an Injury")
        {
            return new Vector2(14f, -3f);
        }
        else if (task.description == "Lesson Planning")
        {
            return new Vector2(-14f, -3f);
        }
        // Add more conditions for other tasks

        // Default position if no match is found
        return Vector2.zero;
    }

    
}