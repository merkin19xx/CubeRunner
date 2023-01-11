using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleScripts : MonoBehaviour
{
    [SerializeField] float TimeToMove;
    public Vector2 Player;

    private void Start()
    {
        //Obstacle_PoolManager.Instance.OnCollider += OnCollider;

        if (Player == null)
        {
            Player = Vector2.zero;
        }
    }

    private void OnDestroy()
    {
        //Obstacle_PoolManager.Instance.OnCollider -= OnCollider;
    }

    void Update()
    {
        transform.DOMoveX(-15f, TimeToMove);

        if (transform.position.x <= -11f)
        {
            gameObject.SetActive(false);
        }
        float CheckX = transform.position.x - Player.x;
        print(CheckX);

    }
    
}
