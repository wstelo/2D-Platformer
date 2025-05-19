using UnityEngine;
using System.Collections.Generic;

public class SpawnPointCollector : MonoBehaviour
{
    public List<Transform> TargetPoints { get; private set; } = new List<Transform>();

    private void Awake()
    {
        int pointCount = transform.childCount;

        if (pointCount == 0)
        {
            throw new System.Exception("Отсутствуют точки спавна.");
        }

        for (int i = 0; i < pointCount; i++)
        {
            TargetPoints.Add(transform.GetChild(i));
        }
    }
}
