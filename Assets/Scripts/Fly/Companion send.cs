using UnityEngine;

public class CompanionSend : MonoBehaviour
{
    [Header("References")]
    public CompanionLockOn lockOnScript;   // drag the object with CompanionLockOn here
    public Transform player;               // drag player here

    [Header("Send Settings")]
    public KeyCode sendKey = KeyCode.E;
    public float flySpeed = 5f;
    public float stopDistance = 0.4f;

    [Header("Return Settings")]
    public float returnDelay = 0.5f;

    private Transform target;
    private bool isFlyingToTarget = false;
    private bool isReturning = false;
    private float returnTimer = 0f;

    void Update()
    {
        // send companion to locked target
        if (Input.GetKeyDown(sendKey))
        {
            if (lockOnScript != null && lockOnScript.currentTarget != null && !isFlyingToTarget && !isReturning)
            {
                target = lockOnScript.currentTarget;
                isFlyingToTarget = true;
            }
        }

        // fly to target
        if (isFlyingToTarget && target != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                flySpeed * Time.deltaTime
            );

            float distance = Vector2.Distance(transform.position, target.position);

            if (distance <= stopDistance)
            {
                EnemyDistract distractScript = target.GetComponent<EnemyDistract>();

                if (distractScript != null)
                {
                    distractScript.Distract();
                }

                isFlyingToTarget = false;
                isReturning = true;
                returnTimer = returnDelay;
            }
        }

        // short pause before return
        if (isReturning && returnTimer > 0f)
        {
            returnTimer -= Time.deltaTime;
            return;
        }

        // return to player
        if (isReturning && player != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                flySpeed * Time.deltaTime
            );

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= stopDistance)
            {
                isReturning = false;
                target = null;
            }
        }
    }
}