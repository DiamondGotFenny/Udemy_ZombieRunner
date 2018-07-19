using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {
    [Tooltip("Number of minutes that pass per second in game")]
    public float minutesPerSecond;

    private Vector3 sunRotatePerSecond;
    void Start()
    {
        sunRotatePerSecond = Vector3.right * 0.25f * minutesPerSecond;
    }
    void Update()
    {
        transform.Rotate(sunRotatePerSecond * Time.deltaTime);
    }
}
