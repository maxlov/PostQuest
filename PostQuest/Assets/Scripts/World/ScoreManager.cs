using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static int score;
    public int scoreAdd;
    static int scoreTarget;
    float lerp = 0f;
    float duration;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreAdd = scoreToAdd;
    }

    // Update is called once per frame
    void Update()
    {
        // Buttery smooth score change
        if (scoreAdd > 0)
        {
            scoreTarget = score + scoreAdd;
            duration = scoreAdd / 100;
            scoreAdd = 0;
        }
        if (score != scoreTarget)
        {
            lerp += Time.deltaTime / duration;
            score = (int)Mathf.Lerp(score, scoreTarget, lerp);
            scoreText.text = "Score: " + score;
        }
    }
}
