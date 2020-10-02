using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform ballPos;
    public GameObject ballPrefab;
    public GameObject hoop;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
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
        StartCoroutine(DisplaceHoop());
    }

    IEnumerator DisplaceHoop ()
    {
        yield return new WaitForSeconds(1f);
        hoop.transform.position = (Vector2)cam.ViewportToWorldPoint(new Vector3(Random.Range(0.4f, 0.9f), Random.Range(0.1f, 0.9f)));
    }
}
