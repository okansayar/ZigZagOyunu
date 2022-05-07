using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    Vector3 y�n;
    public float h�z;
    public zeminSpawner zeminSpawnerScripti;
    public static bool d�st�m�; //static olu�turmam�z�n  sebebi di�er scriptlerden de kullanmak i�in
    public float eklenecekHiz;

    void Start()
    {
        y�n = Vector3.forward;
        d�st�m� = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=0.5f)
        {
            d�st�m� = true;
        }
        if (d�st�m� == true)
        {          
            return;
        }

        if (Input.GetMouseButtonDown(0)) // mause klik yapt�k�a harekett d�nd�s� ger�ekle�icek 0. 1'de ise bas�l� tutuldu�u s�re
        {
        

            if(y�n.x==0)
            {
                y�n = Vector3.left;
            }
            else
            {
                y�n = Vector3.forward;
            }
         h�z=h�z+eklenecekHiz * Time.deltaTime;  //her y�n de�i�tirmeden sonra h�zlanma kazan�r.


        }
    }

    private void FixedUpdate() // harekete sa�lamak i�in 
    {
        Vector3 hareket = y�n * Time.deltaTime * h�z;
        transform.position += hareket;
    }

    private void OnCollisionEnter(Collision collision) // temasttan ��kt��� zaman �al��an
    {
        
        if(collision.gameObject.tag=="zemin") // zeminden ayr�ld�ktan sonra kaybolan zemin eksilir eksildi�i kadar zemin eklenir
        {
            Skor.skor++; // skoru 1er arttt�rmak i�in

            // collision.gameObject.AddComponent<Rigidbody>(); // ayr�lan objeye rigidboyd ekle
            zeminSpawnerScripti.zeminOlustur();
            StartCoroutine(ZeminiSil(collision.gameObject));
        }
    }
     IEnumerator ZeminiSil(GameObject SilinecekZemin)
    {
        yield return new WaitForSeconds(5f);
        Destroy(SilinecekZemin);
    }

}
