using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class testSceneScript : MonoBehaviour
{
    private RhythmManagerScript manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //manager = GameObject.FindGameObjectWithTag("RhythmManager").GetComponent<RhythmManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("PaperMinigame");
        }

    }
}
