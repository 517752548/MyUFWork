using UnityEngine;

public class ClassicQuestionRateCell : MonoBehaviour
{
    public CellLetter letter;

    public void Init(float cellSize, char letter)
    {
        this.letter.SetSize(Vector3.one * cellSize * 0.60f);
        this.letter.text = letter + "";
    }
}