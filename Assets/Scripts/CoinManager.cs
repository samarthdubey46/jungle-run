using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio_;
    ScoreManager scoremanager;
    public float Score_Per_Coin = 15f;
    void Start()
    {
        audio_ = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoremanager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            if (audio_.isPlaying)
                audio_.Stop();
            scoremanager.score += Score_Per_Coin;
            scoremanager.CoinsCollected += 1;
            audio_.Play();
        }
    }
}
