using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    const float ForceMagnitude = 15f;

    const float DeathTime = 1f;
    Timer timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = DeathTime;
        timer.Run();
    }

    void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        rb.AddForce(ForceMagnitude * direction, ForceMode2D.Impulse);
    }
}
