using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScripts : MonoBehaviour
{
    [SerializeField] float TimeToJump;
    [SerializeField] float JumpPositionY;
    float StandPositionY;

    private void Start()
    {
        StandPositionY = transform.position.y;
        //Obstacle_PoolManager.Instance.OnCollider += OnCollider;
    }

    private void OnDestroy()
    {
        //Obstacle_PoolManager.Instance.OnCollider -= OnCollider;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            transform.DOMoveY(JumpPositionY, TimeToJump * .5f).SetEase(Ease.OutQuad).OnComplete(() =>
             {
                 transform.DOMoveY(StandPositionY, TimeToJump * .5f).SetEase(Ease.InQuad);
             });
        }
        
    }


    //void OnCollider(Transform Obstacle)
    //{
    //    float CheckX = Obstacle.position.x - transform.position.x;
    //    if(CheckX <=1.24f)
    //    {
    //        print("game over");
    //    }
    //}
}
