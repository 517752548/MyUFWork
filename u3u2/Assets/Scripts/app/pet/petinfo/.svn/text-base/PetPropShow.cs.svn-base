using System.Collections.Generic;
using System.Text;
using app.db;
using app.utils;

namespace app.pet
{
    public class PetPropShow
    {
        public static string LINE_SEP = "\n";
        public static string EQUIP_ADD_CHAR = "+";
        public static string COLON = ":";

        public static string GetPetGrowthDesc(Pet pet)
        {
            StringBuilder desc = new StringBuilder();

            //int star = pet.getStar();
            //AvatarAGrowthTemplate gTpl = pet.getTpl().propAGrowthStarList[star - 1];
            //float strG = gTpl.strengthGrowth / ClientConstantDef.PET_DIV_BASE;
            //float agiG = gTpl.agilityGrowth / ClientConstantDef.PET_DIV_BASE;
            //float intG = gTpl.intellectGrowth / ClientConstantDef.PET_DIV_BASE;
            //float faiG = gTpl.faithGrowth / ClientConstantDef.PET_DIV_BASE;
            //float staG = gTpl.staminaGrowth / ClientConstantDef.PET_DIV_BASE;

            //desc.Append(ColorUtil.getColorText(ColorUtil.RED,
            //    LangConstant.getPetPropertyName(PetAProperty.STRENGTH) + LangConstant.GROWTH + COLON));
            //desc.Append(strG).Append(LINE_SEP);

            //desc.Append(ColorUtil.getColorText(ColorUtil.RED,
            //    LangConstant.getPetPropertyName(PetAProperty.AGILITY) + LangConstant.GROWTH + COLON));
            //desc.Append(agiG).Append(LINE_SEP);

            //desc.Append(ColorUtil.getColorText(ColorUtil.RED,
            //    LangConstant.getPetPropertyName(PetAProperty.INTELLECT) + LangConstant.GROWTH + COLON));
            //desc.Append(intG).Append(LINE_SEP);

            //desc.Append(ColorUtil.getColorText(ColorUtil.RED,
            //    LangConstant.getPetPropertyName(PetAProperty.FAITH) + LangConstant.GROWTH + COLON));
            //desc.Append(faiG).Append(LINE_SEP);

            //desc.Append(ColorUtil.getColorText(ColorUtil.RED,
            //    LangConstant.getPetPropertyName(PetAProperty.STAMINA) + LangConstant.GROWTH + COLON));
            //desc.Append(staG).Append(LINE_SEP);
            //desc.Append(LINE_SEP);

            return desc.ToString();
        }

        public static string getPetBPropDesc(Pet pet)
        {
            StringBuilder desc = new StringBuilder();

            Dictionary<int, int> equipAddDic = pet.GetPetEquipAddProp();
            int end = PetBProperty._BEGIN + PetBProperty._SIZE;
            for (int i = PetBProperty._BEGIN + 1; i <= end; i++ )
            {
                int tp = pet.PropertyManager.getPetIntProp(i);
                //int tp = pet.PropertyManager.getBProperty(i);
                int equipAdd = 0;
                if (equipAddDic.ContainsKey(i))
                {
                    equipAddDic.TryGetValue(i, out equipAdd);
                }

                desc.Append(ColorUtil.getColorText(ColorUtil.ORANGE, LangConstant.getPetPropertyName(i) + COLON));
                desc.Append(tp - equipAdd);
                if (equipAdd > 0)
                {
                    desc.Append(EQUIP_ADD_CHAR).Append(ColorUtil.getColorText(ColorUtil.GREEN, equipAdd.ToString()));
                }
                desc.Append(LINE_SEP);
            }

            return desc.ToString();
        }

    }
}
