using UnityEngine;

public class CompanionSend : MonoBehaviour
{
    [Header("Test Target")]
    public Transform testTarget;

    [Header("Return Point")]
    public Transform homePoint;

    [Header("Controls")]
    public KeyCode sendKey = KeyCode.E;

    [Header("Movement")]
    public float flySpeed = 5f;
    public float stopDistance = 0.4f;

    [Header("Cooldown")]
    public float cooldownDuration = 3f;
    public float cooldownTimer = 0f;

    [Header("State")]
    public bool isFlying = false;
    public bool isReturning = false;

    void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(sendKey) && !isFlying && !isReturning && cooldownTimer <= 0f)
        {
            isFlying = true;
        }

        if (isFlying && testTarget != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                testTarget.position,
                flySpeed * Time.deltaTime
            );

            float distance = Vector2.Distance(transform.position, testTarget.position);

            if (distance <= stopDistance)
            {
                Debug.Log("Reached target!");

                EnemyDistract distract = testTarget.GetComponent<EnemyDistract>();
                if (distract != null)
                {
                    distract.Distract();
                }

                isFlying = false;
                isReturning = true;

                // start cooldown after successful use
                cooldownTimer = cooldownDuration;
            }
        }

        if (isReturning && homePoint != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                homePoint.position,
                flySpeed * Time.deltaTime
            );

            float distance = Vector2.Distance(transform.position, homePoint.position);

            if (distance <= stopDistance)
            {
                isReturning = false;
            }
        }
    }
}