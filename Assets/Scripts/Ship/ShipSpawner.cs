using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{    
    [SerializeField] private GameObject ship;
    [SerializeField] private int livesLeft;
    public static ShipSpawner instance;
    public delegate void DelSpawn();
    public static event DelSpawn OnShipSpawn;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        ShipController.OnDeath += SpawnShip;
    }

    void SpawnShip()
    {
        ship.transform.position = Vector3.zero;
        OnShipSpawn.Invoke();
        livesLeft--;
        if (livesLeft == 0)
        {
            ShipController.OnDeath -= SpawnShip;
        }
    }

    public int GetLives()
    {
        return livesLeft;
    }

}
