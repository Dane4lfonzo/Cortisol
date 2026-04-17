using UnityEngine;
using UnityEngine.InputSystem;

public class TapCircleScriptRight : MonoBehaviour
{
    private bool isObjectInCircle;
    private GameObject objectToDestroy;
    ScoreScript Scores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scores = GameObject.FindGameObjectWithTag("ScoreScript").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        destroyObjectOnPress();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isObjectInCircle = true;
        objectToDestroy = collision.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isObjectInCircle = false;
    }

    void destroyObjectOnPress()
    {
        if (isObjectInCircle && Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            Destroy(objectToDestroy);
            Scores.AddScore(1);
        }
    }
}
