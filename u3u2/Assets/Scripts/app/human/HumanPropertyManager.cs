
namespace app.human
{
    public class HumanPropertyManager : RolePropertyManager<Human>
    {
        public HumanPropertyManager(Human role)
            : base(role)
        {
        }

        public int getIntProp(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.BASE_ROLE_PROPS_INT);
            return this.getInt(index);
        }

        public long getLongProp(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.BASE_ROLE_PROPS_STR);
            return this.getLong(index);
        }

        public string getStringProp(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.BASE_ROLE_PROPS_STR);
            return this.getString(index);
        }

    }
}
