using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicModeController : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ballPrefab;
    public GameObject hoop;

    public GameEvent gameEnd;
    public GameEvent ballSpawn;

    public IntVariable points;
    public IntVariable ballsLeft;
    public IntVariable highscore;

    public int startingBalls = 3;

    Camera cam;

    int streak = 0;

    private void Start()
    {
        cam = Camera.main;
        OnGameStart();
    }

    public void OnGameStart()
    {
        ballsLeft.Value = startingBalls;
        points.Value = 0;
        streak = 0;

        ballSpawn.Raise();
    }

    public void OnBallSpawn()
    {
        StartCoroutine(SpawnBall());
    }

    public void OnBallDestroyed()
    {
        if (ballsLeft.Value > 0)
        {
            ballSpawn.Raise();
        }
        else if (ballsLeft.Value <= 0)
        {
            if (PlayerPrefs.GetInt("Highscore", 0) < points.Value)
            {
                PlayerPrefs.SetInt("Highscore", points.Value);
            }

            highscore.Value = PlayerPrefs.GetInt("Highscore", 0);

            OnGameEnd();
        }
    }

    public void OnPointScored()
    {
        points.Value++;
        points.Raise();

        if (streak == 3)
        {
            streak = 0;
            ballsLeft.Value++;
        }

        StartCoroutine(DisplaceHoop());
    }
    
    public void OnGameEnd()
    {
        gameEnd.Raise();
    }

    IEnumerator DisplaceHoop()
    {
        yield return new WaitForSeconds(1f);
        hoop.transform.position = (Vector2)cam.ViewportToWorldPoint(new Vector3(Random.Range(0.35f, 0.85f), Random.Range(0.1f, 0.75f)));
    }

    IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(ballPrefab, ballPos);
    }
}
