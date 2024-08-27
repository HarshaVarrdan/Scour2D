using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Manager : MonoBehaviour
{
    
    [SerializeField] bool MagnetGO;
    [SerializeField] bool Magnet;

    [SerializeField] bool ShieldGO;
    [SerializeField] bool Shield;

    [SerializeField] int timeLimit;

    [SerializeField] float magnetAttractSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPowerUp()
    {
        if(MagnetGO)
        {
            EnableMagnet();
            Destroy(this.gameObject);
        }
        if(ShieldGO)
        {
            EnableShield();
            Destroy(this.gameObject);
        }
    }

    private void EnableShield()
    {
        Player_Controller.PC_Instance.ActivateShield();
        GameManager.GM_Instance.Stoping(timeLimit,MagnetGO,ShieldGO);

    }

    private void EnableMagnet()
    {
        Player_Controller.PC_Instance.ActivateMagnet();
        GameManager.GM_Instance.Stoping(timeLimit,MagnetGO,ShieldGO);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(Magnet)
        {
            if(other.gameObject.tag == "Coin")
            {
                //other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position,GameObject.FindWithTag("Player").transform.position,magnetAttractSpeed);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(Magnet)
        {
            if(other.gameObject.tag == "Coin")
            {
                other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position,GameObject.FindWithTag("Player").transform.position,magnetAttractSpeed);
            }
        }
    }
}
