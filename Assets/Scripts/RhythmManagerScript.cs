using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmManagerScript : MonoBehaviour
{
    private int scoreCount;
    private static int paperCount = 0;
    private float sceneSwitchTimer;
    private float switchDuration = 2;
    public Text scoreText;
    private bool switchingScene = false;
    private int[] achieveValues = {20, 30, 40};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        LevelComplete();
    }

    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
        scoreText.text = scoreCount.ToString();
    }

    public void AddPaperCount(int paperToAdd)
    {
        paperCount += paperToAdd;
    }

    public bool haltGame()
    {
        return false;
    }

    public int GetPaperCount()
    {
        return paperCount;
    }

    public int GetScoreCount()
    {
        return scoreCount;
    }

    public bool GetSwitchingSceneBool()
    {
        return switchingScene;
    }

    void LevelComplete()
    {
        if (scoreCount >= achieveValues[paperCount])
        {
            switchingScene = true;
            sceneSwitchTimer += Time.deltaTime;
        
            if (sceneSwitchTimer >= switchDuration)
            {
                sceneSwitchTimer = 0;
                scoreCount = 0;
                AddPaperCount(1);
                switchingScene = false;
                SceneManager.LoadScene("Map");
                
            }
            
        }
    }
}
