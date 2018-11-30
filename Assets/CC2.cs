using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC2 : MonoBehaviour {
    int D = 0;
    public void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.tag == "Enemy" || Object.tag == "Bullet")
        {
            Destroy(gameObject);
            

        }
    }

}
