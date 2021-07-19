using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void StartGame()
    {

        m_Animator.SetTrigger("Play");
    }

    public Animator m_Animator;
    private void Update()
    {
        if(m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "On")
        {
            SceneManager.LoadScene("GameScene");

        }

    }
}
