using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);

        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Health>().Subtract_Health(damage);
            Destroy(gameObject);
        }
    }
}
