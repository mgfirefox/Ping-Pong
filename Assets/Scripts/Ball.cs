using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    public float speed = 75.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * speed;

        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            rigidbody.velocity = Vector2.left;
        }
        else
        {
            rigidbody.velocity = Vector2.right;
        }

        rigidbody.velocity *= speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x;
        if (collision.gameObject.name == "LeftRacket")
        {
            x = 1;
        }
        else if (collision.gameObject.name == "RightRacket")
        {
           x = -1;
        }
        else { return; }
        
        float y = GetDirectionY(transform.position, collision.transform.position, collision.collider.bounds.size.y);

        var direction = new Vector2(x, y).normalized;

        rigidbody.velocity = direction * speed;
    }

    private float GetDirectionY(Vector3 ballPosition, Vector3 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
