using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    const float MinImpulseForce = 2f;
    const float MaxImpulseForce = 5f;

    const float RotateDegreesPerSecond = 180f;

    [SerializeField]
    Sprite[] asteroids;

    CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();

        GetComponent<SpriteRenderer>().sprite = asteroids[Random.Range(0, asteroids.Length)];
    }

    void Update()
    {
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);
    }

    public void Initialize(Direction direction, Vector3 initLocation)
    {
        transform.position = initLocation;

        float angle = Random.Range(-45, 45);
        switch (direction)
        {
            case Direction.Up:
                angle += 90;
                break;

            case Direction.Right:
                break;

            case Direction.Left:
                angle += 180;
                break;

            case Direction.Down:
                angle += 270;
                break;

        }
        angle *= Mathf.Deg2Rad;
        StartMoving(angle);

    }


    public void StartMoving(float angle)
    {
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float force = Random.Range(MinImpulseForce, MaxImpulseForce);

        GetComponent<Rigidbody2D>().AddForce(moveDirection * force, ForceMode2D.Impulse);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            AudioManager.Play(AudioClipName.AsteroidHit);

            if (gameObject.transform.localScale.x <= 0.1f)
            {
                Destroy(gameObject);
            }
            else
            {
                Vector3 asteroidLocalScale = transform.localScale;
                asteroidLocalScale /= 2;
                transform.localScale = asteroidLocalScale;

                circleCollider.radius /= 2;

                for (int i = 0; i < 2; i++)
                {
                    Asteroid newAsteroid = Instantiate(gameObject).GetComponent<Asteroid>();
                    float angle = Random.Range(0, 2 * Mathf.PI);
                    newAsteroid.StartMoving(angle);
                }

                Destroy(gameObject);
            }
        }
    }
}
