using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    public float baseSpeed;
    [HideInInspector] public float speed;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Vector2 startingPosition;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;

    public bool Grounded => Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer) != null;
    private void Start()
    {
        startingPosition = transform.localPosition;
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Time.frameCount <= 3)
        {
            return;
        }
        // Reset velo  city
        playerRigidbody.velocity *= new Vector2(0, 1);

        // Check inputs
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.velocity += Vector2.left * speed;
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.velocity += Vector2.right * speed;
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.W) && Grounded)
        {
            playerRigidbody.velocity *= new Vector2(1, 0);
            playerRigidbody.velocity += jumpVelocity * Screen.currentResolution.height * Vector2.up / Screen.height;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Kill()
    {
        Debug.Log($"player death");
        transform.localPosition = startingPosition;
    }
}
