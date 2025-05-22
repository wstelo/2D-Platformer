using UnityEngine;
using System.Collections.Generic;

public class PointCollector : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;
    public List<Transform> TargetPoints { get; private set; }

    private void Awake()
    {
        TargetPoints = _targetPoints;
    }

    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        TargetPoints = new List<Transform>();
        int pointCount = transform.childCount;

        if (pointCount == 0)
        {
            throw new System.Exception("Отсутствуют точки.");
        }

        for (int i = 0; i < pointCount; i++)
            _targetPoints.Add(transform.GetChild(i));
    }
}
