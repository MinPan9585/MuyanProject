using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject successPanel;

    private ScoreManager scoreManager;
    private CanvasGroup successPanelCanvasGroup;

    void Start()
    {
        successPanelCanvasGroup = successPanel.transform.GetComponent<CanvasGroup>();
        // successPanel.SetActive(false);

        GameObject ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (scoreManager.currentScore >= scoreManager.targetScore)
        {
            //successPanel.SetActive(true);
            successPanelCanvasGroup.alpha = 1;
            successPanelCanvasGroup.interactable = true;
            successPanelCanvasGroup.blocksRaycasts = true;
        }
    }

    public void LoadNextLevel()
    {
        Debug.Log("here");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
