using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerdBrain : MonoBehaviour
{


    #region Herd Brain variable
    Transform shepherd;
    [Header("Sürü Kontrol")]
    public Vector3 shForce; // hareket yonu ve kuvveti
    Vector3 interval; //shepherd ile arasindaki vektor
    [Range(0f, 10f)]
    public float interRange;//ektkilesimin basliyacagi mesafe  //depends on sheep count
    [Range(0f, 3f)]
    public float driveFactor = 10f;//kuvvet carpani // bunu matematiksel bir range fonksiyonuna cevir
    [Range(2f, 10f)]
    public float maxSpeed = 5f;
    [Range(0f, 2f)]
    public float minSpeed = 1f;
    #endregion

    


    void Start()
    {
        shepherd = GameObject.Find("Shepherd").GetComponent<Transform>();

        

    }

    

    void Update()
    {
        #region Herd interaction

        interval = transform.position - shepherd.position;
        interval.y = 0;
        
        if (interval.magnitude < interRange)//aradaki mesafe < sabit
        {

            shForce = (interRange - interval.magnitude) * interval.normalized;
            shForce = shForce * driveFactor;
            transform.forward = interval.normalized;

            if (shForce.magnitude > maxSpeed)
            {
                shForce = shForce.normalized * maxSpeed;
            }
            else if (shForce.magnitude < minSpeed)// cok cirkin oldu // range fonksiyonu bulmak gerek
            {
                shForce = shForce.normalized * minSpeed;
            }
        }
        else 
        {
            shForce = shForce.normalized * minSpeed;
        }

        transform.position += shForce * Time.deltaTime;//hareket fonsiyonu

        GetComponentInChildren<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, interval.magnitude / interRange); //hiza gore renk
        #endregion

        

    }

}

// simdilik calisiyor daha kurcalama