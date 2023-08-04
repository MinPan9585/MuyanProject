using System.Collections.Generic;
using UnityEngine;

public class generatorFork : MonoBehaviour
{
    public int numberOfPoints = 10;
    public float cubeSize = 30f;
    public float minDistanceBetweenPoints = 2f;
    public int minConnections = 1;
    public int maxConnections = 4;

    private List<Vector3> points = new List<Vector3>();
    private List<LineRenderer> lines = new List<LineRenderer>();

    void Start()
    {
        GenerateRandomPoints();
        ConnectPoints();
    }

    private void GenerateRandomPoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector3 randomPoint = new Vector3(
                Random.Range(-cubeSize / 2, cubeSize / 2),
                Random.Range(-cubeSize / 2, cubeSize / 2),
                Random.Range(-cubeSize / 2, cubeSize / 2)
            );

            bool tooClose = false;
            foreach (Vector3 point in points)
            {
                if (Vector3.Distance(point, randomPoint) < minDistanceBetweenPoints)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
            {
                points.Add(randomPoint);
            }
        }
    }

    private void ConnectPoints()
    {
        for (int i = 0; i < points.Count; i++)
        {
            int connections = Random.Range(minConnections, maxConnections + 1);

            for (int j = 0; j < connections; j++)
            {
                int targetIndex = Random.Range(0, points.Count);
                if (targetIndex != i)
                {
                    LineRenderer line = new GameObject("Line").AddComponent<LineRenderer>();
                    line.positionCount = 2;
                    line.SetPosition(0, points[i]);
                    line.SetPosition(1, points[targetIndex]);
                    line.startWidth = 0.1f;
                    line.endWidth = 0.1f;
                    lines.Add(line);
                }
            }
        }
    }
}
