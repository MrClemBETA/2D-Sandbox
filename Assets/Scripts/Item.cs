using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Model.Item info;
    // Start is called before the first frame update
    void Start()
    {
        info = new Model.Item("Iron Sword", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Knight.instance.SetObjectInVicinity(gameObject);
            UIManager.instance.SetObjectInVicinityText(true, info.Name, info.Weight);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Knight.instance.SetObjectInVicinity(null);
            UIManager.instance.SetObjectInVicinityText(false);
        }
    }
}
