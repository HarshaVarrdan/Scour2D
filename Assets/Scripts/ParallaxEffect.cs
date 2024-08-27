using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float additionalScrollSpeed;
    
    public GameObject[] backgrounds;
    
    public float[] scrollSpeed;

    private void FixedUpdate()
    {       
        for (int i = 0; i < backgrounds.Length; i++)
        {
            
            Renderer rend = backgrounds[i].GetComponent<Renderer>();
            
            float xValue = Time.time * (scrollSpeed[i] + additionalScrollSpeed);
            
            rend.material.SetTextureOffset("_MainTex", new Vector2(xValue, 0));
        }
    }
}
