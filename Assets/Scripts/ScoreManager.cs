using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "Scriptable Objects/ScoreManager")]
public class ScoreManager : ScriptableObject
{
    int score;
    TextMesh scoreDisplay;
    
    public void IncreaseScore()
    {
        score += 10;
    }
    public void PurchaseSomething(int cost)
    {
        score -= cost;
    }
    public int GetScore()
    {
        return score;
    }

    public void DisplayScore()
    {
        if (!scoreDisplay)
            scoreDisplay = GameObject.Find("HUD_Score").GetComponent<TextMesh>();
        scoreDisplay.text = "Score: " + score.ToString();
    }
    
}
