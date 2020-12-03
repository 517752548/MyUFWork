using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ProtoBuf
{
	internal sealed class NetObjectCache
	{
		private sealed class ReferenceComparer : IEqualityComparer<object>
		{
			public static readonly ReferenceComparer Default = new ReferenceComparer();

			private ReferenceComparer()
			{
			}

			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				return x == y;
			}

			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}
		}

		internal const int Root = 0;

		private MutableList underlyingList;

		private object rootObject;

		private int trapStartIndex;

		private Dictionary<string, int> stringKeys;

		private Dictionary<object, int> objectKeys;

		private MutableList List
		{
			get
			{
				if (underlyingList == null)
				{
					underlyingList = new MutableList();
				}
				return underlyingList;
			}
		}

		internal object GetKeyedObject(int key)
		{
			if (key-- == 0)
			{
				if (rootObject == null)
				{
					throw new ProtoException("No root object assigned");
				}
				return rootObject;
			}
			BasicList list = List;
			if (key >= 0 && key < list.Count)
			{
				object obj = list[key];
				if (obj == null)
				{
					throw new ProtoException("A deferred key does not have a value yet");
				}
				return obj;
			}
			throw new ProtoException("Internal error; a missing key occurred");
		}

		internal void SetKeyedObject(int key, object value)
		{
			if (key-- == 0)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (rootObject != null && rootObject != value)
				{
					throw new ProtoException("The root object cannot be reassigned");
				}
				rootObject = value;
				return;
			}
			MutableList list = List;
			if (key < list.Count)
			{
				object obj = list[key];
				if (obj == null)
				{
					list[key] = value;
					return;
				}
				if (obj == value)
				{
					return;
				}
				throw new ProtoException("Reference-tracked objects cannot change reference");
			}
			if (key == list.Add(value))
			{
				return;
			}
			throw new ProtoException("Internal error; a key mismatch occurred");
		}

		internal int AddObjectKey(object value, out bool existing)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value == rootObject)
			{
				existing = true;
				return 0;
			}
			string text = value as string;
			BasicList list = List;
			int num;
			if (text == null)
			{
				if (objectKeys == null)
				{
					objectKeys = new Dictionary<object, int>(ReferenceComparer.Default);
					num = -1;
				}
				else if (!objectKeys.TryGetValue(value, out num))
				{
					num = -1;
				}
			}
			else if (stringKeys == null)
			{
				stringKeys = new Dictionary<string, int>();
				num = -1;
			}
			else if (!stringKeys.TryGetValue(text, out num))
			{
				num = -1;
			}
			if (!(existing = (num >= 0)))
			{
				num = list.Add(value);
				if (text == null)
				{
					objectKeys.Add(value, num);
				}
				else
				{
					stringKeys.Add(text, num);
				}
			}
			return num + 1;
		}

		internal void RegisterTrappedObject(object value)
		{
			if (rootObject == null)
			{
				rootObject = value;
			}
			else if (underlyingList != null)
			{
				int num = trapStartIndex;
				while (true)
				{
					if (num < underlyingList.Count)
					{
						trapStartIndex = num + 1;
						if (underlyingList[num] != null)
						{
							num++;
							continue;
						}
						break;
					}
					return;
				}
				underlyingList[num] = value;
			}
		}

		internal void Clear()
		{
			trapStartIndex = 0;
			rootObject = null;
			if (underlyingList != null)
			{
				underlyingList.Clear();
			}
			if (stringKeys != null)
			{
				stringKeys.Clear();
			}
			if (objectKeys != null)
			{
				objectKeys.Clear();
			}
		}
	}
}
