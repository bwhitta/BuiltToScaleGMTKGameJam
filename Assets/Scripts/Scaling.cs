using UnityEngine;

public class Scaling : MonoBehaviour
{
    // Fields
    private Vector2 characterScale;

    // Properties
    private Vector2 RelativeCharacterSize => characterScale * (ResolutionManager.height / Screen.height);

    // Monobehavior Methods
    private void Start()
    {
        characterScale = transform.localScale;
    }
    private void Update()
    {
        transform.localScale = new Vector3(RelativeCharacterSize.x, RelativeCharacterSize.y, transform.localScale.z);
    }
}