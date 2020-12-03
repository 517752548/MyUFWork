#if !SERVER
#endif

namespace DCET
{
	/// <summary>
	/// 每个Config的基类
	/// </summary>
#if !SERVER
	[HideInHierarchy]
#endif
	public abstract class AConfigComponent: Entity, ISerializeToEntity
	{
	}
}