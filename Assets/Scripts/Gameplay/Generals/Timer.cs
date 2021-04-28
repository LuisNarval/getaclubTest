using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int m_Seconds = 60;
    [SerializeField] HUD m_Hud;
    [SerializeField] GameFlow m_GameFlow;
    [SerializeField] GameMenu m_GameMenu;

    public void StartTimer()
    {
        StartCoroutine(Coroutine_Timer());
    }

    IEnumerator Coroutine_Timer()
    {
        while(m_Seconds > 0.0f)
        {
            m_Seconds--;
            m_Hud.updateTime(m_Seconds);
            yield return new WaitForSeconds(1.0f);
        }

        m_GameFlow.Loose();
    }


    public void addTime(int _seconds)
    {
        m_Seconds += _seconds;
        this.GetComponent<AudioSource>().Play();
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        m_Hud.updateTime(m_Seconds);
        m_GameMenu.SetScore(m_Hud.ClockFormat(m_Seconds), m_Seconds);
    }

}