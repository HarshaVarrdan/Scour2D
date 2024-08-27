using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GM_Instance;

    void Awake()
    {
        GM_Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Stoping(int timeLimit, bool Magnet, bool Shield)
    {
        StartCoroutine(StopPowerUp(timeLimit,Magnet,Shield));
    }

    IEnumerator StopPowerUp(int timeLimit, bool Magnet, bool Shield)
    {
        yield return new WaitForSeconds(timeLimit);
        if(Magnet)
        {
            Player_Controller.PC_Instance.DisableMagnet();
        }
        if(Shield)
        {
            Player_Controller.PC_Instance.DisableShield();
        }
    }
}
