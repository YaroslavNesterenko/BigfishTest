using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreContainer
{
    private int score = 0;
    public event Action scoreUpdated;


    public void AddScore()
    {
        score++;
        scoreUpdated?.Invoke();
    }

    public int GetScore() { 
        return score; 
    }

    public void ClearScore()
    {
        score = 0;
        scoreUpdated?.Invoke();
    }
}
