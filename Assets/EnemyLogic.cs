using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private bool movingRight = true;
    public float baseSpeed;
    [HideInInspector] public float speed;
    
    private Rigidbody2D body;
    [SerializeField] private Transform turnaround;
    [SerializeField] private int groundLayer;

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
            turnaround.localPosition = Vector2.right * transform.localScale;
        }
        else
        {
            body.velocity += Vector2.left * speed;
            turnaround.localPosition = Vector2.left * transform.localScale;
        }
        // Debug.Log($"movingRight: {movingRight}");

        Collider2D detected = Physics2D.OverlapCircle(turnaround.position, 0.01f);
        if (detected.gameObject.layer == groundLayer)
        {
            movingRight = !movingRight;
        }
        //Debug.Log($"turning around, collision: {detected}, is null {detected == null}");
    }
}
