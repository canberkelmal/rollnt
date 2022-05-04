using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed1 : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameManager gameManager;
    public int value=20;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){

            gameManager.setSpeed(value);

            SetSpeed1(other);
        }
    }

    

    private void SetSpeed1(Collider other)
    {
        Debug.Log("Color is changed!");

        Instantiate(pickupEffect,transform.position,transform.rotation);

        other.GetComponent<Renderer>().material.color=GetComponent<Renderer>().material.color;
        Debug.Log(other.GetComponent<Renderer>().material.color);



        Destroy(gameObject);
    }


}
