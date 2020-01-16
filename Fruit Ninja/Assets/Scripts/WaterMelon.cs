using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelon : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    public float startForce = 12f;
    Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blader")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            Debug.Log("WaterMelon");
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab,transform.position, rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }
}
