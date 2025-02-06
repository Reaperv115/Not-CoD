using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    GameObject playerGO;
    Transform weaponPlacement;
    GameObject arms;
    Transform armsParent;
    GameObject primaryWeapon;
    GameObject[] primaryWeapons;
    Transform waponSpot;
    float weaponspotX;
    int num;
    public void InitializePlayer()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        weaponPlacement = playerGO.transform.GetChild(0).GetChild(2);
        primaryWeapons = Resources.LoadAll<GameObject>("ARs");
        print(primaryWeapons.Length);
        primaryWeapon = Resources.Load<GameObject>("ARs/AR_A_1");
        num = Random.Range(0, primaryWeapons.Length - 1);
        Instantiate(primaryWeapons[num], weaponPlacement.position, weaponPlacement.rotation, weaponPlacement);
    }

    
    public Transform GetWeaponSpot()
    {
        return weaponPlacement;
    }
}
