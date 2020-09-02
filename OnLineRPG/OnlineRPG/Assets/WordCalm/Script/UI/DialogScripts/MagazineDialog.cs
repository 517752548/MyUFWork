using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using UnityEngine;

public class MagazineDialog : UIWindowBase
{
    
    public Transform bookContent;
    private GameObject BookItem;

    public override void OnOpen()
    {
        base.OnOpen();
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_MagazineBookItem, op =>
        {
            BookItem = op;
            CreatUI();
        });
    }


    void CreatUI()
    {
        List<EliteWorld> allworlds = AppEngine.SSystemManager.GetSystem<EliteSystem>().GetAllSubWorld();
        List<EliteWorld> itemWorld = new List<EliteWorld>(2);
        GameObject item = null;
        List<EliteWorld> ordered = allworlds.OrderBy(x => x.order).ToList();
        for (int i = 0; i < ordered.Count; i++)
        {
            
            if (itemWorld.Count < 2)
            {
                itemWorld.Add(ordered[i]);
            }
            // if (itemWorld[1] == null)
            // {
            //     itemWorld.Add(ordered.GetEnumerator().Current);
            // }

            //if (itemWorld[0] != null && itemWorld[1] != null)
            if (itemWorld.Count == 2)
            {
                item = Instantiate(BookItem, bookContent, false);
                item.transform.SetSiblingIndex(0);
                item.GetComponent<MagazingBookItem>().SetData(this,itemWorld);
                itemWorld = new List<EliteWorld>(2);
            }
        }
        if (itemWorld.Count == 1)
        {
            item = Instantiate(BookItem, bookContent, false);
            item.GetComponent<MagazingBookItem>().SetData(this,itemWorld);
            item.transform.SetSiblingIndex(0);
        }
    }
    
    
    

}
