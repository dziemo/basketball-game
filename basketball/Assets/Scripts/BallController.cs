using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxThrow = 50f;

    Camera cam;
    Rigidbody2D rb;
    Vector2 anchorPos;
    LaunchArcRenderer launchArcRenderer;

    bool isLaunched = false;

    private void Start()
    {
        cam = Camera.main;
        launchArcRenderer = GetComponent<LaunchArcRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (!isLaunched)
        {
            var currMousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                anchorPos = currMousePos;
            }
            else if (Input.GetMouseButton(0))
            {
                launchArcRenderer.RenderArc(Mathf.Clamp(Vector2.Distance(anchorPos, currMousePos) * 10f, 0f, maxThrow), Vector2.Angle(transform.right, (anchorPos - currMousePos).normalized), transform.position);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rb.isKinematic = false;
                rb.velocity = (anchorPos - currMousePos).normalized * Mathf.Clamp(Vector2.Distance(anchorPos, currMousePos) * 10f, 0f, maxThrow);
                isLaunched = true;
                launchArcRenderer.DisableArc();
            }
        }

        var camPos = cam.WorldToViewportPoint(transform.position);

        if (camPos.x < 0 || camPos.x > 1 || camPos.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
