using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private GameScoreContainer gameScoreContainer;

    [Inject]
    private void Construct(GameScoreContainer container)
    {
        gameScoreContainer = container;
    }

    private void Awake()
    {
        gameScoreContainer.scoreUpdated += ShowCurrentScore;
        ShowCurrentScore();
    }

    private void ShowCurrentScore()
    {
        scoreText.text = gameScoreContainer.GetScore().ToString();
    }
}
