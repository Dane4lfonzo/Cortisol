using Unity.VisualScripting;
using UnityEngine;

public class SquareSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject LeftCube;
    [SerializeField] GameObject RightCube;
    private float spawnTimerLeft;
    private float spawnTimerRight;
    [SerializeField] float spawnRateLeft;
    [SerializeField] float spawnRateRight;
    ScoreScript Scores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scores = GameObject.FindGameObjectWithTag("ScoreScript").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        spawnTimerLeft += Time.deltaTime;
        spawnTimerRight += Time.deltaTime;

        if (spawnTimerLeft >= spawnRateLeft)
        {
            Instantiate(LeftCube, new Vector2(-8, -3), transform.rotation);
            spawnTimerLeft = 0;
            Scores.AddCountSpawn(1);
        }

        if (spawnTimerRight >= spawnRateRight)
        {
            Instantiate(RightCube, new Vector2(8, -3), transform.rotation);
            spawnTimerRight = 0;
            Scores.AddCountSpawn(1);
        }

    }
}
