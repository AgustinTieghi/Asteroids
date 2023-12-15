using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private float timer;
    [Header("Difficulty Levels")]
    [SerializeField] private int raiseDifficultyInterval;
    [SerializeField] private float raiseSpawnRateAmount;
    public static DifficultyManager instance;

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

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > raiseDifficultyInterval)
        {
            AsteroidSpawner.instance.spawnRate -= raiseSpawnRateAmount;
            print("Difficulty Raised!");
            timer = 0;
        }
    }

    public float GetTimer()
    {
        return timer;   
    }
}
