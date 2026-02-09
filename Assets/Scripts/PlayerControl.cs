using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 10f;
    private int jumpCount = 0;
    
    private Rigidbody rb;

    private enum PlayerState
    {
        Grounded,
        Jumping,
        Sliding,
        TouchedObstacle
    }
    private PlayerState _playerState;

    private void Awake()
    {
        _playerState = PlayerState.Grounded;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow))
        {
            Slide();
        }
    }

    private void Jump()
    {
        if (jumpCount < 2)
        {
            jumpCount++;
            _playerState = PlayerState.Jumping;
            rb.AddForce(new Vector3 (0f, jumpForce, 0f));

            if (jumpCount == 2) 
            {
                rb.AddForce(new Vector3(0f, jumpForce, 0f));
            }
        }

        if(_playerState == PlayerState.Grounded)
        {
            jumpCount = 0;
        }
    }

    private void Slide()
    {
        rb.MovePosition(new Vector3(-1.5f, -0.25f, 0f));
    }
}
