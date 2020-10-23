using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetSkillBookListItemUI : CommonItemUI
{
    public GameUUButton btn;

	public void Init(GameObject tileBg, GameObject tileSelectedBg)
	{
		base.Init();
	}
	
	public void Init
	(
		Image bg,
        Image icon,
        Image biankuang,
        Text num,
        Text Name,
        GameObject Xing,
        Text XingTxt,
        GameUUToggle selectedToggle,
        GameObject glowEffect,
        Image yizhuangbei
	)
	{
		base.Init(bg, icon, biankuang, num, Name, Xing, XingTxt, selectedToggle, glowEffect, yizhuangbei);
	}
}
