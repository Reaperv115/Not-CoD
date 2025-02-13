using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    [SerializeField]
    PlayerManager playerManager;
    [SerializeField]
    WeaponManager weaponManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerManager.LoadPlayer();
        weaponManager.LoadWeapons();
        weaponManager.LoadGun();

        if (playerManager.GetPlayer())
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
