using UnityEngine;

public class CompanionLockOn : MonoBehaviour
{
    [Header("Lock-On Settings")]
    public float lockRange = 6f;              // how far you can lock on
    public LayerMask targetLayer;             // set this to enemy/worker layer
    public KeyCode lockKey = KeyCode.Tab;     // CHANGE THIS if you want another key

    [Header("Current Target")]
    public Transform currentTarget;

    [Header("Reticle")]
    public GameObject reticleObject;          // DRAG YOUR RETICLE OBJECT HERE

    void Update()
    {
        if (Input.GetKeyDown(lockKey))
        {
            FindNearestTarget();
        }

        UpdateReticle();
    }

    void FindNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, lockRange, targetLayer);

        float closestDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (Collider2D hit in hits)
        {
            float distance = Vector2.Distance(transform.position, hit.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = hit.transform;
            }
        }

        currentTarget = nearest;

        if (currentTarget != null)
        {
            Debug.Log("Locked on: " + currentTarget.name);
        }
        else
        {
            Debug.Log("No target in range.");
        }
    }

    void UpdateReticle()
    {
        if (reticleObject == null) return;

        if (currentTarget != null)
        {
            reticleObject.SetActive(true);

            // 🔧 CHANGE THIS OFFSET IF RETICLE IS TOO HIGH/LOW
            reticleObject.transform.position = currentTarget.position + new Vector3(0f, 1f, 0f);
        }
        else
        {
            reticleObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}