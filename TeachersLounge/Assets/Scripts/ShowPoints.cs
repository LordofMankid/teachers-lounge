using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowPoints : MonoBehaviour
{
    public GameObject pointsText;
    public int productivity;
   public GameHandler gameHandler;

void Start()
{
    GameObject gameHandlerObject = GameObject.FindWithTag("GameHandler");
    if (gameHandlerObject != null)
    {
        gameHandler = gameHandlerObject.GetComponent<GameHandler>();
        if (gameHandler != null)
        {
            productivity = gameHandler.ShowPoints();
        }
    }
    
} 

   void UpdatePoints(){
        Text pointsTextB = pointsText.GetComponent<Text>();
        pointsTextB.text = "Your Productivity: " + productivity;
    }

}
