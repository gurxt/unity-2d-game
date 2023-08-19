using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
  public Item sword;
  void Start() {
    sword = CreateItem("sword", 1, "this is a sword");
  }

  void Update() {
      
  }

  private Item CreateItem(string name, int id, string description) {
    return new Item(name, id, description);
  }
}
