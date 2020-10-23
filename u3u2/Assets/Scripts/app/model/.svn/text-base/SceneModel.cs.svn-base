using System;
using UnityEngine;
using app.zone;
using app.main;

namespace app.model
{
    public class SceneModel
    {
        /// <summary>
        /// 场景中的地面。
        /// </summary>
        /// <value>The ground.</value>
        public GameObject ground { get; private set; }

        /// <summary>
        /// 地图场景根容器。
        /// </summary>
        /// <value>The zone container.</value>
        public GameObject zoneContainer { get; private set; }

        /// <summary>
        /// 地图场景3D模型和粒子特效的容器。
        /// </summary>
        /// <value>The zone model container.</value>
        public GameObject zoneModelContainer { get; private set; }

        /// <summary>
        /// 地图场景摄像机容器。
        /// </summary>
        /// <value>The zone cams container.</value>
        public GameObject zoneCamsContainer { get; private set; }

        /// <summary>
        /// 地图场景地面摄像机。
        /// </summary>
        /// <value>The zone ground cam.</value>
        public GameObject zoneGroundCam { get; private set; }

        /// <summary>
        /// 地图场景3D模型和粒子特效摄像机。
        /// </summary>
        /// <value>The zone3 D model cam.</value>
        public GameObject zone3DModelCam { get; private set; }

        /// <summary>
        /// 地图场景遮挡物摄像机。
        /// </summary>
        /// <value>The zone3 D model cam.</value>
        //public GameObject zoneCoverCam { get; set; }

        /// <summary>
        /// 战斗场景根容器。
        /// </summary>
        /// <value>The battle container.</value>
        public GameObject battleContainer { get; private set; }

        /// <summary>
        /// 战斗场景中的3D模型和粒子特效的容器。
        /// </summary>
        /// <value>The battle model container.</value>
        public GameObject battleModelContainer { get; private set; }

        /// <summary>
        /// 战斗场景摄像机。
        /// </summary>
        /// <value>The battle cam.</value>
        public GameObject battleCam { get; private set; }

        /// <summary>
        /// 战斗场景地面容器。
        /// </summary>
        /// <value>The battle ground container.</value>
        public GameObject battleGroundContainer { get; private set; }

        public GameObject battleGroundMask { get; private set; }

        public ZoneMapConfig zoneMapConfig { get; private set; }

        public GameObject groundTile { get; private set; }

        private static SceneModel mIns = new SceneModel();

        public static SceneModel ins
        {
            get
            {
                return mIns;
            }
        }

        public SceneModel()
        {
            if (SceneModel.ins != null)
            {
                throw new Exception("SceneModel instance already exists!");
            }

            CreateScene();
        }

        private void CreateScene()
        {
            Material dimianMat = new Material(GameClient.ins.gameShaders.FindShader("Unlit/ColoredTexture"));
            //dimianMat.mainTexture = null;
            dimianMat.name = "dimian";

            zoneContainer = new GameObject("Zone");
            zoneContainer.layer = LayerMask.NameToLayer("Zone");
            GameObject.DontDestroyOnLoad(zoneContainer);

            zoneCamsContainer = new GameObject("ZoneCams");
            zoneCamsContainer.layer = LayerMask.NameToLayer("Zone");
            zoneCamsContainer.transform.SetParent(zoneContainer.transform);

            zoneGroundCam = new GameObject("ZoneGroundCam");
            zoneGroundCam.layer = LayerMask.NameToLayer("Zone");
            zoneGroundCam.transform.SetParent(zoneCamsContainer.transform);
            zoneGroundCam.transform.localPosition = Vector3.zero;
            zoneGroundCam.transform.localEulerAngles = new Vector3(90, 0, 0);
            zoneGroundCam.transform.localScale = Vector3.one;
            Camera zoneGroundCamCam = zoneGroundCam.AddComponent<Camera>();
            zoneGroundCamCam.clearFlags = CameraClearFlags.Depth;
            zoneGroundCamCam.cullingMask = 1 << LayerMask.NameToLayer("Ground");
            zoneGroundCamCam.orthographic = true;
            zoneGroundCamCam.orthographicSize = 5;
            zoneGroundCamCam.nearClipPlane = -1;
            zoneGroundCamCam.farClipPlane = 1;
            zoneGroundCamCam.depth = -1;
            zoneGroundCamCam.renderingPath = RenderingPath.UsePlayerSettings;
            zoneGroundCamCam.useOcclusionCulling = false;
            zoneGroundCamCam.hdr = false;

            zone3DModelCam = new GameObject("ZoneModelCam");
            zone3DModelCam.layer = LayerMask.NameToLayer("Zone");
            zone3DModelCam.transform.SetParent(zoneCamsContainer.transform);
            zone3DModelCam.transform.localPosition = Vector3.zero;
            zone3DModelCam.transform.localEulerAngles = new Vector3(30, 0, 0);
            zone3DModelCam.transform.localScale = Vector3.one;
            Camera zoneModelCamCam = zone3DModelCam.AddComponent<Camera>();
            zoneModelCamCam.clearFlags = CameraClearFlags.Depth;
            zoneModelCamCam.cullingMask = 1 << LayerMask.NameToLayer("ZoneModel");
            zoneModelCamCam.orthographic = true;
            zoneModelCamCam.orthographicSize = 5;
            zoneModelCamCam.nearClipPlane = -12;
            zoneModelCamCam.farClipPlane = 12;
            zoneModelCamCam.depth = 0;
            zoneModelCamCam.renderingPath = RenderingPath.UsePlayerSettings;
            zoneModelCamCam.useOcclusionCulling = false;
            zoneModelCamCam.hdr = false;

            ground = new GameObject();
            ground.name = "Ground";
            BoxCollider groundClder = ground.AddComponent<BoxCollider>();
            groundClder.isTrigger = true;
            groundClder.center = new Vector3(0, 0, 0);
            //groundClder.size = new Vector3(31.5f / 4.67f, 31.5f / 4.67f, 1.0f);
            //ground.layer = LayerMask.NameToLayer("Ground");
            ground.transform.localPosition = Vector3.zero;
            ground.transform.localEulerAngles = new Vector3(90, 0, 0);
            ground.transform.localScale = new Vector3(4.67f, 4.67f, 1f);
            GameObject.DontDestroyOnLoad(ground);

            groundTile = GameObject.CreatePrimitive(PrimitiveType.Quad);
            groundTile.name = "groundTile";
            GameObject.DestroyImmediate(groundTile.GetComponent<MeshCollider>(), true);
            MeshRenderer mrder = groundTile.GetComponent<MeshRenderer>();
            mrder.material = dimianMat;
            mrder.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            mrder.receiveShadows = false;
            mrder.useLightProbes = false;
            mrder.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            #if UNITY_EDITOR
            mrder.sharedMaterial.shader = Shader.Find(mrder.sharedMaterial.shader.name);
            #endif
            groundTile.transform.SetParent(ground.transform);
            groundTile.layer = LayerMask.NameToLayer("Ground");
            groundTile.transform.localPosition = Vector3.zero;
            groundTile.transform.localEulerAngles = Vector3.zero;
            groundTile.transform.localScale = Vector3.one;
            groundTile.SetActive(false);

            zoneModelContainer = new GameObject("ZoneModels");
            zoneModelContainer.layer = LayerMask.NameToLayer("ZoneModel");
            zoneModelContainer.transform.SetParent(zoneContainer.transform);
            zoneModelContainer.transform.localPosition = new Vector3(0, 0, 0);

            battleContainer = new GameObject("Battle");
            battleContainer.layer = LayerMask.NameToLayer("Battle");
            GameObject.DontDestroyOnLoad(battleContainer);

            battleCam = new GameObject("BattleCam");
            battleCam.layer = LayerMask.NameToLayer("Battle");
            battleCam.transform.SetParent(battleContainer.transform);
            battleCam.transform.localPosition = new Vector3(0, 1, 0);
            battleCam.transform.localEulerAngles = new Vector3(30, 315, 0);
            battleCam.transform.localScale = Vector3.one;
            Camera battleModelCamCam = battleCam.AddComponent<Camera>();
            battleModelCamCam.clearFlags = CameraClearFlags.Depth;
            battleModelCamCam.cullingMask = 1 << LayerMask.NameToLayer("BattleGround") | 1 << LayerMask.NameToLayer("BattleModel");
            battleModelCamCam.orthographic = true;
            battleModelCamCam.orthographicSize = 5;
            battleModelCamCam.nearClipPlane = -20;
            battleModelCamCam.farClipPlane = 20;
            battleModelCamCam.depth = 0;
            battleModelCamCam.renderingPath = RenderingPath.UsePlayerSettings;
            battleModelCamCam.useOcclusionCulling = false;
            battleModelCamCam.hdr = false;

            battleGroundContainer = new GameObject("BattleGroundContainer");
            battleGroundContainer.layer = LayerMask.NameToLayer("BattleGround");
            battleGroundContainer.transform.SetParent(battleContainer.transform);
            battleGroundContainer.transform.localPosition = new Vector3(-1.25f, 0, 1.24f);
            battleGroundContainer.transform.localEulerAngles = new Vector3(0, 315, 0);

            battleModelContainer = new GameObject("BattleModels");
            battleModelContainer.layer = LayerMask.NameToLayer("BattleModel");
            battleModelContainer.transform.SetParent(battleContainer.transform);
            battleModelContainer.transform.localPosition = new Vector3(0, 0.002f, 0);

            battleGroundMask = SourceManager.Ins.createObjectFromAssetBundle("battleGroundMask.abl");
            battleGroundMask.transform.SetParent(battleGroundContainer.transform);
            battleGroundMask.transform.localPosition = new Vector3(0, 0.001f, -0.1f);
            battleGroundMask.transform.localEulerAngles = new Vector3(90, 0, 0);
            float scrW = UGUIConfig.ZoneViewportWidth;
            float scrH = UGUIConfig.ZoneViewportHeight;
            float orgRatio = 1.5f;
            float curRatio = (float)scrW / (float)scrH;
            battleGroundMask.transform.localScale = new Vector3(1.04f * curRatio / orgRatio, 2.06f, 1.0f);
            battleGroundMask.SetActive(true);
        }

        public void InitScene()
        {
            BoxCollider groundBoxCollider = ground.GetComponent<BoxCollider>();
            if (groundBoxCollider == null)
            {
                groundBoxCollider = ground.AddComponent<BoxCollider>();
            }

            float groundBoxColliderWidth = ((float)ZoneModel.ins.mapPixelWidth / (float)ZoneDef.MAP_PIXEL_ONE_UNIT) / ((float)ZoneDef.MAP_TILE_PIXEL_WIDTH / (float)ZoneDef.MAP_PIXEL_ONE_UNIT);
            float groundBoxColliderHeight = ((float)ZoneModel.ins.mapPixelHeight / (float)ZoneDef.MAP_PIXEL_ONE_UNIT) / ((float)ZoneDef.MAP_TILE_PIXEL_HEIGHT / (float)ZoneDef.MAP_PIXEL_ONE_UNIT);

            groundBoxCollider.size = new Vector3(groundBoxColliderWidth * 1.1f, groundBoxColliderHeight * 1.1f, 0.004f);

            battleCam.SetActive(false);

            zoneMapConfig = GameObject.Find("config").GetComponent<ZoneMapConfig>();
            zoneMapConfig.groundTile = groundTile;
        }

        public void InitZoneScene()
        {
            if (ZoneModel.ins.zoneMap!=null) ZoneModel.ins.zoneMap.ExitBattle();
            //battleContainer.SetActive(false);
            //zoneContainer.SetActive(true);
            battleCam.SetActive(false);
            zoneCamsContainer.SetActive(true);
            ground.transform.SetParent(null);
            ground.transform.localPosition = Vector3.zero;
            ground.transform.localEulerAngles = new Vector3(90, 0, 0);
            ground.transform.localScale = new Vector3((float)ZoneDef.MAP_TILE_PIXEL_WIDTH / (float)ZoneDef.MAP_PIXEL_ONE_UNIT, (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT / (float)ZoneDef.MAP_PIXEL_ONE_UNIT, 1);
            ground.layer = LayerMask.NameToLayer(GlobalConstDefine.SCENE_GROUND_LAYER_NAME);
            ground.SetActive(true);
            //ground.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
            //cover.SetActive(true);

            //ResetShader();
        }

        public void InitBattleScene()
        {
            //zoneContainer.SetActive(false);
            //cover.SetActive(false);
            //battleContainer.SetActive(true);
            battleCam.SetActive(true);
            zoneCamsContainer.SetActive(false);
            ground.transform.SetParent(battleGroundContainer.transform);
            Vector3 zoneCamsPos = zoneCamsContainer.transform.localPosition;
            ground.transform.localPosition = new Vector3(-zoneCamsPos.x, 0, -zoneCamsPos.z * 2.0f);
            ground.transform.localEulerAngles = new Vector3(90, 0, 0);
            ground.transform.localScale = new Vector3((float)ZoneDef.MAP_TILE_PIXEL_WIDTH / (float)ZoneDef.MAP_PIXEL_ONE_UNIT, (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT / (float)ZoneDef.MAP_PIXEL_ONE_UNIT * 2, 1);
            ground.layer = battleGroundContainer.layer;
            ground.SetActive(true);
            ZoneModel.ins.zoneMap.EnterBattle();
            //ground.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.39f, 0.39f, 0.39f, 1));

            //ResetShader();
        }

        /// <summary>
        /// 判断 当前地图格子点 是否可走
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <returns></returns>
        public bool IsMapTileCanWalk(int col, int row)
        {
            int colCount = SceneModel.ins.zoneMapConfig.pathTileColCount;
            int rowCount = SceneModel.ins.zoneMapConfig.pathTileRowCount;

            if (col >= 0 && col < colCount && row >= 0 && row < rowCount)
            {
                if (SceneModel.ins.zoneMapConfig.pathTilesMarix[col][row] != 'X')
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            GameObject.DestroyImmediate(ground, true);
            ground = null;
            GameObject.DestroyImmediate(zoneContainer, true);
            zoneContainer = null;
            GameObject.DestroyImmediate(zoneCamsContainer, true);
            zoneCamsContainer = null;
            GameObject.DestroyImmediate(zoneGroundCam, true);
            zoneGroundCam = null;
            GameObject.DestroyImmediate(zone3DModelCam, true);
            zone3DModelCam = null;
            GameObject.DestroyImmediate(zoneModelContainer, true);
            zoneModelContainer = null;
            GameObject.DestroyImmediate(battleContainer, true);
            battleContainer = null;
            GameObject.DestroyImmediate(battleModelContainer, true);
            battleModelContainer = null;
            GameObject.DestroyImmediate(battleCam, true);
            battleCam = null;
            GameObject.DestroyImmediate(battleGroundContainer, true);
            battleGroundContainer = null;
            if (zoneMapConfig != null) GameObject.DestroyImmediate(zoneMapConfig.groundTile, true);
            zoneMapConfig = null;
            GameObject.DestroyImmediate(battleGroundMask, true);
            battleGroundMask = null;
        }
    }
}