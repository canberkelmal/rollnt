using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCoin : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameManager gameManager;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && GetComponent<Renderer>().material.color==other.GetComponent<Renderer>().material.GetColor("_Color")){
            pickCoin(other);
        }


    }

    private void pickCoin(Collider other)
    {
        Debug.Log("Coin+1");

        Instantiate(pickupEffect,transform.position,transform.rotation);

        gameManager.scorePlus();

        Destroy(gameObject);
    }
}
