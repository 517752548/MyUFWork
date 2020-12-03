namespace ProtoBuf.Meta
{
	internal sealed class MutableList : BasicList
	{
		public new object this[int index]
		{
			get
			{
				return base.head[index];
			}
			set
			{
				base.head[index] = value;
			}
		}

		public void RemoveLast()
		{
			base.head.RemoveLastWithMutate();
		}

		public void Clear()
		{
			base.head.Clear();
		}
	}
}
