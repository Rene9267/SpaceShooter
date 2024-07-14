using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Speed of the Asteroids")]
    public float MaxSpeed;
    public float MinSpeed;

    [Header("Rotational Speed of the Asteroids")]
    public float RotationalSpeedMin;
    public float RotationalSpeedMax;

    public Vector3 MovementDirection;

    private float rotationalSpeed;
    private float xAngle,yAngle,zAngle;
    private float asteroidSpeed;

    void Start()
    {
        //get Random Speed;
        asteroidSpeed = Random.Range(MinSpeed, MaxSpeed);

        //get Random Rotation
        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);
        rotationalSpeed = Random.Range(RotationalSpeedMin, RotationalSpeedMax);

    }

    void Update()
    {
        transform.Translate(MovementDirection * Time.deltaTime * asteroidSpeed, Space.World);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed);
    }


}
