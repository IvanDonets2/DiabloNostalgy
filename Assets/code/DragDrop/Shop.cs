using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI ;

public static class FileHelper
{
 
    public static string[] ReadAllLines(string path)
    {
        // 🔹 Якщо це абсолютний шлях (C:\ або /Users/...), читаємо напряму
        if (Path.IsPathRooted(path))
        {
            if (File.Exists(path))
                return File.ReadAllLines(path);
            else
            {
                Debug.LogError("Файл не знайдено: " + path);
                return new string[0];
            }
        }

        // 🔹 Якщо це відносний шлях — читаємо через Resources
        // (без .txt і без Assets/)
        if (path.EndsWith(".txt"))
            path = path.Substring(0, path.Length - 4);

        TextAsset file = Resources.Load<TextAsset>(path);

        if (file == null)
        {
            Debug.LogError("Файл не знайдено у Resources: " + path);
            return new string[0];
        }

        return file.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
    }
}
public class Shop : MonoBehaviour {

    public GameObject[] ShopSlots;
    public GameObject[] SmallSlots;

    public GameObject SmallItemsPanel;
    public GameObject BigItemsPanel;

    public bool HaveSmallSlots = false;

    public GameObject ItemPrefab;

    public GameObject _canvas;

    public Inventory InventoryScript;

 
    string ItemsPath = ""; 


    
      string PhilosophersNamesListFile = "Philosophers/PhilosophersList"; 



    public string InventoryItemsPrefix = "Inventory items";

    string RndSuffix = "";


    public string[] ItemsList;

    // Use this for initialization
    void Start ()
    {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowInventoryBigSlots()
    {
        _canvas = GameObject.Find("Canvas");
        DragDropMemory DragDropMemoryScript = _canvas.GetComponent<DragDropMemory>();

        InventoryScript = DragDropMemoryScript.InventoryScript;
        InventoryScript._BigItemsButton();

    }
    void ShowInventorySmallSlots()
    {
        _canvas = GameObject.Find("Canvas");
        DragDropMemory DragDropMemoryScript = _canvas.GetComponent<DragDropMemory>();

        InventoryScript = DragDropMemoryScript.InventoryScript;
        InventoryScript._SmallItemsButton();

    }
    public void _ButtonSwords()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateSwords();


    }

    public void _ButtonAxes()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateAxes();
        ShowInventoryBigSlots();
    }

    public void _ButtonMaces()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateMaces();
        ShowInventoryBigSlots();
    }

    public void _ButtonStaffs()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateStaffs();
        ShowInventoryBigSlots();
    }

    public void _ButtonBows()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateBows();
        ShowInventoryBigSlots();
    }

    public void _ButtonShields()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateShields();
        ShowInventoryBigSlots();
    }
    public void _ButtonHelms()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateHelms();
        ShowInventoryBigSlots();
    }

    public void _ButtonArmor()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();

        CreateArmor();
        ShowInventoryBigSlots();
    }

    public void _ButtonJewelry()
    {
        ShowOnlySmallItemsPanel();
        ClearItems();

        CreateJewelry();
        ShowInventorySmallSlots();
    }

    public void _ButtonClear()
    {
        ClearItems();
    }



    public void ShowOnlyBigItemsPanel()
    {
        SmallItemsPanel.SetActive(false);
        BigItemsPanel.SetActive(true);
    }

    public void ShowOnlySmallItemsPanel()
    {
        BigItemsPanel.SetActive(false);
        SmallItemsPanel.SetActive(true);
    }


    public void _ButtonWirt()
    {

    }

    public void _ButtonPepinBigItems()
    {
        ShowOnlyBigItemsPanel();
        ClearItems();
        ShowInventoryBigSlots();

    }

    public void _ButtonPepinSmallItems()
    {
        ShowOnlySmallItemsPanel();
        ClearItems();
        ShowInventorySmallSlots();

    }


    public void _ButtonScrolls()
    {
        ShowOnlySmallItemsPanel();
        ClearItems();

        CreateScrolls();
        ShowInventorySmallSlots();
    }


    public void CreateScrolls()
    {
        //health

        string ItemsFile = PhilosophersNamesListFile;

 
 
        TextAsset itemsFile = Resources.Load<TextAsset>(PhilosophersNamesListFile);

        if (itemsFile == null)
        {
            Debug.LogError("Не знайдено файл: " + PhilosophersNamesListFile);
            return;
        }

        string[] ItemsList = itemsFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < ItemsList.Length; i++)
        {
            ReadScroll("Health", ItemsList[i], SmallSlots[i].transform);
        }
    }

    public void CreateBows()
    {
        ReadFile("weapons", "bows");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadBow("weapons", "bows", ItemsList[i], ShopSlots[i].transform);

        }
    }

    
    public void CreateShields()
    {
        ReadFile("armor", "shields");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadShield("armor", "shields", ItemsList[i], ShopSlots[i].transform);

        }
    }
    

     public void CreateHelms()
    {
        ReadFile("armor", "helms");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadHelm("armor", "helms", ItemsList[i], ShopSlots[i].transform);

        }
    }
    public void CreateArmor()
    {
        ReadFile("armor", "armor");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadArmor("armor", "armor", ItemsList[i], ShopSlots[i].transform);

        }
    }

    
  public void CreateJewelry()
    {
        ReadFile("jewelry", "jewelry");


        

        for (int i = 0; i < ItemsList.Length; i++)
        {
            for (int c = 0; c < 10; c++)
            {
                if (i == 0)
                {
                    MakeSuffix();
                    ReadJewelry("jewelry", "jewelry", ItemsList[i], SmallSlots[c].transform);

                }
                if (i == 1)
                {
                    MakeSuffix();
                    ReadJewelry("jewelry", "jewelry", ItemsList[i], SmallSlots[10 + c].transform);

                }
            }

        }



    }

    public void CreateSwords()
    {
        ReadFile("weapons", "swords");
               

        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadSword("weapons", "swords", ItemsList[i], ShopSlots[i].transform );

        }
    }

    public void CreateAxes()
    {
        ReadFile("weapons", "axes");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadAxes("weapons", "axes", ItemsList[i], ShopSlots[i].transform);

        }
    }

    public void CreateMaces()
    {
        ReadFile("weapons", "maces");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadMaces("weapons", "maces", ItemsList[i], ShopSlots[i].transform);

        }
    }

    public void CreateStaffs()
    {
        ReadFile("weapons", "staffs");


        for (int i = 0; i < ItemsList.Length; i++)
        {
            MakeSuffix();
            ReadStaffs("weapons", "staffs", ItemsList[i], ShopSlots[i].transform);

        }
    }

    public void ReadFile(string Category, string Category2)
    {

 

 
        string resourcePath = ItemsPath + Category + "/" + Category2 + "/" + Category2 + "List";

 
        TextAsset file = Resources.Load<TextAsset>(resourcePath);

        if (file == null)
        {
            Debug.LogError("Не знайдено файл: " + resourcePath);
            return;
        }

        // Розбиваємо текст на рядки
        ItemsList = file.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        Debug.Log($"Файл {resourcePath} прочитано. Рядків: {ItemsList.Length}");
    }


    void ReadScroll(string CategoryOfMantra,string Mantra, Transform Parent)
    {
        string PriceFile = "/Hero/items/scrolls/Price.txt";// "c:\\unity3d resources\\Hero\\items\\scrolls\\Price.txt";

        string[] priceStr = FileHelper.ReadAllLines(PriceFile);//  
        int price = int.Parse(priceStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = "Scroll of " + CategoryOfMantra;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = "Scroll of " + CategoryOfMantra;

        DraggableItemScript.mantra = Mantra;


       DraggableItemScript.ItemKind = ItemKindEnum.Scroll;
                       

        DraggableItemScript.ItemCategory = ItemCategoryEnum.Scroll;


        DraggableItemScript.ItemSize = SmallBigItemEnum.SmallItem;

        DraggableItemScript.price = price;

       

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\scrolls\\scroll";

        img.sprite = Resources.Load<Sprite>(spritePath);
    }


    public void ReadJewelry(string Category, string Category2, string JewelryName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "Price.txt";
        //string DefenceMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "DefenceMin.txt";
       // string DefenceMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "DefenceMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "AppearanceLevel.txt";
       // string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "Durability.txt";
        // string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "Hands.txt";
      //  string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "RequiredDex.txt";
      //  string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + JewelryName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);// 
        int price = int.Parse(priceStr[0]);

 

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile );// 
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

 


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = JewelryName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = JewelryName + RndSuffix;

        if (JewelryName == "Ring")
        {
            DraggableItemScript.ItemKind = ItemKindEnum.Ring;

        }
        if (JewelryName == "Amulet")
        {
            DraggableItemScript.ItemKind = ItemKindEnum.Amulet;

        }

        DraggableItemScript.ItemCategory = ItemCategoryEnum.Jewelry;


        DraggableItemScript.ItemSize = SmallBigItemEnum.SmallItem;

        DraggableItemScript.price = price;

        //DraggableItemScript.DefenceMin = DefenceMin;

        //DraggableItemScript.DefenceMax = DefenceMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        //DraggableItemScript.Durability = Durability;

        //   DraggableItemScript.Hands = Hands;

        //DraggableItemScript.RequiredDex = RequiredDex;

        //DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\jewelry\\jewelry\\" + JewelryName;

        img.sprite = Resources.Load<Sprite>(spritePath);



    }



    public void ReadShield(string Category, string Category2, string ShieldName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "Price.txt";
        string DefenceMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "DefenceMin.txt";
        string DefenceMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "DefenceMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "Durability.txt";
       // string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);//  
        int price = int.Parse(priceStr[0]);
    
        string[] DefenceMinStr = FileHelper.ReadAllLines(DefenceMinFile);//();
        int DefenceMin = int.Parse(DefenceMinStr[0]);

        string[] DefenceMaxStr = FileHelper.ReadAllLines(DefenceMaxFile);//  
        int DefenceMax = int.Parse(DefenceMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);//  
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);//  
        int Durability = int.Parse(DurabilityStr[0]);

 


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = ShieldName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = ShieldName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Shield;

        DraggableItemScript.ItemCategory = ItemCategoryEnum.Armor;


        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;

        DraggableItemScript.price = price;

        DraggableItemScript.DefenceMin = DefenceMin;

        DraggableItemScript.DefenceMax = DefenceMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

     //   DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\armor\\shields\\" + ShieldName;

        img.sprite = Resources.Load<Sprite>(spritePath);



    }


    public void ReadArmor(string Category, string Category2, string ArmorName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "Price.txt";
        string DefenceMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "DefenceMin.txt";
        string DefenceMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "DefenceMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "Durability.txt";
        // string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + ArmorName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DefenceMinStr = FileHelper.ReadAllLines(DefenceMinFile);
        int DefenceMin = int.Parse(DefenceMinStr[0]);

        string[] DefenceMaxStr = FileHelper.ReadAllLines(DefenceMaxFile);
        int DefenceMax = int.Parse(DefenceMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

 


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = ArmorName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = ArmorName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Armor;

        DraggableItemScript.ItemCategory = ItemCategoryEnum.Armor;


        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;

        DraggableItemScript.price = price;

        DraggableItemScript.DefenceMin = DefenceMin;

        DraggableItemScript.DefenceMax = DefenceMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        //   DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\armor\\armor\\" + ArmorName;

        img.sprite = Resources.Load<Sprite>(spritePath);



    }


    

    public void ReadHelm(string Category, string Category2, string HelmName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "Price.txt";
        string DefenceMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "DefenceMin.txt";
        string DefenceMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "DefenceMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "Durability.txt";
        // string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + ShieldName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + HelmName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DefenceMinStr = FileHelper.ReadAllLines(DefenceMinFile);
        int DefenceMin = int.Parse(DefenceMinStr[0]);

        string[] DefenceMaxStr = FileHelper.ReadAllLines(DefenceMaxFile);
        int DefenceMax = int.Parse(DefenceMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

 


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = HelmName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = HelmName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Helm;

        DraggableItemScript.ItemCategory = ItemCategoryEnum.Armor;


        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;

        DraggableItemScript.price = price;

        DraggableItemScript.DefenceMin = DefenceMin;

        DraggableItemScript.DefenceMax = DefenceMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        //   DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\armor\\helms\\" + HelmName;

        img.sprite = Resources.Load<Sprite>(spritePath);



    }


    public void ReadStaffs(string Category, string Category2, string StaffName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "Price.txt";
        string DamageMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "DamageMin.txt";
        string DamageMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "DamageMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "Durability.txt";
        string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + StaffName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DamageMinStr = FileHelper.ReadAllLines(DamageMinFile);
        int DamageMin = int.Parse(DamageMinStr[0]);

        string[] DamageMaxStr = FileHelper.ReadAllLines(DamageMaxFile);
        int DamageMax = int.Parse(DamageMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

        string[] HandsStr = FileHelper.ReadAllLines(HandsFile);
        int Hands = int.Parse(HandsStr[0]);


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = StaffName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = StaffName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Staff;

        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;

        DraggableItemScript.ItemCategory = ItemCategoryEnum.Weapon;


        DraggableItemScript.price = price;

        DraggableItemScript.DamageMin = DamageMin;

        DraggableItemScript.DamageMax = DamageMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\weapons\\staffs\\" + StaffName;

        img.sprite = Resources.Load<Sprite>(spritePath);




       


    }


    void MakeSuffix()
    {
      

 
 

 

 
        TextAsset file = Resources.Load<TextAsset>(PhilosophersNamesListFile);

        if (file == null)
        {
            Debug.LogError("Не знайдено файл: " + PhilosophersNamesListFile);
            return;
        }

        // Розбиваємо текст на рядки
        string[] PersonsStr = file.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        int PersonsNum = PersonsStr.Length;

        if (PersonsNum == 0)
        {
            Debug.LogWarning("Файл порожній");
            return;
        }

        int RndNumber = Random.Range(0, PersonsNum);

        RndSuffix = " of " + PersonsStr[RndNumber];

        Debug.Log("Випадковий суфікс: " + RndSuffix);








    }


    public void ReadMaces(string Category, string Category2, string MaceName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "Price.txt";
        string DamageMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "DamageMin.txt";
        string DamageMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "DamageMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "Durability.txt";
        string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + MaceName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DamageMinStr = FileHelper.ReadAllLines(DamageMinFile);
        int DamageMin = int.Parse(DamageMinStr[0]);

        string[] DamageMaxStr = FileHelper.ReadAllLines(DamageMaxFile);
        int DamageMax = int.Parse(DamageMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

        string[] HandsStr = FileHelper.ReadAllLines(HandsFile);
        int Hands = int.Parse(HandsStr[0]);


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = MaceName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = MaceName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Mace;

        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;
        DraggableItemScript.ItemCategory = ItemCategoryEnum.Weapon;

        DraggableItemScript.price = price;

        DraggableItemScript.DamageMin = DamageMin;

        DraggableItemScript.DamageMax = DamageMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

        string spritePath = "Inventory items\\weapons\\maces\\" + MaceName;

        img.sprite = Resources.Load<Sprite>(spritePath);



    }


    public void ReadAxes(string Category, string Category2, string AxeName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "Price.txt";
        string DamageMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "DamageMin.txt";
        string DamageMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "DamageMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "Durability.txt";
        string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + AxeName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DamageMinStr = FileHelper.ReadAllLines(DamageMinFile);
        int DamageMin = int.Parse(DamageMinStr[0]);

        string[] DamageMaxStr = FileHelper.ReadAllLines(DamageMaxFile);
        int DamageMax = int.Parse(DamageMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

        string[] HandsStr = FileHelper.ReadAllLines(HandsFile);
        int Hands = int.Parse(HandsStr[0]);


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = AxeName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = AxeName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Axe;

        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;
        DraggableItemScript.ItemCategory = ItemCategoryEnum.Weapon;

        DraggableItemScript.price = price;

        DraggableItemScript.DamageMin = DamageMin;

        DraggableItemScript.DamageMax = DamageMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();                        

        string spritePath = "Inventory items\\weapons\\axes\\" + AxeName;
               
        img.sprite = Resources.Load<Sprite>(spritePath);

        

    }

    public void ReadSword(string Category, string Category2,string SwordName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "Price.txt";
        string DamageMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "DamageMin.txt";
        string DamageMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "DamageMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "Durability.txt";
        string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + SwordName + "\\" + "RequiredStr.txt";
        

        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DamageMinStr = FileHelper.ReadAllLines(DamageMinFile);
        int DamageMin = int.Parse(DamageMinStr[0]);

        string[] DamageMaxStr = FileHelper.ReadAllLines(DamageMaxFile);
        int DamageMax = int.Parse(DamageMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

        string[] HandsStr = FileHelper.ReadAllLines(HandsFile);
        int Hands = int.Parse(HandsStr[0]);


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


     GameObject NewItem=   Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = SwordName + RndSuffix;

        DraggableItem DraggableItemScript= NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = SwordName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Sword;

        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;
        DraggableItemScript.ItemCategory = ItemCategoryEnum.Weapon;

        DraggableItemScript.price = price;

        DraggableItemScript.DamageMin = DamageMin;

        DraggableItemScript.DamageMax = DamageMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();



        

        string spritePath = "Inventory items\\weapons\\swords\\" + SwordName;// + ".gif";


        img.sprite = Resources.Load<Sprite>(spritePath);
      
        

    }


    public void ReadBow(string Category, string Category2, string BowName, Transform Parent)
    {
        string PriceFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "Price.txt";
        string DamageMinFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "DamageMin.txt";
        string DamageMaxFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "DamageMax.txt";
        string AppearanceLevelFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "AppearanceLevel.txt";
        string DurabilityFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "Durability.txt";
        string HandsFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "Hands.txt";
        string RequiredDexFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "RequiredDex.txt";
        string RequiredStrFile = ItemsPath + Category + "\\" + Category2 + "\\" + BowName + "\\" + "RequiredStr.txt";


        string[] priceStr = FileHelper.ReadAllLines(PriceFile);
        int price = int.Parse(priceStr[0]);

        string[] DamageMinStr = FileHelper.ReadAllLines(DamageMinFile);
        int DamageMin = int.Parse(DamageMinStr[0]);

        string[] DamageMaxStr = FileHelper.ReadAllLines(DamageMaxFile);
        int DamageMax = int.Parse(DamageMaxStr[0]);

        string[] AppearanceLevelStr = FileHelper.ReadAllLines(AppearanceLevelFile);
        int AppearanceLevel = int.Parse(AppearanceLevelStr[0]);

        string[] DurabilityStr = FileHelper.ReadAllLines(DurabilityFile);
        int Durability = int.Parse(DurabilityStr[0]);

        string[] HandsStr = FileHelper.ReadAllLines(HandsFile);
        int Hands = int.Parse(HandsStr[0]);


        string[] RequiredDexStr = FileHelper.ReadAllLines(RequiredDexFile);
        int RequiredDex = int.Parse(RequiredDexStr[0]);

        string[] RequiredStrStr = FileHelper.ReadAllLines(RequiredStrFile);
        int RequiredStr = int.Parse(RequiredStrStr[0]);


        GameObject NewItem = Instantiate(ItemPrefab, Parent);

        NewItem.transform.name = BowName + RndSuffix;

        DraggableItem DraggableItemScript = NewItem.GetComponent<DraggableItem>();

        DraggableItemScript._name = BowName + RndSuffix;

        DraggableItemScript.ItemKind = ItemKindEnum.Bow;

        DraggableItemScript.ItemSize = SmallBigItemEnum.BigItem;
        DraggableItemScript.ItemCategory = ItemCategoryEnum.Weapon;

        DraggableItemScript.price = price;

        DraggableItemScript.DamageMin = DamageMin;

        DraggableItemScript.DamageMax = DamageMax;

        DraggableItemScript.AppearanceLevel = AppearanceLevel;

        DraggableItemScript.Durability = Durability;

        DraggableItemScript.Hands = Hands;

        DraggableItemScript.RequiredDex = RequiredDex;

        DraggableItemScript.RequiredStr = RequiredStr;

        Image img = NewItem.GetComponent<Image>();

               
      

        string spritePath = "Inventory items\\weapons\\bows\\" + BowName;

      

        img.sprite = Resources.Load<Sprite>(spritePath);


        

    }


    public void ClearItems()
    {
        for (int i = 0; i < ShopSlots.Length; i++)
        {
            Transform Slot = ShopSlots[i].transform;

            if (Slot.childCount > 0)
            {
                for (int num = 0; num < Slot.childCount; num++)
                {
                    Destroy(Slot.GetChild(num).gameObject);
                    
                }


                  
            }


        }

        if (HaveSmallSlots == true)
        {
            for (int i = 0; i < SmallSlots.Length; i++)
            {
                Transform Slot = SmallSlots[i].transform;

                if (Slot.childCount > 0)
                {
                    for (int num = 0; num < Slot.childCount; num++)
                    {
                        Destroy(Slot.GetChild(num).gameObject);

                    }



                }


            }
        }


    }





}
