using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private enum EnemyMode { walk, hover }
    [SerializeField] private EnemyMode enemyMode;
    private bool movingRight = true;
    public float baseSpeed;
    [HideInInspector] public float speed;
    
    private Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform turnaroundCheck;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private bool Seen
    {
        get
        {
            float[] screenArea = ScreenArea();
            Debug.Log($"screen left: {screenArea[0]}, screen top: {screenArea[1]}, screen right: {screenArea[2]}, screen bottom: {screenArea[3]}");
            if (transform.position.x >= screenArea[0] || transform.position.x <= screenArea[2] || transform.position.y >= screenArea[2] || transform.position.y <= screenArea[3])
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
        switch (enemyMode)
        {
            case EnemyMode.walk:
                if (Seen)
                {
                    if (movingRight)
                    {
                        body.velocity += Vector2.right * speed;
                        turnaroundCheck.localPosition = Vector2.right * ((transform.localScale.x * 0.5f) + 0.1f);
                    }
                    else
                    {
                        body.velocity += Vector2.left * speed;
                        turnaroundCheck.localPosition = Vector2.left * ((transform.localScale.x * 0.5f) + 0.1f);
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

                }
                break;
        }
        body.velocity *= new Vector2(0, 1);
        
    }

    private float[] ScreenArea()
    {
        var bounds = new float[4]
        {
            Camera.main.WorldToScreenPoint(Vector2.zero).x,
            Camera.main.WorldToScreenPoint(Vector2.zero).y,
            Camera.main.WorldToScreenPoint(new Vector2(Screen.width, Screen.height)).x,
            Camera.main.WorldToScreenPoint(new Vector2(Screen.width, Screen.height)).y,
        };
        return bounds;
    }
}
