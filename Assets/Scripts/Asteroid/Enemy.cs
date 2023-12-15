using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    protected float initialHP;
    protected float maxHP;
    private float timer;
    [SerializeField] protected float hp;
    [SerializeField] protected AudioSource audioSrc;
    private void Update()
    {
        AutodestroyAfterTime(); 
        
    }
    public void GetDamage(int dmg)
    {
        hp -= dmg;       
        if (hp <= 0)
        {
            audioSrc.Play();
            ScoreManager.instance.ScoreUp((int)initialHP * 2);
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, 1f);
        }
    }
    void AutodestroyAfterTime()
    {
        timer += Time.deltaTime;
        if (timer > 30)
        {
            Destroy(gameObject);
        }
    }   
}
