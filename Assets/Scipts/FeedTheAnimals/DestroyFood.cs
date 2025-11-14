using System;
using System.Collections;
using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    [SerializeField] private float secondsInScene=3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyGameObject());
    }
    
    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(secondsInScene);
        Destroy(gameObject);
    }




}
