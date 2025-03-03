using UnityEngine;
using Unity.Cinemachine;

public class FindPlayer : MonoBehaviour
{
    CinemachineCamera thirdpersonCamera;
    bool foundPlayer = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thirdpersonCamera = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        var obj = GameObject.FindGameObjectWithTag("Player");
        if (obj)
        {
            thirdpersonCamera.Follow = obj.transform.GetChild(2);
        }
    }
}
