using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagManager : MonoBehaviour
{
    public static Dictionary<int, BaseItem> ItemList;
    GameObject item;
    public GameObject[] UIBags;
    Image imagesingle;
    Text index;
    int IndexInt = 0;
    string IndexStr = "";
    public GameObject storage;

    void Awake()
    {
        Load();
    }
    // Use this for initialization
    void Start()
    {
        //UnityEditor.EditorUtility.DisplayDialog("标题", "提示内容", "确认", "取消");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
             // Pickup(ItemList[Random.range(0, 5)]);
             Pickup(ItemList[UnityEngine.Random.Range(0, 5)]);
           
        }
    }
    public void additem()
    {
        //int index = 2;
        Pickup(ItemList[UnityEngine.Random.Range(2, 3)]);
    }
    private void Load()
    {
        ItemList = new Dictionary<int, BaseItem>();
        Weapons black_sword = new Weapons(0, "黑剑", "近战武器", 200, 100, "image/0412007", 120);
        Weapons black_bow = new Weapons(1, "黑弓", "远程武器", 150, 75, "image/0412004", 100);

        Consumables HP_Big_Back = new Consumables(2, "精品丹药", "回复大量生命值", 40, 20, "image/item_501", 50);
        Consumables HP_Small_Back = new Consumables(3, "普通丹药", "回复少量生命值", 30, 15, "image/item_502", 40);

        Armor Helmet = new Armor(4, "头盔", "保护头部", 100, 50, "image/0412001", 60);
       
        ItemList.Add(black_sword.ID, black_sword);
        ItemList.Add(black_bow.ID, black_bow);
        ItemList.Add(HP_Big_Back.ID, HP_Big_Back);
        ItemList.Add(HP_Small_Back.ID, HP_Small_Back);
        ItemList.Add(Helmet.ID, Helmet);

        //string path = Application.streamingAssetsPath + "/GoodJson.json";
        //StreamReader sr = new StreamReader(path);
        //string json = sr.ReadToEnd();
        //sr.Close();

        //JsonData data = JsonMapper.ToObject(json);
        //for(int i = 0;i<=data.Count-1;i++)
        //{
        //    BaseItem bi = JsonMapper.ToObject<BaseItem>(data[i][])
            


       // }


    }
    
    

    public void Pickup(BaseItem baseItem)
    {
        bool isFind = false;
        //item = Instantiate(Resources.Load("Preb/UItem"), transform.position, transform.rotation) as GameObject;
        item = Objectpool.Get("UItem", transform.position, transform.rotation) as GameObject;
        imagesingle = item.transform.GetComponent<Image>();
        imagesingle.overrideSprite = Resources.Load(baseItem.Icon,typeof(Sprite)) as Sprite;

        for(int i=0;i<UIBags.Length;i++)
        {
            if(UIBags[i].transform.childCount>0)
            {
                if(imagesingle.overrideSprite.name == UIBags[i].transform.GetChild(0).transform.GetComponent<Image>().overrideSprite.name)
                {
                    Debug.Log("相等");
                    isFind = true;
                    index = UIBags[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                    IndexInt = int.Parse(index.text);
                    IndexInt += 1;
                    IndexStr = IndexInt.ToString();
                    index.text = IndexStr;
                    StartCoroutine(ReturnPool());
                    // Destroy(item);
                    item.transform.SetParent(storage.transform);
                }
            }
        }
        if(isFind==false)
        {
            for (int i = 0; i < UIBags.Length; i++)
            {
                if (UIBags[i].transform.childCount == 0)
                {
                    item.transform.SetParent(UIBags[i].transform);
                    item.transform.localPosition = Vector3.zero;
                    item.transform.localScale = new Vector3(1, 1, 1);
                    ItemInfo.StoreItem(UIBags[i].transform.name, baseItem);
                    break;
                }
            }
        }  

    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(0.0f);
        Objectpool.Return(item);
    }

}
