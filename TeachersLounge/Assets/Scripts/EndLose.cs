using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLose : MonoBehaviour
{
    public static bool GameisOver = false;
    public GameObject endLoseUI;
    public GameObject classTitleUI;
    public GameObject nurseUI;
    public GameObject labUI;
    public GameObject libUI;
    public GameObject loungeUI;
    public GameObject pointsText;
    public int productivity;
    public GameHandler gameHandler;
    private string novice;
    private string intermediate;
    private string expert;
    public GameObject levelText;
       
       
        void Start (){
                novice = "LEVEL: Novice\nSeems you are quite new at this.";
                intermediate = "LEVEL: Intermediate\nYou've been doing this for quite some time!";
                expert = "LEVEL: Expert\nNo child stands in your way!!";
                endLoseUI.SetActive(false);
                GameisOver = false;
        }
       
        public void setBool( bool value) {
            GameisOver = value;
            endLoseUI.SetActive(GameisOver);
            classTitleUI.SetActive(false);
            nurseUI.SetActive(false);
            labUI.SetActive(false);
            libUI.SetActive(false);
            loungeUI.SetActive(false);
            UpdatePoints();
        }

        void UpdatePoints(){
            GameObject gameHandlerObject = GameObject.FindWithTag("GameHandler");
            if (gameHandlerObject != null){
            gameHandler = gameHandlerObject.GetComponent<GameHandler>();
                if (gameHandler != null){
                    productivity = gameHandler.ShowPoints();
                }
            }
            Text pointsTextB = pointsText.GetComponent<Text>();
            pointsTextB.text = "Your Productivity: " + productivity;

            if(productivity < 100){
                Text levelTextB = levelText.GetComponent<Text>();
                levelTextB.text = novice;
            } else if (productivity > 100 && productivity < 200){
                Text levelTextB = levelText.GetComponent<Text>();
                levelTextB.text = intermediate;
            } else if(productivity > 200){
                Text levelTextB = levelText.GetComponent<Text>();
                levelTextB.text = expert;
            }
        } 
}