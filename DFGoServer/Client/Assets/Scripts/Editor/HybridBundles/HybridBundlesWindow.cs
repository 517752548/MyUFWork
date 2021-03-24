using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using UnityEditor.IMGUI.Controls;
using System.Collections.Generic;
using System.IO;

namespace Hybrid.Bundles
{
	class HybridBundlesWindow : EditorWindow
	{

		[NonSerialized] bool m_Initialized;
		[SerializeField] TreeViewState m_TreeViewState; // Serialized in the window layout file so it survives assembly reloading
		[SerializeField] MultiColumnHeaderState m_MultiColumnHeaderState;
		SearchField m_SearchField;
		HybridBundlesTreeView m_TreeView;
		MyTreeAsset m_MyTreeAsset;

		[MenuItem("LetUs/Release Preprocess/HybridBundles")]
		public static HybridBundlesWindow GetWindow()
		{
			var window = GetWindow<HybridBundlesWindow>();
			window.titleContent = new GUIContent("HybridBundles");
			window.Focus();
			window.Repaint();
			return window;
		}

		Rect multiColumnTreeViewRect
		{
			get { return new Rect(20, 30, position.width - 40, position.height - 60); }
		}


		Rect toolbarRect
		{
			get { return new Rect(20f, 10f, position.width - 40f, 20f); }
		}

		Rect bottomToolbarRect
		{
			get { return new Rect(20f, position.height - 26f, position.width - 40f, 22f); }
		}
		public HybridBundlesTreeView treeView
		{
			get { return m_TreeView; }
		}
		void InitIfNeeded()
		{
			if (!m_Initialized)
			{
				// Check if it already exists (deserialized from window layout file or scriptable object)
				if (m_TreeViewState == null)
					m_TreeViewState = new TreeViewState();

				bool firstInit = m_MultiColumnHeaderState == null;
				var headerState = HybridBundlesTreeView.CreateDefaultMultiColumnHeaderState(multiColumnTreeViewRect.width);
				if (MultiColumnHeaderState.CanOverwriteSerializedFields(m_MultiColumnHeaderState, headerState))
					MultiColumnHeaderState.OverwriteSerializedFields(m_MultiColumnHeaderState, headerState);
				m_MultiColumnHeaderState = headerState;

				var multiColumnHeader = new MyMultiColumnHeader(headerState);
				if (firstInit)
					multiColumnHeader.ResizeToFit();

				var treeModel = new BaseTreeModel<HybridBundlesTreeElement>(GetData());

				m_TreeView = new HybridBundlesTreeView(m_TreeViewState, multiColumnHeader, treeModel);

				m_SearchField = new SearchField();
				m_SearchField.downOrUpArrowKeyPressed += m_TreeView.SetFocusAndEnsureSelectedItem;
				//先自动保存一下 
				SaveData();

				m_Initialized = true;

			}
		}

		IList<HybridBundlesTreeElement> GetData()
		{
			if (m_MyTreeAsset == null)
			{
				m_MyTreeAsset = AssetDatabase.LoadMainAssetAtPath(HybridBundlesConsts.DATA_PATH) as MyTreeAsset;
			}
			if (m_MyTreeAsset != null)
			{
				m_MyTreeAsset.UpdateData();
				return m_MyTreeAsset.treeElements;
			}
			return null;
		}

		void SaveData()
		{
			AssetDatabase.DeleteAsset(HybridBundlesConsts.DATA_PATH);
			AssetDatabase.Refresh();
			MyTreeAsset dataScript = ScriptableObject.CreateInstance<MyTreeAsset>();
			dataScript.treeElements = m_MyTreeAsset.treeElements;
			AssetDatabase.CreateAsset(dataScript, HybridBundlesConsts.DATA_PATH);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		void OnGUI()
		{
			InitIfNeeded();

			SearchBar(toolbarRect);
			DoTreeView(multiColumnTreeViewRect);
			BottomToolBar(bottomToolbarRect);
		}

		void SearchBar(Rect rect)
		{
			treeView.searchString = m_SearchField.OnGUI(rect, treeView.searchString);
		}

		void DoTreeView(Rect rect)
		{
			m_TreeView.OnGUI(rect);
		}

		void BottomToolBar(Rect rect)
		{
			GUILayout.BeginArea(rect);

			using (new EditorGUILayout.HorizontalScope())
			{

				if (GUILayout.Button("Expand All"))
				{
					treeView.ExpandAll();
				}

				if (GUILayout.Button("Collapse All"))
				{
					treeView.CollapseAll();
				}

				GUILayout.FlexibleSpace();

				GUILayout.Label(m_MyTreeAsset != null ? AssetDatabase.GetAssetPath(m_MyTreeAsset) : string.Empty);

				GUILayout.FlexibleSpace();

				GUILayout.Space(10);

				if (GUILayout.Button("Save"))
				{
					SaveData();
				}
			}

			GUILayout.EndArea();
		}
	}

}


internal class MyMultiColumnHeader : MultiColumnHeader
{
	Mode m_Mode;

	public enum Mode
	{
		DefaultHeader,
		MinimumHeaderWithoutSorting
	}

	public MyMultiColumnHeader(MultiColumnHeaderState state)
		: base(state)
	{
		mode = Mode.MinimumHeaderWithoutSorting;
	}

	public Mode mode
	{
		get
		{
			return m_Mode;
		}
		set
		{
			m_Mode = value;
			switch (m_Mode)
			{
				case Mode.DefaultHeader:
					canSort = true;
					height = DefaultGUI.defaultHeight;
					break;
				case Mode.MinimumHeaderWithoutSorting:
					canSort = false;
					height = DefaultGUI.minimumHeight;
					break;
			}
		}
	}
}
