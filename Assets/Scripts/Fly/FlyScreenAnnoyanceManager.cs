using UnityEngine;
using System.Collections;

public class FlyScreenAnnoyance : MonoBehaviour
{
    [Header("UI")]
    public RectTransform bigFlyImage;   // drag your big fly UI image here

    [Header("Timing")]
    public float minDelay = 4f;
    public float maxDelay = 8f;

    [Header("Annoyance Duration")]
    public float lingerDuration = 4f;   // how long it stays on screen

    [Header("Movement Area")]
    public float moveRangeX = 600f;     // how far left/right it can wander
    public float moveRangeY = 250f;     // how far up/down it can wander
    public float moveSpeed = 4f;        // how fast it moves between points

    [Header("Companion State")]
    public CompanionSend companionSend; // drag your FLY object here

    void Start()
    {
        if (bigFlyImage != null)
        {
            bigFlyImage.gameObject.SetActive(false);
        }

        StartCoroutine(AnnoyRoutine());
    }

    IEnumerator AnnoyRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            if (companionSend != null &&
                !companionSend.isFlying &&
                !companionSend.isReturning &&
                bigFlyImage != null)
            {
                yield return StartCoroutine(LingerOnScreen());
            }
        }
    }

    IEnumerator LingerOnScreen()
    {
        bigFlyImage.gameObject.SetActive(true);

        float timer = 0f;

        // start somewhere random on screen
        bigFlyImage.anchoredPosition = GetRandomScreenPosition();

        Vector2 currentTarget = GetRandomScreenPosition();

        while (timer < lingerDuration)
        {
            timer += Time.deltaTime;

            // move toward current random point
            bigFlyImage.anchoredPosition = Vector2.Lerp(
                bigFlyImage.anchoredPosition,
                currentTarget,
                moveSpeed * Time.deltaTime
            );

            // if close enough, pick another random point
            if (Vector2.Distance(bigFlyImage.anchoredPosition, currentTarget) < 30f)
            {
                currentTarget = GetRandomScreenPosition();
            }

            yield return null;
        }

        bigFlyImage.gameObject.SetActive(false);
    }

    Vector2 GetRandomScreenPosition()
    {
        float randomX = Random.Range(-moveRangeX, moveRangeX);
        float randomY = Random.Range(-moveRangeY, moveRangeY);
        return new Vector2(randomX, randomY);
    }
}