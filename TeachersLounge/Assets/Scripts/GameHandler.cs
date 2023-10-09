using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

    public GameObject pointsText;
    private int pointsNum = 0;
    
    void Start(){
        UpdatePoints();
    }

    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        GameObject.FindWithTag("GameHandler").GetComponent<GameHandler_PauseMenu>().setBool(false);
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

    void UpdatePoints(){
        Text pointsTextB = pointsText.GetComponent<Text>();
        pointsTextB.text = "Points:" + pointsNum;
    }


}