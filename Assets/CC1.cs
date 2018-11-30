using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC1 : MonoBehaviour {

  
    public void OnTriggerEnter2D(Collider2D Object)
    {


        if (Object.tag == "Enemy" || Object.tag == "Bullet")
        {

            Destroy(gameObject);
            
        }

    }
  
}
