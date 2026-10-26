using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
//from devsourcehub 

public class ScoreManager : MonoBehaviour
{
    public static int score; // Store the player's score
    public TextMeshProUGUI scoreText;   // Reference to the UI text component

    void Start()
    {
        score = 0; // Initialize score
        UpdateScoreUI(); // Update the UI with the initial score
    }

    private void Update()
    {
        UpdateScoreUI();
    }


    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // Display the score in the UI
    }

    public void AddPoints(int points)
    {
        score += points;
    }

    
    
}
   
