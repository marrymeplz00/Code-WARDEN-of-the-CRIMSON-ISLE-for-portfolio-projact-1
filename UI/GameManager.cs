using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;
    public GameObject inventoryPanel;
    
    float toggleCooldown = 0.2f;
    float lastToggleTime;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        inventoryPanel.SetActive(false); 
        Time.timeScale = 1f;             
        isPaused = false;
        DisplayItem();
    }

    private void DisplayItem()
    {
        
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprites;

                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemNumbers[i].ToString();

                 slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = null;

                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && Time.unscaledTime - lastToggleTime > toggleCooldown)
        {
            ToggleInventory();
            lastToggleTime = Time.unscaledTime;
        }
    }

    public void AddItem(Item _item)
    {
        if(!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log(" YOU HAVE ALREALDY HAD THIS ONE!!!");
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }

        }
        DisplayItem();
    }

    public void RemoveItem(Item _item)
    {
        if(items.Contains(_item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]--;
                    if((itemNumbers[i]) == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("THERE IS NO" + _item + "IN MY BAGS");
        }
        DisplayItem();
    }

    void ToggleInventory()
{
    isPaused = !isPaused;
    inventoryPanel.SetActive(isPaused);
    Time.timeScale = isPaused ? 0f : 1f; 

    Cursor.visible = isPaused;
    Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
}

}

