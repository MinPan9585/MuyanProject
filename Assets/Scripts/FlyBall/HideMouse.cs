using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || scoreManager.currentScore >= scoreManager.targetScore)
        {
            ShowMouseCursor();
        }
        else
        {
            HideMouseCursor();
        }
    }

    void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
