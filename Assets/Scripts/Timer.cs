using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int Seconds = 70;
    [SerializeField] HUD Hud;

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(Coroutine_Timer());
    }

    IEnumerator Coroutine_Timer()
    {
        while(Seconds > 0.0f)
        {
            Seconds--;
            Hud.updateTime(Seconds);
            yield return new WaitForSeconds(1.0f);
        }

    }


    public void addTime(int _seconds)
    {
        Seconds += _seconds;
        this.GetComponent<AudioSource>().Play();
    }



}