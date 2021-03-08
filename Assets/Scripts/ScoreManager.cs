using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int highScore;
    private int currentScore;
    public TMPro.TextMeshProUGUI currentScoreText;
    public TMPro.TextMeshProUGUI currentHiScoreText;
     // Start is called before the first frame update
    void Start()
    {
          highScore = 0;
          currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

     public void UpdateScore(int points) {
          currentScore += points;
          if (highScore <= currentScore) {
               highScore = currentScore;
               UpdateHighScoreText();
          }
          UpdateScoreText();
     }

     public void UpdateScoreText() {
          if (currentScore < 10)
          {
               currentScoreText.SetText("000" + currentScore.ToString());
          }
          else if (currentScore < 100)
          {
               currentScoreText.SetText("00" + currentScore.ToString());
          }
          else if (currentScore < 1000)
          {
               currentScoreText.SetText("0" + currentScore.ToString());
          }
          else {
               currentScoreText.SetText(currentScore.ToString());
          }
     }

     public void UpdateHighScoreText() {
          if (highScore < 10)
          {
               currentHiScoreText.SetText("000" + highScore.ToString());
          }
          else if (highScore < 100)
          {
               currentHiScoreText.SetText("00" + highScore.ToString());
          }
          else if (highScore < 1000)
          {
               currentHiScoreText.SetText("0" + highScore.ToString());
          }
          else
          {
               currentHiScoreText.SetText(highScore.ToString());
          }
     }
}
