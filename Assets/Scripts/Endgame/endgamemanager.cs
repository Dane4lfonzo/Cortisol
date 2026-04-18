using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject endingCompleteJob;
    public GameObject endingKillSomeone;
    public GameObject endingTimeUp;

    private bool gameEnded = false;

    public void ShowCompleteJobEnding()
    {
        if (gameEnded) return;
        gameEnded = true;

        endingCompleteJob.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowKillSomeoneEnding()
    {
        if (gameEnded) return;
        gameEnded = true;

        endingKillSomeone.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowTimeUpEnding()
    {
        if (gameEnded) return;
        gameEnded = true;

        endingTimeUp.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        // temporary test keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowCompleteJobEnding();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowKillSomeoneEnding();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowTimeUpEnding();
        }
    }
}