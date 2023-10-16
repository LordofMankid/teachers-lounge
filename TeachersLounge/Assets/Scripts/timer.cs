using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class myTimer : MonoBehaviour {
       public GameObject timerText;
       private int gameTime = 300;
       private float timer = 0f;

       void Start () {
           UpdateTime();
       }
       void FixedUpdate(){
           timer += 0.03f;
            if (timer >= 1f){
                gameTime -= 1;
                timer = 0;
                UpdateTime();
            }
            if (gameTime <= 0){
                gameTime = 0;
                GameObject.FindWithTag("GameHandler").GetComponent<EndScene>().setBool(true);
            }   
      }

      public void UpdateTime(){
            Text timeTextTemp = timerText.GetComponent<Text>();
            timeTextTemp.text = "Timer:" + gameTime;
      }
}
