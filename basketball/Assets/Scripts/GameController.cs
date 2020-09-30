using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ballPrefab;
    public GameObject hoop;

    private void Start()
    {
        Instantiate(ballPrefab, ballPos.position, Quaternion.identity);
    }

    public void OnBallDestroyed ()
    {
        Instantiate(ballPrefab, ballPos);
    }

    public void OnPointScored ()
    {
        //hoop random place
    }
}
