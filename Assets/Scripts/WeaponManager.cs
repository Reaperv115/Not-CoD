using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "WeaponManager", menuName = "Scriptable Objects/WeaponManager")]
public class WeaponManager : ScriptableObject
{
    [SerializeField]
    PlayerManager playerManager;
    Transform weaponGrip;
    GameObject[] ARs, shotGuns, _smgs;
    int num;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadWeapons()
    {
        ARs = Resources.LoadAll<GameObject>("ARs");
        shotGuns = Resources.LoadAll<GameObject>("Shotguns");
        _smgs = Resources.LoadAll<GameObject>("SMGs");
        num = Random.Range(0, _smgs.Length - 1);
        weaponGrip = playerManager.GetPlayer().transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(5);
    }
    public GameObject GetRandomGun()
    {
        int num = Random.Range(0, ARs.Length - 1);
        return ARs[num];
    }

    public Transform GetGrip()
    {
        return weaponGrip;
    }
    public void LoadGun()
    {
        int weaponIndex = Random.Range(0, ARs.Length);
        var gun = Instantiate(ARs[weaponIndex], weaponGrip.transform.position, weaponGrip.transform.rotation, weaponGrip.transform);
        Debug.Log(gun);
    }

}
