using UnityEngine;

public class Scaling : MonoBehaviour
{
    // Properties
    private Vector2 RelativeScale => Vector2.one * ResolutionManager.height / Screen.height;

    // Monobehavior Methods
    private void Update()
    {
        // Bugs out in first few frames so they are skipped.
        if (Time.frameCount > 3)
        {
            transform.localScale = new Vector3(RelativeScale.x, RelativeScale.y, transform.localScale.z);
        }
    }
}