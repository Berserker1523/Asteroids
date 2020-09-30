using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    float asteroidColliderRadius;

    // Start is called before the first frame update
    void Start()
    {
        GameObject asteroid = Instantiate(prefabAsteroid);
        asteroidColliderRadius = asteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(asteroid);


        SpawnAsteroid(Direction.Left,
            ScreenUtils.ScreenRight + asteroidColliderRadius,
            (ScreenUtils.ScreenTop + ScreenUtils.ScreenBottom) / 2);

        SpawnAsteroid(Direction.Right,
            ScreenUtils.ScreenLeft - asteroidColliderRadius,
            (ScreenUtils.ScreenTop + ScreenUtils.ScreenBottom) / 2);

        SpawnAsteroid(Direction.Down,
            (ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft) / 2,
            ScreenUtils.ScreenTop + asteroidColliderRadius);

        SpawnAsteroid(Direction.Up,
            (ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft) / 2,
            ScreenUtils.ScreenBottom - asteroidColliderRadius);

    }

    void SpawnAsteroid(Direction direction, float positionX, float positionY)
    {
        GameObject asteroid2 = Instantiate(prefabAsteroid);
        Vector3 initPosition = new Vector3(positionX, positionY, -Camera.main.transform.position.z);
        asteroid2.GetComponent<Asteroid>().Initialize(direction, initPosition);
    }
}
