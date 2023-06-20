using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMoveController
{
    // Start is called before the first frame update
   public void Snow_Move(float addX,Rigidbody2D rb)
    {
        Vector2 force = new Vector2(addX, 0);
        rb.AddForce(force);
    }
}
