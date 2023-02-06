using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorCambas : MonoBehaviour
{

    public GameObject panelPerder;
    public GameObject[] hearts;



    void Start()
    {
        panelPerder.SetActive(false);
    }

    public void PrenderPanel()
    {
        panelPerder.SetActive(true);
    }

    public void ActualizarCorazones(int life)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
           if(i< life)
            {
                hearts[i].SetActive(true);
            }
           else
            {
                hearts[i].SetActive(false);
            }
        }
        
    }
}
