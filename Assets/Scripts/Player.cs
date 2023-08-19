using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  // movement global variables
  public float speed = 10.0f;
  public float horizontalInput;
  public float verticalInput;

  // laser prefab
  [SerializeField]
  private GameObject _laserPrefab;
  [SerializeField]
  private float _fireRate;
  private float _canFire = -1.0f;

  void Start() {
    transform.position = new Vector3(0, 0, 0);      
    _fireRate = 0.25f;
  }

  void Update() {
    CalculateMovement();
    if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
      FireLaser();
    }
  }

  void FireLaser() {
    _canFire = Time.time + _fireRate;
    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
  }

  void CalculateMovement() {
    horizontalInput = GetPositionX();
    verticalInput = GetPositionY();

    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
    transform.Translate(direction * speed * Time.deltaTime);
  }

  float GetPositionX() {
    horizontalInput = Input.GetAxis("Horizontal");

    if (transform.position.x >= 11.3f) {
      transform.Translate(-22.5f, 0, 0);
      return 0.0f;
    }

    if (transform.position.x <= -11.3f) {
      transform.Translate(22.5f, 0, 0);
      return 0.0f;
    }

    return horizontalInput;
  }

  float GetPositionY() {
    verticalInput = Input.GetAxis("Vertical");

    if (transform.position.y >= 11.1f) {
      transform.Translate(0, -13.1f, 0);
      return 0.0f;
    }

    if (transform.position.y <= -2.0f) {
      transform.Translate(0, 13.0f, 0);
      return 0.0f;
    }

    return verticalInput;
  }

}
