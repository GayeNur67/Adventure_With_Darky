using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenerAydinlanmasi : MonoBehaviour
{
  [SerializeField]
  SpriteRenderer fenersprite;

  [SerializeField]
  Sprite fenerOnSprite, fenerOffSprite;
  private void Awake() {
    fenersprite.sprite=fenerOffSprite;
  }
private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player"))             //oyuncu etiketine sahip nesne fener collider'a geldiğinde fener on sprite etkin olur
    
fenersprite.sprite=fenerOnSprite; }
    
private void OnTriggerExit2D(Collider2D other) {
    
    if (other.CompareTag("Player"))

      Invoke("FeneriKapat", .5f);   // belli süre sonra kapanmasını sağlar

}   void FeneriKapat(){
        fenersprite.sprite=fenerOffSprite;
    }
}

