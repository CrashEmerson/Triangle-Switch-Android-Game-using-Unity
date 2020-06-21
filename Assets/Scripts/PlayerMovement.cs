using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
    float xmin, xmax, ymin, ymax;
    
    void Start()
    {
        transform.position = new Vector2(-3f, 3f); // Ball inital position
        SetUpBoundaries();
    }
    private void Update()
    { 
        var newXpos = Mathf.Clamp(transform.position.x , xmin, xmax);
        var newYpos = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector2(newXpos, newYpos);
        transform.localRotation = Quaternion.identity;
    }
    private void SetUpBoundaries()
    {
        Camera camera = Camera.main;
        xmin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.3f;
        xmax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.3f;
        ymin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 0.3f;
        ymax = camera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - 0.3f;
    }

}