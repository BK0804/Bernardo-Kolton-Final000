using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float distance = 5;
    [SerializeField] float minVerticleAngle = -45;
    [SerializeField] float maxVerticleAngle = 45;
    [SerializeField] Vector2 framingOffset;
    [SerializeField] bool invertX;
    [SerializeField] bool invertY;
    float rotationX;
    float rotationY;
    float invertXval;
    float invertYval;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()


    {
       

        invertXval = (invertX) ? -1 : 1;
        invertYval = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertXval * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticleAngle, maxVerticleAngle);

        rotationY += Input.GetAxis("Mouse X") * invertYval * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y, 0);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;

        
    }
    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}