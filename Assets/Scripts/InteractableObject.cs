using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool PlayerInRange;
    // public bool CanCollect;
    public string ItemName;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerInRange && SelectionManager.Instance.onTarget)
        {
            AddToInventory();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }

    public string GetItemName()
    {
        return ItemName;
    }

    public void AddToInventory() {
        Debug.Log("item added to inventory");
        Destroy(gameObject);
    }
}
 
 