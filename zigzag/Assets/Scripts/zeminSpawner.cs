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
        Vector3 yön;
        if(Random.Range(0,2)==0)
        {
            yön = Vector3.left;
        }
        else
        {
            yön = Vector3.forward;
        }
        sonZemin=Instantiate(sonZemin, sonZemin.transform.position + yön,sonZemin.transform.rotation);   //obje spamlamak için
    }
}
