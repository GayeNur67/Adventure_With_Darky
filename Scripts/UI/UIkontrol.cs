using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIkontrol : MonoBehaviour
{
    public static UIkontrol instance;
    [SerializeField]
    Slider PlayerSlider;
     [SerializeField]
     TMP_Text textaltin;
     [SerializeField]
     TMP_Text coinTxt;




    private void Awake() {
        instance = this;
    
    }
    public void Slidergüncelle(int gecerlideger, int maxdeger){
        PlayerSlider.maxValue = maxdeger;
        PlayerSlider.value = gecerlideger;

    }
    public void altingüncelle(){
        coinTxt.text=GameManager.instance.toplananaltinsayisi.ToString();
    }
    }

