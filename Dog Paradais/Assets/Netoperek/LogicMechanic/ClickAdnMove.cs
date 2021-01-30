using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAdnMove : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] GameObject swich;
    [SerializeField] GameObject moveObject;
    Transform startPoint;
    [SerializeField] Transform targetPoint;
    [Tooltip("Tag obejektu który ma to uruchomić")] [SerializeField] string interactiveObject;
    [SerializeField] bool isLoop = false;
    private void Awake()
    {
        startPoint = moveObject.transform;
        if (TryGetComponent(out Rigidbody2D rg))
        {
            this.rg = rg;
        }
        else
        {
            Debug.LogError(gameObject.name + " Brak komponentu Rigidbody 2D dla: " + moveObject.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == interactiveObject)
        {
            StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        while (true)
        {
            if (isLoop)
            {
                rg.MovePosition( Vector3.MoveTowards(moveObject.transform.position, targetPoint.position, 0.01f));
            }
            else
            {

            }
            //yield return new WaitForFixedUpdate();
            yield return null;
        }
    }
}
