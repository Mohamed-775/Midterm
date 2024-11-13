using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // Reference to the player
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the player
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement

    void LateUpdate()
    {
        // Calculate the target position
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Make the camera look at the player
        transform.LookAt(target);
    }
}
