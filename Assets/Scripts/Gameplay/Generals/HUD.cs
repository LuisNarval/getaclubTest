using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] float MaxSpeed = 20;
    [SerializeField] float MaxSpeedFillment = 7;
    [SerializeField] Color LowSpeedColor;
    [SerializeField] Color HighSpeedColor;

    [Header("REFERENCES")]
    [SerializeField] Text m_SpeedText;
    [SerializeField] Text m_TimeText;
    [SerializeField] Image SpeedFiller;

    [SerializeField] Animator Anim_CountDown;
    [SerializeField] Text txt_CountDown;
    [SerializeField] AudioSource SFX_CountDown;
    [SerializeField] AudioClip[] m_CountDownClips;

    public void updateSpeed(float _speed)
    {
        m_SpeedText.text = _speed > 0.1f ? _speed.ToString("F1") : "0.0";
        SpeedFiller.fillAmount = (_speed * MaxSpeedFillment) / MaxSpeed;
        SpeedFiller.color = Color.Lerp(LowSpeedColor, HighSpeedColor, SpeedFiller.fillAmount / MaxSpeedFillment);
    }

    public void updateTime(int _time)
    {
        m_TimeText.text = ClockFormat(_time);
    }

    public string ClockFormat(int _time)
    {
        int Minutes = _time / 60;
        int Seconds = _time - (Minutes * 60);

        if (Seconds > 9)
            return "0" + Minutes + ":" + Seconds;
        else
            return "0" + Minutes + ":0" + Seconds;
    }


    public IEnumerator ShowCountDown()
    {
        for (int i = 3; i >= 0; i--){
            txt_CountDown.text = i.ToString("F0"); ;
            Anim_CountDown.Play("ShowNumber");

            yield return new WaitForSeconds(1.0f);
            SFX_CountDown.clip = m_CountDownClips[i];
            SFX_CountDown.Play();
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1.0f);
    }

}