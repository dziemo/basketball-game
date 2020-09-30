using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDisplayer : MonoBehaviour
{
    SpriteRenderer sr;
    LineRenderer lr;
    Camera cam;
    Vector2 anchorPos;

    private void Start()
    {
        cam = Camera.main;

        sr = GetComponent<SpriteRenderer>();
        lr = GetComponent<LineRenderer>();
        
        sr.enabled = false;
        lr.enabled = false;

        lr.positionCount = 2;
    }

    void Update()
    {
        var currMousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            sr.enabled = true;
            lr.enabled = true;

            anchorPos = currMousePos;

            transform.position = anchorPos;
            lr.SetPosition(0, anchorPos);
            lr.SetPosition(1, currMousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            lr.SetPosition(1, currMousePos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sr.enabled = false;
            lr.enabled = false;
        }
    }
}
