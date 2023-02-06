using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiMonedas : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;


    void Start()
    {
        actualizarMonedas();   
    }

    public void actualizarMonedas() 
    {
        textoMonedas.text = VariablesGlobales.instance.cantidadMonedas.ToString();
    }
}
