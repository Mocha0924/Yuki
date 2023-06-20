using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    DestroyController _destrohcontroller;
    SnowMoveController moveController;
    SpriteRenderer Star_Renderer;
    Rigidbody2D rb;
    private bool Destroy_Check = false;
    private bool Move_Check = true;
    public float add_power;
    private GameObject Player;
    [SerializeField]private GameObject player_main;
    private FixedJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        _destrohcontroller = GetComponent<DestroyController>();
        moveController = new SnowMoveController();
        Star_Renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        player_main = Player.transform.Find("Main").gameObject;
        joint = GetComponent<FixedJoint2D>();
        joint.enabled = false;
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
        if (collision.gameObject.tag == "ground")
        {
            Destroy_Check = true;

        }
        else if (collision.gameObject.tag == "Player"||
                 collision.gameObject.tag == "playerPlayer")
        {
            //gameObject.transform.SetParent(Player.transform);
            gameObject.tag = ("playerSnow");
            joint.enabled = true;
            joint.connectedBody = player_main.gameObject.GetComponent<Rigidbody2D>();
        }
       
    }
}
