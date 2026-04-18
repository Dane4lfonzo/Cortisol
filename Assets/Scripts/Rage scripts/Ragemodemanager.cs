using UnityEngine;

public class RageModeManager : MonoBehaviour
{
    public PressureMeterUI pressureMeter;
    public CameraShake cameraShake;
    public PlayerRageTarget playerRageTarget;
    public EnemyAiScript[] enemies;

    public bool rageModeActive = false;

    [Header("Rage Timer")]
    public float rageDuration = 5f;   // how long rage lasts
    private float rageTimer = 0f;

    void Update()
    {
        if (!rageModeActive && pressureMeter.currentPressure >= pressureMeter.maxPressure)
        {
            ActivateRageMode();
        }

        if (rageModeActive)
        {
            rageTimer += Time.deltaTime;

            if (rageTimer >= rageDuration)
            {
                EndRageMode();
            }
        }
    }

    void ActivateRageMode()
    {
        rageModeActive = true;
        rageTimer = 0f;

        StartCoroutine(cameraShake.Shake(0.4f, 0.15f));

        // enable player rage pull
        playerRageTarget.rageModeActive = true;

        // stop all enemies from chasing
        foreach (EnemyAiScript enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.enabled = false;
            }
        }

        Debug.Log("RAGE MODE ACTIVATED");
    }

    void EndRageMode()
    {
        rageModeActive = false;
        rageTimer = 0f;

        // stop player rage pull
        playerRageTarget.rageModeActive = false;

        // let enemies work again
        foreach (EnemyAiScript enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.enabled = true;
            }
        }

        // reset pressure meter
        pressureMeter.currentPressure = 0f;

        Debug.Log("RAGE MODE ENDED");
    }
}