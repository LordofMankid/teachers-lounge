using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

    public GameObject pointsText;
    private int pointsNum = 0;
    private GameObject player;
    public static int playerTolerance = 100;
    public int StartPlayerTolerance = 100;
    public GameObject toleranceText;

    public bool isDefending = false;

    private string sceneName;
    public static string lastLevelDied;  //allows replaying the Level where you died
    
    void Start(){
        player = GameObject.FindWithTag("Player");
        sceneName = SceneManager.GetActiveScene().name;
        playerTolerance = StartPlayerTolerance;   
        updateStatsDisplay();
        UpdatePoints();
    }

    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        GameObject.FindWithTag("GameHandler").GetComponent<GameHandler_PauseMenu>().setBool(false);
        GameObject.FindWithTag("GameHandler").GetComponent<EndScene>().setBool(false);
        GameObject.FindWithTag("GameHandler").GetComponent<EndLose>().setBool(false);
        GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>().ResetAllInventory();
        SceneManager.LoadScene("Main Menu");
    }

     public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
      }

    public void AddPoints(int point){
        pointsNum += point;
        UpdatePoints();
    }
    
    public int ShowPoints(){
        return pointsNum;
    }

    void UpdatePoints(){
        Text pointsTextB = pointsText.GetComponent<Text>();
        pointsTextB.text = "Points:" + pointsNum;
    }

    public void playerGetHit(int damage){
           if (isDefending == false){
                  playerTolerance -= damage;
                  if (playerTolerance >=0){
                        updateStatsDisplay();
                  }
            }

           if (playerTolerance > StartPlayerTolerance){
                  playerTolerance = StartPlayerTolerance;
                  updateStatsDisplay();
            }

           if (playerTolerance <= 0){
                  playerTolerance = 0;
                  updateStatsDisplay();
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
            Text toleranceTextTemp = toleranceText.GetComponent<Text>();
            toleranceTextTemp.text = "TOLERANCE: " + playerTolerance;
      }

      public void playerDies(){
            lastLevelDied = sceneName;     
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMoveAround>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            GameObject.FindWithTag("NPC1").SetActive(false);
            GameObject.FindWithTag("NPC2").SetActive(false);
            GameObject.FindWithTag("Resource").SetActive(false);
            GameObject.FindWithTag("GameHandler").GetComponent<EndLose>().setBool(true);
      }
}