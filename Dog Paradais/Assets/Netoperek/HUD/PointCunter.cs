using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCunter : MonoBehaviour
{
    [SerializeField] Text pointText;
    int point = 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Token")
        {
            point++;
            pointText.text = point.ToString();
        }
    }
}
