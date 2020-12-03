using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
#if !SERVER
using UnityEngine;
using DCETRuntime;
#endif

namespace DCET
{
	public class EntityStatus
	{
		public static int None = 0;
		public static int IsFromPool = 1;
		public static int IsRegister = 2;
		public static int IsComponent = 4;
	}
	
	public partial class Entity : Object, IDisposable
	{
		private static readonly Pool<HashSet<Entity>> hashSetPool = new Pool<HashSet<Entity>>();
		
		private static readonly Pool<Dictionary<Type, Entity>> dictPool = new Pool<Dictionary<Type, Entity>>();
		
		private static readonly Pool<Dictionary<long, Entity>> childrenPool = new Pool<Dictionary<long, Entity>>();
		
		
		[BsonIgnore]
		public long InstanceId { get; set; }
		
#if !SERVER
		public static GameObject Global { get; } = GameObject.Find("Game");
		
		[BsonIgnore]
		public GameObject ViewGO { get; set; }
#endif

		[BsonIgnore]
		private int status = EntityStatus.None;

		[BsonIgnore]
		public bool IsFromPool
		{
			get
			{
				return (status & EntityStatus.IsFromPool) == EntityStatus.IsFromPool;
			}
			set
			{
				if (value)
				{
					status |= EntityStatus.IsFromPool;
				}
				else
				{
					status &= ~EntityStatus.IsFromPool;
				}

				if (InstanceId == 0)
				{
					InstanceId = IdGenerater.GenerateId();
				}

				IsRegister = value;
			}
		}
		
		[BsonIgnore]
		private bool IsRegister
		{
			get
			{
				return (status & EntityStatus.IsRegister) == EntityStatus.IsRegister;
			}
			set
			{
				if (IsRegister == value)
				{
					return;
				}
				if (value)
				{
					status |= EntityStatus.IsRegister;
				}
				else
				{
					status &= ~EntityStatus.IsRegister;
				}
				Game.EventSystem.RegisterSystem(this, value);
			}
		}
		
		[BsonIgnore]
		private bool IsComponent
		{
			get
			{
				return (status & EntityStatus.IsComponent) == EntityStatus.IsComponent;
			}
			set
			{
				if (value)
				{
					status |= EntityStatus.IsComponent;
				}
				else
				{
					status &= ~EntityStatus.IsComponent;
				}
			}
		}

		[BsonIgnore]
		public bool IsDisposed
		{
			get
			{
				return InstanceId == 0;
			}
		}

		[BsonIgnore]
		protected Entity parent;
		
		[BsonIgnore]
		public Entity Parent
		{
			get
			{
				return parent;
			}
			set
			{
				if (value == null)
				{
					throw new Exception($"cant set parent null: {GetType().Name}");
				}
				
				if (parent != null) // 之前有parent
				{
					// parent相同，不设置
					if (parent.InstanceId == value.InstanceId)
					{
						Log.Error($"重复设置了Parent: {GetType().Name} parent: {parent.GetType().Name}");
						return;
					}
					
					parent.RemoveChild(this);
					
					parent = value;
					parent.AddChild(this);
					
					Domain = parent.domain;
				}
				else
				{
					parent = value;
					parent.AddChild(this);
				
					IsComponent = false;
				
					AfterSetParent();
				}
			}
		}
		
		// 该方法只能在AddComponent中调用，其他人不允许调用
		[BsonIgnore]
		private Entity ComponentParent
		{
			set
			{
				if (parent != null)
				{
					throw new Exception($"Component parent is null: {GetType().Name}");
				}

				parent = value;
				
				IsComponent = true;

				AfterSetParent();
			}
		}

		private void AfterSetParent()
		{
			if (parent.domain != null)
			{
				Domain = parent.domain;
			}

			// 检测自己的domain是不是跟父亲一样
			if (Domain != null && parent.Domain != null && Domain.InstanceId != parent.Domain.InstanceId && !(this is Scene))
			{
				Log.Error($"自己的domain跟parent不一样: {GetType().Name}");
			}
#if !SERVER
			if (ViewGO != null && parent.ViewGO != null)
			{
				ViewGO.transform.SetParent(parent.ViewGO.transform, false);
			}
#endif
		}

		public T GetParent<T>() where T : Entity
		{
			return Parent as T;
		}
		
		public override string ToString()
		{
			return DCETRuntime.MongoHelper.ToJson(this);
		}
		
		
		[BsonIgnoreIfDefault]
		[BsonDefaultValue(0L)]
		[BsonElement]
		[BsonId]
		public long Id { get; set; }

		[BsonIgnore]
		protected Entity domain;

		[BsonIgnore]
		public Entity Domain 
		{
			get
			{
				return domain;
			}
			set
			{
				if (value == null)
				{
					return;
				}
				
				Entity preDomain = domain;
				domain = value;
				
				if (!(domain is Scene))
				{
					throw new Exception($"domain is not scene: {GetType().Name}");
				}
				
				domain = value;
				
				// 是否注册跟parent一致
				if (parent != null)
				{
					IsRegister = Parent.IsRegister;
				}

				// 递归设置孩子的Domain
				if (children != null)
				{
					foreach (Entity entity in children.Values)
					{
						entity.Domain = domain;
					}
				}
				
				if (components != null)
				{
					foreach (Entity component in components.Values)
					{
						component.Domain = domain;
					}
				}
				
				if (preDomain == null && !IsFromPool)
				{
					Game.EventSystem.Deserialize(this);
				}
			}
		}

		[BsonElement("Children")]
		[BsonIgnoreIfNull]
		private HashSet<Entity> childrenDB;

		[BsonIgnore]
		private Dictionary<long, Entity> children;
		
		[BsonIgnore]
		public Dictionary<long, Entity> Children 
		{
			get
			{
				if (children == null)
				{
					children = childrenPool.Fetch();
				}

				return children;
			}
		}
		
		private void AddChild(Entity entity)
		{
			Children.Add(entity.Id, entity);
			AddChildDB(entity);
		}
		
		private void RemoveChild(Entity entity)
		{
			if (children == null)
			{
				return;
			}

			children.Remove(entity.Id);

			if (children.Count == 0)
			{
				childrenPool.Recycle(children);
				children = null;
			}
			RemoveChildDB(entity);
		}
		
		private void AddChildDB(Entity entity)
		{
			if (!(entity is ISerializeToEntity))
			{
				return;
			}
			if (childrenDB == null)
			{
				childrenDB = hashSetPool.Fetch();
			}
			childrenDB.Add(entity);
		}
		
		private void RemoveChildDB(Entity entity)
		{
			if (!(entity is ISerializeToEntity))
			{
				return;
			}

			if (childrenDB == null)
			{
				return;
			}
			
			childrenDB.Remove(entity);
			
			if (childrenDB.Count == 0)
			{
				if (IsFromPool)
				{
					hashSetPool.Recycle(childrenDB);
					childrenDB = null;
				}
			}
		}

		[BsonElement("C")]
		[BsonIgnoreIfNull]
		private HashSet<Entity> componentsDB;
		
		[BsonIgnore]
		private Dictionary<Type, Entity> components;

		[BsonIgnore]
		public Dictionary<Type, Entity> Components
		{
			get
			{
				return components;
			}
		}
		
		protected Entity()
		{
			InstanceId = IdGenerater.GenerateId();

#if !SERVER
			if (!GetType().IsDefined(typeof (HideInHierarchy), true))
			{
				ViewGO = new GameObject();
				ViewGO.name = GetType().Name;
				ViewGO.layer = LayerNames.GetLayerInt(LayerNames.HIDDEN);
				ViewGO.transform.SetParent(Global.transform, false);
				var componentView = ViewGO.AddComponent(typeof(ComponentView)) as ComponentView;

				if (componentView)
				{
					componentView.Component = this;
				}
			}
#endif
		}

		public virtual void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			long instanceId = InstanceId;
			InstanceId = 0;
			
			Game.EventSystem.Remove(instanceId);

			// 触发Destroy事件
			Game.EventSystem.Destroy(this);

			domain = null;
		
			// 清理Children
			if (children != null)
			{
				var deletes = children;
				children = null;

				foreach (Entity child in deletes.Values)
				{
					child.Dispose();
				}

				deletes.Clear();
				childrenPool.Recycle(deletes);
				
				if (childrenDB != null)
				{
					childrenDB.Clear();
					// 从池中创建的才需要回到池中,从db中不需要回收
					if (IsFromPool)
					{
						hashSetPool.Recycle(childrenDB);
						childrenDB = null;
					}
				}
			}

			// 清理Component
			if (components != null)
			{
				var deletes = components;
				components = null;
				foreach (var kv in deletes)
				{
					kv.Value.Dispose();
				}
				
				deletes.Clear();
				dictPool.Recycle(deletes);
				
				// 从池中创建的才需要回到池中,从db中不需要回收
				if (componentsDB != null)
				{
					componentsDB.Clear();
					
					if (IsFromPool)
					{
						hashSetPool.Recycle(componentsDB);
						componentsDB = null;
					}
				}
			}

			if (IsComponent)
			{
				parent?.RemoveComponentWithInstance(this);
			}
			else
			{
				parent?.RemoveChild(this);	
			}

			parent = null;

			if (IsFromPool)
			{
				Game.ObjectPool.Recycle(this);
			}
			else
			{
#if !SERVER
				if (ViewGO != null)
				{
					UnityEngine.Object.Destroy(ViewGO);
				}
#endif
			}

			status = EntityStatus.None;
		}
		
		public override void EndInit()
		{
			try
			{
				if (childrenDB != null)
				{
					foreach (Entity child in childrenDB)
					{
						child.IsComponent = false;
						AddChild(child);
						child.parent = this;
					}
				}
				
				if (componentsDB != null)
				{
					foreach (Entity component in componentsDB)
					{
						component.IsComponent = true;
						AddToComponent(component.GetType(), component);
						component.parent = this;
					}
				}
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}
		
		private void AddToComponentsDB(Entity component)
		{
			if (componentsDB == null)
			{
				componentsDB = hashSetPool.Fetch();
			}

			componentsDB.Add(component);
		}
		
		private void RemoveFromComponentsDB(Entity component)
		{
			if (componentsDB == null)
			{
				return;
			}
			componentsDB.Remove(component);
			if (componentsDB.Count == 0 && IsFromPool)
			{
				hashSetPool.Recycle(componentsDB);
				componentsDB = null;
			}
		}
		
		private void AddToComponent(Type type, Entity component)
		{
			if (components == null)
			{
				components = dictPool.Fetch();
			}

			components.Add(type, component);
			
			if (component is ISerializeToEntity)
			{
				AddToComponentsDB(component);
			}
		}
		
		private void RemoveFromComponent(Type type, Entity component)
		{
			if (components == null)
			{
				return;
			}
			
			components.Remove(type);
			
			if (components.Count == 0 && IsFromPool)
			{
				dictPool.Recycle(components);
				components = null;
			}
			
			RemoveFromComponentsDB(component);
		}
		
		public Entity AddComponentWithInstance(Entity component)
		{
			component.ComponentParent = this;
			
			Type type = component.GetType();
			
			AddToComponent(type, component);

			return component;
		}

		public Entity AddComponentWithType(Type type)
		{
			Entity component = CreateWithComponentParent(type);

			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponent<K>() where K : Entity, new()
		{
			Type type = typeof (K);
			
			K component = CreateWithComponentParent<K>();

			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponent<K, P1>(P1 p1) where K : Entity, new()
		{
			Type type = typeof (K);
			
			K component = CreateWithComponentParent<K, P1>(p1);
			
			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponent<K, P1, P2>(P1 p1, P2 p2) where K : Entity, new()
		{
			Type type = typeof (K);

			K component = CreateWithComponentParent<K, P1, P2>(p1, p2);
			
			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponent<K, P1, P2, P3>(P1 p1, P2 p2, P3 p3) where K : Entity, new()
		{
			Type type = typeof (K);
			
			K component = CreateWithComponentParent<K, P1, P2, P3>(p1, p2, p3);
			
			AddToComponent(type, component);
			
			return component;
		}
		
		public K AddComponentNoPool<K>() where K : Entity, new()
		{
			Type type = typeof (K);
			
			K component = CreateWithComponentParent<K>(false);

			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponentNoPool<K, P1>(P1 p1) where K : Entity, new()
		{
			Type type = typeof (K);
			
			K component = CreateWithComponentParent<K, P1>(p1, false);
			
			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponentNoPool<K, P1, P2>(P1 p1, P2 p2) where K : Entity, new()
		{
			Type type = typeof (K);

			K component = CreateWithComponentParent<K, P1, P2>(p1, p2, false);
			
			AddToComponent(type, component);
			
			return component;
		}

		public K AddComponentNoPool<K, P1, P2, P3>(P1 p1, P2 p2, P3 p3) where K : Entity, new()
		{
			Type type = typeof (K);
			
			K component = CreateWithComponentParent<K, P1, P2, P3>(p1, p2, p3, false);
			
			AddToComponent(type, component);
			
			return component;
		}

		public void RemoveComponent<K>() where K : Entity
		{
			if (IsDisposed)
			{
				return;
			}

			if (components == null)
			{
				return;
			}
			
			Type type = typeof (K);
			Entity c = GetComponentWithType(type);
			if (c == null)
			{
				return;
			}

			RemoveFromComponent(type, c);
			c.Dispose();
		}
		
		public void RemoveComponentWithInstance(Entity component)
		{
			if (IsDisposed)
			{
				return;
			}
			
			if (components == null)
			{
				return;
			}

			Type type = component.GetType();
			Entity c = GetComponentWithType(component.GetType());
			if (c == null)
			{
				return;
			}
			if (c.InstanceId != component.InstanceId)
			{
				return;
			}
			
			RemoveFromComponent(type, c);
			c.Dispose();
		}

		public void RemoveComponentWithType(Type type)
		{
			if (IsDisposed)
			{
				return;
			}
			
			Entity c = GetComponentWithType(type);
			if (c == null)
			{
				return;
			}

			RemoveFromComponent(type, c);
			c.Dispose();
		}

		public K GetComponent<K>() where K : Entity
		{
			if (components == null)
			{
				return null;
			}
			Entity component;
			if (!components.TryGetValue(typeof(K), out component))
			{
				return default(K);
			}
			return (K)component;
		}

		public Entity GetComponentWithType(Type type)
		{
			if (components == null)
			{
				return null;
			}
			Entity component;
			if (!components.TryGetValue(type, out component))
			{
				return null;
			}
			return component;
		}
	}
}