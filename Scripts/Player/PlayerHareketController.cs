using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHareketController : MonoBehaviour
{
   public static PlayerHareketController intance;
    Rigidbody2D rb;

    [SerializeField]
    GameObject normalPlayer,kilicPlayer;

     [SerializeField]
Transform zeminkontrolnoktasi;
      [SerializeField]
      Animator normalAnim,kilicAnim;
      [SerializeField]
    SpriteRenderer normalsprite,kilicsprite;
    [SerializeField]
GameObject kilicvuruskutusu;
public LayerMask zeminMaske;

   public float hareketHizi;
   public float ziplamaGucu;
   bool zemindemi;
   bool ikincikezziplama;
   
   [SerializeField]
   public float tepkisüresi, tepkigucu;
   float tepkisayaci;
   bool yonileri;
   bool playercanverdimi;
   bool kilicataktami;
private void Awake() {

      intance=this;
      kilicataktami=false;
      rb = GetComponent<Rigidbody2D>();   
      playercanverdimi=false;
      kilicvuruskutusu.SetActive(false);
}
private void Update() {
  if(playercanverdimi==true){
    return;
  }
  if(tepkisayaci<=0){
     HareketEt();
    ZiplaFNC();
    yondegisikligi();
    if(normalPlayer.activeSelf){
    normalsprite.color=new Color(normalsprite.color.r,normalsprite.color.g,normalsprite.color.b,1f); //spritedaki red,green,blue değerleri değiştirmeyip alfasını 1'e çektik
  }
if(kilicPlayer.activeSelf)  {
  kilicsprite.color=new Color(kilicsprite.color.r,kilicsprite.color.g,kilicsprite.color.b,1f);
}
if(Input.GetMouseButtonDown(0) && kilicPlayer.activeSelf){
  kilicataktami=true;
  kilicvuruskutusu.SetActive(true);
}else{
  kilicataktami=false;
}
  }
  else{
    tepkisayaci-=Time.deltaTime;
    if(yonileri){
      rb.velocity=new Vector2(-tepkigucu,rb.velocity.y);
    
    }else{
      rb.velocity=new Vector2(tepkigucu,rb.velocity.y);
    }
  }
    
if(normalPlayer.activeSelf) {
    normalAnim.SetBool("zemindemi",zemindemi);
    normalAnim.SetFloat("hareketHizi",Mathf.Abs( rb.velocity.x));}

if(kilicPlayer.activeSelf) {
    kilicAnim.SetBool("zemindemi",zemindemi);
    kilicAnim.SetFloat("hareketHizi",Mathf.Abs( rb.velocity.x));
    if(kilicataktami){
      kilicAnim.SetTrigger("kilicatak");
    }
    }
   
}
void HareketEt()
{
    float h = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(h*hareketHizi, rb.velocity.y);
    

}
void yondegisikligi(){
   if(rb.velocity.x<0)
    {
      transform.localScale =new Vector3(-1,1,1);
      yonileri=false;
    }else if(rb.velocity.x>0)
    {
      transform.localScale =new Vector3(1,1,1);
      yonileri=true;
    }

}
  void ZiplaFNC()
  {
zemindemi=Physics2D.OverlapCircle(zeminkontrolnoktasi.position,.2F,zeminMaske);

if(Input.GetButtonDown("Jump") && (zemindemi || ikincikezziplama))
{
    if(zemindemi)
    {
   ikincikezziplama = true;
    } else
    {
  ikincikezziplama = false;
    }

  rb.velocity = new Vector2(rb.velocity.x,ziplamaGucu);

  
}
  }
  public void tepkifonk(){
    tepkisayaci=tepkisüresi;
    if(normalPlayer.activeSelf){
    normalsprite.color=new Color(normalsprite.color.r,normalsprite.color.g,normalsprite.color.b,0.5f);} //karakterin hasar aldığındaki değişimi
     if(kilicPlayer.activeSelf){
kilicsprite.color=new Color(kilicsprite.color.r,kilicsprite.color.g,kilicsprite.color.b,0.5f);
     }
    rb.velocity=new Vector2(0,rb.velocity.y);
  }
public void playercanverdifonk(){
        rb.velocity=Vector2.zero;
        playercanverdimi=true;

        if(normalPlayer.activeSelf) {
   normalAnim.SetTrigger("canverdi");}

if(kilicPlayer.activeSelf) {
    kilicAnim.SetTrigger("canverdi");
}
        
        StartCoroutine(PlayerBastanBasla());
    }
     IEnumerator PlayerBastanBasla()
    {
        yield return new WaitForSeconds(2f); //2 saniye ölü beklesin
        GetComponentInChildren<SpriteRenderer>().enabled=false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//scenemanager kütüphansini kullanarak sahneyi yeniden yükle
    }
    public void normaldenkilicagecis(){
      normalPlayer.SetActive(false);
      kilicPlayer.SetActive(true);
    }
   
    }
    

