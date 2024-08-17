using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private float speed, jumpVelocity;
    private Rigidbody2D _playerRigidbody;
    private Rigidbody2D PlayerRigidbody
    {
        get
        {
            if (_playerRigidbody == null)
            {
                _playerRigidbody = GetComponent<Rigidbody2D>();
            }
            return _playerRigidbody;
        }
    }

    private bool Grounded => PlayerRigidbody.velocity.y == 0;
    
    void Update()
    {
        // Reset velocity
        PlayerRigidbody.velocity *= new Vector2(0, 1);
        
        // Check inputs
        if (Input.GetKey(KeyCode.A))
        {
            PlayerRigidbody.velocity += Vector2.left * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
             PlayerRigidbody.velocity += Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.W) && Grounded)
        {
            PlayerRigidbody.velocity += jumpVelocity * Screen.currentResolution.height * Vector2.up/Screen.height;
        }
    }
}
