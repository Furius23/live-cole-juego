using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    public float velocidad;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.position += transform.up * Time.deltaTime * velocidad; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}
