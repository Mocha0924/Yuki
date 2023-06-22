using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] int PLAYER_SPEED_MAX;
    public float player_addPower;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity += new Vector2(1, 0);
            rb.AddForce(transform.right * -player_addPower*Time.deltaTime);
            if(rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x*-1,0);
            }
            rb.velocity = new Vector2(
                rb.velocity.x * 1000, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity += new Vector2(-1, 0);
            rb.AddForce(transform.right * player_addPower * Time.deltaTime);
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * -1, 0);
            }
            rb.velocity = new Vector2(
                rb.velocity.x * 1000, 0);

        }
        float horizontalSpeed = (float)Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2));
       
        if (horizontalSpeed > PLAYER_SPEED_MAX)
        {
            rb.velocity = new Vector2(
                rb.velocity.x / (horizontalSpeed / PLAYER_SPEED_MAX),0
                
            );
        }
    }
}
