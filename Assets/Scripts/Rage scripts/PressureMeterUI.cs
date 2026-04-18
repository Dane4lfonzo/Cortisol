using UnityEngine;
using UnityEngine.UI;

public class PressureMeterUI : MonoBehaviour
{
    [Header("UI")]
    public Image pressureFill;

    [Header("Pressure")]
    public float currentPressure = 0f;
    public float maxPressure = 100f;
    public float changeSpeed = 30f;

    void Start()
    {
        UpdateMeter();
    }

    void Update()
    {
        // temporary testing
        if (Input.GetKey(KeyCode.E))
        {
            currentPressure += changeSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            currentPressure -= changeSpeed * Time.deltaTime;
        }

        currentPressure = Mathf.Clamp(currentPressure, 0f, maxPressure);
        UpdateMeter();
    }

    void UpdateMeter()
    {
        if (pressureFill != null)
        {
            pressureFill.fillAmount = currentPressure / maxPressure;
        }
    }

    public void AddPressure(float amount)
    {
        currentPressure = Mathf.Clamp(currentPressure + amount, 0f, maxPressure);
        UpdateMeter();
    }

    public void RemovePressure(float amount)
    {
        currentPressure = Mathf.Clamp(currentPressure - amount, 0f, maxPressure);
        UpdateMeter();
    }

    public void SetPressure(float amount)
    {
        currentPressure = Mathf.Clamp(amount, 0f, maxPressure);
        UpdateMeter();
    }
}