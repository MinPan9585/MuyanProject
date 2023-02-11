using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    private bool slowdownPressed = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(slowdownPressed == false)
            {
                if (Time.timeScale > 0)
                {
                    Time.timeScale = 0.1f;
                    slowdownPressed = true;
                    StartCoroutine(Slowdown());
                }
            }
            
        }
    }

    IEnumerator Slowdown()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        slowdownPressed = false;
    }
}
