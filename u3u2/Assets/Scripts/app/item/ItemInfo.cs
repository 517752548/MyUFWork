using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.item
{
    public class ItemInfo
    {
        private int tplId;

        public int TplId
        {
            get { return tplId; }
            set { tplId = value; }
        }

        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private int qualityId;

        public int QualityId
        {
            get { return qualityId; }
            set { qualityId = value; }
        }

        private int typeId;

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }


    }
}
