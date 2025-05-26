using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    
    private int points = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string scorePrefix = "Score:"; //UI prefix

    private bool timedMode = true; //game mode
    [SerializeField] private TextMeshProUGUI timeText; //time UI text
    [SerializeField] private float timeLimitSecs = 30; //the time limit for timed mode
    private float startTime;
    private string emptyTimePlaceholder = "-:--"; //this displays if we're not in timed mode

    [SerializeField] private GameObject newGameUI; //the new game UI

    private void Start(){
        AddScore(0); //init score to 0
        startTime = Time.time;
        newGameUI.SetActive(false); //init new game UI to inactive
        
        if (!timedMode){ //if not timed mode, set the timer text to empty
            timeText.SetText(emptyTimePlaceholder);
        }
    }

    private void Update(){
        if (!timedMode) return; //if we're not in timed mode, then who cares about this

        DisplayTime(); //display the (formatted) time in UI

        if (!TimeRemains() && !newGameUI.active){ //if time is up and we haven't already shown the new game UI, do that now
            newGameUI.SetActive(true);
        }
    }

    public void ResetGame(){
        SetScore(0); //reset score
        startTime = Time.time;
        newGameUI.SetActive(false); //hide new game UI

        if (!timedMode){ //if not timed mode, set the timer text to empty
            timeText.SetText(emptyTimePlaceholder);
        }
    }

    public int GetScore(){
        return points;
    }

    public void SetScore(int p){ //set score and text
        points = p;
        scoreText.SetText(scorePrefix + " " + points.ToString());
    }

    public void AddScore(int p){ //add score and set text
        points += p;
        scoreText.SetText(scorePrefix + " " + points.ToString());
    }

    public void TakeScore(int p){ //subtract score and set text
        points -= p;
        scoreText.SetText(scorePrefix + " " + points.ToString());
    }

    public bool TimeRemains(){ //does time remain?
        return Time.time < (startTime + timeLimitSecs);
    }

    public void DisplayTime(){ //display the time, formatted
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

    public void FlipTimedMode(){ //switch between timed/untimed modes
        timedMode = !timedMode;
    }

    public bool TimedMode(){ //are we in timed mode?
        return timedMode;
    }

}
