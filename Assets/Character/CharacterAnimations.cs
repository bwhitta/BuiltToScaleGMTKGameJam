using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Sprite jumpUp, jumpNeutral, jumpDown;
    [SerializeField] private float jumpNeutralRange;
    [SerializeField] private Sprite[] idleAnimation;
    [SerializeField] private Sprite[] runningAnimation;

    [SerializeField] private int idleUpdateFrames, runningUpdateFrames;

    [SerializeField] private float allowableVelocityDiscrepancy;
    private int timeSinceLastIdleFrame, timeSinceLastRunFrame;

    private CharacterControls characterControls;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private int framesRunning, framesIdle;

    private void Start()
    {
        characterControls = GetComponent<CharacterControls>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!characterControls.Grounded)
        {
            if (body.velocity.y > jumpNeutralRange * body.gravityScale)
            {
                spriteRenderer.sprite = jumpUp;
            }
            else if (body.velocity.y < -jumpNeutralRange * body.gravityScale)
            {
                spriteRenderer.sprite = jumpDown;
            }
            else
            {
                spriteRenderer.sprite = jumpNeutral;
            }
        }
        else
        {
            if(body.velocity.x > allowableVelocityDiscrepancy || body.velocity.x < -allowableVelocityDiscrepancy)
            {
                // Reset idle animation info
                framesIdle = 0;
                timeSinceLastIdleFrame = idleUpdateFrames;

                if (timeSinceLastRunFrame > runningUpdateFrames)
                {
                    timeSinceLastRunFrame = 0;

                    // Go to next frame
                    framesRunning++;
                    spriteRenderer.sprite = runningAnimation[framesRunning % runningAnimation.Length];
                }

                // Tick towards next running frame
                timeSinceLastRunFrame++;

            }
            else
            {
                // Reset run animation info
                framesRunning = 0;
                timeSinceLastRunFrame = runningUpdateFrames;

                if (timeSinceLastIdleFrame > idleUpdateFrames)
                {
                    timeSinceLastIdleFrame = 0;

                    // Go to next frame
                    framesIdle++;
                    spriteRenderer.sprite = idleAnimation[framesIdle % idleAnimation.Length];
                }
                // Tick towards next idle frame
                timeSinceLastIdleFrame++;
            }
        }
    }
}
