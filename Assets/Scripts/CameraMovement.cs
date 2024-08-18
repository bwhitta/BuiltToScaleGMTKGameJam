using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float followTime = 0.3F;
    
    [SerializeField] private float zPosition;
    private Vector2 velocity = Vector2.zero;

    private void Start()
    {
        transform.position = character.position;
    }

    void Update()
    {
        Vector2 monitorCenter = new Vector2(ResolutionManager.width, ResolutionManager.height) / 2;
        Vector2 windowCenter = Screen.mainWindowPosition + (new Vector2(Screen.width, Screen.height) / 2);
        Vector2 windowOffset = (monitorCenter - windowCenter);
        windowOffset *= new Vector2(-1, 1);
        Vector2 offsetPercent = (windowOffset / ResolutionManager.Size);

        // finds the 1:X aspect ratio
        float aspectRatio = ResolutionManager.width / ResolutionManager.height;
        float cameraFullWidth = Camera.main.orthographicSize * 2 * aspectRatio;
        float cameraFullHeight = Camera.main.orthographicSize * 2;

        // Choose the target position
        float cameraTargetX = cameraFullWidth * offsetPercent.x * transform.lossyScale.x;
        float cameraTargetY =  cameraFullHeight * offsetPercent.y * transform.lossyScale.y;
        
        // Move the camera towards that position
        Vector2 position2d = Vector2.SmoothDamp(transform.position, character.position + new Vector3(cameraTargetX, cameraTargetY, 0), ref velocity, followTime);

        // The z position is locked, since it shouldn't really ever change in this game.
        transform.position = new Vector3(position2d.x, position2d.y, zPosition);
    }
}
