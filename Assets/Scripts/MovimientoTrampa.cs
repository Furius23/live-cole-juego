using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTrampa : MonoBehaviour
{
    public float velocidadGiro;
    
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
       {
            contros_hero player = collision.gameObject.GetComponent<contros_hero>();
       
            if(player !=null)
            {
                player.DanarHero(2);
            }

       }
    }
}
