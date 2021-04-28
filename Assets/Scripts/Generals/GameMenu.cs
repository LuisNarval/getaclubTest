using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] CanvasGroup m_Black;
    [SerializeField] CanvasGroup m_WinScreen;
    [SerializeField] CanvasGroup m_LooseScreen;
    [SerializeField] Text m_Score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void Continue()
    {
        PlayerPrefs.SetString("NEXTSCENE", "MainMenu");
        StartCoroutine(FadeOut());
    }

    public void Restart()
    {
        PlayerPrefs.SetString("NEXTSCENE", "GameMenu");
        StartCoroutine(FadeOut());
    }

    public void Exit()
    {
        PlayerPrefs.SetString("NEXTSCENE", "Exit");
        StartCoroutine(FadeOut());
    }

    public void Show_WinScreen()
    {
        StartCoroutine(ShowScreen(m_WinScreen));
    }

    public void Show_LoseScreen()
    {
        StartCoroutine(ShowScreen(m_LooseScreen));
    }

    IEnumerator FadeOut()
    {
        m_Black.alpha = 0.0f;
        m_Black.blocksRaycasts = true;
        while (m_Black.alpha < 1.0f)
        {
            m_Black.alpha += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_Black.alpha = 1.0f;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator FadeIn()
    {
        m_Black.alpha = 1.0f;
        m_Black.blocksRaycasts = true;

        yield return new WaitForSeconds(1.0f);

        while (m_Black.alpha > 0.0f)
        {
            m_Black.alpha -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        m_Black.alpha = 0.0f;
        m_Black.blocksRaycasts = false;
    }


    IEnumerator ShowScreen(CanvasGroup _Canvas)
    {
        _Canvas.alpha = 0.0f;
        _Canvas.blocksRaycasts = false;

        while (_Canvas.alpha < 1.0f)
        {
            _Canvas.alpha += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _Canvas.alpha = 1.0f;
        _Canvas.blocksRaycasts = true;
    }


    public void SetScore(string _TimeString, int _TimeInt)
    {
        m_Score.text = _TimeString;
    }


}