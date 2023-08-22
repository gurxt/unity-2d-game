using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField]
  private float _speed = 4.0f;
  private Player _player;
  private Animator _anim;

  void Start() {
    float randomX = Random.Range(-9.0f, 9.0f);
    transform.position = new Vector3(randomX, 13.0f, 0);

    _player = GameObject.Find("Player").GetComponent<Player>();
    if (_player == null) {
      Debug.LogError("The Player is NULL");
    }

    _anim = GetComponent<Animator>();
    if (_anim == null) {
      Debug.LogError("The Animator is NULL");
    } 
  }

  void Update() {
    if (transform.position.y <= -2.0f) {
      float randomX = Random.Range(-9.0f, 9.0f);
      transform.Translate(new Vector3(randomX, 15.0f, 0));
    } else {
      transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      // check if the player exists
      Player player = other.transform.GetComponent<Player>();
      // damage the player
      if (player != null)
        player.Damage();
      _speed = 0.0f;
      _anim.SetTrigger("OnEnemyDeath");
      Destroy(this.gameObject, 2.5f);
    }

    if (other.tag == "Laser") { 
      if (_player != null)
        _player.AddScore(Random.Range(5, 10));
      // destroy both player and enemy
      _speed = 0.0f;
      _anim.SetTrigger("OnEnemyDeath");
      Destroy(this.gameObject, 2.5f);
      Destroy(other.gameObject);
    }
  }
}
