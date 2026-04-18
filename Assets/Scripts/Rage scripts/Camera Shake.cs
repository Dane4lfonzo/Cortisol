using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // YOU CAN TWEAK THESE VALUES LATER IF YOU WANT
    public float defaultDuration = 0.4f;   // how long shake lasts
    public float defaultMagnitude = 0.15f; // how strong shake is

    public IEnumerator Shake(float duration, float magnitude)
    {
        // DO NOT TOUCH THIS PART
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(
                originalPos.x + x,
                originalPos.y + y,
                originalPos.z
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}