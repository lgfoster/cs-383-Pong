using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI p1ScoreText, p2ScoreText;

    int p1Score = 0;
    int p2Score = 0;
    
    // Create instance of UI for the game
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Set scores to zero on game start
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }

    // Functions for updating score on UI
    public void AddPointsP1() 
    {
        p1Score += 1;
        p1ScoreText.text = p1Score.ToString();
    }

    public void AddPointsP2() 
    {
        p2Score += 1;
        p2ScoreText.text = p2Score.ToString();
    }
}
