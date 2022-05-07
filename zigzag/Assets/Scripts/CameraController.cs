using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform topKonumu;
    public Vector3 mesafe;
 

    void Start()
    {
        mesafe = transform.position - topKonumu.position; 
    }


    void Update()
    {
        if(ballMovement.düstümü==false)
        {
            transform.position = topKonumu.position + mesafe;
        }
      
    }
    
}
