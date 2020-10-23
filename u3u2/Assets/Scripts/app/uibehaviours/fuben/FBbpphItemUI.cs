using UnityEngine.UI;
using UnityEngine;

public class FBbpphItemUI : MonoBehaviour {


    public Text m_tex_paiming;
    public Text m_tex_bpName;
    public Text m_tex_Score;
    public Image m_obj_qiansan;

    public void Init()
    {
        m_tex_paiming=transform.Find("paiming").GetComponent<UnityEngine.UI.Text>();
        m_tex_bpName=transform.Find("bpname").GetComponent<UnityEngine.UI.Text>();
        m_tex_Score=transform.Find("score").GetComponent<UnityEngine.UI.Text>();
        if (transform.Find("qiansan") != null)
        {
            m_obj_qiansan = transform.Find("qiansan").GetComponent<Image>();
        }

    }

}
