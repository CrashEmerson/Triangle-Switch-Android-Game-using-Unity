using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    float rotateSpeed;

    [SerializeField] LevelScript level;

    private void Start()
    {
        rotateSpeed = level.GetTriangleRotateSpeed();
    }
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);   //triangle rotate
    }

    public void UpdateTriangleRotateSpeed()
    {
        rotateSpeed = rotateSpeed + 20f;
    }
}