using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Player_Speed;
   
    // Update is called once per frame
   
    void Update()
    {
     
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x > -6.6f)
                this.transform.Translate(Vector2.left*Player_Speed*Time.deltaTime);
            
        }
        
       if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 6.6f)
                this.transform.Translate(Vector2.left * -Player_Speed * Time.deltaTime);
        }
       
       
    }
}
