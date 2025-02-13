using UnityEditor.iOS;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerManager", menuName = "Scriptable Objects/PlayerManager")]
public class PlayerManager : ScriptableObject
{
    GameObject playerGO;
    [SerializeField]
    Transform spawnPoint;
    
    void Start()
    {
        
        
    }

    public void LoadPlayer()
    {
        playerGO = Resources.Load<GameObject>("Player");
        playerGO = Instantiate(playerGO, spawnPoint.position, spawnPoint.rotation);

    }

    public GameObject GetPlayer() {return playerGO;}
    

}
