using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCameraTarget : MonoBehaviour
{
    public Transform cat;

    void Update()
    {
        transform.position = cat.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, cat.rotation, Time.deltaTime);
    }
}
