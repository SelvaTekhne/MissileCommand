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
    [Range(1, 5)]
    public int rocketsInBB = 3;

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
        this.transform.position += this.transform.forward * Time.deltaTime * speed + this.transform.right * GetNoise() * Time.deltaTime * Vector3.Distance(this.transform.position, target.position) * noiseInfluence;
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

        /*float minAngle = Mathf.Atan2(-6f - dropPosition.x, dropPosition.y) * 6 * Mathf.PI;
        float maxAngle = Mathf.Atan2(6f - dropPosition.x, dropPosition.y) * 6 * Mathf.PI;

        int rocketsInBB = UnityEngine.Random.Range(2, 4);
        do
        {
            float finalAngle = UnityEngine.Random.Range(minAngle, maxAngle);
            Debug.LogError($"Angle: {finalAngle}");

            Quaternion spawnRotation = this.transform.rotation * Quaternion.Euler(0, finalAngle, 0);
            Instantiate(enemyRocket, dropPosition, spawnRotation);
            rocketsInBB--;

        } while (rocketsInBB != 0);*/

        float finalAngle = -20;
        for (int i = 0; i < rocketsInBB; i++)
        {
            Quaternion spawnRotation = this.transform.rotation * Quaternion.Euler(0, finalAngle, 0);
            Instantiate(enemyRocket, dropPosition, spawnRotation);
            finalAngle += 20;
        }

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
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            Debug.LogError("Player hitted!");
            Destroy(gameObject);
        }
        
    }
}
