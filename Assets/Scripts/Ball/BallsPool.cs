using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallsPool : MonoBehaviour
{
    private static IObjectPool<Ball> ballsPool = null;

    [SerializeField] private Ball ballPrefab;
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxCapacity = 100;

    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        ballsPool = new ObjectPool<Ball>(CreateObject, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxCapacity);
    }

    private Ball CreateObject()
    {
        Ball instance = Instantiate(ballPrefab);
        instance.BallsPool = ballsPool;
        return instance;
    }

    private void OnGetFromPool(Ball ball)
    {
        ball.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Ball ball)
    {
        ball.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Ball ball)
    {
        Destroy(ball.gameObject);
    }

    public Ball SpawnBall(Vector3 spawnPoint)
    {
        if (ballsPool != null)
        {
            Ball newBall = ballsPool.Get();

            if (newBall == null)
            {
                return null;
            }

            SetupNewBall(newBall, spawnPoint);

            return newBall;

        }

        return null;
    }

    private void SetupNewBall(Ball newBall, Vector3 spawnPoint)
    {
        newBall.transform.position = spawnPoint;
    }
}
