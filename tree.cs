using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    private float xp_tree=50;
    private bool origenal=false;

    private bool colis_plaer=false;

    private float time_brake_tree=1;
    // Start is called before the first frame update
    void Start()
    {
        if(Event_help.list_tree.Count==0)
        {
            origenal=true;
        }
        if(origenal==false)
        {
            transform.position=new Vector2(Random.Range(-97, 78f), Random.Range(97f, -55f));
        }
    }

    // Update is called once per frame
    void Update()
    {

        time_brake_tree=time_brake_tree+1*Time.deltaTime;

        if(time_brake_tree>=1 && colis_plaer==true && Input.GetMouseButtonDown(0))
        {
            time_brake_tree=0;
            xp_tree-=10;
            Debug.Log(xp_tree+"XP_tree");
        }
        if(xp_tree<=0)
        {
            foreach(GameObject tree in Event_help.list_tree)
            {
                if(tree.transform.position==transform.position)
                {
                    Event_help.list_tree.Remove(tree);
                    Player.materrial+=100;
                    Destroy(tree);
                }
            }
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colis_plaer=true;
            
        
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colis_plaer=false;
            
        
        }
    }




}
