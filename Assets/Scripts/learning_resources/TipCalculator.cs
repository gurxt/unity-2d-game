using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipCalculator : MonoBehaviour {
  // bill is $40.00
  // tip is 20% or base on user input
  // calculate total amount
  public int bill = 40;
  public float tip = 20.0f;
  public float total;

  // Start is called before the first frame update
  void Start() {
    tip = bill * (tip / 100);
    total = bill + tip;

    Debug.Log(
      "Your bill is: $" + bill + 
      " and your tim amount is: $" + tip + 
      " thus you owe: $" + total
      );
  }

  // Update is called once per frame
  void Update() {
      
  }
}
