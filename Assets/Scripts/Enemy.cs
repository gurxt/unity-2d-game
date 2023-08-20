using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField]
  private float _speed = 4.0f;

  void Start() {
    float randomX = Random.Range(-9.0f, 9.0f);
    transform.position = new Vector3(randomX, 13.0f, 0);
  }

  void Update() {
    if (transform.position.y <= -2.0f) {
      float randomX = Random.Range(-9.0f, 9.0f);
      transform.Translate(new Vector3(randomX, 15.0f, 0));
    } else {
      transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
  }

  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      Destroy(this.gameObject);
      //Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
    Debug.Log(other.tag);
    if (other.tag == "Laser") { 
      Destroy(this.gameObject);
      Destroy(other.gameObject);
    }
  }
}
