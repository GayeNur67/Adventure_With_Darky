using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altintoplama : MonoBehaviour
{
    [SerializeField]
    bool altinmi;
    [SerializeField]
    GameObject AltinEfekt;
bool toplandimi;
    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !toplandimi){
            toplandimi=true;
            GameManager.instance.toplananaltinsayisi++;
            UIkontrol.instance.altingüncelle();
            Destroy(gameObject);
            Instantiate (AltinEfekt,transform.position,Quaternion.identity);
        }
        
    }
}
