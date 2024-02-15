using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockkontrol : MonoBehaviour
{
    public Transform alt;
    Animator anim;
    Vector3 hareketYonu = Vector3.up;
    Vector3 orijinalPos;
    Vector3 animPos;
    public LayerMask PlayerLayer;

    private bool animasyonBasla;
    private bool hareketDevam = true;

public GameObject altinPrefarb;
Vector3 altinPos;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        orijinalPos = transform.position;
        animPos = transform.position;
        animPos.y += 0.15f;

        altinPos = transform.position;
        altinPos.y+= 1f;

    }
    private void Update()
    {
        Carpmakontrol();
        animasyonBaslat();

    }
    void Carpmakontrol()
    {

        if (hareketDevam)
        {
            RaycastHit2D hit = Physics2D.Raycast(alt.position, Vector2.down, .1f, PlayerLayer);
            if (hit && hit.collider.gameObject.tag == "Player" )
            {
                anim.Play("bonusmat");
                animasyonBasla = true;
                hareketDevam=false;

                Instantiate(altinPrefarb,altinPos,Quaternion.identity);
            }
        }
    }
    void animasyonBaslat()
    {

        if (animasyonBasla)
        {
            transform.Translate(hareketYonu * Time.smoothDeltaTime);
            if (transform.position.y >= animPos.y)
            {
                hareketYonu = Vector3.down;
            }
            else if (transform.position.y <= orijinalPos.y)
            {
                animasyonBasla = false;

            }
        }
    }

}

