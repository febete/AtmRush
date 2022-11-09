using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public bool isStackController;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "money" && !other.gameObject.GetComponent<Money>().isStackController && gameObject.GetComponent<Money>().isStackController)
        {
            PlayerMovement.instance.moneyStack[PlayerMovement.instance.stackCount] = other.gameObject;
            PlayerMovement.instance.stackCount++;

            other.gameObject.GetComponent<Money>().isStackController = true;
            PlayerMovement.instance.SS();
 
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
