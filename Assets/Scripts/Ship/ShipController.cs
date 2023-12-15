using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour, IDamagable
{
    [Header("Player Settings")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerRotSpeed;
    [SerializeField] private int hp;
    [SerializeField] private int initialHP;
    [Header("Component References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject invencibility;
    private Vector2 playerInput;
    public static ShipController instance;
    public delegate void DelDeath();
    public static event DelDeath OnDeath;
    [HideInInspector] public bool shoot;
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
    private void Start()
    {
        initialHP = hp;
        ShipSpawner.OnShipSpawn += StartInvencibility;
    }
    void Update()
    {
        PlayerMovement();
    }

    void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    void OnShoot(InputValue value)
    {
        ShootInput(value.isPressed);
    }

    void ShootInput(bool newShootState)
    {
        shoot = newShootState;
    }

    void PlayerMovement()
    {
        characterController.Move(transform.up * playerInput.y * playerSpeed * Time.deltaTime);
        transform.Rotate(-transform.forward, playerRotSpeed * playerInput.x * Time.deltaTime);
    }

    public void GetDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            ManageDeath();
        }
    }
    void ManageDeath()
    {
        PlaySoundOnDeath();
        if (OnDeath != null)
        {
            OnDeath.Invoke();
        }
        else if (OnDeath == null)
        {
            SceneManager.LoadScene("GameOver");
            if(ScoreManager.instance.GetScore() > ScoreManager.instance.GetHighScore())
            {
                ScoreManager.instance.SaveScore();
            }           
            Time.timeScale = 0;
        }
    }
    void StartInvencibility()
    {
        StartCoroutine(Invencibility());
    }

    IEnumerator Invencibility()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        invencibility.SetActive(true);
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<Collider>().enabled = true;
        invencibility.SetActive(false);
        hp = initialHP;
        StopAllCoroutines();
    }
    void PlaySoundOnDeath()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
