using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string highScoreKey;
    [SerializeField] private AudioSource audioSource;
    private int score;
    private int highScore;    
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            highScore = PlayerPrefs.GetInt(highScoreKey);
        }
    }

    public int GetScore()
    {
        return score;
    }
    public int GetHighScore()
    {
        return highScore;
    }

    public void ScoreUp(int scoreSum)
    {
        score += scoreSum;
    }

    public void SaveScore()
    {
        highScore = score;
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();
        audioSource.Play();
    }
}
