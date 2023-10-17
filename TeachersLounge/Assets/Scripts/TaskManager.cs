using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject taskIconPrefab;
    public Text taskDescriptionText;
    public List<Task> potentialTasks = new List<Task>();
    // public float taskGenerationInterval = 15.0f; // Time between generating tasks in seconds
    public float taskDuration = 15.0f; // Time a task remains on the screen in seconds

    private float timeSinceLastTask = 0.0f;
    private List<Task> activeTasks = new List<Task>(); // Store active tasks
    private bool taskCompleted = false;

    public class Task
    {
        public string description;
        public string locationName;
        public List<string> cost;
        public int points;

        public Task(string desc, string locName, List<string> costs, int pts)
        {
            description = desc;
            locationName = locName;
            cost = costs;
            points = pts;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add tasks to the list
        potentialTasks.Add(new Task("Grading", "Classroom", new List<string> { "Pencil", "Paper" }, 15));
        potentialTasks.Add(new Task("Update Software", "Computer Lab", new List<string> { "Laptop", "Book" }, 10));
        potentialTasks.Add(new Task("Lesson Research", "Library", new List<string> { "Paper", "Laptop", "Book", "Book" }, 20));
        potentialTasks.Add(new Task("Handle a Crisis", "Nurse's Office", new List<string> { "FirstAidKit" }, 10));
        potentialTasks.Add(new Task("Print Materials", "Library", new List<string> { "Paper" }, 10));
        potentialTasks.Add(new Task("Pop Quiz", "Classroom", new List<string> { "Pencil", "Paper", "Paper", "Paper" }, 20));
        potentialTasks.Add(new Task("Movie Day", "Classroom", new List<string> { "Laptop", "KeyBoard" }, 15));
        potentialTasks.Add(new Task("Classroom Management", "Classroom", new List<string>(){"None"}, 5));
        potentialTasks.Add(new Task("Checkup", "Nurse's Office", new List<string> { "Pencil", "Paper", "FirstAidKit" }, 15));
        potentialTasks.Add(new Task("Teach a Game Design Class", "Computer Lab", new List<string> { "Laptop", "KeyBoard", "Book" }, 25));

        // Start generating tasks
        // StartCoroutine(GenerateRandomTasks());
        GenerateRandomTask();
    }

    // Coroutine to continuously generate tasks
    // private IEnumerator GenerateRandomTasks()
    // {
    //     while (true)
    //     {
    //         GenerateRandomTask();
    //         yield return new WaitForSeconds(taskGenerationInterval);
    //     }
    // }

    // Coroutine to continuously generate tasks

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        timeSinceLastTask += Time.deltaTime;

        // Check if it's time to generate a new task
        if ((taskCompleted == true) || (timeSinceLastTask >= taskDuration)) {
            taskCompleted = false;
            GenerateRandomTask();
            timeSinceLastTask = 0.0f;
        }
        // timeSinceLastTask += Time.deltaTime;

        // // Check if it's time to generate a new task
        // if (timeSinceLastTask >= taskGenerationInterval) {
        //     GenerateRandomTask();
        //     timeSinceLastTask = 0.0f;
        // }

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

    public void CompleteAndGenerateNewTask() {
        taskCompleted = true;
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

                // Create the task description string
                string descriptionText = "Task: " + randomTask.description +
                                        "\nLocation: " + randomTask.locationName +
                                        "\nResource Costs: " + GetResourceCostsText(randomTask.cost);
                                        // "\nPoints: " + randomTask.points;

                // Update the text component
                taskDescriptionText.text = descriptionText;
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

    // Helper function to format resource costs with quantities
private string GetResourceCostsText(List<string> resourceCosts)
{
    if (resourceCosts[0] != "None") {
        Dictionary<string, int> resourceQuantities = new Dictionary<string, int>();

        // Count the occurrences of each resource
        foreach (string resource in resourceCosts)
        {
            if (resourceQuantities.ContainsKey(resource))
            {
                resourceQuantities[resource]++;
            }
            else
            {
                resourceQuantities[resource] = 1;
            }
        }

        // Create the formatted text
        List<string> formattedResources = new List<string>();
        foreach (var entry in resourceQuantities)
        {
            if (entry.Value > 1)
            {
                formattedResources.Add(entry.Value + " " + entry.Key + "s");
            }
            else
            {
                formattedResources.Add(entry.Value + " " + entry.Key);
            }
        }

        return string.Join(", ", formattedResources);

    } else {
        return "None";
    }
}

    private IEnumerator RemoveTaskAfterDelay(Task task, GameObject toBeRemoved) {
        yield return new WaitForSeconds(taskDuration);

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
            return new Vector2(14f, -3.5f); // Example position for "Update Software" task
        }
        else if (task.locationName == "Library")
        {
            return new Vector2(14f, 6.5f);
            
        }
        else if (task.locationName == "Classroom")
        {   
            return new Vector2(-14f, 6.5f);
        }
        else if (task.locationName == "Nurse's Office")
        {
            return new Vector2(-14f, -3.5f);
        }
        // Add more conditions for other tasks

        // Default position if no match is found
        return Vector2.zero;
    }
}
