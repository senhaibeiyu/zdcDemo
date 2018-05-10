using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManage : MonoBehaviour {

    
    /// <summary>
    /// OnClick点击事件
    /// </summary>
    public void OnStatuButtonClick()
    {
        Status.instance.SwithState();
        
    }
    //public void OnStatuButtonClick()
    //{
    //    Status.instance.SwithState();

    //}

    public void OnBagButtonClick()
    {
        //Bag.instance.SwithState();
        bagstate._instance.kaiguan();
    }
    //public void OnEquipButtonClick()
    //{

    //}
    //public void OnSkillButtonClick()
    //{

    //}
    public void OnSettingButtonClick()
    {
        Setting.instance.Switch();
    }
}
