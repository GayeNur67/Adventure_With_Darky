using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdKontrol : MonoBehaviour
{[SerializeField]
Transform[] posizyonlar;
public float BirdSpeed;
public float beklemeSuresi;
float beklemeSayaci;
int kaçinciPosizyon;
Animator anim;
Vector2 kusYonu;
private void Awake() {
    anim=GetComponent<Animator>(); //animatörü çağırıyor 
    foreach(Transform pos in posizyonlar) //posizonlar içinde pos degerlerini bird dışına atıyor
    {
        pos.parent=null;
    }
}
private void Start() {
    kaçinciPosizyon=0;
    transform.position=posizyonlar[kaçinciPosizyon].position;
}
private void Update() {
    if(beklemeSayaci>0){
        beklemeSayaci-=Time.deltaTime;
        anim.SetBool("ucsunmu",false);
    }else{
        //iki pos arasındaki vektör bulma
        kusYonu=new Vector2(posizyonlar[kaçinciPosizyon].position.x-transform.position.x,posizyonlar[kaçinciPosizyon].position.y-transform.position.y);
           //önce y degerini ister, bulduğu radyanı dereceye dönüstürür
        float angle=Mathf.Atan2(kusYonu.y,kusYonu.x)*Mathf.Rad2Deg;
        //kuş bu if fonksiyonu olmazsa geri dönerken ters uçar
        if(transform.position.x>posizyonlar[kaçinciPosizyon].position.x)
        {
            transform.localScale=new Vector3(1,-1,1);
        }else{
            transform.localScale= Vector3.one;
        }
        //kusun hareketine göre sadece z degerinin degismesi gerek x ve y degismez z angel degiskenine göre ilerler
        transform.rotation=Quaternion.Euler(0,0,angle) ;
        transform.position=Vector3.MoveTowards(transform.position,posizyonlar[kaçinciPosizyon].position,BirdSpeed*Time.deltaTime);
         anim.SetBool("ucsunmu",true);

        if(Vector3.Distance(transform.position,posizyonlar[kaçinciPosizyon].position)<0.1f){
          
            PosizyonDegistir();

            beklemeSayaci=beklemeSuresi;
           
        }
        void PosizyonDegistir(){
            kaçinciPosizyon++;
            if(kaçinciPosizyon>=posizyonlar.Length){
                kaçinciPosizyon=0;

            }


        }
    }
}
}
