using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        body.velocity *= new Vector2(0, 1);
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
}
