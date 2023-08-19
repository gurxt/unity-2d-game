using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
  public int WeaponID;

  // ID 1 = Gun
  // ID 2 = Knife
  // ID 3 = Machine Gun

  void Start() {
    
  }

  void Update() {
    switch (WeaponID) {
      case 1: 
        Debug.Log("Gun");
        break;
      case 2: 
        Debug.Log("Knife");
        break;
      case 3: 
        Debug.Log("Machine Gun");
        break;
      default:
        Debug.Log("Invalid Weapon");
        break;
    }   
  }
}
