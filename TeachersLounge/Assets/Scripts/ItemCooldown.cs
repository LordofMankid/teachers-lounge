using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCooldown : MonoBehaviour
{
    public GameObject item;

    public bool isVisible = false;

    public float cooldownTimer = 5f;

    void Start()
    {
        isVisible = true; //new command to disable the object through the bool
    }

    void Update()
    {
        if (isVisible == true)
        {
            item.SetActive(true);
        }
        else
        {
            item.SetActive(false);
        }
        Debug.Log("hi");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startCooldown();
        }
    }

    public void startCooldown()
    {
        isVisible = !isVisible;
        Debug.Log("hi");
        StopCoroutine(DelayItemAway());
        StartCoroutine(DelayItemAway());

    }

    IEnumerator DelayItemAway()
    {
        yield return new WaitForSeconds(2f);
        isVisible = true;
    }
}
