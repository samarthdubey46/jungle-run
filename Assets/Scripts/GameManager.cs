using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public Player player;
    public ScoreManager scoremanager;
    public GameObject GameOverScreen;
    public GameObject GameStartScreen;
    public GameObject PauseScreen;

    public GameObject LargeGround;
    public GameObject MediumGround;
    public GroundGenerator groundGenerator;


    private Vector3 GroundGeneration_Point;
    private Vector3 PlayerStart_Point;

    private Vector3 GroundGeneration_Point_Pause;
    private Vector3 PlayerStart_Point_Pause;

    public AudioSource DeathSound;
    public AudioSource BackgroundSound;

    void Start()
    {
        PlayerStart_Point = player.transform.position;
        GroundGeneration_Point = groundGenerator.transform.position;
        GameOverScreen.SetActive(false);
        player.gameObject.SetActive(false);
        GameStartScreen.SetActive(true);
        scoremanager.IsScoreIncreasing = false;
        PauseScreen.SetActive(false) ;
        groundGenerator.IsGroundGenerating = false;
    }

    public void PauseGame()
    {
        PlayerStart_Point_Pause = player.transform.position;
        GroundGeneration_Point_Pause = groundGenerator.transform.position;
        PauseScreen.SetActive(true);
        player.gameObject.SetActive(false);
        scoremanager.IsScoreIncreasing = false;
        groundGenerator.IsGroundGenerating = false;
    }

    public void StartGame_After_Pause()
    {
        player.transform.position = PlayerStart_Point_Pause;
        groundGenerator.transform.position = GroundGeneration_Point_Pause;
        scoremanager.IsScoreIncreasing = true;
        groundGenerator.IsGroundGenerating = true;
        player.gameObject.SetActive(true);
        PauseScreen.SetActive(false);

    }

    public void StartGame()
    {
        GameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        GameStartScreen.SetActive(false);
        scoremanager.IsScoreIncreasing = true;
        groundGenerator.IsGroundGenerating = true;
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        GameOverScreen.SetActive(true);
        player.gameObject.SetActive(false);
        scoremanager.IsScoreIncreasing = false;
        BackgroundSound.Stop();
        DeathSound.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        GroundDestroy[] destroyers = FindObjectsOfType<GroundDestroy>();
        for(int i = 0;i < destroyers.Length; i++)
        {
            destroyers[i].gameObject.SetActive(false);
        }
        LargeGround.SetActive(true);
        MediumGround.SetActive(true);

        player.transform.position = PlayerStart_Point;
        groundGenerator.transform.position = GroundGeneration_Point;
        GameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        DeathSound.Stop();
        BackgroundSound.Play();
        scoremanager.score = 0;
        scoremanager.CoinsCollected = 0;
        scoremanager.IsScoreIncreasing = true;

    }

}
