using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InformationUI : MonoBehaviour
{

    public Transform m_HearAnchor;

    public GameObject m_HeartPrefab;
    public int m_CurrentHeartNum;
    public List<Transform> m_CurrentAllHeart;

    private void Start()
    {
        m_CurrentAllHeart.AddRange(m_HearAnchor.GetComponents<Transform>());
        m_CurrentAllHeart.Remove(m_HearAnchor.transform);
        m_CurrentHeartNum = GameManager.Instance.passengerNumber;



        for (int i = 0; i < m_CurrentHeartNum; i++)
        {
            GameObject obj = Instantiate(m_HeartPrefab, m_HearAnchor.transform);
            m_CurrentAllHeart.Add(obj.transform);
        }

    }

    private void Update()
    {


        if(GameManager.Instance.passengerNumber < 0)
        {

        }
        else
        {

            if (m_CurrentHeartNum != GameManager.Instance.passengerNumber)
            {



                for (int i = 0; i < m_CurrentHeartNum; i++)
                {
                    Destroy(m_CurrentAllHeart[i].gameObject);
                }
                m_CurrentAllHeart.Clear();

                m_CurrentHeartNum = GameManager.Instance.passengerNumber;


                for (int i = 0; i < m_CurrentHeartNum; i++)
                {
                    GameObject obj = Instantiate(m_HeartPrefab, m_HearAnchor.transform);
                    m_CurrentAllHeart.Add(obj.transform);
                }

            }
        }




    }
}
