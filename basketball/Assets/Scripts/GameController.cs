using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ballPrefab;
    public GameObject hoop;

    public IntVariable points;
    public IntVariable ballsLeft;

    public int startingBalls = 3;

    int streak = 0;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        OnGameStart();
    }

    public void OnGameStart ()
    {
        ballsLeft.Value = startingBalls;
        points.Value = 0;
        streak = 0;

        Instantiate(ballPrefab, ballPos.position, Quaternion.identity);
    }

    public void OnBallDestroyed ()
    {
        Instantiate(ballPrefab, ballPos);
    }

    public void OnPointScored ()
    {
        //Point celebration
        //Add point
        points.Value++;
        points.Raise();

        if (streak == 3)
        {
            streak = 0;
            ballsLeft.Value++;
        }

        StartCoroutine(DisplaceHoop());
    }

    IEnumerator DisplaceHoop ()
    {
        yield return new WaitForSeconds(1f);
        hoop.transform.position = (Vector2)cam.ViewportToWorldPoint(new Vector3(Random.Range(0.4f, 0.9f), Random.Range(0.1f, 0.75f)));
    }
}
