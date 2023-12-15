using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    [SerializeField] private float shootForceAmount;
    [HideInInspector] public Vector3 direction;
    public int dmg;
    private float timer;
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(direction * shootForceAmount, ForceMode.Impulse);
    }

    private void Update()
    {
       AutodestroyAfterTime();
    }

    void AutodestroyAfterTime()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IDamagable>().GetDamage(dmg);
        Destroy(this.gameObject);
    }
}
