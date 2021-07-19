using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    public int passengerNumber;
    public int m_CurrentMoneyNum = 0;
    public int m_CurrentHeart = 1;

    public AudioSource m_audio;

    public void ChangePassengerNumber(int number)
    {
        m_audio.Play();
        passengerNumber = passengerNumber + number;
    }


    public int MeetTrainStation()
    {
        int returnNum = passengerNumber;
        passengerNumber = 0;
        return returnNum;

    }






    /// <summary>
    /// ���ӳ���ķ�����
    /// </summary>
    public void AddCarriage()
    {
        Debug.Log("���� �˸��µĳ���");
    }

    /// <summary>
    /// ����Ѫ���ķ���
    /// </summary>
    public void AddHeart()
    {
        m_CurrentHeart += 1;
    }

    /// <summary>
    /// �۳�Ѫ���ķ���
    /// </summary>
    public void CutHeart()
    {
        m_audio.clip = m_DeathClip;
        m_audio.Play();
        m_CurrentHeart = 0;
    }



    public AudioClip m_DeathClip;
}