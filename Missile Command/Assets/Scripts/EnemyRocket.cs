using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EnemyRocket : MonoBehaviour, IDestroyable
{
    public static event Action Destroyed;
    public static event Action<int> RocketHitIntoPlayer;

    [SerializeField] private float speed = 1;
    [SerializeField] private float protectionDuration = 1.5f;
    [SerializeField] private int damageForBullets = 1;
    public CapsuleCollider rocketCollider;
    public GameObject trailRenderer;

    public void Awake()
    {
        speed = speed + 0.2f * LevelManager.Level;
        rocketCollider.enabled = false;
    }

    public void Start()
    {
        Waiting();
    }


    public void Update()
    {
        //float step = speed * Time.deltaTime;
        this.transform.position += transform.forward * Time.deltaTime * speed;
        //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
    }

    public void Destroy()
    {
        //Debug.Log("Bang!");
        Destroyed?.Invoke();
        //trailRenderer.transform.parent = null;
        //Destroy(trailRenderer.gameObject, 13);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Łup-");
        if (collision.gameObject.tag == "City")
        {
           // Debug.Log("-du-");
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
            if (destroyable != null)
            {
                destroyable.Destroy();
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            //Debug.LogError("Player hitted!");
            RocketHitIntoPlayer?.Invoke(damageForBullets);
            Destroy(gameObject);
        }
        //trailRenderer.transform.parent = null;
        //Destroy(trailRenderer.gameObject, 13);
        Destroy(gameObject);
    }

    private void Waiting()
    {
        StartCoroutine(ProtectionTime());
    }

    IEnumerator ProtectionTime()
    {
        yield return new WaitForSecondsRealtime(protectionDuration);
        rocketCollider.enabled = true;
    }
}
    