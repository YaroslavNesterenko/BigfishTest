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

    [Inject]
    private void Construct(BallsPool pool)
    {
        ballsPool = pool;
    }

    private void Start()
    {
        rand = new System.Random(gameObject.GetInstanceID());
    }

    public void SpawnBall()
    {
        newSpawnPoint = ChooseRandomSpawnPoint();
        ballsPool.SpawnBall(newSpawnPoint.position);
    }

    private Transform ChooseRandomSpawnPoint()
    {
        newSpawnPointIndex = rand.Next(ballSpawnPoints.Length);
        return ballSpawnPoints[newSpawnPointIndex];
    }
}
