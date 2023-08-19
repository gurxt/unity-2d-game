using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField]
  private float _speed = 3.5f;
  public float horizontalInput;
  public float verticalInput;

  void Start() {
    transform.position = new Vector3(0, 0, 0);      
  }

  void Update() {
    horizontalInput = GetPositionX();
    verticalInput = GetPositionY();

    Debug.Log(horizontalInput + " " + verticalInput);

    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
    transform.Translate(direction * _speed * Time.deltaTime);
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
