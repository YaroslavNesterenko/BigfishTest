using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class Ball : MonoBehaviour
{
    private IObjectPool<Ball> ballsPool;
    public IObjectPool<Ball> BallsPool { set => ballsPool = value; }

    private GameScoreContainer gameScoreContainer;

    private bool isBallCanTakeCollision = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBallCanTakeCollision)
        {
            isBallCanTakeCollision = false;
            if (collision.CompareTag("Targets"))
            {
                ReturnBallToPool();
                AddScoreToGameScoreContainer();
            }

            if (collision.CompareTag("Walls"))
            {
                ReturnBallToPool();
            }
        }
    }

    private void AddScoreToGameScoreContainer()
    {
        gameScoreContainer.AddScore();
    }

    private void ReturnBallToPool()
    {
        ballsPool.Release(this);
    }

    public void SetGameScoreContainer(GameScoreContainer container)
    {
        gameScoreContainer = container;
    }

    public void ResetCollisionFlag()
    {
        isBallCanTakeCollision = true;
    }
}
