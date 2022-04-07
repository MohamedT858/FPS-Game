using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public int Health = 100;
    public void TakenDamage(int AmoutOfDamage)
    {
        Health -= AmoutOfDamage;
    }
    void Update()
    {
        
        if (Health <= 0)
        {
            Debug.Log("Died!!");
            Die();
            
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Deystroyed!!!!");
    }
}

