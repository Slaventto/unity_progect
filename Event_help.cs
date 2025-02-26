using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_help : MonoBehaviour
{
    public GameObject enemy;
    public GameObject tnt_run;
    public GameObject tree;
    public GameObject base_enemy;

    public GameObject gun_enemy;


   static public List<GameObject> list_enemy = new List<GameObject>();
   static public List<GameObject> destr_towers = new List<GameObject>();
   static public List<GameObject> list_turrel = new List<GameObject>();
   static public List<GameObject> list_wall = new List<GameObject>();
   static public List<GameObject> list_bullet = new List<GameObject>();
   static public List<GameObject> list_fabrika= new List<GameObject>();
   static public List<GameObject> list_tree= new List<GameObject>();
   static public List<GameObject> list_tnt_runer=new List<GameObject>();
   static public List<GameObject> list_gun_enemy=new List<GameObject>();
   static public List<GameObject> list_bullet_enemy=new List<GameObject>();


   float time_voln;

   public int number_tree;

   private int count_point;

   private float counter_summ_point;

   public int summ_point=2;

   private int rng;

   private int price_object; 

   private bool create_enemy=false;





    // Start is called before the first frame update
    void Start()
    {
        count_point=summ_point;
        for(int i = 0;i<number_tree+1;i++)
        {
            list_tree.Add(Instantiate(tree, new Vector3(0, 0, 0), Quaternion.identity));


        }
    }

    // Update is called once per frame
    void Update()
    {

        counter_summ_point=counter_summ_point+1*Time.deltaTime;
        time_voln=time_voln+1*Time.deltaTime;
        if(counter_summ_point>=100)
        {
            summ_point=summ_point*2;
            Debug.Log("up_summ_point");
            counter_summ_point=0;
        }
        if(time_voln>=10)
        {

            time_voln-=10;
            count_point=summ_point;

            for(int i=0; count_point>0;i++)
            {
                create_enemy=false;
                rng=Random.Range(1, 4);
            for(int e = 0; create_enemy==false;e++)
            {
                if(rng==1)
                {
                    price_object=1;
                }else if(rng==2)
                {
                    price_object=2;
                }else if(rng==3)
                {
                    price_object=2;
                }
            
                if(count_point-price_object>=0)
                {
                    count_point-=price_object;
                    if(rng==1)
                    {
                        list_enemy.Add(Instantiate(enemy, base_enemy.transform.position+new Vector3(Random.Range(-2f, 3f),Random.Range(-2f, 3f)), Quaternion.identity));
                        create_enemy=true;
                    }else if(rng==2)
                    {
                        list_tnt_runer.Add(Instantiate(tnt_run, base_enemy.transform.position+new Vector3(Random.Range(-2f, 3f),Random.Range(-2f, 3f)), Quaternion.identity));
                        create_enemy=true;
                    }else if(rng==3)
                    {
                        list_gun_enemy.Add(Instantiate(gun_enemy, base_enemy.transform.position+new Vector3(Random.Range(-2f, 3f),Random.Range(-2f, 3f)), Quaternion.identity));
                        create_enemy=true;
                    }
                }else if(count_point-price_object<0)
                {
                    rng-=1;  
                }
            }
                
            }

        }



        
        
        if(Input.GetKeyUp(KeyCode.C))
         {
         list_enemy.Add(Instantiate(enemy, base_enemy.transform.position, Quaternion.identity));

         }
        if(Input.GetKeyUp(KeyCode.Q))
         {
            list_gun_enemy.Add(Instantiate(gun_enemy, base_enemy.transform.position+new Vector3(Random.Range(-2f, 3f),Random.Range(-2f, 3f)), Quaternion.identity));
                        create_enemy=true;
         }
        
        if(Input.GetKeyUp(KeyCode.X))
        {
           list_tnt_runer.Add(Instantiate(tnt_run, base_enemy.transform.position+new Vector3(Random.Range(-2f, 3f),Random.Range(-2f, 3f)), Quaternion.identity));
        }
    }
    
}
