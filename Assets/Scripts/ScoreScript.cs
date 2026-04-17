using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int testscore_boxescaptured;
    public int howManySpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scorevalue)
    {
        testscore_boxescaptured += scorevalue;
        Debug.Log("Captures Count: " + testscore_boxescaptured);
    }

    public void AddCountSpawn(int spawnvalue)
    {
        howManySpawn += spawnvalue;
        Debug.Log("Spawn Count: " + howManySpawn);
    }
}
