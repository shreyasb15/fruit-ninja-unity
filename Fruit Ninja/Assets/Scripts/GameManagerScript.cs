using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Text scoreText;

    private int score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
