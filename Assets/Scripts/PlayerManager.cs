using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    GameObject playerGO, playerGoInst;
    Transform weaponSpot;
    Transform[] shoulders;
    GameObject[] shoulderGOs, shoulderGoInst;
    public void InitializePlayer()
    {
        shoulders = new Transform[2];
        shoulderGOs = new GameObject[2];
        shoulderGoInst = new GameObject[2];
        playerGO = GameObject.FindGameObjectWithTag("Player");
        shoulders[0] = playerGO.transform.GetChild(2); // Right shoulder
        shoulders[1] = playerGO.transform.GetChild(3); // Left shoulder
        shoulderGOs[0] = Resources.Load<GameObject>("right shoulder");
        shoulderGOs[1] = Resources.Load<GameObject>("left shoulder");
        shoulderGoInst[0] = Instantiate(shoulderGOs[0], shoulders[0].position, shoulderGOs[0].transform.rotation, shoulders[0]);
        shoulderGoInst[1] = Instantiate(shoulderGOs[1], shoulders[1].position, shoulderGOs[1].transform.rotation, shoulders[1]);
        //playerGoInst = Instantiate(playerGO, playerspawnPoint.position, playerGO.transform.rotation);
        //playerGO = GameObject.Find("Player");
        weaponSpot = playerGO.transform.GetChild(1);
    }

    
    public Transform GetWeaponSpot()
    {
        return weaponSpot;
    }
    public GameObject GetPlayer()
    {
        return playerGoInst;
    }
    public Transform GetPlayerTransform()
    {
        return playerGoInst.transform;
    }
}
