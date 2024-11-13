using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    public Transform player; // Reference to the player object

    void Update()
    {
        // Match the CameraTarget's position to the player's position
        transform.position = player.position;
    }
}
