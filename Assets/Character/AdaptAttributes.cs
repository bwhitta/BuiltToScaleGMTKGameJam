using UnityEngine;

public class AdaptAttributes : MonoBehaviour
{
    [SerializeField] private float gravityPower;

    private Rigidbody2D playerRigidbody;
    private CharacterControls characterControls;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        characterControls = GetComponent<CharacterControls>();
    }
    void Update()
    {
        playerRigidbody.gravityScale = (ResolutionManager.height / Screen.height) * gravityPower;
        characterControls.speed = characterControls.baseSpeed * (ResolutionManager.height / Screen.height);
    }
}
