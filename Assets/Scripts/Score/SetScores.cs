using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScores : MonoBehaviour
{
    Score CurrentScore;
    ScoreTable Table;

    public void AddScore(int _time, string _name)
    {
        CurrentScore = new Score();
        CurrentScore.time = _time;
        CurrentScore.name = _name;

        Table = JSONManager.LoadJSON();
        Table.ScoreList.Add(CurrentScore);

        SortTable();
        Table.ScoreList.Reverse();

        if(Table.ScoreList.Count>5)
            Table.ScoreList.Remove(Table.ScoreList[Table.ScoreList.Count - 1]);

        JSONManager.SaveJSON(Table);
    }

    public void ResetScores()
    {
        Table = new ScoreTable();
        JSONManager.SaveJSON(Table);
    }


    void SortTable()
    {
        Score aux;

        for (int i = 1; i < Table.ScoreList.Count; ++i){
            for (int j = 0; j < (Table.ScoreList.Count - i); j++){

                if (Table.ScoreList[j].time > Table.ScoreList[j + 1].time){
                    aux = Table.ScoreList[j];
                    Table.ScoreList[j] = Table.ScoreList[j + 1];
                    Table.ScoreList[j + 1] = aux;
                }
            }
        }
    }

    
}