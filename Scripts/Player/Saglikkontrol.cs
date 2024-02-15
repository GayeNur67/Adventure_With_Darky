using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saglikkontrol : MonoBehaviour
{
    public static Saglikkontrol instance;  //statik script (her yerden ulaşımı sağlamak için kullanılır.)
    public int maxsaglik , gecerlisaglik;
    private void Awake() {
        instance=this; // statik script haline geldi
    }
    private void Start() {
        gecerlisaglik = maxsaglik;  
        UIkontrol.instance.Slidergüncelle(gecerlisaglik,maxsaglik); 
    }
    public void hasaralmafonk(){
        gecerlisaglik--;
        UIkontrol.instance.Slidergüncelle(gecerlisaglik,maxsaglik);
        if(gecerlisaglik<=0){
            gecerlisaglik=0;
           // gameObject.SetActive(false);
           PlayerHareketController.intance.playercanverdifonk();
           
        }
    }
   
}
