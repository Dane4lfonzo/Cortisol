using UnityEngine;
using System.Collections;

public class EnemyDistract : MonoBehaviour
{
    [Header("Distract Settings")]
    public float distractDuration = 3f;

    private EnemyAiScript enemyAi;
    private Coroutine distractRoutine;

    void Awake()
    {
        enemyAi = GetComponent<EnemyAiScript>();
    }

    public void Distract()
    {
        if (distractRoutine != null)
        {
            StopCoroutine(distractRoutine);
        }

        distractRoutine = StartCoroutine(DistractRoutine());
    }

    IEnumerator DistractRoutine()
    {
        if (enemyAi != null)
        {
            enemyAi.enabled = false;
        }

        Debug.Log(gameObject.name + " is distracted!");

        yield return new WaitForSeconds(distractDuration);

        if (enemyAi != null)
        {
            enemyAi.enabled = true;
        }

        Debug.Log(gameObject.name + " is no longer distracted.");
        distractRoutine = null;
    }
}