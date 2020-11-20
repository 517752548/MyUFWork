using System.Collections;
using System.Collections.Generic;
using ET;
using Hotfix;
using UnityEngine;

namespace ET
{
    public class MapMoveAwakeComponent: AwakeSystem<MapMoveComponent>
    {
        public override void Awake(MapMoveComponent self)
        {
            self.Awake();
        }
    }

    public class MapMoveUpdateComponent: UpdateSystem<MapMoveComponent>
    {
        public override void Update(MapMoveComponent self)
        {
            self.GUI();
            self.Move();
        }
    }

    public class MapMoveComponent: Entity
    {
        public Vector3 lastOffset = Vector2.zero;
        public Transform point;
        public MapComponent _mapconpoent;
        public Camera _camera;

        public Vector2 Margin, Smoothing = Vector2.one;

        private Vector3
                _min,
                _max;

        private Vector2 first = Vector2.zero; //鼠标第一次落下点
        private Vector2 second = Vector2.zero; //鼠标第二次位置（拖拽位置）
        private Vector3 vecPos = Vector3.zero;
        private bool IsNeedMove = false; //是否需要移动
        private Ray ray = new Ray(Vector3.forward, Vector3.forward);
        private RaycastHit hit;
        private JMapControllerCompoent _jmapControllerComponent;

        public void Awake()
        {
            Log.Info("MapMoveComponent");
            this.point = this.GetParent<MapComponent>().point;
            this._mapconpoent = GetParent<MapComponent>();
            this._camera = this._mapconpoent.mapComera;
            _min = GetParent<MapComponent>().polygonCollider2D.bounds.min; //包围盒
            _max = GetParent<MapComponent>().polygonCollider2D.bounds.max;
            first.x = point.position.x; //初始化
            first.y = point.position.y;
            CreatUIController();
        }

        private void CreatUIController()
        {
            _jmapControllerComponent = this.GetParent<MapComponent>()._jmapControllerComponent;
            _jmapControllerComponent.pointDown += PointDown;
        }

        public override void Dispose()
        {
            base.Dispose();
            _jmapControllerComponent.pointDown -= PointDown;
        }

        private void PointDown()
        {
            first = Input.mousePosition;
        }
        public void GUI()
        {
            if(_jmapControllerComponent == null)
                return;
            if(_jmapControllerComponent.GetMouseButtonDownZero)
            {
                ray.origin = this._camera.ScreenToWorldPoint(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, int.MaxValue, 1 << LayerMask.NameToLayer("NPC")))
                {
                    return;
                }
            }
            if(_jmapControllerComponent.GetMouseButtonDownZero)
            {
                //记录鼠标拖动的位置 　　
                second = Input.mousePosition;
                Vector3 fir = _camera.ScreenToWorldPoint(new Vector3(first.x, first.y, 0)); //转换至世界坐标
                Vector3 sec = _camera.ScreenToWorldPoint(new Vector3(second.x, second.y, 0));
                vecPos = sec - fir; //需要移动的 向量
                first = second;
                IsNeedMove = true;
            }
            else
            {
                IsNeedMove = false;
            }
        }

        public void Move()
        {
            if(_jmapControllerComponent == null)
                return;
            if (IsNeedMove == false)
            {
                return;
            }
            var x = point.position.x;
            var y = point.position.y;
            x = x - vecPos.x; //向量偏移
            y = y - vecPos.y;

            var cameraHalfWidth = _camera.orthographicSize * ((float) Screen.width / Screen.height);
            //保证不会移除包围盒
            x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, _min.y + _camera.orthographicSize, _max.y - _camera.orthographicSize);

            point.position = new Vector3(x, y, point.position.z);
        }
    }
}