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
        //weaponManager.InstantiateGun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
