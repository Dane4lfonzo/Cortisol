using UnityEngine;

public class MoveCubeScript : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
    }

    void MoveCube()
    {
        myRigidbody.linearVelocity = new Vector2(10, 0);
    }
}
