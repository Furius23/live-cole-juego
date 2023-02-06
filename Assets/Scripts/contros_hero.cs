using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class contros_hero : MonoBehaviour
{
    public float velocidad, fuerzaDeSalto;//Global
    public Rigidbody2D miRigobody;
    public bool puedoSaltar;
    public SpriteRenderer miSprite;
    public Animator miAnimator;
    public Transform respawn;
    public int vida;
    public controladorCambas cambas;
    public UiMonedas uiMonedas;
    public bool estoyVivo;
    public Vector3 puntoDisparo;
    public GameObject bala, explosion;


    void Start()
    {
        puedoSaltar = true;
        estoyVivo = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (estoyVivo == false)
        {
            return;
        }

        float velocidadEnX = Input.GetAxisRaw("Horizontal");

        if (velocidadEnX != 0)
        {
            miAnimator.SetBool("walk", true);
        }
        else
        {
            miAnimator.SetBool("walk", false);
        }

        if (velocidadEnX > 0)
        {
            miSprite.flipX = false;
        }
        if (velocidadEnX < 0)
        {
            miSprite.flipX = true;
        }
        transform.position += transform.right * Time.deltaTime * velocidad * velocidadEnX;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puedoSaltar)
            {
                jump();
            }
            puedoSaltar = false;
        }
        if (Input.GetMouseButtonDown(0))//0 izquierdo, 1derecho ,2ruedita     
        {
            shoot();
        }
    }


    public void jump()
    {
        miAnimator.SetBool("Fly", true);
        miRigobody.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
    }
    public void shoot()   
    {
        var positivo = 0;
        if (miSprite.flipX==false)
        {
            positivo = 1;
        }
        else
        {
            positivo = -1;
        }
        Instantiate(explosion, transform.position + new Vector3(0.37f *positivo, 0, 0),quaternion.identity,transform);
        GameObject balita =  Instantiate(bala, transform.position + new Vector3(0.37f * positivo, 0, 0), quaternion.identity);
        balita.GetComponent<BalaPlayer>().direccion = positivo;
        Destroy(balita, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            puedoSaltar = true;
            miAnimator.SetBool("Fly", false);
        }
        if (collision.gameObject.layer == 7)
        {
            transform.position = respawn.position;
        }
        if(collision.gameObject.layer == 8)
        {
            DanarHero(1);
        }

        if(collision.gameObject.layer==10)
        {
            VariablesGlobales.instance.cantidadMonedas += 1;
            uiMonedas.actualizarMonedas();
            Destroy(collision.gameObject);
        }
    }
    public void DanarHero(int danoRecibido)
    {
        vida -= danoRecibido;
        cambas.ActualizarCorazones(vida);
        if (vida <=0)
        {
            estoyVivo = false;
            Time.timeScale = 0;
            cambas.PrenderPanel();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + new Vector3(0.37f, 0, 0), 0.05f);
    }

}
