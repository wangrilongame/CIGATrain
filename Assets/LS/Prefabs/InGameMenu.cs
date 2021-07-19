using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class InGameMenu : MonoBehaviour
{

    public DOTweenAnimation m_StopPanelUP;

    public void StopGame()
    {

        m_StopPanelUP.DOPlayForward();
        Time.timeScale = 0f;



    }


    public void ContinueGame()
    {
        m_StopPanelUP.DOPlayBackwards();
        Time.timeScale = 1f;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("GameScene");

    }

    public void BackMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");

    }
}
