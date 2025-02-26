using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed;
    public static float xp=100;

    public GameObject enemy;

    public GameObject turrel;

    public GameObject wall;

    public GameObject fabrika_Oak;

    public GameObject camer;

    public static float materrial=200;

    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camer.transform.position=transform.position-new Vector3(0,0,10);
        speed=3f*Time.deltaTime;
        if(Input.GetKey(KeyCode.D))
        {
            transform.position= transform.position + new Vector3(speed,0,0);
        }else if(Input.GetKey(KeyCode.A))
        {
            transform.position= transform.position + new Vector3(speed*-1,0,0);
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.position= transform.position + new Vector3(0,speed);
        }else if(Input.GetKey(KeyCode.S))
        {
            transform.position= transform.position + new Vector3(0,speed*-1);
        }

        if(Input.GetKeyUp(KeyCode.Q) && materrial>=100)
        {
            materrial-=100;
            Event_help.list_turrel.Add(Instantiate(turrel, gameObject.transform.position, Quaternion.identity));
        }
        if(Input.GetKeyUp(KeyCode.E) && materrial>=50)
        {
            materrial-=50;
            Event_help.list_wall.Add(Instantiate(wall, gameObject.transform.position, Quaternion.identity));
        }
        if(Input.GetKeyUp(KeyCode.R) && materrial>=200)
        {
            materrial-=200;
            Event_help.list_fabrika.Add(Instantiate(fabrika_Oak, gameObject.transform.position, Quaternion.identity));
        }




        if(xp<=0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
            xp=100;
            materrial=200;
        }
         

    }
     void OnTriggerEnter2D( Collider2D colider)
    {
         if (colider.gameObject.tag == "enemy_bullet")
        {
        
            xp-=10;
            Debug.Log(xp+"player_XP");
            foreach(GameObject bullet_enemy in Event_help.list_bullet_enemy)
            {
                if(colider.transform.position==bullet_enemy.transform.position)
                {
                    
                  
                    Event_help.list_bullet_enemy.Remove(bullet_enemy);
                    Destroy(bullet_enemy);
                    break;
                }
            }


        }
    }

}
