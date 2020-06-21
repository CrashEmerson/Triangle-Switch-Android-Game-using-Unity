using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkDealer : MonoBehaviour
{
    [SerializeField] GameObject Triangle;
    [SerializeField] GameObject Ball;
    [SerializeField] TrailRenderer Trail;
    TriangleMovement triangleMovement;

    private void Start()
    {
        triangleMovement = FindObjectOfType<TriangleMovement>();
    }
    public void ShrinkTriangle()
    {
        Triangle.transform.localScale = new Vector2(Triangle.transform.localScale.x - 0.1f, Triangle.transform.localScale.y - 0.1f);
        SpeedUpTriangle();
    }
    private void Update()
    {
        if(Triangle.transform.localScale.x < 0.7f)
        {
            if(Ball != null) Ball.transform.localScale = new Vector2(0.23f, 0.23f);
            if(Trail != null) Trail.startWidth = 0.3f;
        }
    }

    void SpeedUpTriangle()
    {
        triangleMovement.UpdateTriangleRotateSpeed();
    }
}