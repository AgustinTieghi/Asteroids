using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private float timer;
    [Header("Difficulty Levels")]
    [SerializeField] private int firstLevel;
    [SerializeField] private int secondLevel;
    [SerializeField] private int thirdLevel;
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

        if (timer > firstLevel)
        {
            AsteroidSpawner.instance.spawnRate = 1.5f;
        }

        if (timer > secondLevel)
        {
            AsteroidSpawner.instance.spawnRate = 1f;
        }

        if (timer > thirdLevel)
        {
            AsteroidSpawner.instance.spawnRate = 0.5f;
        }
    }

    public float GetTimer()
    {
        return timer;
    }
}
