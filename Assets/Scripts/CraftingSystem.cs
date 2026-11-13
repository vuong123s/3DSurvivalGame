using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <--- ĐÃ THÊM DÒNG NÀY VÀO ĐỂ SỬA LỖI

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;

    public List<string> inventoryItemList = new List<string>();
    
    Button toolsBTN;
    Button craftAxeBTN;

    Text AxeReq1, AxeReq2;
    public bool isOpen;

    public Blueprint AxeBLP = new Blueprint("Axe", 2, "Stone", 3, "Stick", 3);
    
    public static CraftingSystem Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        };
    }

    void Start()
    {
        isOpen = false;
        
        // Lưu ý: Để dòng này chạy được, trong Hierarchy bạn phải có một nút Button tên chính xác là "ToolsBTN" nằm trong craftingScreenUI
        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });
    
        //Axe
        AxeReq1 = toolsScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<Text>();
        AxeReq2 = toolsScreenUI.transform.Find("Axe").transform.Find("req2").GetComponent<Text>();

        craftAxeBTN = toolsScreenUI.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
        craftAxeBTN.onClick.AddListener(delegate {CraftAnyItem(AxeBLP); });

    }

    void CraftAnyItem(Blueprint blueprint)
    {
        InventorySystem.Instance.AddToInventory(blueprint.itemName);

        if(blueprint.numOfRequirements == 2)
        {
            InventorySystem.Instance.RemoveItem(blueprint.Req1, blueprint.Req1amount);
            InventorySystem.Instance.RemoveItem(blueprint.Req2, blueprint.Req2amount);
        }
        else if(blueprint.numOfRequirements == 1)
        {
            InventorySystem.Instance.RemoveItem(blueprint.Req1, blueprint.Req1amount);
        }

        StartCoroutine(calculate());
    }

    public IEnumerator calculate()
    {
        yield return 0;
        InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems();
    }



    void OpenToolsCategory()
    {
        // Đồng bộ danh sách từ các ô UI trước khi kiểm tra nguyên liệu.
        // Việc này cũng xử lý trường hợp người chơi vừa kéo/thả item trong inventory.
        InventorySystem.Instance.ReCalculateList();
        RefreshNeededItems();

        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
 
		    
            craftingScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);

            if(!InventorySystem.Instance.isOpen){
                Cursor.lockState = CursorLockMode.Locked;
            }

            isOpen = false;
        }
    }

    

    

    public void RefreshNeededItems()
    {
        int stone_count = 0;
        int stick_count = 0;

        inventoryItemList = InventorySystem.Instance.itemList;

        foreach (string itemName in inventoryItemList)
        {
            switch (itemName)
            {
                case "Stone":
                    stone_count++;
                    break;
                case "Stick":
                    stick_count++;
                    break;
            }
        }

        AxeReq1.text = "3 Stone [" + stone_count + "]";
        AxeReq2.text = "3 Stick [" + stick_count + "]";

        if(stone_count >= 3 && stick_count >= 3)
        {
            craftAxeBTN.gameObject.SetActive(true);
        }
        else
        {
            craftAxeBTN.gameObject.SetActive(false);
        }

    }

    // Alias for backward compatibility
    public void RefeshNeededItems()
    {
        RefreshNeededItems();
    }
}
