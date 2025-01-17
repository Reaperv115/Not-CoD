using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    ScoreManager scoremanager;
    Image healthBar;
    float health;
    GameObject endgameCamera;
    [SerializeField]
    GameObject egcfocusPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        healthBar = GameObject.Find("Player Health Bar").transform.GetChild(2).GetComponent<Image>();
        endgameCamera = GameObject.Find("EndGame Camera");
        endgameCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            endgameCamera.SetActive(true);
            endgameCamera.tag = "MainCamera";
            endgameCamera.transform.LookAt(egcfocusPoint.transform);
            Destroy(gameObject);
            print("player died");
        }
        scoremanager.DisplayScore();
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.fillAmount = health / 100f;
    }

    public float GetHealth() {return health;}
}
