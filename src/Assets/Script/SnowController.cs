using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    DestroyController _destrohcontroller;
    SnowMoveController moveController;
    [SerializeField] private SnowManager _manager;
    SpriteRenderer Star_Renderer;
    Rigidbody2D rb;
    private bool Destroy_Check = false;
    private bool Move_Check = true;
    private bool touchCheck = false;
    public float add_power;
    private GameObject Player;
    //[SerializeField]private GameObject player_main;
    // Start is called before the first frame update
    void Start()
    {
        _destrohcontroller = GetComponent<DestroyController>();
        moveController = new SnowMoveController();
        Star_Renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
      //  player_main = Player.transform.Find("Main").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Destroy_Check)
            _destrohcontroller.Star_Destroy(Star_Renderer, this.gameObject);
        else if(Move_Check)
            moveController.Snow_Move(add_power, rb);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Move_Check = false;
        if (collision.gameObject.tag == "ground"||
            collision.gameObject.tag == "foundation"||
            gameObject.transform.position.y < -3)
        {
            Destroy_Check = true;
            this.transform.parent = null;
  
            if(touchCheck)
            {
                touchCheck = false;
            }

        }
        else if (collision.gameObject.tag == "Player"||
                 collision.gameObject.tag == "playerSnow"&&
                 gameObject.transform.position.y >= -3)
        {
            gameObject.tag = ("playerSnow");
            this.transform.parent = Player.transform;
            touchCheck = true;
           
        }
        
    }
   
}
