using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameFlow : MonoBehaviour
{
    [SerializeField] GameMenu m_Menu;
    [SerializeField] Timer m_Timer;
    [SerializeField] HUD m_HUD;
    [SerializeField] CarController m_Car;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        m_Car.enabled = false;
        yield return new WaitForSeconds(2.0f);
        yield return m_HUD.StartCoroutine("ShowCountDown");
        m_Timer.StartTimer();
        m_Car.enabled = true;
    }

    public void Win()
    {
        m_Menu.Show_WinScreen();
        m_Timer.StopTimer();
        m_Car.enabled = false;
    }

    public void Loose()
    {
        m_Menu.Show_LoseScreen();
        m_Timer.StopTimer();
        m_Car.enabled = false;
    }
}