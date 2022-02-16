using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models;
using MItem = Assets.Scripts.Models.Item;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public static Knight instance;
    public float speed = 5f;

    private Animator anim;
    private GameObject objectInVicinity;
    private Inventory inventory;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        inventory = new Inventory(3);
    }

    // Update is called once per frame
    void Update()
    {
        // Attack
        if(Input.GetKeyDown("right shift"))
        {
            anim.SetTrigger("isAttacking");
        }

        // Jump
        if(Input.GetKeyDown("space"))
        {
            anim.SetTrigger("hasJumped");
        }

        // Pick up Item
        if(Input.GetKeyDown(KeyCode.E) && objectInVicinity != null)
        {
            PickUpItem();
        }

        // Drop Top Item
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalking", true);
            transform.localScale = new Vector3(1, 1, 1);
            Vector2 pos = transform.position;
            transform.position = pos + new Vector2(speed * Time.deltaTime, 0);
        } else if(Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isWalking", true);
            transform.localScale = new Vector3(-1, 1, 1);
            Vector2 pos = transform.position;
            transform.position = pos - new Vector2(speed * Time.deltaTime, 0);
        } else
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void SetObjectInVicinity(GameObject obj)
    {
        objectInVicinity = obj;
    }

    private void PickUpItem()
    {
        if (inventory.AddItem(objectInVicinity.GetComponent<Item>().Info))
        {
            UIManager.instance.UpdateInventoryText();
            Destroy(objectInVicinity);
        } else
        {
            UIManager.instance.ShowMessage("Unable to pick up item.");
        }
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    private void DropItem()
    {
        if(inventory.Items.Count > 0)
        {
            MItem item = inventory.RemoveItem(0);
            var itemObject = Resources.Load(item.PrefabName);
            GameObject obj = (GameObject)Instantiate(itemObject);
            obj.transform.position = transform.position;
        } else
        {
            UIManager.instance.ShowMessage("No items to drop!");
        }
    }
}
