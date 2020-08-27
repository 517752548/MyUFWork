using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BaseEditorWindow : EditorWindow
{
    #region Window Constants
    public const float MinLabelWidth = 200f;
    public const int Indent = 20;
    public const float LineHeight = 20f;
    public const float TopBuffer = 2f;
    public const float LeftBuffer = 2f;
    public const float RightBuffer = 2f;
    public const float VectorFieldBuffer = 0.75f;
    public const float MinTextAreaWidth = 100f;
    public const float MinTextAreaHeight = LineHeight;
    public const double DoubleClickTime = 0.5;
    public const double AutoSaveTime = 30;
    public const float PreferencesMinWidth = 640f;
    public const float PreferencesMinHeight = 280f;
    #endregion

    protected GUIStyle m_MainHeaderStyle = null;
    protected string m_MainHeaderText = "XXX Window";
    protected Color m_HeaderColor = Color.red;
    protected float m_CurrentLinePosition = 2;
    protected float m_CurrentLine = 0;

    protected virtual void OnGUI()
    {
        m_MainHeaderStyle = new GUIStyle(GUI.skin.label);
        m_MainHeaderStyle.fontSize = 20;
        m_MainHeaderStyle.fontStyle = FontStyle.Bold;

        ResetToTop();
        DrawHeaderLabel();
    }

    protected virtual void DrawHeaderLabel()
    {
        GUIContent labelContent = new GUIContent(m_MainHeaderText);
        m_HeaderColor.a = 1f;
        m_MainHeaderStyle.normal.textColor = m_HeaderColor;

        Vector2 contentSize = m_MainHeaderStyle.CalcSize(labelContent);
        float headerLabelWidth = contentSize.x;
        float headerLabelHeight = contentSize.y;

        m_CurrentLinePosition = Math.Max(HorizontalMiddleOfLine() - headerLabelWidth / 2f, 0);
        GUI.Label(new Rect(m_CurrentLinePosition, TopOfLine(), headerLabelWidth, headerLabelHeight), labelContent, m_MainHeaderStyle);
        m_CurrentLinePosition += (headerLabelWidth + 2);

        NewLine(headerLabelHeight / LineHeight);

        DrawSectionSeparator();


    }







    protected virtual void DrawSectionSeparator()
    {
        NewLine(0.25f);
        GUI.Box(new Rect(m_CurrentLinePosition, TopOfLine(), FullSeparatorWidth(), 1), string.Empty);
    }

    #region GUI Position Methods
    protected virtual void ResetToTop()
    {
        m_CurrentLine = TopBuffer / LineHeight;
        m_CurrentLinePosition = LeftBuffer;
    }

    protected virtual void NewLine(float numNewLines = 1)
    {
        m_CurrentLine += numNewLines;
        m_CurrentLinePosition = LeftBuffer;
    }

    protected virtual float TopOfLine()
    {
        return LineHeight * m_CurrentLine;
    }

    protected virtual float VerticalMiddleOfLine()
    {
        return LineHeight * m_CurrentLine + LineHeight / 2;
    }

    protected virtual float HorizontalMiddleOfLine()
    {
        return FullSeparatorWidth() / 2f + LeftBuffer;
    }

    protected virtual float PopupTop()
    {
        return TopOfLine() + 1;
    }

    protected virtual float StandardHeight()
    {
        return LineHeight - 2;
    }

    protected virtual float TextBoxHeight()
    {
        return LineHeight - 4;
    }

    protected virtual float VectorFieldHeight()
    {
        return LineHeight * 1.2f;
    }

    protected virtual float FullSeparatorWidth()
    {
        return this.position.width - LeftBuffer - RightBuffer;
    }

    protected virtual float WidthLeftOnCurrentLine()
    {
        return FullWindowWidth() - LeftBuffer - RightBuffer - m_CurrentLinePosition;
    }

    protected virtual float ScrollViewWidth()
    {
        return FullWindowWidth() - 20;
    }

    protected virtual float FullWindowWidth()
    {
        return this.position.width;
    }

    protected virtual float HeightToBottomOfWindow()
    {
        return this.position.height - (m_CurrentLine * LineHeight);
    }

    protected virtual float CurrentHeight()
    {
        return m_CurrentLine * LineHeight;
    }

   
    #endregion
}
