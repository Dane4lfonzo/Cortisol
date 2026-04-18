using UnityEngine;

public class RageShakeTest : MonoBehaviour
{
    // 🔴 DRAG MAIN CAMERA HERE IN INSPECTOR
    public CameraShake cameraShake;

    void Update()
    {
        // 🔵 PRESS R TO TRIGGER SHAKE
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 🟢 THESE VALUES CONTROL THE SHAKE
            StartCoroutine(cameraShake.Shake(
                0.4f,   // duration (change this if needed)
                0.15f   // strength (change this if needed)
            ));
        }
    }
}