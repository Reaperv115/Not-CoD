using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerManager playerManager;
    [SerializeField]
    WeaponManager weaponManager;
    GameObject currentplayerWeapon, currentplayerweaponInst;

    GameObject playerGoInst, playerStanceInst;

    void Start()
    {
        currentplayerWeapon = Resources.Load<GameObject>("ARs/AR_A_1");
        playerManager.InitializePlayer();
        //playerStanceInst = Instantiate(playerManager.GetPlayerStance(), playerManager.GetPlayer().transform.position, playerManager.GetPlayerStance().transform.rotation, playerManager.GetPlayerTransform());
        //currentplayerweaponInst = Instantiate(currentplayerWeapon, playerManager.GetWeaponSpot().position, currentplayerWeapon.transform.rotation, playerManager.GetWeaponSpot());
    }
}
