using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta : MonoBehaviour
{
    public float rangoDeVision;
    public Transform objetivo;
    private bool detectado;
    private Vector2 direccion;
    public GameObject flecha;
    public GameObject armaDeTorreta;
    public GameObject canon;
    public float tiempoDeDisparo;
    private float tiempoDeDisparoIniciar;



    private void Start()
    {
        tiempoDeDisparoIniciar = tiempoDeDisparo;

    }




    void Update()
    {
        Vector2 posicionObjetivo = objetivo.position;
        direccion = posicionObjetivo - (Vector2)armaDeTorreta.transform.position;
        RaycastHit2D raycastHit = Physics2D.Raycast(armaDeTorreta.transform.position, direccion,rangoDeVision);

        if(raycastHit)
        {
            if(raycastHit.collider.gameObject.tag == "Player")
            {
                if(!detectado)
                {
                    detectado = true;
                }

               
            }
        }
        else
        {
            if (detectado)
            {
                detectado = false;
            }
        }
        if (detectado)
        {
            armaDeTorreta.transform.up = direccion; 
            if(tiempoDeDisparo <=0)
            {
                Instantiate(flecha, canon.transform.position, canon.transform.rotation);
                tiempoDeDisparo = tiempoDeDisparoIniciar;
            }
            else
            {
                tiempoDeDisparo -= Time.deltaTime;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(armaDeTorreta.transform.position,rangoDeVision);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(armaDeTorreta.transform.position, direccion);
    }
}
