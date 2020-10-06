using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{
    public GameEvent pointScored;
    
    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (collision.attachedRigidbody.velocity.y < 0)
            {
                collision.GetComponent<BallController>().OnPointScored();
                pointScored.Raise();
            }
        }
    }
}
