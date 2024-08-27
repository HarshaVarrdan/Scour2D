using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] GameObject pMagnet;
    [SerializeField] GameObject pShield;

    //[SerializeField] GameObject Player;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    Rigidbody2D playerRB;

    bool isMouseDown = false;

    public int CollectedCoin;

    public static Player_Controller PC_Instance;

    void Awake()
    {
        PC_Instance = this;
    }


    void Start() 
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0)) {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            isMouseDown = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            isMouseDown = false;
        }

        if (isMouseDown) {
            // code to move the player up
            playerRB.velocity = new Vector2(moveSpeed,jumpSpeed);
        } else {
            // code to move the player down
            playerRB.velocity = new Vector2(moveSpeed,0f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "PowerUp")
        {
            other.gameObject.GetComponent<PowerUp_Manager>().StartPowerUp();
        }
        if(other.gameObject.tag == "Coin")
        {
            CollectCoin();
            Destroy(other.gameObject);
        }
    }

    internal void ActivateMagnet()
    {
        pMagnet.SetActive(true);
    }

    internal void DisableMagnet()
    {
        pMagnet.SetActive(false);
    }

    internal void ActivateShield()
    {
        pShield.SetActive(true);
    }

    internal void DisableShield()
    {
        pShield.SetActive(false);
    }

    internal void CollectCoin()
    {
        CollectedCoin++;
    }
}
