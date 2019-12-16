﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers
{
   private List<BaseManager> _baseManagers = new List<BaseManager>();
   public Action IninFinished = null;
   /// <summary>
   /// 初始化
   /// </summary>
   /// <returns></returns>
   public void Init(Action IninFinished)
   {
      this.IninFinished = IninFinished;
      for (int i = 0; i < _baseManagers.Count; i++)
      {
         _baseManagers[i].Init();
      }

      InitAsync();
   }

   private void InitAsync()
   {
      for (int i = 0; i < _baseManagers.Count; i++)
      {
         if ( !_baseManagers[i].Finished())
         {
            _baseManagers[i].InitFinshed = InitAsync;
            _baseManagers[i].InitAsync();
            break;
         }
         IninFinished?.Invoke();
      }
   }
}
