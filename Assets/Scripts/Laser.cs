using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
  [SerializeField]
  private float _speed = 20.0f;
  
  void Start() {
      
  }

  void Update() {
    if (transform.position.y >= 11.0f) {
      Destroy(this.gameObject);
    }
    
    transform.Translate(Vector3.up * _speed * Time.deltaTime);      

  }
}
