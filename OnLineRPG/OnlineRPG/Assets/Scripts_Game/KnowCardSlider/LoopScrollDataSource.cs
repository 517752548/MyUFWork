using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Bag;

namespace UnityEngine.UI
{
    public abstract class LoopScrollDataSource
    {
        public abstract void ProvideData(Transform transform, int idx);
        public abstract void ProvideData(KnowledgeCardViewItem transform, int idx,bool isStartItem);
    }

	public class LoopScrollSendIndexSource : LoopScrollDataSource
    {
		public static readonly LoopScrollSendIndexSource Instance = new LoopScrollSendIndexSource();

		LoopScrollSendIndexSource(){}

        public override void ProvideData(Transform transform, int idx)
        {
            transform.GetComponent<KnowledgeCardViewItem>().ReCreatView(idx,false);
        }

        public override void ProvideData(KnowledgeCardViewItem transform, int idx, bool isStartItem)
        {
            throw new System.NotImplementedException();
        }
    }

	public class LoopScrollArraySource<T> : LoopScrollDataSource
    {
        T[] objectsToFill;

		public LoopScrollArraySource(T[] objectsToFill)
        {
            this.objectsToFill = objectsToFill;
        }

        public override void ProvideData(Transform transform, int idx)
        {
            transform.SendMessage("ScrollCellContent", objectsToFill[idx]);
        }

        public override void ProvideData(KnowledgeCardViewItem transform, int idx, bool isStartItem)
        {
            throw new System.NotImplementedException();
        }
    }
    public class KnowledgeLoopScrollArraySource<T> : LoopScrollDataSource
    {
        List<T> objectsToFill;

        public KnowledgeLoopScrollArraySource(List<T> objectsToFill)
        {
            this.objectsToFill = objectsToFill;
        }

        public override void ProvideData(Transform transform, int idx)
        {
            throw new System.NotImplementedException();
        }

        public override void ProvideData(KnowledgeCardViewItem transform, int idx,bool isAtartItem)
        {
            transform.ReCreatView(this.objectsToFill[idx],isAtartItem);
        }
    }
}