using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BigBrother : MonoBehaviour, IDestroyable
{
    public static event Action Destroyed;
    [SerializeField] private float speed = 1, noiseInfluence = 1;
    public GameObject enemyRocket;
    private Transform target;

    private float random;

    private void Awake()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        random = UnityEngine.Random.Range(0, 1000);
        target = FindObjectOfType<PlayerShooting>().transform;
    }

    public void Update()
    {
        //float step = speed * Time.deltaTime;
        this.transform.position += this.transform.forward * Time.deltaTime * speed + this.transform.right * GetNoise() * Time.deltaTime * noiseInfluence;
        transform.LookAt(target, this.transform.up);
        //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
    }

    private float GetNoise()
    {
        return Mathf.PerlinNoise(this.transform.position.x * random, this.transform.position.y * random) - 0.5f;
    }

    public void Destroy()
    {
        Vector3 dropPosition = this.transform.position;
        Debug.Log("Bang!");
        Destroyed?.Invoke();
        Instantiate(enemyRocket, dropPosition, this.transform.rotation);
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
        Destroy(gameObject);
    }
}
