using UnityEngine;

public class CharacterScale : MonoBehaviour
{
    // Fields
    [SerializeField] private Vector2 characterSize;
    [SerializeField] private float gravityPower;

    private float resolutionCheckCountdown = 0;
    [SerializeField] private int resolutionCheckFrequency;

    private float currentResolutionHeight;

    // Properties
    private Vector2 RelativeCharacterSize => characterSize * (currentResolutionHeight / Screen.height);

    private Rigidbody2D _playerRigidbody;
    private Rigidbody2D PlayerRigidbody
    {
        get
        {
            if (_playerRigidbody == null)
            {
                _playerRigidbody = GetComponent<Rigidbody2D>();
            }
            return _playerRigidbody;
        }
    }

    // Monobehavior Methods
    void Update()
    {
        resolutionCheckCountdown -= Time.deltaTime;
        if(resolutionCheckCountdown <= 0)
        {
            // For some reason Screen.currentResolution.height being in the RelativeCharacterHeight property makes things real jittery, so leave it in the update loop here.
            resolutionCheckCountdown = resolutionCheckFrequency;
            currentResolutionHeight = Screen.currentResolution.height;
        }
        
        transform.localScale = RelativeCharacterSize;
        PlayerRigidbody.gravityScale = (currentResolutionHeight / Screen.height) * gravityPower;
    }
}
