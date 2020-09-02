using UnityEngine;
using System.Collections;
using Facebook.Unity;
using UnityEngine.UI;
using BetaFramework;
using Newtonsoft.Json;

public class FBSettingUserImage : MonoBehaviour
{
	public Color m_notLgoinColor;
	public Color m_loginColor;

	[Header("Set by Script")]
	[SerializeField] private Image m_fbiconLogin;
	[SerializeField] private GameObject m_fbiconNotLogin;
	[SerializeField] private Text m_fbText;

	private void Awake()
	{
		m_fbiconLogin = transform.Find("Img_Head_Bg/Img_Bg/Img_Mask/Img_UerHead").GetComponent<Image>();
		m_fbiconNotLogin = transform.Find("Img_Head_Bg/Img_Fb").gameObject;
		m_fbText = transform.Find("Text_Name").GetComponent<Text>();
	}

	public void LoadFbUserPicture()
	{ 
		if (FaceBookSDK.IsFacebookLoggedIn()) {
			GetComponent<Button>().interactable = false;
			m_fbiconLogin.gameObject.SetActive(true);
			m_fbiconNotLogin.SetActive(false);
			if (Record.HasFile(PrefKeys.FaceBookImageCache))
			{
				LoadFBImage();
				m_fbText.text = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value;
				return;
			}
			m_fbText.text = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value;
		} else {
			GetComponent<Button>().interactable = true;
			m_fbiconNotLogin.SetActive(true);
			m_fbiconLogin.gameObject.SetActive(false);
			m_fbText.text = "Login to Facebook";
		}
	}
	

	private void LoadFBImage()
	{
		m_fbiconLogin.sprite = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerFBPic();
	}
}
