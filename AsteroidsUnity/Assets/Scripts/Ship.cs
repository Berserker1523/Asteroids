using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject HUD;

    Rigidbody2D rb;

    const float ShipInitialRotation = 90f;
    const float RotateDegreesPerSecond = 180f;

    Vector3 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rotate();
        FireBullet();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        Thrust();
    }

    void Rotate()
    {
        float rotationInput = Input.GetAxis(GameInitializer.RotationInputAxis);

        float rotationAmount = rotationInput * RotateDegreesPerSecond * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);

        float eulerAnglesZRad = (transform.eulerAngles.z + ShipInitialRotation) * Mathf.Deg2Rad;
        thrustDirection.x = Mathf.Cos(eulerAnglesZRad);
        thrustDirection.y = Mathf.Sin(eulerAnglesZRad);
    }

    void Thrust()
    {
        if (Input.GetAxis(GameInitializer.ThrustInputAxis) > 0)
        {
            rb.AddForce(thrustDirection * ThrustForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Asteroid"))
        {
            HUD.GetComponent<HUD>().StopGamerTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
        }
    }

    void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);
        }
    }
}
