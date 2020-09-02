using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;

public class WordCategorySystem : ISystem
{
    private List<WordCategoryEntity> cateList;

    public override void InitSystem()
    {
        cateList = new List<WordCategoryEntity>();
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_DailyQuestionDisplay, ( prefab) =>
        {
            if (prefab != null)
            {
                Sprite[] icons = prefab.GetComponent<DailyQuestionDisplay>().categotyIcons;
                cateList.Add(new WordCategoryEntity() { ID = 1, Name = "Entertainment", Icon = icons[0] });
                cateList.Add(new WordCategoryEntity() { ID = 2, Name = "Science", Icon = icons[1] });
                cateList.Add(new WordCategoryEntity() { ID = 3, Name = "Geography", Icon = icons[2] });
                cateList.Add(new WordCategoryEntity() { ID = 4, Name = "Language", Icon = icons[3] });
                cateList.Add(new WordCategoryEntity() { ID = 5, Name = "History", Icon = icons[4] });
                cateList.Add(new WordCategoryEntity() { ID = 6, Name = "Lifestyle", Icon = icons[5] });
            }
        });
        base.InitSystem();
    }

    public List<int> GetAllIDs()
    {
        List<int> ids = new List<int>();
        cateList.ForEach(c => ids.Add(c.ID));
        return ids;
    }

    public WordCategoryEntity GetCategory(int id)
    {
        return cateList.Find(c => c.ID == id);
    }

    public string GetCategoryName(int id)
    {
        WordCategoryEntity cate = cateList.Find(c => c.ID == id);
        if (cate != null)
            return cate.Name;
        return "unknown";
    }

    public Sprite GetCategoryIcon(int id)
    {
        WordCategoryEntity cate = cateList.Find(c => c.ID == id);
        if (cate != null)
            return cate.Icon;
        return null;
    }
}

public class WordCategoryEntity
{
    public int ID;
    public string Name;
    public Sprite Icon;
}
