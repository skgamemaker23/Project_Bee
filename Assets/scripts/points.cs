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



    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // Display the score in the UI
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("flower1"))
        {
            score += 10;
            UpdateScoreUI();
        }
        if (other.gameObject.CompareTag("flower2"))
        {
            score += 5;
            UpdateScoreUI();
        }

    }
}
   
