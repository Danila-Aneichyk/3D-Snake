using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private void Update()
    {
        CurrentCameraRotation();
    }

    private void CurrentCameraRotation()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;

        currentRotation.z = 0;

        transform.rotation = Quaternion.Euler(currentRotation);
    }
}