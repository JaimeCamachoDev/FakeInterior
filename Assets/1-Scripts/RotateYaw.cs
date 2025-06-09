using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYaw : MonoBehaviour
{
    public enum Axis { X, Y, Z }
    public enum Direction { Positive = 1, Negative = -1 }

    [Header("Rotation Settings")]
    public Axis rotationAxis = Axis.Y;
    public Direction rotationDirection = Direction.Positive;
    public float speed = 90f;

    void Update()
    {
        float signedSpeed = speed * (int)rotationDirection;
        Vector3 rotationVector = GetRotationVector(rotationAxis, signedSpeed * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(rotationVector);
    }

    private Vector3 GetRotationVector(Axis axis, float value)
    {
        return axis switch
        {
            Axis.X => new Vector3(value, 0f, 0f),
            Axis.Y => new Vector3(0f, value, 0f),
            Axis.Z => new Vector3(0f, 0f, value),
            _ => Vector3.zero
        };
    }
}
