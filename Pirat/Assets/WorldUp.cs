using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUp : MonoBehaviour
{
    public Transform cat;
    public Transform world;

    // Update is called once per frame
    void Update()
    {
        transform.position = cat.position;
        transform.rotation = Quaternion.Euler(cat.position.x - world.position.x, 0, cat.position.z - world.position.z);
    }
}
