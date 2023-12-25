using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    bool timerActive = true;
    float currentTime;
    
    double score;
    public int maxLevelScore;
    public Text scoreText;
    public float multiplier = 5f;

    public float startTime;
    public Text currentTimeText;

    public Text increament;
    int j;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime * 60;

        score = maxLevelScore;
        increament.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        j++;
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                SceneManager.LoadScene(3);
                Debug.Log("Timer  finished!");
            }
            score = score - multiplier;
            scoreText.text = score.ToString(@"0");
            PlayerPrefs.SetInt("score",(int)score);
        }
        //int currentScore = Mathf.RoundToInt(Time.deltaTime * );
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss");
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void AddScore()
    {
        score += 500;
    }
}
