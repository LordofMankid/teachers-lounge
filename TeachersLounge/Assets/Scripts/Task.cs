// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class TaskManager : MonoBehaviour
// {
//     public GameObject taskIconPrefab;
//     public Text taskDescriptionText;
//     public List<Task> potentialTasks = new List<Task>();
//     public float taskGenerationInterval = 5.0f;
//     public float taskDuration = 3.0f;

//     private float timeSinceLastTask = 0.0f;

//     public class Task
//     {
//         public string description;
//         public string taskDetail;
//         public int points;

//         public Task(string desc, string detail, int pts)
//         {
//             description = desc;
//             taskDetail = detail;
//             points = pts;
//         }
//     }

//     void Start()
//     {
//         potentialTasks.Add(new Task("Grading", "Grade assignments in classroom", 10));
//         potentialTasks.Add(new Task("Update Software", "Update software in the computer lab", 15));
//         potentialTasks.Add(new Task("Lesson Planning", "Plan the next lesson in the library", 20));
//         potentialTasks.Add(new Task("Handle an Injury", "Grab a first-aid kit from the nurse's office", 20));

//         // Generate the first task
//         GenerateRandomTask();
//     }

//     void Update()
//     {
//         timeSinceLastTask += Time.deltaTime;

//         if (timeSinceLastTask >= taskGenerationInterval)
//         {
//             GenerateRandomTask();
//             timeSinceLastTask = 0.0f;
//         }
//     }

//     private void GenerateRandomTask()
//     {
//         if (potentialTasks.Count > 0)
//         {
//             int randomIndex = Random.Range(0, potentialTasks.Count);
//             Task randomTask = potentialTasks[randomIndex];

//             // Find the Task Description Text GameObject by tag
//             GameObject taskDescriptionTextObject = GameObject.FindGameObjectWithTag("TaskDescriptionText");

//             if (taskDescriptionTextObject != null)
//             {
//                 Text taskDescriptionText = taskDescriptionTextObject.GetComponent<Text>();
//                 taskDescriptionText.text = "Task: " + randomTask.description + "\nDetails: " + randomTask.taskDetail;
//             }
//             else
//             {
//                 Debug.LogError("TaskDescriptionText GameObject not found or not tagged!");
//             }

//             // Instantiate the task icon prefab at the task position
//             Vector2 taskPosition = GetTaskPositionForTask(randomTask);
//             GameObject taskIconObject = Instantiate(taskIconPrefab, taskPosition, Quaternion.identity);

//             // Get the TaskIcon component from the instantiated object
//             TaskIcon taskIcon = taskIconObject.GetComponent<TaskIcon>();

//             // Associate the task with the task icon
//             taskIcon.SetTask(randomTask);

//             // Set timer for removing tasks
//             StartCoroutine(RemoveTaskAfterDelay(randomTask, taskIconObject));
//         }
//         else
//         {
//             Debug.LogError("potentialTasks is empty! Add tasks to the list.");
//         }
//     }

//     private IEnumerator RemoveTaskAfterDelay(Task task, GameObject taskIconObject)
//     {
//         yield return new WaitForSeconds(taskDuration);

//         // Remove the task
//         Debug.Log("Task removed: " + task.description);

//         // Destroy the task icon object associated with this task
//         Destroy(taskIconObject);
//     }

//     private Vector2 GetTaskPositionForTask(Task task)
//     {
//         if (task.description == "Grading")
//         {
//             return new Vector2(4f, 2f); // Example position for "Grading" task
//         }
//         else if (task.description == "Update Software")
//         {
//             return new Vector2(-4f, 2f); // Example position for "Update Software" task
//         }
//         else if (task.description == "Handle an Injury")
//         {
//             return new Vector2(4f, -2f);
//         }
//         else if (task.description == "Lesson Planning")
//         {
//             return new Vector2(-4f, -2f);
//         }
//         // Add more conditions for other tasks

//         // Default position if no match is found
//         return Vector2.zero;
//     }
// }
