using UnityEngine;

public class LightLogic : MonoBehaviour
{
    [SerializeField] private Sprite lightOnSprite;
    [SerializeField] private ButtonLogic button;
    [SerializeField] private bool reverseLight;
    private SpriteRenderer spriteRenderer;
    private Sprite lightOffSprite;

    [HideInInspector]
    public bool LightOn
    {
        get
        {
            if (!reverseLight)
            {
                return button.ButtonPushed;
            }
            else
            {
                return !button.ButtonPushed;
            }
        }
    }
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lightOffSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        if (LightOn)
        {
            spriteRenderer.sprite = lightOnSprite;
        }
        else
        {
            spriteRenderer.sprite = lightOffSprite;
        }
    }
}
