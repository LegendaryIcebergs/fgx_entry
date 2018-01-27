using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rotate : MonoBehaviour {

    //Duration of the rotation in seconds, can be set via Inspector
    public float RotationDuration = 1f;

    //Duration of rotation of one (euler) degree in seconds
    private float RotationSpeed;

    //The angle of the right-position of camera in eulers
    public float RotationFromCenter = 60f;

    private Quaternion cameraRotation;

    private Quaternion rotationRight;

    private Quaternion rotationLeft;

    private bool _isRotating = false;

    void Start()
    {
        RotationSpeed = RotationDuration / RotationFromCenter;
        cameraRotation = this.transform.rotation;
        rotationRight = cameraRotation * Quaternion.Euler(0, RotationFromCenter, 0);
        rotationLeft = cameraRotation * Quaternion.Euler(0, -RotationFromCenter, 0);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftArrow) && !_isRotating)
        {
            turnLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !_isRotating)
        {
            turnRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !_isRotating)
        {
            turnCenter();
        }*/
    }

    IEnumerator RotateObject(Quaternion start, Quaternion end, float duration)
    {
        float endTime = Time.time + duration;
        _isRotating = true;
        while (Time.time <= endTime)
        {
            // normalized progress from 0 - 1
            float t = 1f - (endTime - Time.time) / duration;
            transform.rotation = Quaternion.Lerp(start, end, t);
            yield return 0;
        }
        transform.rotation = end;
        _isRotating = false;
    }

    public void turnLeft()
    {
        if(this.transform.rotation != rotationLeft) { 
        StartCoroutine(RotateObject(
                transform.rotation,
                rotationLeft,
                RotationSpeed * Mathf.Abs(transform.rotation.eulerAngles.y - rotationLeft.eulerAngles.y)
            ));
        }
    }

    public void turnCenter()
    {
        if (this.transform.rotation != cameraRotation)
        {
            StartCoroutine(RotateObject(
                    transform.rotation,
                    cameraRotation,
                    RotationSpeed * Mathf.Abs(transform.rotation.eulerAngles.y - cameraRotation.eulerAngles.y)
                ));
        }
    }

    public void turnRight()
    {
        if (this.transform.rotation != rotationRight)
        {
            StartCoroutine(RotateObject(
                    transform.rotation,
                    rotationRight,
                    RotationSpeed * Mathf.Abs(transform.rotation.eulerAngles.y - rotationRight.eulerAngles.y)
                ));
        }
    }
}
