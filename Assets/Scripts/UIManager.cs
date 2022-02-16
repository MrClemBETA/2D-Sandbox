using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MItem = Assets.Scripts.Models.Item;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text objectInVicinity;
    public Text inventoryText;
    public Text messageText;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectInVicinityText(bool active, string name="", float weight=0)
    {
        if(!active)
        {
            objectInVicinity.gameObject.SetActive(false);
        } else
        {
            objectInVicinity.gameObject.SetActive(true);
            objectInVicinity.text = name + ": " + weight + " lbs.";
        }
    }

    public void UpdateInventoryText()
    {
        string text = "Inventory:\n";
        foreach(MItem i in Knight.instance.GetInventory().Items)
        {
            text += i.Name + "\n";
        }

        inventoryText.text = text;
    }

    public void ShowMessage(string text)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = text;
        // Set a default color to full opaque by changing
        // alpha to 1
        Color c = messageText.color;
        c.a = 1f;
        messageText.color = c;

        StartCoroutine(FadeMessageAway());
    }

    private IEnumerator FadeMessageAway()
    {
        yield return new WaitForSeconds(3f);

        float fadeTime = 1.5f;
        while(messageText.color.a >= 0)
        {
            Color c = messageText.color;
            c.a -= Time.deltaTime / fadeTime;
            messageText.color = c;
            yield return null;
        }

        messageText.gameObject.SetActive(false);
    }
}
