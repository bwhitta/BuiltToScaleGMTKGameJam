using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private enum EnemyMode { walk, hover }
    [SerializeField] private EnemyMode enemyMode;
    private bool movingRight = true;
    public float baseSpeed;
    [HideInInspector] public float speed;
    private Sprite movingSprite;

    [Header("Only if walking")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform turnaroundCheck;

    [Header("Only if flying")]
    [SerializeField] private Sprite stationarySprite;


    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        movingSprite = spriteRenderer.sprite;
    }

    private bool Seen
    {
        get
        {
            float[] screenArea = ScreenArea();
            // Debug.Log($"screen left: {screenArea[0]}, screen top: {screenArea[1]}, screen right: {screenArea[2]}, screen bottom: {screenArea[3]}");
            if (transform.position.x > screenArea[0] && transform.position.x < screenArea[2] && transform.position.y > screenArea[1] && transform.position.y < screenArea[3])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity *= new Vector2(0, 1);
        switch (enemyMode)
        {
            case EnemyMode.walk:
                if (Seen)
                {
                    if (movingRight)
                    {
                        body.velocity += Vector2.right * speed;
                        turnaroundCheck.localPosition = Vector2.right * ((boxCollider.size.x * 0.5f)/* + 0.1f*/);
                    }
                    else
                    {
                        body.velocity += Vector2.left * speed;
                        turnaroundCheck.localPosition = Vector2.left * ((boxCollider.size.x * 0.5f)/* + 0.1f*/);
                    }
                    var collision = Physics2D.OverlapCircle(turnaroundCheck.position, 0.1f, groundLayer);
                    if (collision != null)
                    {
                        movingRight = !movingRight;
                    }
                }
                break;
            case EnemyMode.hover:
                if (Seen)
                {
                    body.velocity = Vector2.up * speed;
                    spriteRenderer.sprite = movingSprite;
                }
                else 
                {
                    spriteRenderer.sprite = stationarySprite;
                }
                break;
        }
    }

    private float[] ScreenArea()
    {
        var bounds = new float[4]
        {
            Camera.main.ScreenToWorldPoint(Vector2.zero).x - (transform.lossyScale.x * boxCollider.size.x * 0.5f),
            Camera.main.ScreenToWorldPoint(Vector2.zero).y - (transform.lossyScale.y * boxCollider.size.y * 0.5f),
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x + (transform.lossyScale.x * boxCollider.size.x * 0.5f),
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y + (transform.lossyScale.y * boxCollider.size.x * 0.5f),
        };
        return bounds;
    }
}
