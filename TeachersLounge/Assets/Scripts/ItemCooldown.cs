using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCooldown : MonoBehaviour
{
    public GameObject item;

    public bool isVisible = false;

    public float cooldownTimer = 1f;

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
        yield return new WaitForSeconds(cooldownTimer);
        isVisible = true;
    }
}
