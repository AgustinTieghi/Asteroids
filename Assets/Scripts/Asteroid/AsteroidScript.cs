using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : Enemy
{
    private float asteroidForce;
    [SerializeField] private float scaleMultiplier;
    [SerializeField] private float hpMultiplier;

    private void Start()
    {
        RandomizeStats();
        Vector3 direction = ShipController.instance.gameObject.transform.position - this.transform.position;
        this.GetComponent<Rigidbody>().AddForce(direction * asteroidForce, ForceMode.Impulse);
    }

    void RandomizeStats()
    {
        maxHP = DifficultyManager.instance.GetTimer() * hpMultiplier;
        asteroidForce = Random.Range(0.05f, 0.2f);
        hp = Random.Range(10, maxHP);
        initialHP = hp;
        this.transform.localScale = new Vector3(hp, hp, hp) * scaleMultiplier;
    }   
}
   