using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    private GameInventory gameInventory;
    private string itemName;

    void Start()
    {
        gameInventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "taskIcon")
        {
            Debug.Log("task hit");
            other.gameObject.GetComponent<TaskIcon>().completeTask(other.gameObject);
        } 
        else if (other.transform.parent.tag == "Resource")
        {
            Debug.Log("object hit");
            itemName = other.transform.parent.name;
            other.gameObject.GetComponentInParent<AudioSource>().Play();
            // start cooldown script on the object hit
            other.gameObject.GetComponentInParent<ItemCooldown>().startCooldown();
            gameInventory.InventoryAdd(itemName);
            StartCoroutine(DestroySound());
        }

        IEnumerator DestroySound(){
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<AudioSource>().Stop();
         }

    }
}