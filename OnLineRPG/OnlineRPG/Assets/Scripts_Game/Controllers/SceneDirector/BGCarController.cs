using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCarController : BaseHomeUI
{
   public override void OnShow()
   {
      base.OnShow();
      gameObject.SetActive(true);
   }


   public override void OnHidden()
   {
      base.OnHidden();
      gameObject.SetActive(false);
   }
}
