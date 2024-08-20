using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] private Sprite buttonPushedSprite;
    private SpriteRenderer spriteRenderer;
    private Sprite buttonNormalSprite;
    private readonly int characterLayer = 6, enemyLayer = 7;
    private bool _buttonPushed;
    public bool ButtonPushed
    {
        get
        {
            return _buttonPushed;
        }
        set
        {
            if (value == true)
            {
                spriteRenderer.sprite = buttonPushedSprite;
            }
            else
            {
                spriteRenderer.sprite = buttonNormalSprite;
            }
            _buttonPushed = value;
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        buttonNormalSprite = spriteRenderer.sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == characterLayer || collision.gameObject.layer == enemyLayer)
        {
            ButtonPushed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == characterLayer || collision.gameObject.layer == enemyLayer)
        {
            ButtonPushed = false;
        }
    }
}
