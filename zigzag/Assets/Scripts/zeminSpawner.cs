using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminSpawner : MonoBehaviour
{
    public GameObject sonZemin;
  
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            zeminOlustur();        
        }
    }


 
     
    public void zeminOlustur()
    {
        Vector3 y�n;
        if(Random.Range(0,2)==0)
        {
            y�n = Vector3.left;
        }
        else
        {
            y�n = Vector3.forward;
        }
        sonZemin=Instantiate(sonZemin, sonZemin.transform.position + y�n,sonZemin.transform.rotation);   //obje spamlamak i�in
    }
}
