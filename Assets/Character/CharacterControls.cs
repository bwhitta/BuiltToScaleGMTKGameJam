using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    public float baseSpeed;
    [HideInInspector] public float speed;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRigidbody;

    private bool Grounded => Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer) != null;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // Reset velo  city
        playerRigidbody.velocity *= new Vector2(0, 1);

        // Check inputs
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.velocity += Vector2.left * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.velocity += Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.W) && Grounded)
        {
            playerRigidbody.velocity *= new Vector2(1, 0);
            playerRigidbody.velocity += jumpVelocity * Screen.currentResolution.height * Vector2.up / Screen.height;
        }
    }
}
