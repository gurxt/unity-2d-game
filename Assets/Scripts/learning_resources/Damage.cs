using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
  [SerializeField]
  private int health = 100;
  [SerializeField]
  private GameObject player;

  void Start() {

  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && health > 0) {
      TakeDamage();
    }   
  }

  private void TakeDamage() {
    int _damage = Random.Range(0, 25);
    if (health - _damage <= 0) {
      health = 0;
      Destroy(player, 1f);
    } else {
      health -= _damage;
    }
  }
}
