namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class itemStackCategory : ACategory<itemStack>
	{
	}

	public class itemStack: IConfig
	{
		public long Id { get; set; }
		public string name;
		public int stack;
	}
}
