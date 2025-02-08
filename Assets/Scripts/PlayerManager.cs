using UnityEditor.iOS;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    GameObject playerGO;
    Transform weaponPlacement;
    GameObject[] ARs, shotGuns, _smgs;
    int num;
    public void InitializePlayer()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        ARs = Resources.LoadAll<GameObject>("ARs");
        shotGuns = Resources.LoadAll<GameObject>("Shotguns");
        _smgs = Resources.LoadAll<GameObject>("SMGs");
        num = Random.Range(0, _smgs.Length - 1);
        //Instantiate(_smgs[num], weaponPlacement.position, weaponPlacement.rotation, weaponPlacement);
    }

    
    public Transform GetWeaponSpot()
    {
        return weaponPlacement;
    }
}
