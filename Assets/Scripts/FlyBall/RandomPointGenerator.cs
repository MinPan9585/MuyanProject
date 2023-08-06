using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointGenerator : MonoBehaviour
{
    public GameObject point;
    public GameObject player;
    public float coinTriggerDistance;
    public float coinGenerateDistance;

    private List<Vector3> pathList;
    private GameObject currentPoint;
    private ScoreManager scoreManager;

    void Start()
    {
        pathList = GeneratePathList();
        GeneratePoint();
        GameObject ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (currentPoint && Vector3.Distance(player.transform.position, currentPoint.transform.position) < coinTriggerDistance)
        {
            scoreManager.AddScore(1);
            Destroy(currentPoint);
            if (scoreManager.currentScore < scoreManager.targetScore)
            {
                GeneratePoint();
            }
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
        //float t = Random.Range(0f, 1f);
        //Vector3 spawnPosition = Vector3.Lerp(startPoint, endPoint, t);
        //currentPoint = Instantiate(point, spawnPosition, Quaternion.identity);
        float minDistance = coinGenerateDistance;
        Vector3 spawnPosition = startPoint;
        bool validPosition = false;

        while (!validPosition)
        {
            float t = Random.Range(0f, 1f);
            spawnPosition = Vector3.Lerp(startPoint, endPoint, t);

            if (Vector3.Distance(spawnPosition, startPoint) >= minDistance && Vector3.Distance(spawnPosition, endPoint) >= minDistance)
            {
                validPosition = true;
            }
        }

        currentPoint = Instantiate(point, spawnPosition, Quaternion.identity);
    }
}
