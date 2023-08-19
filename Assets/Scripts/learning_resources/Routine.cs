using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour {
  public int apples;

  void Start() {
    StartCoroutine(AddApplesRoutine());
  }

  void Update() {
    
  }

  IEnumerator AddApplesRoutine() {
    for (int i=0; i < 100; i++) {
      apples++;
      yield return new WaitForSeconds(1.0f);
    }
  }
}
