using UnityEngine;

namespace app.petstore
{
	public class PetStoreLevelListItem
	{
		public int level { get; private set; }
		private PetStoreLevelListItemUI mUI = null;
		public PetStoreLevelListItem(PetStoreLevelListItemUI ui)
		{
			mUI = ui;
			
		}

        public void SetLevel(int level)
        {
            this.level = level;
            mUI.label.text = "Lv " + level;
        }

        public void Destroy()
        {
            GameObject.DestroyImmediate(mUI.gameObject);
            mUI = null;
        }
	}
}