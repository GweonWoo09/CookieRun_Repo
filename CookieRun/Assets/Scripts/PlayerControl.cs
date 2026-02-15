using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : GameManager
{
    public float jumpForce = 3f;
    public int jumpCount = 0;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.DownArrow))
        {
            Slide(); 
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _ = Die();
        }
    }

    private void Jump()
    {
        Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpForce * -Physics.gravity.y);

        if (jumpCount < 2)
        {
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(jumpVelocity, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void Slide()
    {
        transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
    }

    public bool Die() 
    {
        Destroy(gameObject);
        return true;
    }
}
