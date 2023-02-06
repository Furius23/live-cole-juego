using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    public int direccion;//-1 o 1
    public SpriteRenderer miSprit;
    public float velocidad;
    
    void Start()
    {
        if (direccion < 0)
        {
            miSprit.flipX = false;        
        }
        else
        {
            miSprit.flipX = true;
        }
    } 
   
        
       
    
         

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * direccion * velocidad;
    }
}

