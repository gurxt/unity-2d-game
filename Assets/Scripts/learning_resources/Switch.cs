using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
  [SerializeField]
  private GameObject player;
  [SerializeField]
  private int currCode;
  
  // Start is called before the first frame update
  void Start() {
    //player.GetComponent<Renderer>().material.color = Color.red;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) currCode = 1;
    if (Input.GetKeyDown(KeyCode.Alpha2)) currCode = 2;
    if (Input.GetKeyDown(KeyCode.Alpha3)) currCode = 3;
    if (Input.GetKeyDown(KeyCode.Alpha4)) currCode = 4;

    switch (currCode) {
      case 1:
        player.GetComponent<Renderer>().material.color = Color.blue;
        break;
      case 2:
        player.GetComponent<Renderer>().material.color = Color.red;
        break;
      case 3:
        player.GetComponent<Renderer>().material.color = Color.green;
        break;
      case 4:
        player.GetComponent<Renderer>().material.color = Color.black;
        break;
      default:
        player.GetComponent<Renderer>().material.color = Color.white;
        break;
    }
  }
}
