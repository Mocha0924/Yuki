using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    SpriteRenderer Star_Renderer;
    const int color_delete = 3;
    public int color_delete_level = 0;
    const int max_color_delete_level = 255;
    public void Snow_Destroy(SpriteRenderer mr,GameObject Snow)
    {
        if(color_delete_level >= max_color_delete_level)
        {
            Destroy(Snow);
            return;
        }
        mr.material.color -=  new Color32(0,0,0,color_delete);
        color_delete_level += color_delete;
    }
}
