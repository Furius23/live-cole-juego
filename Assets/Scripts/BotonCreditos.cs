using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotonCreditos : MonoBehaviour
{
    public GameObject panelCreditos, panelMenu;


    private void Start()
    {
        DOTween.Init();
    }




    public void cerrarMenu()
    {
        panelMenu.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(AbrirCreditos);
    }

    public void AbrirCreditos()
    {
        panelMenu.SetActive(false);
        panelCreditos.SetActive(true);
        panelCreditos.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
    }

    public void cerrarCreditos()
    {
        panelCreditos.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(AbrirMenu);
    }

    public void AbrirMenu()
    {
        panelMenu.SetActive(false);
        panelMenu.SetActive(true);
        panelMenu.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
    }




}
