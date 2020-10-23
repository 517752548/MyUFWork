using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainButtonUI : MonoBehaviour
{
    public Image btnBg;
    public GameUUButton btn;
    
    public void Init(){
        btnBg = transform.GetComponent<Image>();
        btn = transform.GetComponent<GameUUButton>();
    }
}
