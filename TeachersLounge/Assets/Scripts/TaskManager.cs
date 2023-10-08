using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject taskIconPrefab;
    public Text taskDescriptionText;
    public List<Task> potentialTasks = new List<Task>();
    public float initialTaskGenerationInterval = 4.0f; // Initial time between generating tasks in seconds
    public float initialTaskRemovalInterval = 10.0f; // Initial time between removing tasks in seconds
    public float timePressureStartDelay = 60.0f; // Time to start applying time pressure (1 minute)
    public float timePressureTaskGenerationInterval = 2.0f; // Time between generating tasks under time pressure
    public float timePressureTaskRemovalInterval = 6.0f; // Time between removing tasks under time pressure

    private List<Task> activeTasks = new List<Task>(); // Store active tasks
    private bool isUnderTimePressure = false;
    private float elapsedTime = 0.0f;

    public class Task
    {
        public string description;
        public string locationName;
        public string cost;
        public int points;

        public Task(string desc, string locName, string taskCost, int pts)
        {
            description = desc;
            locationName = locName;
            cost = taskCost;
            points = pts;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add tasks to the list
        potentialTasks.Add(new Task("Grading", "Classroom", "Paper", 10));
        potentialTasks.Add(new Task("Update Software", "Computer Lab", "Computer", 15));
        potentialTasks.Add(new Task("Lesson Planning", "Library", "Book", 20));
        potentialTasks.Add(new Task("Handle an Injury", "Nurse's Office", "First Aid Kit", 20));
        potentialTasks.Add(new Task("Print Worksheets", "Library", "Paper", 20));
        potentialTasks.Add(new Task("Teach a Class", "Classroom", "Laptop", 20));

        // Start generating tasks
        StartCoroutine(GenerateRandomTasks());
    }

    // Coroutine to continuously generate tasks
    private IEnumerator GenerateRandomTasks()
    {
        while (true)
        {
            GenerateRandomTask();

            // Check if we should apply time pressure
            if (elapsedTime >= timePressureStartDelay && !isUnderTimePressure)
            {
                isUnderTimePressure = true;
                Debug.Log("Time pressure applied!");
            }

            // Adjust task generation and removal intervals based on time pressure
            float taskGenerationInterval = isUnderTimePressure ? timePressureTaskGenerationInterval : initialTaskGenerationInterval;
            float taskRemovalInterval = isUnderTimePressure ? timePressureTaskRemovalInterval : initialTaskRemovalInterval;

            yield return new WaitForSeconds(taskGenerationInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
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

            // Set the task details for the TaskIcon component
            TaskIcon taskIcon = newTask.GetComponent<TaskIcon>();
            taskIcon.SetTask(randomTask);

            // Find the Task Description Text GameObject by tag
            GameObject taskDescriptionTextObject = GameObject.FindGameObjectWithTag("TaskDescriptionText");

            // Check if the GameObject is found
            if (taskDescriptionTextObject != null)
            {
                // Get the Text component from the found GameObject
                Text taskDescriptionText = taskDescriptionTextObject.GetComponent<Text>();

                // Create the task description string with newlines
                string descriptionText = "Task: " + randomTask.description +
                                         "\nLocation: " + randomTask.locationName +
                                         "\nCost: " + randomTask.cost +
                                         "\nPoints: " + randomTask.points;

                // Update the text component
                taskDescriptionText.text = descriptionText;
            }
            else
            {
                Debug.LogError("TaskDescriptionText GameObject not found or not tagged!");
            }

            Debug.Log("Task generated: " + randomTask.description);

            // Set timer for removing tasks
            StartCoroutine(RemoveTaskAfterDelay(randomTask, newTask));
        }
        else
        {
            Debug.LogError("potentialTasks is empty! Add tasks to the list.");
        }
    }

    private IEnumerator RemoveTaskAfterDelay(Task task, GameObject toBeRemoved)
    {
        // Adjust task removal interval based on time pressure
        float taskRemovalInterval = isUnderTimePressure ? timePressureTaskRemovalInterval : initialTaskRemovalInterval;

        yield return new WaitForSeconds(taskRemovalInterval);

        // Remove the task
        Debug.Log("Task removed: " + task.description);
        Destroy(toBeRemoved);
    }

    private Vector2 GetTaskPositionForTask(Task task)
    {
        // You can implement a logic here to return the position based on the task.
        // For example, you can use a dictionary to map tasks to positions.
        // Here's a simplified example assuming you have predefined positions:

        if (task.locationName == "Computer Lab")
        {
            return new Vector2(14f, 7f); // Example position for "Grading" task
        }
        else if (task.locationName == "Library")
        {
            return new Vector2(-14f, 7f); // Example position for "Update Software" task
        }
        else if (task.locationName == "Classroom")
        {
            return new Vector2(14f, -3f);
        }
        else if (task.locationName == "Nurse's Office")
        {
            return new Vector2(-14f, -3f);
        }
        // Add more conditions for other tasks

        // Default position if no match is found
        return Vector2.zero;
    }
}
