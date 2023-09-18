using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class PlayerMagneticTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollectableBase i = other.transform.GetComponent<ItemCollectableCoins>();
        if(i != null)
        {
            i.gameObject.AddComponent<Magnetic>();
        }
    }
}
