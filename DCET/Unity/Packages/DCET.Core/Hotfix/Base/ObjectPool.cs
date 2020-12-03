using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
#if !SERVER
using UnityEngine;
using DCETRuntime;
#endif

namespace DCET
{
	public class ComponentQueue: IDisposable
	{
		public long Id;
#if !SERVER
		public static GameObject Game { get; } = GameObject.Find("Game");
		
		public GameObject ViewGO { get; set; }
#endif
		
		public string TypeName { get; }
		
		private readonly Queue<Entity> queue = new Queue<Entity>();

		public ComponentQueue(string typeName)
		{
			Id = IdGenerater.GenerateId();
			TypeName = typeName;
#if !SERVER
			ViewGO = new GameObject();
			ViewGO.name = GetType().Name;
			ViewGO.layer = LayerNames.GetLayerInt(LayerNames.HIDDEN);
			ViewGO.transform.SetParent(Game.transform, false);
			var componentView = ViewGO.AddComponent(typeof(ComponentView)) as ComponentView;

			if (componentView)
			{
				componentView.Component = this;
			}
#endif
		}

		public void Enqueue(Entity entity)
		{
			queue.Enqueue(entity);
		}

		public Entity Dequeue()
		{
			return queue.Dequeue();
		}

		public Entity Peek()
		{
			return queue.Peek();
		}

		public Queue<Entity> Queue
		{
			get
			{
				return queue;
			}
		}

		public int Count
		{
			get
			{
				return queue.Count;
			}
		}

		public void Dispose()
		{
			while (queue.Count > 0)
			{
				Entity component = queue.Dequeue();
				component.Dispose();
			}
		}
	}
	
    public class ObjectPool: IDisposable
    {
#if !SERVER
		public static GameObject Game { get; } = GameObject.Find("Game");
		
		public GameObject ViewGO { get; set; }
#endif
	    
        private readonly Dictionary<Type, ComponentQueue> dictionary = new Dictionary<Type, ComponentQueue>();

        public ObjectPool()
        {
#if !SERVER
			ViewGO = new GameObject();
			ViewGO.name = GetType().Name;
			ViewGO.layer = LayerNames.GetLayerInt(LayerNames.HIDDEN);
			ViewGO.transform.SetParent(Game.transform, false);
			var componentView = ViewGO.AddComponent(typeof(ComponentView)) as ComponentView;

			if (componentView)
			{
				componentView.Component = this;
			}
#endif
		}

        public Entity Fetch(Type type)
        {
	        Entity obj;
            if (!dictionary.TryGetValue(type, out ComponentQueue queue))
            {
	            obj = (Entity)Activator.CreateInstance(type);
            }
	        else if (queue.Count == 0)
            {
	            obj = (Entity)Activator.CreateInstance(type);
            }
            else
            {
	            obj = queue.Dequeue();
            }
	        
	        obj.IsFromPool = true;
            return obj;
        }

        public T Fetch<T>() where T: Entity
		{
            T t = (T) Fetch(typeof(T));
			return t;
		}
        
        public void Recycle(Entity obj)
        {
            Type type = obj.GetType();
	        ComponentQueue queue;
            if (!dictionary.TryGetValue(type, out queue))
            {
                queue = new ComponentQueue(type.Name);
	            
#if !SERVER
	            if (queue.ViewGO != null)
	            {
		            queue.ViewGO.transform.SetParent(ViewGO.transform);
		            queue.ViewGO.name = $"{type.Name}s";
	            }
#endif
				dictionary.Add(type, queue);
            }
            
#if !SERVER
	        if (obj.ViewGO != null)
	        {
		        obj.ViewGO.transform.SetParent(queue.ViewGO.transform);
	        }
#endif
	        obj.Id = 0;
            queue.Enqueue(obj);
        }

	    public void Dispose()
	    {
		    foreach (var kv in dictionary)
		    {
			    kv.Value.Dispose();
		    }
		    dictionary.Clear();
	    }
	    
	    public override string ToString()
	    {
		    StringBuilder sb = new StringBuilder();
		    Dictionary<Type, int> typeCount = new Dictionary<Type, int>();
		    foreach (var kv in dictionary)
		    { 
			    typeCount[kv.Key] = kv.Value.Count;
		    }

		    IOrderedEnumerable<KeyValuePair<Type, int>> orderByDescending = typeCount.OrderByDescending(s => s.Value);
			
		    sb.AppendLine("ObjectPool Count: ");
		    foreach (var kv in orderByDescending)
		    {
			    if (kv.Value == 1)
			    {
				    continue;
			    }
			    sb.AppendLine($"\t{kv.Key.Name}: {kv.Value}");
		    }

		    MultiMapSet<string, string> dict = Check();
		    
		    sb.Append("not reset field:\n");
		    foreach (KeyValuePair<string,HashSet<string>> pair in dict.GetDictionary())
		    {
			    sb.Append(pair.Key + ": ");
			    foreach (string value in pair.Value)
			    {
				    sb.Append(value + ", ");
			    }
			    sb.Append("\n");
		    }

		    return sb.ToString();
	    }

	    public void LogErrorCheckResult()
	    {
		    MultiMapSet<string, string> dict = Check();
		    if (dict.Count == 0)
		    {
			    return;
		    }
		    StringBuilder sb = new StringBuilder();
		    sb.Append("not reset field:\n");
		    foreach (KeyValuePair<string,HashSet<string>> pair in dict.GetDictionary())
		    {
			    sb.Append(pair.Key + ": ");
			    foreach (string value in pair.Value)
			    {
				    sb.Append(value + ", ");
			    }
			    sb.Append("\n");
		    }
		    Log.Error(sb.ToString());
	    }

	    public MultiMapSet<string, string> Check()
	    {
		    MultiMapSet<string, string> dict = new MultiMapSet<string, string>();
		    foreach (ComponentQueue queue in dictionary.Values)
		    {
			    foreach (Entity entity in queue.Queue)
			    {
				    Type type = entity.GetType();
				    
				    FieldInfo[] fieldInfos = type.GetFields();
				    foreach (FieldInfo fieldInfo in fieldInfos)
				    {
					    if (fieldInfo.IsLiteral)
					    {
						    continue;
					    }

					    if (fieldInfo.GetCustomAttributes(typeof (NoMemoryCheck)).Count() > 0)
					    {
						    continue;
					    }
					    
					    Type fieldType = fieldInfo.FieldType;
					    if (fieldType == typeof (int))
					    {
						    if ((int) fieldInfo.GetValue(entity) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (uint))
					    {
						    if ((uint) fieldInfo.GetValue(entity) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (long))
					    {
						    if ((long) fieldInfo.GetValue(entity) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (ulong))
					    {
						    if ((ulong) fieldInfo.GetValue(entity) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (short))
					    {
						    if ((short) fieldInfo.GetValue(entity) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (ushort))
					    {
						    if ((ushort) fieldInfo.GetValue(entity) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (float))
					    {
						    if (Math.Abs((float)fieldInfo.GetValue(entity)) > 0.0001)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (double))
					    {
						    if (Math.Abs((double)fieldInfo.GetValue(entity)) > 0.0001)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (fieldType == typeof (bool))
					    {
						    if ((bool) fieldInfo.GetValue(entity) != false)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
					    
					    if (typeof(ICollection).IsAssignableFrom(fieldType))
					    {
						    object fieldValue = fieldInfo.GetValue(entity);
						    if (fieldValue == null)
						    {
							    continue;
						    }
						    if (((ICollection)fieldValue).Count != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }

					    PropertyInfo propertyInfo = fieldType.GetProperty("Count");
					    if (propertyInfo != null)
					    {
						    if ((int) propertyInfo.GetValue(fieldInfo.GetValue(entity)) != 0)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }

					    if (fieldType.IsClass)
					    {
						    if (fieldInfo.GetValue(entity) != null)
						    {
							    dict.Add(type.Name, fieldInfo.Name);
						    }
						    continue;
					    }
				    }
			    }
		    }

		    return dict;
	    }
    }
}