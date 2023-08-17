using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    private void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
