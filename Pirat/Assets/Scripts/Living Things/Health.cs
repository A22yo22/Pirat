using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void Add_Health(int amount)
    {
        health += amount;
    }

    public void Subtract_Health(int amount)
    {
        health -= amount;
    }
}
