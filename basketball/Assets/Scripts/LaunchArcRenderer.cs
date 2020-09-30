using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArcRenderer : MonoBehaviour
{
    public GameObject predictionSpritePrefab;

    public float velocity;
    public float angle;
    public int resolution;
    
    float g; //force of gravity on the y axis
    float radianAngle;

    bool isGenerated = false;

    List<GameObject> predSprites = new List<GameObject>();

    private void Awake()
    {
        g = Mathf.Abs(Physics2D.gravity.y);
    }
    
    public void RenderArc(float vel, float ang, Vector3 origin)
    {
        velocity = vel;
        angle = ang;

        var arc = CalculateArcArray();

        if (!isGenerated)
        {
            for (int i = 0; i < arc.Length; i++)
            {
                var predSprite = Instantiate(predictionSpritePrefab, origin + arc[i], Quaternion.identity);
                predSprites.Add(predSprite);
            }

            isGenerated = true;
        } else
        {
            for (int i = 0; i < predSprites.Count; i++)
            {
                predSprites[i].transform.position = origin + arc[i];
            }
        }
    }

    public void DisableArc ()
    {
        for (int i = predSprites.Count - 1; i >= 0; i--)
        {
            Destroy(predSprites[i]);
        }

        isGenerated = false;
        predSprites.Clear();
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution / 2; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }

}