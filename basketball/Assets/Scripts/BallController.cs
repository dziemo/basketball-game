using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameEvent ballDestroyed;

    public float maxThrow = 50f;
    public float forceMultiplier = 10f;
    
    Camera cam;
    Rigidbody2D rb;
    Vector2 anchorPos;
    LaunchArcRenderer launchArcRenderer;
    Collider2D coll;

    bool isLaunched = false;

    private void Start()
    {
        cam = Camera.main;
        launchArcRenderer = GetComponent<LaunchArcRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
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
                var force = Vector2.Distance(anchorPos, currMousePos);

                rb.isKinematic = false;
                coll.enabled = true;
                rb.velocity = (anchorPos - currMousePos).normalized * Mathf.Clamp(force * forceMultiplier, 0f, maxThrow);
                rb.MoveRotation(forceMultiplier * Random.Range(-2, 2));
                isLaunched = true;
                launchArcRenderer.DisableArc();
                ballDestroyed.Raise();
            }
        }

        var camPos = cam.WorldToViewportPoint(transform.position);

        if (camPos.x < 0 || camPos.x > 1 || camPos.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
