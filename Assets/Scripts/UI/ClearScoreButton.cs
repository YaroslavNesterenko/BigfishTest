using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClearScoreButton : MonoBehaviour
{
    private Button clearScoreButton;
    private GameScoreContainer gameScoreContainer;

    [Inject]
    private void Construct(GameScoreContainer container)
    {
        gameScoreContainer = container;
    }

    private void Awake()
    {
        clearScoreButton = GetComponent<Button>();
        clearScoreButton.onClick.AddListener(ClearScore);
    }

    private void ClearScore()
    {
        gameScoreContainer.ClearScore();
    }
}
