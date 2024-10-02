using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ThrowBallButton : MonoBehaviour
{
    private Button throwBallButton;
    private BallSpawner ballsSpawner;

    [Inject]
    private void Construct(BallSpawner spawner)
    {
        ballsSpawner = spawner;
    }

    private void Awake()
    {
        throwBallButton = GetComponent<Button>();
        throwBallButton.onClick.AddListener(ThrowBall);
    }

    private void ThrowBall()
    {
        ballsSpawner.SpawnBall();
    }
}
