using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointGenerator : MonoBehaviour
{
    public GameObject point;
    public GameObject player;
    private List<Vector3> pathList;
    private GameObject currentPoint;

    void Start()
    {
        pathList = GeneratePathList();
        GeneratePoint();
    }

    void Update()
    {
        // point disappears after colliding, then generate new point
        Debug.Log(Vector3.Distance(player.transform.position, currentPoint.transform.position));
        if (Vector3.Distance(player.transform.position, currentPoint.transform.position) < 3.0f)
        {
            Destroy(currentPoint);
            GeneratePoint();
        }
    }

    List<Vector3> GeneratePathList()
    {
        GameObject[] ForkList = GameObject.FindGameObjectsWithTag("Fork");
        List<Vector3> pathList = new List<Vector3>();

        for (int i = 0; i < ForkList.Length; i++)
        {
            for (int j = i + 1; j < ForkList.Length; j++)
            {
                pathList.Add(ForkList[i].transform.position);
                pathList.Add(ForkList[j].transform.position);
            }
        }

        return pathList;
    }

    void GeneratePoint()
    {
        int randomIndex = Random.Range(0, pathList.Count / 2) * 2;
        Vector3 startPoint = pathList[randomIndex];
        Vector3 endPoint = pathList[randomIndex + 1];
        float t = Random.Range(0f, 1f);
        Vector3 spawnPosition = Vector3.Lerp(startPoint, endPoint, t);
        currentPoint = Instantiate(point, spawnPosition, Quaternion.identity);
    }

    // test
}
