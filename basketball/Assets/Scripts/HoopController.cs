using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody)
        {
            if (collision.attachedRigidbody.velocity.y > 0)
            {
                Debug.Log("Going up - no points!");
            }  else if (collision.attachedRigidbody.velocity.y < 0)
            {
                Debug.Log("Going down - points!");
            }
        }
    }
}
