using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] Text m_SpeedText;
    [SerializeField] Text m_TimeText;

    public void updateSpeed(float _speed)
    {
        m_SpeedText.text = _speed.ToString("F1");
    }

    public void updateTime(float _time)
    {
        m_TimeText.text = _time.ToString("F1");
    }
}