using UnityEngine;
using UnityEngine.InputSystem;

public class House : MonoBehaviour
{
    float movementX;
    float movementY;
    private float speed = 6;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        //movementY = v.y;
        Debug.Log(v);

    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;

        //transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
        //rb.LinearVelocity= new Vector2(XmoveDistance, YmoveDistance);
        rb.linearVelocityX = XmoveDistance;
    }
    //if(collision.gameObject.CompareTag(""))
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.CompareTag("ground"))
       //  {
       //      rb.AddForce(new Vector2(0, 500));
       // }

    }
}
