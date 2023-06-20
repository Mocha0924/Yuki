using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.right * -1*0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right*0.1f);
        }
    }
}
