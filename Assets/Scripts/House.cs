using UnityEngine;
using UnityEngine.InputSystem;

public class House : MonoBehaviour
{
    float movementX;
    float movementY;
    bool jumping = false;
    bool touchingGround;

    [SerializeField] float speed = 6f;
    [SerializeField] float jumpPower = 5f;

    private Animator animator;


    [SerializeField] Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", movementX != 0f);

    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
        Debug.Log(v);

    }

    void OnJump()
    {
    if (touchingGround)
            {
            jumping = true;
            }   

    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed;
        float YmoveDistance = movementY * speed;

        rb.linearVelocityX = XmoveDistance;
        
        if (touchingGround && jumping)
        {
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            jumping = false;
        }
        
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = true;
            
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            touchingGround = false;
        }
    }


}
