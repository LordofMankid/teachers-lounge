using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLose : MonoBehaviour
{
    public static bool GameisOver = false;
    public GameObject endLoseUI;
    public GameObject pointsText;
    public int productivity;
    public GameHandler gameHandler;
       
        void Start (){
                endLoseUI.SetActive(false);
                GameisOver = false;
        }
       
        public void setBool( bool value) {
            GameisOver = value;
            endLoseUI.SetActive(GameisOver);
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
        } 
}