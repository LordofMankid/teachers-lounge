using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {
      public GameObject InventoryMenu;
      //public GameObject CraftMenu;
      public bool InvIsOpen = false;

      //5 Inventory Items:
    public static bool item1bool = false;
    public static bool item2bool = false;
    public static bool item3bool = false;
    public static bool item4bool = false;
    public static bool item5bool = false;
    public static bool item6bool = false;
    public static bool item7bool = false;

    public static int item1num = 0;
    public static int item2num = 0;
    public static int item3num = 0;
    public static int item4num = 0;
    public static int item5num = 0;
    public static int item6num = 0;
    public static int item7num = 0;
    

      [Header("Add item image objects here")]
      public GameObject item1image;
      public GameObject item2image;
      public GameObject item3image;
      public GameObject item4image;
      public GameObject item5image;
      public GameObject item6image;
      public GameObject item7image;
      

      // Item number text variables. Comment out if each item is unique (1/2).
      [Header("Add item number Text objects here")]
    public Text item1Text;
    public Text item2Text;
    public Text item3Text;
    public Text item4Text;
    public Text item5Text;
    public Text item6Text;
    public Text item7Text;

      public GameObject buttonUseResource1; 
 
      void Start(){
            InventoryMenu.SetActive(true);
            //CraftMenu.SetActive(false);
            InventoryDisplay();
      }

      void InventoryDisplay(){
            if (item1bool == true) {
                item1image.SetActive(true);
            } 
            else {
                item1image.SetActive(false);
            }
            if (item2bool == true) {item2image.SetActive(true);} else {item2image.SetActive(false);}
            if (item3bool == true) {item3image.SetActive(true);} else {item3image.SetActive(false);}
            if (item4bool == true) {item4image.SetActive(true);} else {item4image.SetActive(false);}
            if (item5bool == true) {item5image.SetActive(true);} else {item5image.SetActive(false);}
            if (item6bool == true) {item6image.SetActive(true);} else {item6image.SetActive(false);}
            if (item7bool == true) {item7image.SetActive(true);} else {item7image.SetActive(false);}

            //Text coinTextB = coinText.GetComponent<Text>();
            //coinTextB.text = ("COINS: " + coins);

            // Item number updates. Comment out if each item is unique (2/2).
            Text item1TextB = item1Text.GetComponent<Text>();
            item1TextB.text = ("Paper: " + item1num);

             Text item2TextB = item2Text.GetComponent<Text>();
            item2TextB.text = ("Book: " + item2num);

            Text item3TextB = item3Text.GetComponent<Text>();
            item3TextB.text = ("Laptop: "  + item3num);

            Text item4TextB = item4Text.GetComponent<Text>();
            item4TextB.text = ("FirstAid: " + item4num);

            Text item5TextB = item5Text.GetComponent<Text>();
            item5TextB.text = ("Resource5:" + item5num);

            Text item6TextB = item6Text.GetComponent<Text>();
            item6TextB.text = ("Resource6:" + item6num);

            Text item7TextB = item7Text.GetComponent<Text>();
            item7TextB.text = ("Resource7:" + item7num);
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "Paper") {item1bool = true; item1num ++;}
            else if (foundItemName == "Book") {item2bool = true; item2num ++;}
            else if (foundItemName == "Laptop") {item3bool = true; item3num ++;}
            else if (foundItemName == "First Aid") {item4bool = true; item4num ++;}
            else if (foundItemName == "item5") {item5bool = true; item5num ++;}
            else if (foundItemName == "item6") {item6bool = true; item6num ++;}
            else if (foundItemName == "item7") {item5bool = true; item7num ++;}
            else { Debug.Log("This item does not exist to be added"); }
            InventoryDisplay();

            if (!InvIsOpen){
                  OpenCloseInventory();
            }
      }

      public bool InventoryRemove(string item){
            string itemRemove = item;
        bool success = true;
            if (itemRemove == "Paper") {
                  item1num -= 1;
                  if (item1num <= 0) { item1bool =false; }
                  // Add any other intended effects: new item crafted, speed boost, slow time, etc
             }
             else if (itemRemove == "Book") {
                   item2num -= 1;
                   if (item2num <= 0) { item2bool =false; }
            //       // Add any other intended effects
               }
             else if (itemRemove == "Laptop") {
                   item3num -= 1;
                   if (item3num <= 0) { item3bool =false; }
                     // Add any other intended effects
             }
             else if (itemRemove == "First Aid") {
                   item4num -= 1;
                   if (item4num <= 0) { item4bool =false; }
                     // Add any other intended effects
             }
             else if (itemRemove == "item5") {
                   item5num -= 1;
                   if (item5num <= 0) { item5bool =false; }
                     // Add any other intended effects
            }else if (itemRemove == "item6") {
                   item6num -= 1;
                   if (item6num <= 0) { item6bool =false; }
                     // Add any other intended effects
            }else if (itemRemove == "item7") {
                   item7num -= 1;
                   if (item7num <= 0) { item7bool =false; }
                     // Add any other intended effects
            }
            else { Debug.Log("This item does not exist to be removed");
            success = false;    
        }
            InventoryDisplay();
        return success;
      }

      //public void CoinChange(int amount){
            //coins +=amount;
            //InventoryDisplay();
      //}

      // Open and Close the Inventory. Use this function on a button next to the inventory bar.
      public void OpenCloseInventory(){
            if (InvIsOpen){ InventoryMenu.SetActive(false); }
            else { InventoryMenu.SetActive(true); }
            InvIsOpen = !InvIsOpen;
      }

      //Open and Close the Cookbook
      //public void OpenCraftBook(){CraftMenu.SetActive(true);}
      //public void CloseCraftBook(){CraftMenu.SetActive(false);}

      // Reset all static inventory values on game restart.
      public void ResetAllInventory(){
            item1bool = false;
            item2bool = false;
            item3bool = false;
            item4bool = false;
            item5bool = false;
            item6bool = false;
            item7bool = false;

            item1num = 0; // object name
            item2num = 0; // object name
            item3num = 0; // object name
            item4num = 0; // object name
            item5num = 0; // object name
            item6num = 0;
            item7num = 0;
      }

}