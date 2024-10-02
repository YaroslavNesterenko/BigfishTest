using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    private IObjectPool<Ball> ballsPool;
    public IObjectPool<Ball> BallsPool { set => ballsPool = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Targets"))
        {
            ReturnBallToPool();
        }
    }

    private void ReturnBallToPool()
    {
        ballsPool.Release(this);
    }
}
