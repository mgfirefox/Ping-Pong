using UnityEngine;

public class Racket : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    public string axisName = "Vertical";
    public float speed = 50.0f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float velocity = Input.GetAxisRaw(axisName);

        rigidbody.velocity = new Vector2(0, velocity) * speed;
    }
}
