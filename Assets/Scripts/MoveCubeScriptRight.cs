using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveCubeScriptRight : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    [SerializeField] float speedModifier;
    private bool isObjectInCircle;
    private RhythmManagerScript manager;
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("RhythmManager").GetComponent<RhythmManagerScript>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
        Boundary();
        destroyObjectOnPress();
    }

    void ColorFadeOut()
    {
        Color tempColor = sprite.color;

        tempColor.a -= 1 * Time.deltaTime;

        tempColor.a = Mathf.Max(tempColor.a, 0);

        sprite.color = tempColor;
    }

    void MoveCube()
    {
        myRigidbody.linearVelocity = new Vector2(-(speedModifier), myRigidbody.linearVelocityY);
    }

    void Boundary()
    {
        if (transform.position.x <= 0.5)
        {
            myRigidbody.gravityScale = 1;
            ColorFadeOut();
        }

        if (sprite.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isObjectInCircle = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isObjectInCircle = false;
    }

    void destroyObjectOnPress()
    {
        if (isObjectInCircle && Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            manager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
