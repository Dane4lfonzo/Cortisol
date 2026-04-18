using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject LeftCube;
    [SerializeField] GameObject RightCube;
    private float spawnTimerLeft;
    private float spawnTimerRight;
    [SerializeField] float spawnRateLeft;
    [SerializeField] float spawnRateRight;
    private RhythmManagerScript manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("RhythmManager").GetComponent<RhythmManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.GetSwitchingSceneBool())
        {
            SpawnCubes();  
        }

        Debug.Log(manager.GetPaperCount());
    }

    void SpawnCubes()
    {
        spawnTimerLeft += Time.deltaTime;
        spawnTimerRight += Time.deltaTime;

        if (spawnTimerLeft >= (spawnRateLeft))
        {
            Instantiate(LeftCube, new Vector2(-8, -3), transform.rotation);
            spawnTimerLeft = 0;
            spawnRateLeft = Random.Range(0.1f, 3f);
        }

        if (spawnTimerRight >= spawnRateRight)
        {
            Instantiate(RightCube, new Vector2(8, -3), transform.rotation);
            spawnTimerRight = 0;
            spawnRateLeft = Random.Range(0.1f, 3f);
        }

    }
}
