using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    ScoreManager scoremanager;
    Image healthBar;
    Animator animator;
    CharacterController characterController;

    enum PlayerState
    {
        idle,
        walking,
        running,
    } 
    PlayerState playerState;
    float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        healthBar = GameObject.Find("Player Health Bar").transform.GetChild(2).GetComponent<Image>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerState = PlayerState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            SceneManager.LoadScene("Game Over");
            
        }

        switch(playerState)
        {
            case PlayerState.idle:
            {
                animator.SetBool("idle", true);
                break;
            }
            case PlayerState.walking:
            {
                animator.SetBool("walking", true);
                break;
            }
        }
        //scoremanager.DisplayScore();
    }
    void FixedUpdate()
    {
        print(playerState);
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerState = PlayerState.walking;
        }
        else
        {
            playerState = PlayerState.idle;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.fillAmount = health / 100f;
    }

    public float GetHealth() {return health;}
}
