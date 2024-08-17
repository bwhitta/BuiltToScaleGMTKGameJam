using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float followTime = 0.3F;

    [SerializeField] private float scaledPositionY;
    [SerializeField] private float relativePositionZ;
    private Vector2 velocity = Vector2.zero;

    void Update()
    {
        //float positionY = scaledPositionY * (Screen.height / Screen.currentResolution.height); <- temporarily removed
        Vector3 relativePosition = new(0, 0/*positionY*/, relativePositionZ);

        // Choose the target position
        Vector3 targetPosition = character.TransformPoint(relativePosition);
        
        // Move the camera towards that position
        Vector2 position2d = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, followTime);
        
        // The z position is locked, since it shouldn't really ever change in this game.
        transform.position = new Vector3(position2d.x, position2d.y, relativePosition.z);
    }
}
