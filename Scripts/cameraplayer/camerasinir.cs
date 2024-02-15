using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasinir : MonoBehaviour
{ PlayerHareketController player;
   
   [SerializeField]
   Collider2D boundsBox;
   float halfYukseklik;
   float halfGenislik;

   Vector2 g_kayma;
   [SerializeField]
   Transform Background;
   private void Awake() {
    player=Object.FindObjectOfType<PlayerHareketController>();
   }
   private void Start() {

     halfYukseklik=Camera.main.orthographicSize;
     halfGenislik=halfYukseklik*Camera.main.aspect;
     g_kayma=transform.position;
   
   }
   private void Update() {

    if (player!=null){
     transform.position=new Vector3(Mathf.Clamp (player.transform.position.x,boundsBox.bounds.min.x+halfGenislik,boundsBox.bounds.max.x-halfGenislik),
      Mathf.Clamp (player.transform.position.y,boundsBox.bounds.min.y+halfYukseklik,boundsBox.bounds.max.y-halfYukseklik),
     transform.position.z);
    }
    BackgroundHareketFonk();
   }
   void BackgroundHareketFonk()
   {
Vector2 aradkifark = new Vector2(transform.position.x - g_kayma.x,transform.position.y - g_kayma.y);
Background.position += new Vector3(aradkifark.x,aradkifark.y,0F);
g_kayma=transform.position;
   }
}
