using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    public const string RotationInputAxis = "Rotate";
    public const string ThrustInputAxis = "Thrust";

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }
}
