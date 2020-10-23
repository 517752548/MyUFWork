using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DragManager
{
    private static DragManager _ins;

    private DragMe _currentDragItem;

    private bool _isDragging;

    private Object dragData;

    private Object dropData;

    public static DragManager Ins
    {
        get
        {
            if (_ins==null)
            {
                _ins = new DragManager();
            }
            return _ins;
        }
    }

    public DragMe CurrentDragItem
    {
        get { return _currentDragItem; }
        set { _currentDragItem = value; }
    }

    public bool IsDragging
    {
        get { return _isDragging; }
        set { _isDragging = value; }
    }

    public object DragData
    {
        get { return dragData; }
        set { dragData = value; }
    }

    public object DropData
    {
        get { return dropData; }
        set { dropData = value; }
    }
}
