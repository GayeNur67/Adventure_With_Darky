using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public int toplananaltinsayisi;
  private void Awake() {
    instance = this;
  }
  private void Start() {
    toplananaltinsayisi = 0;
  }
}
