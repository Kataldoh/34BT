using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesEvents : MonoBehaviour
{

    public void _IDLE()
    {

    }

    public void _PLAY()
    {
        GameController.instance.pannelli[0].SetActive(false);
        GameController.instance.pannelli[1].SetActive(false);
        Time.timeScale = 1f;
        //GameController.instance.puntatore.SetActive(true);

    }

    public void _DEAD()
    {
        GameController.instance.pannelli[0].SetActive(true);
        GameController.instance.pannelli[1].SetActive(false);
        //GameController.instance.puntatore.SetActive(false); //In alcuni stati il puntatore va disattivato altrimenti, pur essendo il timescale a 0, il player guarda in direzione del mouse muovendosi.
        Time.timeScale = 0f;


    }

    public void _PAUSE()
    {
        GameController.instance.pannelli[1].SetActive(true);
        Time.timeScale = 0f;
        //GameController.instance.puntatore.SetActive(false);

    }
}
