using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoseUI : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.m_CurrentHeart<= 0)
        {
            GameOver();
        }
    }


    public GameObject GameOverUI;

    public void GameOver()
    {
        Time.timeScale = 0.3f;
        GameOverUI.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void BackMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");

    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");

    }
}
