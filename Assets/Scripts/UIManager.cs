using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text objectInVicinity;

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
}
