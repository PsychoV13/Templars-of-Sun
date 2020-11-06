using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerknight;
    public float cameradistance = 180;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameradistance);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(playerknight.position.x, playerknight.position.y, transform.position.z);
            
    }




}

