using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class che : MonoBehaviour {
    string deletedEnemies;
    public Text left;
    private void start()
    {
        deletedEnemies = "";
    }
    public void OnTriggerEnter2D(Collider2D Object)
    {
        
        
        if (Object.tag == "Enemy" || Object.tag == "Bullet") {
            
            print(deletedEnemies); deletedEnemies += "D";
            DeleteObject(Object);
        }
       //

    }
    void DeleteObject(Collider2D G)
    {
        Destroy(gameObject);
    }
   
  


}
