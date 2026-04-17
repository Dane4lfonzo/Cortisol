using UnityEngine;

public class MoveCubeScriptLeft : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    [SerializeField] float speedModifier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
        Boundary();
    }

    void MoveCube()
    {
        myRigidbody.linearVelocity = new Vector2(speedModifier, myRigidbody.linearVelocityY);
    }

    void Boundary()
    {
        if (transform.position.x >= -0.5)
        {
            Destroy(gameObject);
        }
    }
}
