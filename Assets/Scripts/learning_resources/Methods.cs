using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour {
  [SerializeField]
  private GameObject obj;

  void Start() {
    transform.position = DefaultPosition();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      if (obj.GetComponent<MeshRenderer>().material.color == Color.red)
        ChangeColor(obj, Color.black);
      else 
        ChangeColor(obj, Color.red);
    }
  }

  private void ChangeColor(GameObject obj, Color color) {
    obj.GetComponent<MeshRenderer>().material.color = color;
  }

  private Vector3 DefaultPosition() {
    return Vector3.zero;
  }
}
