using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPosition : PlayerMovement
{

    void Update()
    {
        CameraRot();
    }
    private void CameraRot()
    {
        // ici juste le up and down rotation
        Vector2 rotateAmount = cameraRotation.ReadValue<Vector2>();
        // rotate = Mathf.Clamp(rotate - rotateAmount.y * cameraSpeed * Time.deltaTime, -89f, 89f);
        verticalRotate = verticalRotate - rotateAmount.y * cameraSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(verticalRotate, 0f, 0f); // On utilise Euler pour multiplier rotate
    }
}
