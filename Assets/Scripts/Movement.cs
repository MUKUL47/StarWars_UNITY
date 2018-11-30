using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{

    Rigidbody2D Player;
    public GameObject Bullet, Enemy;
    float time = .25f, m = -8f , eY = 3.6f, T = 4;
    bool canShoot = true, spawn=true ,reset=false;
    GameObject Enemy1,Bullet1;
    int wave = 0, n = -1, score = 0 ,k=0;
    public Text Score, Wave, Gameover;
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        Score.text = "SCORE : " + score;
    }

    void Update()
    {
       
        float X = Input.GetAxis("Mouse X"); ;
        Player.velocity = new Vector2(X, 0) * 20;
        if (!reset)
        {
            shootBullets();
            spawnEnemies();
        }
        else
        {
            Reset();
        }
        
      
    }
    void shootBullets()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Bullet1 = Instantiate(Bullet, new Vector2(Player.position.x, -2.6f), Quaternion.identity);           
            Bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
            Bullet1.tag = "Bullet";
            canShoot = false;
            time = .25f;
          


        }
        if (!canShoot)
        {
            time -= Time.deltaTime;
            if (time <= 0) { canShoot = true; }
        }
        checkBoundary();
       
    }
    void spawnEnemies()
    {
        if (spawn) { wave += 1; n += 1; eY =  3.6f;  }
        Wave.text = "WAVE : " + (wave);

        for (int i = 0; i < (9*wave) && spawn; i++)
        {
            if(wave>1 && i % 9 == 0) { eY += 1; m = -8f; }
            Enemy1 = Instantiate(Enemy, new Vector2(m, eY), Quaternion.identity);
            Enemy1.tag = "Enemy";
            m += 2f;
        }
        spawn = false;
        moveEnemies();
    }
    void moveEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                ++k;
                Enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
                if (Enemy.GetComponent<Rigidbody2D>().position.y <= -5.6 && k == GameObject.FindGameObjectsWithTag("Enemy").Length - 1)
                {
                    score += (wave * 9) - k - 1;
                    deleteEnemies();

                }
            }
        }
        else
        {
            score += (wave * 9);
            spawn = true;
            m = -8f;

        }
        Score.text = "SCORE : " + score;
        k = 0;
       
    }
    void deleteEnemies()
    {
       
        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {                        
            Destroy(Enemy);
            spawn = true;
            m = -8f;            
        }
        
    }
    void checkBoundary()//bullet
    {
        foreach (GameObject Bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            if (Bullet.GetComponent<Rigidbody2D>().position.y >= 6.6f) { Destroy(Bullet); }            
        }
    }
    private void OnTriggerEnter2D(Collider2D Object)    {         reset = true;         }

    void Reset()
    {
        
        if (T >= 0)
        {
            Gameover.text = "GameOver!!\nStarting in " + (int)T;
            T -= Time.deltaTime;
        }
        else
        {
            T = 4;
            Gameover.text = "";            
            score = 0;
            wave = 0;
            reset = false;
            deleteEnemies();
            eY = 3.6f;
        }
            


    }

}

