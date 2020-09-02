using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.Home
{
    public class BaseEntranceCtrl : BaseHomeUI
    {
        protected List<BaseEntranceBtn> btnList = new List<BaseEntranceBtn>();
        public override void Init(HomeRoot root)
        {
            base.Init(root);
            childHomeUIs.ForEach(ui =>
            {
                var btn = ui as BaseEntranceBtn;
                if (btn == null)
                    return;
                btn.SetParentCtrl(this);
                UpdateBtnWeight(ref btn);
                btnList.Add(btn);
            });
        }

        public override void OnShow()
        {
            base.OnShow();
            SortBtns();
        }

        public override void OnHidden()
        {
            base.OnHidden();
        }

        protected virtual void UpdateBtnWeight(ref BaseEntranceBtn btn)
        {

        }

        public async void AddBtn(string prefabName, int weight)
        {
            var prefab = await ResourceManager.LoadAsync<GameObject>(prefabName);
            GameObject entranceButton = Instantiate(prefab);
            entranceButton.transform.SetParent(transform, false);
            entranceButton.transform.SetSiblingIndex(weight);
            var baseEntrance = entranceButton.GetComponent<BaseEntranceBtn>();
            childHomeUIs.Add(baseEntrance);
            baseEntrance.Weight = weight;
            baseEntrance.Init(root);
            baseEntrance.SetParentCtrl(this);
            btnList.Add(baseEntrance);
            OnShow();
        }

        protected void SortBtns()
        {
            return;
            btnList.Sort((x, y) => x.Weight.CompareTo(x.Weight));
            float posY = 0;
            int index = 0;
            btnList.ForEach(btn =>
            {
                if (!btn.IsValid() || !btn.IsVisible())
                    return;
                btn.transform.SetSiblingIndex(index);
                index++;
                btn.DOLocalMoveY(posY);
                LoggerHelper.Error("Enter pos " + btn.gameObject.name + " && y=" + posY);
                posY -= btn.Height;
            });
        }
    }
}