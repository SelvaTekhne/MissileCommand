using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BigBrother : MonoBehaviour, IDestroyable
{
    public static event Action Destroyed;
    [SerializeField] private float speed = 1;
    public GameObject enemyRocket;

    public void Update()
    {
        //float step = speed * Time.deltaTime;
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
        //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
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
