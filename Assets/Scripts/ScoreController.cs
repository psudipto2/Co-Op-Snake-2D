using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public Snake snake1;
    public Snake2 snake2;
    public TextMeshProUGUI Snake1ScoreText;
    public TextMeshProUGUI Snake2ScoreText;
    int Snake1Score = 0;
    int Snake2Score = 0;
    private void Start()
    {
        Snake1ScoreText.text = Snake1Score.ToString();
        Snake2ScoreText.text = Snake2Score.ToString();
    }

    private void Update()
    {
        Snake1Score = snake1.Score();
        Snake2Score = snake2.Score();
        Snake1ScoreText.text = Snake1Score.ToString();
        Snake2ScoreText.text = Snake2Score.ToString();
    }

}
