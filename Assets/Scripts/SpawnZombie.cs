using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
     GameObject zombie, zombieClone;
    int numzombiestoSpawn;
    float spawnTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombie = Resources.Load<GameObject>("Zombie");
        spawnTimer = 5;
        numzombiestoSpawn = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
            {
                if (numzombiestoSpawn > 0)
                {
                    zombieClone = Instantiate(zombie, transform.position, Quaternion.identity);
                    spawnTimer = 5;
                }
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
    }
}
