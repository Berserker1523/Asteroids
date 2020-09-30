using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Vector3 position = transform.position;

        if (position.x > ScreenUtils.ScreenRight || position.x < ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
        }

        if (position.y > ScreenUtils.ScreenTop || position.y < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        transform.position = position;

    }
}
