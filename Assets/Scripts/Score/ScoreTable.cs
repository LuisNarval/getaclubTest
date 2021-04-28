using System.Collections.Generic;

[System.Serializable]
public class ScoreTable
{
    public List<Score> ScoreList = new List<Score>();
}


[System.Serializable]
public class Score{
    public int time;
    public string name;
}

