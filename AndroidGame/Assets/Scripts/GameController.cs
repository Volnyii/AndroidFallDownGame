using System;
using UnityEngine;

public enum ObjectType
{
    Airplane,
    Chicken,
    Cloud
}


public class GameController
{
    public SessionInfo Info;

    public GameController()
    {
        Info = new SessionInfo();
    }
}

public class SessionInfo
{
    public ScoreInfo ScoreInfo;

    public SessionInfo()
    {
        ScoreInfo = new ScoreInfo();
    }
}

public class ScoreInfo
{
    public int Score;
    public event Action<int> OnScoreChanged;

    public void ChangeScore(int postCollisionValue, ObjectType objectType)
    {
        if (objectType == ObjectType.Airplane)
        {
            Score -= postCollisionValue;   
        }
        else if (objectType == ObjectType.Chicken)
        {
            Score += postCollisionValue;   
        }

        if (Score < 0)
            Score = 0;
        OnScoreChanged?.Invoke(Score);
    }
}
