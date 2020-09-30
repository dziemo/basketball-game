using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ballPrefab;

    private void Start()
    {
        Instantiate(ballPrefab, ballPos.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(ballPrefab, ballPos);
        }
    }
}
