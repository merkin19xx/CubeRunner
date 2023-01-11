using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_PoolManager : MonoBehaviour
{
    
    [System.Serializable]
    public class Pool
    {
        public string Name;
        public ObstacleScripts PrefabsOstacle; //
        public int Size;
        
    }
    

    public static Obstacle_PoolManager Instance;

    void Awake()
    {
        //Instance = this;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<Pool> ListPool;
    Dictionary<string, Queue<GameObject>> DictOstacle;

    void Start()  //sinh ra object, setAtive = false, xep hang Queue
    {
        DictOstacle = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool PoolElement in ListPool)
        {
            PoolElement.PrefabsOstacle.Player = Player;
            Queue<GameObject> ObjectInPool = new Queue<GameObject>();
            for (int i = 0; i < PoolElement.Size; i++)
            {
                GameObject CloneObject = Instantiate(PoolElement.PrefabsOstacle.gameObject);
                //PoolElement.PrefabsOstacle.Player = Player;
                
                CloneObject.SetActive(false);
                ObjectInPool.Enqueue(CloneObject);
                //OnCollider(Player);
            }

            DictOstacle.Add(PoolElement.Name, ObjectInPool);
        }

        IsSpawn = true;

        //
        //if(OstaclePos == null)
        //{
        //    return;
        //}
    }


    GameObject SpawnPool(string KeyDict, Vector2 StartPosition)
    {

        //Debug.Log("position: "+ position);
        if (!DictOstacle.ContainsKey(KeyDict))
        {
            Debug.Log("Pool with name " + KeyDict + "doesnt exist");
            return null;
        }

        //nhay vao day
        GameObject ObjectDequeue = DictOstacle[KeyDict].Dequeue();

        ObjectDequeue.SetActive(true);
        ObjectDequeue.transform.position = StartPosition;

        DictOstacle[KeyDict].Enqueue(ObjectDequeue);
        return ObjectDequeue;
    }

    bool IsSpawn;
    float ObstacleRandomPosY;
    IEnumerator SpawnObstacle()
    {
        
        if (IsSpawn)
        {
            ObstacleRandomPosY = UnityEngine.Random.Range(-5f, -3f);

            SpawnPool("Obstacle", new Vector2(15, ObstacleRandomPosY));
            

            IsSpawn = false;
            yield return new WaitForSeconds(2);
            IsSpawn = true;
        }
        
    }


    private void Update()
    {
        StartCoroutine("SpawnObstacle");

    }

    [SerializeField] Vector2 Player;
    //public Action<Transform> OnCollider; //loi o day
}
