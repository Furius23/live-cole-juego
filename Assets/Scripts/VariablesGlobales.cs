using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesGlobales : MonoBehaviour
{
    public static VariablesGlobales instance { get; private set; }
    public int cantidadMonedas;



    private void Awake()
    {
        if(instance !=null && instance !=this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        
    }
}
