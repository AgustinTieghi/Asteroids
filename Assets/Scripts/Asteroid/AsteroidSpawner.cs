using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    public float spawnRate;
    public static AsteroidSpawner instance;
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
        StartCoroutine(SpawnAsteroid());
    }

    IEnumerator SpawnAsteroid()
    {
        while (ShipController.instance != null)
        {
            Instantiate(asteroid, CalculateSpawnPoint(), Quaternion.identity);     
            yield return new WaitForSeconds(spawnRate);
        }
    }

    Vector3 CalculateSpawnPoint()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float randomX = Random.Range(stageDimensions.x, stageDimensions.x + 10);
        float randomY = Random.Range(stageDimensions.y, stageDimensions.y + 10);
        return new Vector3(randomX, randomY, 0);
    }
}
