using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    Transform weaponGrip;
    Image healthBar;
    float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        healthBar = GameObject.Find("Player Health Bar").transform.GetChild(2).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void FixedUpdate()
    {
       
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.fillAmount = health / 100f;
    }

    public float GetHealth() {return health;}
    public Transform GetWeaponGrip() {return weaponGrip;}
}
