using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFlux : MonoBehaviour
{
    [SerializeField] CanvasGroup m_Black;
    [SerializeField] CanvasGroup m_Title;
    [SerializeField] CanvasGroup m_Menu;
    [SerializeField] CanvasGroup m_Scores;

    private bool OpenMenu = false;
    
    private void Start()
    {
        m_Title.alpha = 1;
        m_Menu.alpha = 0;
        m_Menu.blocksRaycasts = false;
        m_Scores.alpha = 0;
        m_Scores.blocksRaycasts = false;
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        if (!OpenMenu){
            if (Input.anyKey){
                OpenMenu = true;
                StartCoroutine(ChangePage(m_Title, m_Menu));
            }

        }
    }

    public void Play()
    {
        StartCoroutine(C_Play());
    }

    public void Exit()
    {
        StartCoroutine(C_Exit());
    }

    public IEnumerator C_Play() 
    {
        yield return StartCoroutine("FadeOut");
        PlayerPrefs.SetString("NEXTSCENE", "Gameplay");
        SceneManager.LoadScene("Loading");
    }


    public IEnumerator C_Exit()
    {
        yield return StartCoroutine("FadeOut");
        Application.Quit();
    }



    public void ShowScores()
    {
        StartCoroutine(ChangePage(m_Menu, m_Scores));
    }

    public void ShowMenu()
    {
        StartCoroutine(ChangePage(m_Scores, m_Menu));
    }



    IEnumerator ChangePage(CanvasGroup _past, CanvasGroup _new)
    {
        _past.blocksRaycasts = false;
        while (_past.alpha > 0.0f)
        {
            _past.alpha -= Time.deltaTime;
            _new.alpha += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _new.alpha = 1.0f;
        _new.blocksRaycasts = true;
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



}