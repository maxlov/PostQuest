using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static int score;
    public int scoreAdd;
    public static int scoreTarget;
    float lerp = 0f;
    float duration;
    public float durationDiv = 10;
    public TextMeshProUGUI scoreText;
    PersitentValues pValues;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ValueManager = GameObject.Find("ValueManager");
        pValues = ValueManager.GetComponent<PersitentValues>();
        score = pValues.score;
        scoreTarget = score;
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreAdd += scoreToAdd;
    }

    // Update is called once per frame
    void Update()
    {
        // Buttery smooth score change
        if (scoreAdd > 0)
        {
            scoreTarget = scoreAdd + scoreTarget;
            duration = scoreAdd / durationDiv;
            scoreAdd = 0;
        }
        if (score != scoreTarget)
        {
            lerp += Time.deltaTime;
            score = (int)Mathf.Lerp(score, scoreTarget, lerp / duration);
            if (score >= scoreTarget - 2 && score <= scoreTarget + 2)
            {
                score = scoreTarget;
            }
            scoreText.text = "Score: " + score;
        }
        else
        {
            lerp = 0;
        }
    }

    private void OnDestroy()
    {
        pValues.score = score;
    }
}
