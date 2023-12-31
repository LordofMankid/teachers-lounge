using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameHandler_PauseMenu : MonoBehaviour {

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public GameObject toleranceTextUI;
        public GameObject toleranceBG;
       
        void Start (){
                pauseMenuUI.SetActive(false);
                GameisPaused = false;
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }
       
        public void setBool( bool value) {
            GameisPaused = value;
        }

        void Pause(){
                pauseMenuUI.SetActive(true);
                toleranceTextUI.SetActive(false);
                toleranceBG.SetActive(false);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                toleranceTextUI.SetActive(true);
                toleranceBG.SetActive(true);
                Time.timeScale = 1f;
                GameisPaused = false;
        }
}