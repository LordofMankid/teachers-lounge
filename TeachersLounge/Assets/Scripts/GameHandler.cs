using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    public GameObject pointsText;
    private int pointsNum = 0;

    void Start(){
        UpdatePoints();
    }

    public void AddPoints(int point){
        pointsNum += point;
        UpdatePoints();
    }

    void UpdatePoints(){
        Text pointsTextB = pointsText.GetComponent<Text>();
        pointsTextB.text = "Productivity Points:" + pointsNum;
    }


}