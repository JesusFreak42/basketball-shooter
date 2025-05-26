using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    
    private int points = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string scorePrefix = "Score:";

    // [SerializeField] private int maxBalls = 10;
    // private int balls = 0;
    // [SerializeField] private TextMeshProUGUI ballsText;
    // [SerializeField] private string ballsPrefix = "Balls:";

    private bool timedMode = true;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float timeLimitSecs = 30;
    private float startTime;
    private string emptyTimePlaceholder = "-:--";

    [SerializeField] private GameObject newGameUI;

    private void Start(){
        AddScore(0);
        startTime = Time.time;
        // AddBalls(maxBalls);
        newGameUI.SetActive(false);
        
        if (!timedMode){
            timeText.SetText(emptyTimePlaceholder);
        }
    }

    private void Update(){
        if (!timedMode) return;

        DisplayTime();

        if (!TimeRemains() && !newGameUI.active){
            newGameUI.SetActive(true);
        }
    }

    public void ResetGame(){
        SetScore(0);
        startTime = Time.time;
        newGameUI.SetActive(false);
        // SetBalls(maxBalls);

        if (!timedMode){
            timeText.SetText(emptyTimePlaceholder);
        }
    }

    public int GetScore(){
        return points;
    }

    public void SetScore(int p){
        points = p;
        scoreText.SetText(scorePrefix + " " + points.ToString());
    }

    public void AddScore(int p){
        points += p;
        scoreText.SetText(scorePrefix + " " + points.ToString());
    }

    public void TakeScore(int p){
        points -= p;
        scoreText.SetText(scorePrefix + " " + points.ToString());
    }

    public bool TimeRemains(){
        // Debug.Log(Time.time + " " + startTime + " " + timeLimitSecs + " " + (Time.time > (startTime + timeLimitSecs)));
        return Time.time < (startTime + timeLimitSecs);
    }

    public void DisplayTime(){
        // timeText.SetText((timeLimitSecs - Mathf.Floor(Time.time - startTime)).ToString());
        int minutes, seconds;
        if (TimeRemains()){
            minutes = Mathf.FloorToInt((timeLimitSecs - Mathf.Floor(Time.time - startTime)) / 60f);
            seconds = Mathf.FloorToInt((timeLimitSecs - Mathf.Floor(Time.time - startTime)) % 60f);
        }
        else{
            minutes = 0;
            seconds = 0;
        }
        timeText.SetText(string.Format("{0:0}:{1:00}", minutes, seconds));
    }

    public void FlipTimedMode(){
        timedMode = !timedMode;
    }

    public bool TimedMode(){
        return timedMode;
    }

    // public int GetBalls(){
    //     return balls;
    // }

    // public int GetMaxBalls(){
    //     return maxBalls;
    // }

    // public void SetBalls(int b){
    //     balls = b;
    //     ballsText.SetText(ballsPrefix + " " + balls.ToString());
    // }

    // public void AddBalls(int b){
    //     balls += b;
    //     ballsText.SetText(ballsPrefix + " " + balls.ToString());
    // }

    // public void TakeBalls(int b){
    //     balls -= b;
    //     ballsText.SetText(ballsPrefix + " " + balls.ToString());
    // }

}
