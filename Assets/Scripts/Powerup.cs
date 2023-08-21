using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
  [SerializeField]
  private float _speed = 3.0f;

  [SerializeField]
  private int powerUpID; // 0 = triple shot, 1 = speed powerup, 2 = shields

  void Start() {
  }

  void Update() {
    transform.Translate(Vector3.down * _speed * Time.deltaTime);

    if (transform.position.y <= -2.0f) {
      Destroy(this.gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      Player player = other.transform.GetComponent<Player>();
      if (player != null) {
        switch (powerUpID) {
          case 0:
            player.TripleShotActive();
            break;
          case 1:
            player.SpeedBoostActive();
            break;
          case 2:
            player.ShieldBoostActive();
            break;
          default:
            Debug.Log("King Timothy of Bugs");
            break;
        }
      }
      Destroy(this.gameObject);
    }
  }
}
