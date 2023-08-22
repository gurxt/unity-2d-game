using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
  [SerializeField]
  private float _rotationSpeed;
  [SerializeField]
  private GameObject _explosion;
  private SpawnManager _spawnManager;
  void Start() {
    _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
  }

  void Update() {
    transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Laser") {
      Instantiate(_explosion, transform.position, Quaternion.identity);
      Destroy(other.gameObject);
      Destroy(this.gameObject, 0.2f);
      _spawnManager.StartSpawning();
    }
  }
}
