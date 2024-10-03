using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    System.Random rand;

    [SerializeField] private Transform[] ballSpawnPoints;

    private Transform newSpawnPoint;
    private int newSpawnPointIndex;

    private BallsPool ballsPool;
    private GameScoreContainer gameScoreContainer;

    [Inject]
    private void Construct(BallsPool pool, GameScoreContainer container)
    {
        ballsPool = pool;
        gameScoreContainer = container;
    }

    private void Start()
    {
        rand = new System.Random(gameObject.GetInstanceID());
    }

    public void SpawnBall()
    {
        newSpawnPoint = ChooseRandomSpawnPoint();
        Ball newBall = ballsPool.SpawnBall(newSpawnPoint.position);
        SetupBall(newBall);
    }

    private Transform ChooseRandomSpawnPoint()
    {
        newSpawnPointIndex = rand.Next(ballSpawnPoints.Length);
        return ballSpawnPoints[newSpawnPointIndex];
    }

    private void SetupBall(Ball ball)
    {
        ball.SetGameScoreContainer(gameScoreContainer);
        ball.ResetCollisionFlag();
    }
}
