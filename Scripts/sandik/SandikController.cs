using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandikController : MonoBehaviour
{
   Animator anim;
   int vurussayisi;

[SerializeField]
GameObject parlamaEfekti;

[SerializeField]
GameObject altinPrefab;

Vector2 patlamaMiktari = new Vector2(1,4);

   private void Awake() {    //ilk çalışan fon. awake//
   anim=GetComponent<Animator>();
    vurussayisi=0;
   }
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("kilicvurmakutusu")){
        if(vurussayisi==0){
            anim.SetTrigger("sallanma");
            Instantiate(parlamaEfekti,transform.position,transform.rotation);
        }else if(vurussayisi==1){
            anim.SetTrigger("sallanma");
              Instantiate(parlamaEfekti,transform.position,transform.rotation);
        }else{
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetTrigger("sandikkirma");

            for (int i = 0; i < 3; i++)    
            {
                Vector3 rastgeleVector = new Vector3(transform.position.x + (i-1), transform.position.y, transform.position.z);
                GameObject altin = Instantiate(altinPrefab, rastgeleVector, transform.rotation);
                altin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                altin.GetComponent<Rigidbody2D>().velocity = patlamaMiktari * new Vector2(Random.Range(1, 2), transform.localScale.y+Random.Range(0,2));
                

            }
        }
        vurussayisi++;
    }
   }
    }

