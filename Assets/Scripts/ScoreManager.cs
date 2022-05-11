using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Score;
    public Text HighScore;
    public Text Coins_;
    public int CoinsCollected = 0;
    public float Points_PerSecond;
    public float score;
    private float HighScore_;
    public bool IsScoreIncreasing;
    void Start()
    {
        IsScoreIncreasing = false;
        if (PlayerPrefs.HasKey("hiscore"))
        {
            HighScore_ = PlayerPrefs.GetFloat("hiscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsScoreIncreasing)
            score += Points_PerSecond * Time.deltaTime;
        if(score > HighScore_)
        {
            HighScore_ = score;
            PlayerPrefs.SetFloat("hiscore", score);
        }
        Coins_.text = CoinsCollected.ToString();
        Score.text = Mathf.Round(score).ToString();
        HighScore.text = Mathf.Round(HighScore_).ToString();


    }
}
