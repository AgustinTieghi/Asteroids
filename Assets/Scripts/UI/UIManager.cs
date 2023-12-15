using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainUI;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = "Score: " + ScoreManager.instance.GetScore();
        highScoreText.text = "High Score: " + ScoreManager.instance.GetHighScore();
        UpdateTimer();
        livesText.text = "Lives: " + ShipSpawner.instance.GetLives();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            mainUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    void UpdateTimer()
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
