using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      private GameInventory gameInventory;
      public string itemName = "item1";

      void Start(){
            gameInventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
      }
 
      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                gameInventory.InventoryAdd(itemName);     
            }
      }
}