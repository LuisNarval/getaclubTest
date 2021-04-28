using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameFlow m_GameFlow;
    bool m_FirstLapFinished = false;
    bool m_OnSecondLap = false;

    public void SetFirstLap()
    {
        m_FirstLapFinished = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if(m_FirstLapFinished && !m_OnSecondLap){
                m_GameFlow.Win();
                m_OnSecondLap = true;
            }
        }
    }
}