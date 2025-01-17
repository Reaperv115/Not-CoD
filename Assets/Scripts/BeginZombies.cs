using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginZombies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayZombies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayZombies()
    {
        SceneManager.LoadScene("Zombies");
    }
}
