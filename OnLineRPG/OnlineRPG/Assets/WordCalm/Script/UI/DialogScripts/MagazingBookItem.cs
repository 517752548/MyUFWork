using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazingBookItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bookContent;
    private GameObject bookObj;
    private MagazineDialog _magazineDialog;
    void Start()
    {
        
    }

    public void SetData(MagazineDialog _magazineDialog,List<EliteWorld> items)
    {
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_BookItem, op =>
        {
            for (int i = 0; i < items.Count; i++)
            {
                bookObj = Instantiate(op, bookContent, false);
                bookObj.GetComponent<MagazingBook>().SetEliteData(_magazineDialog,items[i]);
            }
        });
    }
    
}
