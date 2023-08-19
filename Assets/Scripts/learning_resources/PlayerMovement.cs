using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField]
  private float _speed; 

  void Start() {
    // take the current position and assign a starting position of (0,0,0)
    transform.position = new Vector3(0, 0, 0);
  }

  // Update is called once per frame (60 fps)
  void Update() {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
  }
}
