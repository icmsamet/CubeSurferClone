using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameManager
{
    public class GameManagerScore
    {
        TextMeshProUGUI scoreText;
        int score;

        public GameManagerScore(int _score,TextMeshProUGUI _scoreText)
        {
            score = _score;
            scoreText = _scoreText;
        }

        public void StartScore()
        {
            score = 0;
            SetScoreText();
        }

        public void AddScore(int value)
        {
            score += value;
            SetScoreText();
        }
        public void SetScoreText()
        {
            scoreText.text = score.ToString();
        }
    }
}
