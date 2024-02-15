using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orumcekcontroller : MonoBehaviour
{
   [SerializeField]
   Transform[] pozisyonlar;

   public float orumcekhizi;

   public float beklemesuresi;
   float beklemeSayaci;

   Animator anim;
   int kacinciPozisyon;

   Transform hedefPlayer;
public float takip_mesafesi = 5f;
 BoxCollider2D orumcekCollider;
bool saldirsinmi;
   private void Awake()
   {
    anim = GetComponent<Animator>();
    orumcekCollider=GetComponent<BoxCollider2D>();
   }

private void Start()
{
    saldirsinmi = true;
    hedefPlayer = GameObject.Find("Player").transform;
    foreach (Transform pos in pozisyonlar)
    {
        pos.parent = null;
    }
}
private void Update()
{
    if(!saldirsinmi)
 { return;
        
    }
    if(beklemeSayaci>0)
    {
        beklemeSayaci -= Time.deltaTime;
        anim.SetBool("hareketEdsinmi", false);
    }
    else {
        if(hedefPlayer.position.x > pozisyonlar[0].position.x && hedefPlayer.position.x<pozisyonlar[1].position.x) {
            transform.position=Vector3.MoveTowards(transform.position,hedefPlayer.position,orumcekhizi*Time.deltaTime);
            anim.SetBool("hareketEdsinmi",true);
            if(transform.position.x>hedefPlayer.position.x){
      transform.localScale = new Vector3(-1, 1, 1);
}
else if (transform.position.x < hedefPlayer.position.x)
{
    transform.localScale = Vector3.one;

}
        }
        else{
    anim.SetBool("hareketEdsinmi", true);
if(transform.position.x>pozisyonlar[kacinciPozisyon].position.x){
      transform.localScale = new Vector3(-1, 1, 1);
}
else if (transform.position.x < pozisyonlar[kacinciPozisyon].position.x)
{
    transform.localScale = Vector3.one;

}
        transform.position=Vector3.MoveTowards(transform.position,pozisyonlar[kacinciPozisyon].position,orumcekhizi*Time.deltaTime);

        if(Vector3.Distance(transform.position,pozisyonlar[kacinciPozisyon].position)<0.1f){
            beklemeSayaci = beklemesuresi;
            PozisyonuDegistir();
        }
        }
    
    }
}
void PozisyonuDegistir(){
    kacinciPozisyon++;
    if(kacinciPozisyon>=pozisyonlar.Length)
    kacinciPozisyon = 0;
}

private void OnDrawGizmoSelected()
{
    Gizmos.color = Color.green; 

    Gizmos.DrawWireSphere(transform.position, takip_mesafesi);
}
  private void OnTriggerEnter2D(Collider2D other) {
    if(orumcekCollider.IsTouchingLayers(LayerMask.GetMask("PlayerLayer"))&& saldirsinmi) {
        saldirsinmi = false;
        anim.SetTrigger("saldirdi");
        other.GetComponent<PlayerHareketController>().tepkifonk();
          other.GetComponent<Saglikkontrol>().hasaralmafonk();
        StartCoroutine(Yenidensaldirsin());
    }
  }
  IEnumerator Yenidensaldirsin()
  {
    yield return new WaitForSeconds(1f);
    saldirsinmi = true;
  }
}
