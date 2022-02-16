using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MItem = Assets.Scripts.Models.Item;

public class Item : MonoBehaviour
{
    public MItem Info;
    // Start is called before the first frame update
    void Start()
    {
        // Info = new MItem("Iron Sword", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SaveManager.Save(Info);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Info = SaveManager.Load();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Knight.instance.SetObjectInVicinity(gameObject);
            UIManager.instance.SetObjectInVicinityText(true, Info.Name, Info.Weight);
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
