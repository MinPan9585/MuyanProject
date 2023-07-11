using System.Collections.Generic;
using UnityEngine;

public class RandomPointsGenerator : MonoBehaviour
{
    public int pointCount = 10;
    public float cubeSize = 10.0f;
    public GameObject pointPrefab;
    public Material lineMaterial;

    private List<GameObject> points;

    void Start()
    {
        points = new List<GameObject>();

        for (int i = 0; i < pointCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-cubeSize / 2, cubeSize / 2),
                                           Random.Range(-cubeSize / 2, cubeSize / 2),
                                           Random.Range(-cubeSize / 2, cubeSize / 2));
            GameObject point = Instantiate(pointPrefab, position, Quaternion.identity);
            points.Add(point);
        }

        ConnectPoints();
    }

    void ConnectPoints()
    {
        for (int i = 0; i < points.Count; i++)
        {
            int connections = Random.Range(0, 2) == 0 ? 1 : 4;
            for (int j = 0; j < connections; j++)
            {
                GameObject pointA = points[i];
                GameObject pointB = points[(i + j + 1) % points.Count];

                LineRenderer line = new GameObject("Line").AddComponent<LineRenderer>();
                line.material = lineMaterial;
                line.startWidth = 0.1f;
                line.endWidth = 0.1f;
                line.positionCount = 2;
                line.SetPosition(0, pointA.transform.position);
                line.SetPosition(1, pointB.transform.position);
            }
        }
    }
}
