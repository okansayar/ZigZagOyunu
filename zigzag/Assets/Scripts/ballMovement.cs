using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    Vector3 yön;
    public float hýz;
    public zeminSpawner zeminSpawnerScripti;
    public static bool düstümü; //static oluþturmamýzýn  sebebi diðer scriptlerden de kullanmak için
    public float eklenecekHiz;

    void Start()
    {
        yön = Vector3.forward;
        düstümü = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=0.5f)
        {
            düstümü = true;
        }
        if (düstümü == true)
        {          
            return;
        }

        if (Input.GetMouseButtonDown(0)) // mause klik yaptýkça harekett döndüsü gerçekleþicek 0. 1'de ise basýlý tutulduðu süre
        {
        

            if(yön.x==0)
            {
                yön = Vector3.left;
            }
            else
            {
                yön = Vector3.forward;
            }
         hýz=hýz+eklenecekHiz * Time.deltaTime;  //her yön deðiþtirmeden sonra hýzlanma kazanýr.


        }
    }

    private void FixedUpdate() // harekete saðlamak için 
    {
        Vector3 hareket = yön * Time.deltaTime * hýz;
        transform.position += hareket;
    }

    private void OnCollisionEnter(Collision collision) // temasttan çýktýðý zaman çalýþan
    {
        
        if(collision.gameObject.tag=="zemin") // zeminden ayrýldýktan sonra kaybolan zemin eksilir eksildiði kadar zemin eklenir
        {
            Skor.skor++; // skoru 1er artttýrmak için

            // collision.gameObject.AddComponent<Rigidbody>(); // ayrýlan objeye rigidboyd ekle
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
