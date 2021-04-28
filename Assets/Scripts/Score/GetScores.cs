using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScores : MonoBehaviour
{
    [SerializeField] Text[] m_textNames;
    [SerializeField] Text[] m_textScores;

    // Start is called before the first frame update
    void Start()
    {
        FillScoreTable();
    }

    public void FillScoreTable()
    {
        ScoreTable m_CurrentScoreTable;
        m_CurrentScoreTable = JSONManager.LoadJSON();

        for (int i = 0; i < m_CurrentScoreTable.ScoreList.Count; i++)
        {
            if (i < 5){
                m_textNames[i].text = m_CurrentScoreTable.ScoreList[i].name;
                m_textScores[i].text = ClockFormat(m_CurrentScoreTable.ScoreList[i].time);
            }
        }
    }

    string ClockFormat(int _time)
    {
        int Minutes = _time / 60;
        int Seconds = _time - (Minutes * 60);

        if (Seconds > 9)
            return "0" + Minutes + ":" + Seconds;
        else
            return "0" + Minutes + ":0" + Seconds;
    }

}
