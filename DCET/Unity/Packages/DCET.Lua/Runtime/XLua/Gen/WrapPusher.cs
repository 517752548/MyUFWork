#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class ObjectTranslator
    {
        
        class IniterAdderUnityEngineVector2
        {
            static IniterAdderUnityEngineVector2()
            {
                LuaEnv.AddIniter(Init);
            }
			
			static void Init(LuaEnv luaenv, ObjectTranslator translator)
			{
			
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector2>(translator.PushUnityEngineVector2, translator.Get, translator.UpdateUnityEngineVector2);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector3>(translator.PushUnityEngineVector3, translator.Get, translator.UpdateUnityEngineVector3);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector4>(translator.PushUnityEngineVector4, translator.Get, translator.UpdateUnityEngineVector4);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Color>(translator.PushUnityEngineColor, translator.Get, translator.UpdateUnityEngineColor);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Quaternion>(translator.PushUnityEngineQuaternion, translator.Get, translator.UpdateUnityEngineQuaternion);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray>(translator.PushUnityEngineRay, translator.Get, translator.UpdateUnityEngineRay);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Bounds>(translator.PushUnityEngineBounds, translator.Get, translator.UpdateUnityEngineBounds);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray2D>(translator.PushUnityEngineRay2D, translator.Get, translator.UpdateUnityEngineRay2D);
				translator.RegisterPushAndGetAndUpdate<System.Net.Sockets.AddressFamily>(translator.PushSystemNetSocketsAddressFamily, translator.Get, translator.UpdateSystemNetSocketsAddressFamily);
				translator.RegisterPushAndGetAndUpdate<System.Net.Sockets.SocketType>(translator.PushSystemNetSocketsSocketType, translator.Get, translator.UpdateSystemNetSocketsSocketType);
				translator.RegisterPushAndGetAndUpdate<System.Net.Sockets.ProtocolType>(translator.PushSystemNetSocketsProtocolType, translator.Get, translator.UpdateSystemNetSocketsProtocolType);
				translator.RegisterPushAndGetAndUpdate<PF.HeuristicOptimizationMode>(translator.PushPFHeuristicOptimizationMode, translator.Get, translator.UpdatePFHeuristicOptimizationMode);
				translator.RegisterPushAndGetAndUpdate<PF.GraphUpdateThreading>(translator.PushPFGraphUpdateThreading, translator.Get, translator.UpdatePFGraphUpdateThreading);
				translator.RegisterPushAndGetAndUpdate<PF.ThreadCount>(translator.PushPFThreadCount, translator.Get, translator.UpdatePFThreadCount);
				translator.RegisterPushAndGetAndUpdate<PF.PathState>(translator.PushPFPathState, translator.Get, translator.UpdatePFPathState);
				translator.RegisterPushAndGetAndUpdate<PF.PathCompleteState>(translator.PushPFPathCompleteState, translator.Get, translator.UpdatePFPathCompleteState);
				translator.RegisterPushAndGetAndUpdate<PF.CloseToDestinationMode>(translator.PushPFCloseToDestinationMode, translator.Get, translator.UpdatePFCloseToDestinationMode);
				translator.RegisterPushAndGetAndUpdate<PF.Side>(translator.PushPFSide, translator.Get, translator.UpdatePFSide);
				translator.RegisterPushAndGetAndUpdate<PF.InspectorGridMode>(translator.PushPFInspectorGridMode, translator.Get, translator.UpdatePFInspectorGridMode);
				translator.RegisterPushAndGetAndUpdate<PF.GraphDebugMode>(translator.PushPFGraphDebugMode, translator.Get, translator.UpdatePFGraphDebugMode);
				translator.RegisterPushAndGetAndUpdate<PF.PathLog>(translator.PushPFPathLog, translator.Get, translator.UpdatePFPathLog);
				translator.RegisterPushAndGetAndUpdate<PF.Heuristic>(translator.PushPFHeuristic, translator.Get, translator.UpdatePFHeuristic);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.RVO.MovementPlane>(translator.PushPathfindingRVOMovementPlane, translator.Get, translator.UpdatePathfindingRVOMovementPlane);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.RVO.RVOLayer>(translator.PushPathfindingRVORVOLayer, translator.Get, translator.UpdatePathfindingRVORVOLayer);
				translator.RegisterPushAndGetAndUpdate<AstarPath.AstarDistribution>(translator.PushAstarPathAstarDistribution, translator.Get, translator.UpdateAstarPathAstarDistribution);
				translator.RegisterPushAndGetAndUpdate<PF.MultiTargetPath.HeuristicMode>(translator.PushPFMultiTargetPathHeuristicMode, translator.Get, translator.UpdatePFMultiTargetPathHeuristicMode);
				translator.RegisterPushAndGetAndUpdate<PF.RecastGraph.RelevantGraphSurfaceMode>(translator.PushPFRecastGraphRelevantGraphSurfaceMode, translator.Get, translator.UpdatePFRecastGraphRelevantGraphSurfaceMode);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.Seeker.ModifierPass>(translator.PushPathfindingSeekerModifierPass, translator.Get, translator.UpdatePathfindingSeekerModifierPass);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.GraphModifier.EventType>(translator.PushPathfindingGraphModifierEventType, translator.Get, translator.UpdatePathfindingGraphModifierEventType);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.RaycastModifier.Quality>(translator.PushPathfindingRaycastModifierQuality, translator.Get, translator.UpdatePathfindingRaycastModifierQuality);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.SimpleSmoothModifier.SmoothType>(translator.PushPathfindingSimpleSmoothModifierSmoothType, translator.Get, translator.UpdatePathfindingSimpleSmoothModifierSmoothType);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.StartEndModifier.Exactness>(translator.PushPathfindingStartEndModifierExactness, translator.Get, translator.UpdatePathfindingStartEndModifierExactness);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.BlockManager.BlockMode>(translator.PushPathfindingBlockManagerBlockMode, translator.Get, translator.UpdatePathfindingBlockManagerBlockMode);
				translator.RegisterPushAndGetAndUpdate<Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding>(translator.PushPathfindingRVORVOObstacleObstacleVertexWinding, translator.Get, translator.UpdatePathfindingRVORVOObstacleObstacleVertexWinding);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.BlendMode>(translator.PushFairyGUIBlendMode, translator.Get, translator.UpdateFairyGUIBlendMode);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.HitTestMode>(translator.PushFairyGUIHitTestMode, translator.Get, translator.UpdateFairyGUIHitTestMode);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.DestroyMethod>(translator.PushFairyGUIDestroyMethod, translator.Get, translator.UpdateFairyGUIDestroyMethod);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.EaseType>(translator.PushFairyGUIEaseType, translator.Get, translator.UpdateFairyGUIEaseType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.TweenPropType>(translator.PushFairyGUITweenPropType, translator.Get, translator.UpdateFairyGUITweenPropType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.PackageItemType>(translator.PushFairyGUIPackageItemType, translator.Get, translator.UpdateFairyGUIPackageItemType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ObjectType>(translator.PushFairyGUIObjectType, translator.Get, translator.UpdateFairyGUIObjectType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.AlignType>(translator.PushFairyGUIAlignType, translator.Get, translator.UpdateFairyGUIAlignType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.VertAlignType>(translator.PushFairyGUIVertAlignType, translator.Get, translator.UpdateFairyGUIVertAlignType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.OverflowType>(translator.PushFairyGUIOverflowType, translator.Get, translator.UpdateFairyGUIOverflowType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.FillType>(translator.PushFairyGUIFillType, translator.Get, translator.UpdateFairyGUIFillType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.AutoSizeType>(translator.PushFairyGUIAutoSizeType, translator.Get, translator.UpdateFairyGUIAutoSizeType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ScrollType>(translator.PushFairyGUIScrollType, translator.Get, translator.UpdateFairyGUIScrollType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ScrollBarDisplayType>(translator.PushFairyGUIScrollBarDisplayType, translator.Get, translator.UpdateFairyGUIScrollBarDisplayType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.RelationType>(translator.PushFairyGUIRelationType, translator.Get, translator.UpdateFairyGUIRelationType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ListLayoutType>(translator.PushFairyGUIListLayoutType, translator.Get, translator.UpdateFairyGUIListLayoutType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ListSelectionMode>(translator.PushFairyGUIListSelectionMode, translator.Get, translator.UpdateFairyGUIListSelectionMode);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ProgressTitleType>(translator.PushFairyGUIProgressTitleType, translator.Get, translator.UpdateFairyGUIProgressTitleType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ButtonMode>(translator.PushFairyGUIButtonMode, translator.Get, translator.UpdateFairyGUIButtonMode);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.TransitionActionType>(translator.PushFairyGUITransitionActionType, translator.Get, translator.UpdateFairyGUITransitionActionType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.GroupLayoutType>(translator.PushFairyGUIGroupLayoutType, translator.Get, translator.UpdateFairyGUIGroupLayoutType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ChildrenRenderOrder>(translator.PushFairyGUIChildrenRenderOrder, translator.Get, translator.UpdateFairyGUIChildrenRenderOrder);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.PopupDirection>(translator.PushFairyGUIPopupDirection, translator.Get, translator.UpdateFairyGUIPopupDirection);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.FlipType>(translator.PushFairyGUIFlipType, translator.Get, translator.UpdateFairyGUIFlipType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.FillMethod>(translator.PushFairyGUIFillMethod, translator.Get, translator.UpdateFairyGUIFillMethod);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.OriginHorizontal>(translator.PushFairyGUIOriginHorizontal, translator.Get, translator.UpdateFairyGUIOriginHorizontal);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.OriginVertical>(translator.PushFairyGUIOriginVertical, translator.Get, translator.UpdateFairyGUIOriginVertical);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.Origin90>(translator.PushFairyGUIOrigin90, translator.Get, translator.UpdateFairyGUIOrigin90);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.Origin180>(translator.PushFairyGUIOrigin180, translator.Get, translator.UpdateFairyGUIOrigin180);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.Origin360>(translator.PushFairyGUIOrigin360, translator.Get, translator.UpdateFairyGUIOrigin360);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.FitScreen>(translator.PushFairyGUIFitScreen, translator.Get, translator.UpdateFairyGUIFitScreen);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.Utils.HtmlElementType>(translator.PushFairyGUIUtilsHtmlElementType, translator.Get, translator.UpdateFairyGUIUtilsHtmlElementType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.Utils.XMLTagType>(translator.PushFairyGUIUtilsXMLTagType, translator.Get, translator.UpdateFairyGUIUtilsXMLTagType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.RTLSupport.DirectionType>(translator.PushFairyGUIRTLSupportDirectionType, translator.Get, translator.UpdateFairyGUIRTLSupportDirectionType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.TextFormat.SpecialStyle>(translator.PushFairyGUITextFormatSpecialStyle, translator.Get, translator.UpdateFairyGUITextFormatSpecialStyle);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.GPathPoint.CurveType>(translator.PushFairyGUIGPathPointCurveType, translator.Get, translator.UpdateFairyGUIGPathPointCurveType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.ControllerAction.ActionType>(translator.PushFairyGUIControllerActionActionType, translator.Get, translator.UpdateFairyGUIControllerActionActionType);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.UIConfig.ConfigKey>(translator.PushFairyGUIUIConfigConfigKey, translator.Get, translator.UpdateFairyGUIUIConfigConfigKey);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.UIContentScaler.ScaleMode>(translator.PushFairyGUIUIContentScalerScaleMode, translator.Get, translator.UpdateFairyGUIUIContentScalerScaleMode);
				translator.RegisterPushAndGetAndUpdate<FairyGUI.UIContentScaler.ScreenMatchMode>(translator.PushFairyGUIUIContentScalerScreenMatchMode, translator.Get, translator.UpdateFairyGUIUIContentScalerScreenMatchMode);
				translator.RegisterPushAndGetAndUpdate<Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType>(translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType, translator.Get, translator.UpdateMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType);
				translator.RegisterPushAndGetAndUpdate<Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason>(translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason, translator.Get, translator.UpdateMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason);
			
			}
        }
        
        static IniterAdderUnityEngineVector2 s_IniterAdderUnityEngineVector2_dumb_obj = new IniterAdderUnityEngineVector2();
        static IniterAdderUnityEngineVector2 IniterAdderUnityEngineVector2_dumb_obj {get{return s_IniterAdderUnityEngineVector2_dumb_obj;}}
        
        
        int UnityEngineVector2_TypeID = -1;
        public void PushUnityEngineVector2(RealStatePtr L, UnityEngine.Vector2 val)
        {
            if (UnityEngineVector2_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector2_TypeID = getTypeId(L, typeof(UnityEngine.Vector2), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 8, UnityEngineVector2_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector2 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector2 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector2");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector2)objectCasters.GetCaster(typeof(UnityEngine.Vector2))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector2(RealStatePtr L, int index, UnityEngine.Vector2 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector2 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineVector3_TypeID = -1;
        public void PushUnityEngineVector3(RealStatePtr L, UnityEngine.Vector3 val)
        {
            if (UnityEngineVector3_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector3_TypeID = getTypeId(L, typeof(UnityEngine.Vector3), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 12, UnityEngineVector3_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector3 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector3 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector3");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector3)objectCasters.GetCaster(typeof(UnityEngine.Vector3))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector3(RealStatePtr L, int index, UnityEngine.Vector3 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector3 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineVector4_TypeID = -1;
        public void PushUnityEngineVector4(RealStatePtr L, UnityEngine.Vector4 val)
        {
            if (UnityEngineVector4_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector4_TypeID = getTypeId(L, typeof(UnityEngine.Vector4), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineVector4_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector4 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector4 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector4");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector4)objectCasters.GetCaster(typeof(UnityEngine.Vector4))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector4(RealStatePtr L, int index, UnityEngine.Vector4 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector4 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineColor_TypeID = -1;
        public void PushUnityEngineColor(RealStatePtr L, UnityEngine.Color val)
        {
            if (UnityEngineColor_TypeID == -1)
            {
			    bool is_first;
                UnityEngineColor_TypeID = getTypeId(L, typeof(UnityEngine.Color), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineColor_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Color ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Color val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Color");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Color)objectCasters.GetCaster(typeof(UnityEngine.Color))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineColor(RealStatePtr L, int index, UnityEngine.Color val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Color ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineQuaternion_TypeID = -1;
        public void PushUnityEngineQuaternion(RealStatePtr L, UnityEngine.Quaternion val)
        {
            if (UnityEngineQuaternion_TypeID == -1)
            {
			    bool is_first;
                UnityEngineQuaternion_TypeID = getTypeId(L, typeof(UnityEngine.Quaternion), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineQuaternion_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Quaternion ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Quaternion val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Quaternion");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Quaternion)objectCasters.GetCaster(typeof(UnityEngine.Quaternion))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineQuaternion(RealStatePtr L, int index, UnityEngine.Quaternion val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Quaternion ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRay_TypeID = -1;
        public void PushUnityEngineRay(RealStatePtr L, UnityEngine.Ray val)
        {
            if (UnityEngineRay_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay_TypeID = getTypeId(L, typeof(UnityEngine.Ray), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineRay_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Ray val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray)objectCasters.GetCaster(typeof(UnityEngine.Ray))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRay(RealStatePtr L, int index, UnityEngine.Ray val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineBounds_TypeID = -1;
        public void PushUnityEngineBounds(RealStatePtr L, UnityEngine.Bounds val)
        {
            if (UnityEngineBounds_TypeID == -1)
            {
			    bool is_first;
                UnityEngineBounds_TypeID = getTypeId(L, typeof(UnityEngine.Bounds), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineBounds_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Bounds ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Bounds val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Bounds");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Bounds)objectCasters.GetCaster(typeof(UnityEngine.Bounds))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineBounds(RealStatePtr L, int index, UnityEngine.Bounds val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Bounds ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRay2D_TypeID = -1;
        public void PushUnityEngineRay2D(RealStatePtr L, UnityEngine.Ray2D val)
        {
            if (UnityEngineRay2D_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay2D_TypeID = getTypeId(L, typeof(UnityEngine.Ray2D), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineRay2D_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray2D ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Ray2D val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray2D");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray2D)objectCasters.GetCaster(typeof(UnityEngine.Ray2D))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRay2D(RealStatePtr L, int index, UnityEngine.Ray2D val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray2D ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int SystemNetSocketsAddressFamily_TypeID = -1;
		int SystemNetSocketsAddressFamily_EnumRef = -1;
        
        public void PushSystemNetSocketsAddressFamily(RealStatePtr L, System.Net.Sockets.AddressFamily val)
        {
            if (SystemNetSocketsAddressFamily_TypeID == -1)
            {
			    bool is_first;
                SystemNetSocketsAddressFamily_TypeID = getTypeId(L, typeof(System.Net.Sockets.AddressFamily), out is_first);
				
				if (SystemNetSocketsAddressFamily_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(System.Net.Sockets.AddressFamily));
				    SystemNetSocketsAddressFamily_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, SystemNetSocketsAddressFamily_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, SystemNetSocketsAddressFamily_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for System.Net.Sockets.AddressFamily ,value="+val);
            }
			
			LuaAPI.lua_getref(L, SystemNetSocketsAddressFamily_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out System.Net.Sockets.AddressFamily val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != SystemNetSocketsAddressFamily_TypeID)
				{
				    throw new Exception("invalid userdata for System.Net.Sockets.AddressFamily");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for System.Net.Sockets.AddressFamily");
                }
				val = (System.Net.Sockets.AddressFamily)e;
                
            }
            else
            {
                val = (System.Net.Sockets.AddressFamily)objectCasters.GetCaster(typeof(System.Net.Sockets.AddressFamily))(L, index, null);
            }
        }
		
        public void UpdateSystemNetSocketsAddressFamily(RealStatePtr L, int index, System.Net.Sockets.AddressFamily val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != SystemNetSocketsAddressFamily_TypeID)
				{
				    throw new Exception("invalid userdata for System.Net.Sockets.AddressFamily");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for System.Net.Sockets.AddressFamily ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int SystemNetSocketsSocketType_TypeID = -1;
		int SystemNetSocketsSocketType_EnumRef = -1;
        
        public void PushSystemNetSocketsSocketType(RealStatePtr L, System.Net.Sockets.SocketType val)
        {
            if (SystemNetSocketsSocketType_TypeID == -1)
            {
			    bool is_first;
                SystemNetSocketsSocketType_TypeID = getTypeId(L, typeof(System.Net.Sockets.SocketType), out is_first);
				
				if (SystemNetSocketsSocketType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(System.Net.Sockets.SocketType));
				    SystemNetSocketsSocketType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, SystemNetSocketsSocketType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, SystemNetSocketsSocketType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for System.Net.Sockets.SocketType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, SystemNetSocketsSocketType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out System.Net.Sockets.SocketType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != SystemNetSocketsSocketType_TypeID)
				{
				    throw new Exception("invalid userdata for System.Net.Sockets.SocketType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for System.Net.Sockets.SocketType");
                }
				val = (System.Net.Sockets.SocketType)e;
                
            }
            else
            {
                val = (System.Net.Sockets.SocketType)objectCasters.GetCaster(typeof(System.Net.Sockets.SocketType))(L, index, null);
            }
        }
		
        public void UpdateSystemNetSocketsSocketType(RealStatePtr L, int index, System.Net.Sockets.SocketType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != SystemNetSocketsSocketType_TypeID)
				{
				    throw new Exception("invalid userdata for System.Net.Sockets.SocketType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for System.Net.Sockets.SocketType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int SystemNetSocketsProtocolType_TypeID = -1;
		int SystemNetSocketsProtocolType_EnumRef = -1;
        
        public void PushSystemNetSocketsProtocolType(RealStatePtr L, System.Net.Sockets.ProtocolType val)
        {
            if (SystemNetSocketsProtocolType_TypeID == -1)
            {
			    bool is_first;
                SystemNetSocketsProtocolType_TypeID = getTypeId(L, typeof(System.Net.Sockets.ProtocolType), out is_first);
				
				if (SystemNetSocketsProtocolType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(System.Net.Sockets.ProtocolType));
				    SystemNetSocketsProtocolType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, SystemNetSocketsProtocolType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, SystemNetSocketsProtocolType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for System.Net.Sockets.ProtocolType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, SystemNetSocketsProtocolType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out System.Net.Sockets.ProtocolType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != SystemNetSocketsProtocolType_TypeID)
				{
				    throw new Exception("invalid userdata for System.Net.Sockets.ProtocolType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for System.Net.Sockets.ProtocolType");
                }
				val = (System.Net.Sockets.ProtocolType)e;
                
            }
            else
            {
                val = (System.Net.Sockets.ProtocolType)objectCasters.GetCaster(typeof(System.Net.Sockets.ProtocolType))(L, index, null);
            }
        }
		
        public void UpdateSystemNetSocketsProtocolType(RealStatePtr L, int index, System.Net.Sockets.ProtocolType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != SystemNetSocketsProtocolType_TypeID)
				{
				    throw new Exception("invalid userdata for System.Net.Sockets.ProtocolType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for System.Net.Sockets.ProtocolType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFHeuristicOptimizationMode_TypeID = -1;
		int PFHeuristicOptimizationMode_EnumRef = -1;
        
        public void PushPFHeuristicOptimizationMode(RealStatePtr L, PF.HeuristicOptimizationMode val)
        {
            if (PFHeuristicOptimizationMode_TypeID == -1)
            {
			    bool is_first;
                PFHeuristicOptimizationMode_TypeID = getTypeId(L, typeof(PF.HeuristicOptimizationMode), out is_first);
				
				if (PFHeuristicOptimizationMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.HeuristicOptimizationMode));
				    PFHeuristicOptimizationMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFHeuristicOptimizationMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFHeuristicOptimizationMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.HeuristicOptimizationMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFHeuristicOptimizationMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.HeuristicOptimizationMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFHeuristicOptimizationMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.HeuristicOptimizationMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.HeuristicOptimizationMode");
                }
				val = (PF.HeuristicOptimizationMode)e;
                
            }
            else
            {
                val = (PF.HeuristicOptimizationMode)objectCasters.GetCaster(typeof(PF.HeuristicOptimizationMode))(L, index, null);
            }
        }
		
        public void UpdatePFHeuristicOptimizationMode(RealStatePtr L, int index, PF.HeuristicOptimizationMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFHeuristicOptimizationMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.HeuristicOptimizationMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.HeuristicOptimizationMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFGraphUpdateThreading_TypeID = -1;
		int PFGraphUpdateThreading_EnumRef = -1;
        
        public void PushPFGraphUpdateThreading(RealStatePtr L, PF.GraphUpdateThreading val)
        {
            if (PFGraphUpdateThreading_TypeID == -1)
            {
			    bool is_first;
                PFGraphUpdateThreading_TypeID = getTypeId(L, typeof(PF.GraphUpdateThreading), out is_first);
				
				if (PFGraphUpdateThreading_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.GraphUpdateThreading));
				    PFGraphUpdateThreading_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFGraphUpdateThreading_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFGraphUpdateThreading_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.GraphUpdateThreading ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFGraphUpdateThreading_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.GraphUpdateThreading val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFGraphUpdateThreading_TypeID)
				{
				    throw new Exception("invalid userdata for PF.GraphUpdateThreading");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.GraphUpdateThreading");
                }
				val = (PF.GraphUpdateThreading)e;
                
            }
            else
            {
                val = (PF.GraphUpdateThreading)objectCasters.GetCaster(typeof(PF.GraphUpdateThreading))(L, index, null);
            }
        }
		
        public void UpdatePFGraphUpdateThreading(RealStatePtr L, int index, PF.GraphUpdateThreading val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFGraphUpdateThreading_TypeID)
				{
				    throw new Exception("invalid userdata for PF.GraphUpdateThreading");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.GraphUpdateThreading ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFThreadCount_TypeID = -1;
		int PFThreadCount_EnumRef = -1;
        
        public void PushPFThreadCount(RealStatePtr L, PF.ThreadCount val)
        {
            if (PFThreadCount_TypeID == -1)
            {
			    bool is_first;
                PFThreadCount_TypeID = getTypeId(L, typeof(PF.ThreadCount), out is_first);
				
				if (PFThreadCount_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.ThreadCount));
				    PFThreadCount_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFThreadCount_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFThreadCount_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.ThreadCount ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFThreadCount_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.ThreadCount val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFThreadCount_TypeID)
				{
				    throw new Exception("invalid userdata for PF.ThreadCount");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.ThreadCount");
                }
				val = (PF.ThreadCount)e;
                
            }
            else
            {
                val = (PF.ThreadCount)objectCasters.GetCaster(typeof(PF.ThreadCount))(L, index, null);
            }
        }
		
        public void UpdatePFThreadCount(RealStatePtr L, int index, PF.ThreadCount val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFThreadCount_TypeID)
				{
				    throw new Exception("invalid userdata for PF.ThreadCount");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.ThreadCount ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFPathState_TypeID = -1;
		int PFPathState_EnumRef = -1;
        
        public void PushPFPathState(RealStatePtr L, PF.PathState val)
        {
            if (PFPathState_TypeID == -1)
            {
			    bool is_first;
                PFPathState_TypeID = getTypeId(L, typeof(PF.PathState), out is_first);
				
				if (PFPathState_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.PathState));
				    PFPathState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFPathState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFPathState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.PathState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFPathState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.PathState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFPathState_TypeID)
				{
				    throw new Exception("invalid userdata for PF.PathState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.PathState");
                }
				val = (PF.PathState)e;
                
            }
            else
            {
                val = (PF.PathState)objectCasters.GetCaster(typeof(PF.PathState))(L, index, null);
            }
        }
		
        public void UpdatePFPathState(RealStatePtr L, int index, PF.PathState val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFPathState_TypeID)
				{
				    throw new Exception("invalid userdata for PF.PathState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.PathState ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFPathCompleteState_TypeID = -1;
		int PFPathCompleteState_EnumRef = -1;
        
        public void PushPFPathCompleteState(RealStatePtr L, PF.PathCompleteState val)
        {
            if (PFPathCompleteState_TypeID == -1)
            {
			    bool is_first;
                PFPathCompleteState_TypeID = getTypeId(L, typeof(PF.PathCompleteState), out is_first);
				
				if (PFPathCompleteState_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.PathCompleteState));
				    PFPathCompleteState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFPathCompleteState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFPathCompleteState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.PathCompleteState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFPathCompleteState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.PathCompleteState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFPathCompleteState_TypeID)
				{
				    throw new Exception("invalid userdata for PF.PathCompleteState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.PathCompleteState");
                }
				val = (PF.PathCompleteState)e;
                
            }
            else
            {
                val = (PF.PathCompleteState)objectCasters.GetCaster(typeof(PF.PathCompleteState))(L, index, null);
            }
        }
		
        public void UpdatePFPathCompleteState(RealStatePtr L, int index, PF.PathCompleteState val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFPathCompleteState_TypeID)
				{
				    throw new Exception("invalid userdata for PF.PathCompleteState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.PathCompleteState ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFCloseToDestinationMode_TypeID = -1;
		int PFCloseToDestinationMode_EnumRef = -1;
        
        public void PushPFCloseToDestinationMode(RealStatePtr L, PF.CloseToDestinationMode val)
        {
            if (PFCloseToDestinationMode_TypeID == -1)
            {
			    bool is_first;
                PFCloseToDestinationMode_TypeID = getTypeId(L, typeof(PF.CloseToDestinationMode), out is_first);
				
				if (PFCloseToDestinationMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.CloseToDestinationMode));
				    PFCloseToDestinationMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFCloseToDestinationMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFCloseToDestinationMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.CloseToDestinationMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFCloseToDestinationMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.CloseToDestinationMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFCloseToDestinationMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.CloseToDestinationMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.CloseToDestinationMode");
                }
				val = (PF.CloseToDestinationMode)e;
                
            }
            else
            {
                val = (PF.CloseToDestinationMode)objectCasters.GetCaster(typeof(PF.CloseToDestinationMode))(L, index, null);
            }
        }
		
        public void UpdatePFCloseToDestinationMode(RealStatePtr L, int index, PF.CloseToDestinationMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFCloseToDestinationMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.CloseToDestinationMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.CloseToDestinationMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFSide_TypeID = -1;
		int PFSide_EnumRef = -1;
        
        public void PushPFSide(RealStatePtr L, PF.Side val)
        {
            if (PFSide_TypeID == -1)
            {
			    bool is_first;
                PFSide_TypeID = getTypeId(L, typeof(PF.Side), out is_first);
				
				if (PFSide_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.Side));
				    PFSide_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFSide_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFSide_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.Side ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFSide_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.Side val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFSide_TypeID)
				{
				    throw new Exception("invalid userdata for PF.Side");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.Side");
                }
				val = (PF.Side)e;
                
            }
            else
            {
                val = (PF.Side)objectCasters.GetCaster(typeof(PF.Side))(L, index, null);
            }
        }
		
        public void UpdatePFSide(RealStatePtr L, int index, PF.Side val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFSide_TypeID)
				{
				    throw new Exception("invalid userdata for PF.Side");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.Side ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFInspectorGridMode_TypeID = -1;
		int PFInspectorGridMode_EnumRef = -1;
        
        public void PushPFInspectorGridMode(RealStatePtr L, PF.InspectorGridMode val)
        {
            if (PFInspectorGridMode_TypeID == -1)
            {
			    bool is_first;
                PFInspectorGridMode_TypeID = getTypeId(L, typeof(PF.InspectorGridMode), out is_first);
				
				if (PFInspectorGridMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.InspectorGridMode));
				    PFInspectorGridMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFInspectorGridMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFInspectorGridMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.InspectorGridMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFInspectorGridMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.InspectorGridMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFInspectorGridMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.InspectorGridMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.InspectorGridMode");
                }
				val = (PF.InspectorGridMode)e;
                
            }
            else
            {
                val = (PF.InspectorGridMode)objectCasters.GetCaster(typeof(PF.InspectorGridMode))(L, index, null);
            }
        }
		
        public void UpdatePFInspectorGridMode(RealStatePtr L, int index, PF.InspectorGridMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFInspectorGridMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.InspectorGridMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.InspectorGridMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFGraphDebugMode_TypeID = -1;
		int PFGraphDebugMode_EnumRef = -1;
        
        public void PushPFGraphDebugMode(RealStatePtr L, PF.GraphDebugMode val)
        {
            if (PFGraphDebugMode_TypeID == -1)
            {
			    bool is_first;
                PFGraphDebugMode_TypeID = getTypeId(L, typeof(PF.GraphDebugMode), out is_first);
				
				if (PFGraphDebugMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.GraphDebugMode));
				    PFGraphDebugMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFGraphDebugMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFGraphDebugMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.GraphDebugMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFGraphDebugMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.GraphDebugMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFGraphDebugMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.GraphDebugMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.GraphDebugMode");
                }
				val = (PF.GraphDebugMode)e;
                
            }
            else
            {
                val = (PF.GraphDebugMode)objectCasters.GetCaster(typeof(PF.GraphDebugMode))(L, index, null);
            }
        }
		
        public void UpdatePFGraphDebugMode(RealStatePtr L, int index, PF.GraphDebugMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFGraphDebugMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.GraphDebugMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.GraphDebugMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFPathLog_TypeID = -1;
		int PFPathLog_EnumRef = -1;
        
        public void PushPFPathLog(RealStatePtr L, PF.PathLog val)
        {
            if (PFPathLog_TypeID == -1)
            {
			    bool is_first;
                PFPathLog_TypeID = getTypeId(L, typeof(PF.PathLog), out is_first);
				
				if (PFPathLog_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.PathLog));
				    PFPathLog_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFPathLog_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFPathLog_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.PathLog ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFPathLog_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.PathLog val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFPathLog_TypeID)
				{
				    throw new Exception("invalid userdata for PF.PathLog");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.PathLog");
                }
				val = (PF.PathLog)e;
                
            }
            else
            {
                val = (PF.PathLog)objectCasters.GetCaster(typeof(PF.PathLog))(L, index, null);
            }
        }
		
        public void UpdatePFPathLog(RealStatePtr L, int index, PF.PathLog val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFPathLog_TypeID)
				{
				    throw new Exception("invalid userdata for PF.PathLog");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.PathLog ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFHeuristic_TypeID = -1;
		int PFHeuristic_EnumRef = -1;
        
        public void PushPFHeuristic(RealStatePtr L, PF.Heuristic val)
        {
            if (PFHeuristic_TypeID == -1)
            {
			    bool is_first;
                PFHeuristic_TypeID = getTypeId(L, typeof(PF.Heuristic), out is_first);
				
				if (PFHeuristic_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.Heuristic));
				    PFHeuristic_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFHeuristic_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFHeuristic_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.Heuristic ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFHeuristic_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.Heuristic val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFHeuristic_TypeID)
				{
				    throw new Exception("invalid userdata for PF.Heuristic");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.Heuristic");
                }
				val = (PF.Heuristic)e;
                
            }
            else
            {
                val = (PF.Heuristic)objectCasters.GetCaster(typeof(PF.Heuristic))(L, index, null);
            }
        }
		
        public void UpdatePFHeuristic(RealStatePtr L, int index, PF.Heuristic val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFHeuristic_TypeID)
				{
				    throw new Exception("invalid userdata for PF.Heuristic");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.Heuristic ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingRVOMovementPlane_TypeID = -1;
		int PathfindingRVOMovementPlane_EnumRef = -1;
        
        public void PushPathfindingRVOMovementPlane(RealStatePtr L, Pathfinding.RVO.MovementPlane val)
        {
            if (PathfindingRVOMovementPlane_TypeID == -1)
            {
			    bool is_first;
                PathfindingRVOMovementPlane_TypeID = getTypeId(L, typeof(Pathfinding.RVO.MovementPlane), out is_first);
				
				if (PathfindingRVOMovementPlane_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.RVO.MovementPlane));
				    PathfindingRVOMovementPlane_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingRVOMovementPlane_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingRVOMovementPlane_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.RVO.MovementPlane ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingRVOMovementPlane_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.RVO.MovementPlane val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRVOMovementPlane_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RVO.MovementPlane");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.RVO.MovementPlane");
                }
				val = (Pathfinding.RVO.MovementPlane)e;
                
            }
            else
            {
                val = (Pathfinding.RVO.MovementPlane)objectCasters.GetCaster(typeof(Pathfinding.RVO.MovementPlane))(L, index, null);
            }
        }
		
        public void UpdatePathfindingRVOMovementPlane(RealStatePtr L, int index, Pathfinding.RVO.MovementPlane val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRVOMovementPlane_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RVO.MovementPlane");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.RVO.MovementPlane ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingRVORVOLayer_TypeID = -1;
		int PathfindingRVORVOLayer_EnumRef = -1;
        
        public void PushPathfindingRVORVOLayer(RealStatePtr L, Pathfinding.RVO.RVOLayer val)
        {
            if (PathfindingRVORVOLayer_TypeID == -1)
            {
			    bool is_first;
                PathfindingRVORVOLayer_TypeID = getTypeId(L, typeof(Pathfinding.RVO.RVOLayer), out is_first);
				
				if (PathfindingRVORVOLayer_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.RVO.RVOLayer));
				    PathfindingRVORVOLayer_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingRVORVOLayer_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingRVORVOLayer_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.RVO.RVOLayer ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingRVORVOLayer_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.RVO.RVOLayer val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRVORVOLayer_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RVO.RVOLayer");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.RVO.RVOLayer");
                }
				val = (Pathfinding.RVO.RVOLayer)e;
                
            }
            else
            {
                val = (Pathfinding.RVO.RVOLayer)objectCasters.GetCaster(typeof(Pathfinding.RVO.RVOLayer))(L, index, null);
            }
        }
		
        public void UpdatePathfindingRVORVOLayer(RealStatePtr L, int index, Pathfinding.RVO.RVOLayer val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRVORVOLayer_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RVO.RVOLayer");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.RVO.RVOLayer ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int AstarPathAstarDistribution_TypeID = -1;
		int AstarPathAstarDistribution_EnumRef = -1;
        
        public void PushAstarPathAstarDistribution(RealStatePtr L, AstarPath.AstarDistribution val)
        {
            if (AstarPathAstarDistribution_TypeID == -1)
            {
			    bool is_first;
                AstarPathAstarDistribution_TypeID = getTypeId(L, typeof(AstarPath.AstarDistribution), out is_first);
				
				if (AstarPathAstarDistribution_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(AstarPath.AstarDistribution));
				    AstarPathAstarDistribution_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, AstarPathAstarDistribution_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, AstarPathAstarDistribution_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for AstarPath.AstarDistribution ,value="+val);
            }
			
			LuaAPI.lua_getref(L, AstarPathAstarDistribution_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out AstarPath.AstarDistribution val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AstarPathAstarDistribution_TypeID)
				{
				    throw new Exception("invalid userdata for AstarPath.AstarDistribution");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for AstarPath.AstarDistribution");
                }
				val = (AstarPath.AstarDistribution)e;
                
            }
            else
            {
                val = (AstarPath.AstarDistribution)objectCasters.GetCaster(typeof(AstarPath.AstarDistribution))(L, index, null);
            }
        }
		
        public void UpdateAstarPathAstarDistribution(RealStatePtr L, int index, AstarPath.AstarDistribution val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != AstarPathAstarDistribution_TypeID)
				{
				    throw new Exception("invalid userdata for AstarPath.AstarDistribution");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for AstarPath.AstarDistribution ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFMultiTargetPathHeuristicMode_TypeID = -1;
		int PFMultiTargetPathHeuristicMode_EnumRef = -1;
        
        public void PushPFMultiTargetPathHeuristicMode(RealStatePtr L, PF.MultiTargetPath.HeuristicMode val)
        {
            if (PFMultiTargetPathHeuristicMode_TypeID == -1)
            {
			    bool is_first;
                PFMultiTargetPathHeuristicMode_TypeID = getTypeId(L, typeof(PF.MultiTargetPath.HeuristicMode), out is_first);
				
				if (PFMultiTargetPathHeuristicMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.MultiTargetPath.HeuristicMode));
				    PFMultiTargetPathHeuristicMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFMultiTargetPathHeuristicMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFMultiTargetPathHeuristicMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.MultiTargetPath.HeuristicMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFMultiTargetPathHeuristicMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.MultiTargetPath.HeuristicMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFMultiTargetPathHeuristicMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.MultiTargetPath.HeuristicMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.MultiTargetPath.HeuristicMode");
                }
				val = (PF.MultiTargetPath.HeuristicMode)e;
                
            }
            else
            {
                val = (PF.MultiTargetPath.HeuristicMode)objectCasters.GetCaster(typeof(PF.MultiTargetPath.HeuristicMode))(L, index, null);
            }
        }
		
        public void UpdatePFMultiTargetPathHeuristicMode(RealStatePtr L, int index, PF.MultiTargetPath.HeuristicMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFMultiTargetPathHeuristicMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.MultiTargetPath.HeuristicMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.MultiTargetPath.HeuristicMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PFRecastGraphRelevantGraphSurfaceMode_TypeID = -1;
		int PFRecastGraphRelevantGraphSurfaceMode_EnumRef = -1;
        
        public void PushPFRecastGraphRelevantGraphSurfaceMode(RealStatePtr L, PF.RecastGraph.RelevantGraphSurfaceMode val)
        {
            if (PFRecastGraphRelevantGraphSurfaceMode_TypeID == -1)
            {
			    bool is_first;
                PFRecastGraphRelevantGraphSurfaceMode_TypeID = getTypeId(L, typeof(PF.RecastGraph.RelevantGraphSurfaceMode), out is_first);
				
				if (PFRecastGraphRelevantGraphSurfaceMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(PF.RecastGraph.RelevantGraphSurfaceMode));
				    PFRecastGraphRelevantGraphSurfaceMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PFRecastGraphRelevantGraphSurfaceMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PFRecastGraphRelevantGraphSurfaceMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for PF.RecastGraph.RelevantGraphSurfaceMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PFRecastGraphRelevantGraphSurfaceMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out PF.RecastGraph.RelevantGraphSurfaceMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFRecastGraphRelevantGraphSurfaceMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.RecastGraph.RelevantGraphSurfaceMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for PF.RecastGraph.RelevantGraphSurfaceMode");
                }
				val = (PF.RecastGraph.RelevantGraphSurfaceMode)e;
                
            }
            else
            {
                val = (PF.RecastGraph.RelevantGraphSurfaceMode)objectCasters.GetCaster(typeof(PF.RecastGraph.RelevantGraphSurfaceMode))(L, index, null);
            }
        }
		
        public void UpdatePFRecastGraphRelevantGraphSurfaceMode(RealStatePtr L, int index, PF.RecastGraph.RelevantGraphSurfaceMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PFRecastGraphRelevantGraphSurfaceMode_TypeID)
				{
				    throw new Exception("invalid userdata for PF.RecastGraph.RelevantGraphSurfaceMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for PF.RecastGraph.RelevantGraphSurfaceMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingSeekerModifierPass_TypeID = -1;
		int PathfindingSeekerModifierPass_EnumRef = -1;
        
        public void PushPathfindingSeekerModifierPass(RealStatePtr L, Pathfinding.Seeker.ModifierPass val)
        {
            if (PathfindingSeekerModifierPass_TypeID == -1)
            {
			    bool is_first;
                PathfindingSeekerModifierPass_TypeID = getTypeId(L, typeof(Pathfinding.Seeker.ModifierPass), out is_first);
				
				if (PathfindingSeekerModifierPass_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.Seeker.ModifierPass));
				    PathfindingSeekerModifierPass_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingSeekerModifierPass_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingSeekerModifierPass_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.Seeker.ModifierPass ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingSeekerModifierPass_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.Seeker.ModifierPass val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingSeekerModifierPass_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.Seeker.ModifierPass");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.Seeker.ModifierPass");
                }
				val = (Pathfinding.Seeker.ModifierPass)e;
                
            }
            else
            {
                val = (Pathfinding.Seeker.ModifierPass)objectCasters.GetCaster(typeof(Pathfinding.Seeker.ModifierPass))(L, index, null);
            }
        }
		
        public void UpdatePathfindingSeekerModifierPass(RealStatePtr L, int index, Pathfinding.Seeker.ModifierPass val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingSeekerModifierPass_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.Seeker.ModifierPass");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.Seeker.ModifierPass ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingGraphModifierEventType_TypeID = -1;
		int PathfindingGraphModifierEventType_EnumRef = -1;
        
        public void PushPathfindingGraphModifierEventType(RealStatePtr L, Pathfinding.GraphModifier.EventType val)
        {
            if (PathfindingGraphModifierEventType_TypeID == -1)
            {
			    bool is_first;
                PathfindingGraphModifierEventType_TypeID = getTypeId(L, typeof(Pathfinding.GraphModifier.EventType), out is_first);
				
				if (PathfindingGraphModifierEventType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.GraphModifier.EventType));
				    PathfindingGraphModifierEventType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingGraphModifierEventType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingGraphModifierEventType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.GraphModifier.EventType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingGraphModifierEventType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.GraphModifier.EventType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingGraphModifierEventType_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.GraphModifier.EventType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.GraphModifier.EventType");
                }
				val = (Pathfinding.GraphModifier.EventType)e;
                
            }
            else
            {
                val = (Pathfinding.GraphModifier.EventType)objectCasters.GetCaster(typeof(Pathfinding.GraphModifier.EventType))(L, index, null);
            }
        }
		
        public void UpdatePathfindingGraphModifierEventType(RealStatePtr L, int index, Pathfinding.GraphModifier.EventType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingGraphModifierEventType_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.GraphModifier.EventType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.GraphModifier.EventType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingRaycastModifierQuality_TypeID = -1;
		int PathfindingRaycastModifierQuality_EnumRef = -1;
        
        public void PushPathfindingRaycastModifierQuality(RealStatePtr L, Pathfinding.RaycastModifier.Quality val)
        {
            if (PathfindingRaycastModifierQuality_TypeID == -1)
            {
			    bool is_first;
                PathfindingRaycastModifierQuality_TypeID = getTypeId(L, typeof(Pathfinding.RaycastModifier.Quality), out is_first);
				
				if (PathfindingRaycastModifierQuality_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.RaycastModifier.Quality));
				    PathfindingRaycastModifierQuality_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingRaycastModifierQuality_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingRaycastModifierQuality_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.RaycastModifier.Quality ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingRaycastModifierQuality_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.RaycastModifier.Quality val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRaycastModifierQuality_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RaycastModifier.Quality");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.RaycastModifier.Quality");
                }
				val = (Pathfinding.RaycastModifier.Quality)e;
                
            }
            else
            {
                val = (Pathfinding.RaycastModifier.Quality)objectCasters.GetCaster(typeof(Pathfinding.RaycastModifier.Quality))(L, index, null);
            }
        }
		
        public void UpdatePathfindingRaycastModifierQuality(RealStatePtr L, int index, Pathfinding.RaycastModifier.Quality val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRaycastModifierQuality_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RaycastModifier.Quality");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.RaycastModifier.Quality ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingSimpleSmoothModifierSmoothType_TypeID = -1;
		int PathfindingSimpleSmoothModifierSmoothType_EnumRef = -1;
        
        public void PushPathfindingSimpleSmoothModifierSmoothType(RealStatePtr L, Pathfinding.SimpleSmoothModifier.SmoothType val)
        {
            if (PathfindingSimpleSmoothModifierSmoothType_TypeID == -1)
            {
			    bool is_first;
                PathfindingSimpleSmoothModifierSmoothType_TypeID = getTypeId(L, typeof(Pathfinding.SimpleSmoothModifier.SmoothType), out is_first);
				
				if (PathfindingSimpleSmoothModifierSmoothType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.SimpleSmoothModifier.SmoothType));
				    PathfindingSimpleSmoothModifierSmoothType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingSimpleSmoothModifierSmoothType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingSimpleSmoothModifierSmoothType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.SimpleSmoothModifier.SmoothType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingSimpleSmoothModifierSmoothType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.SimpleSmoothModifier.SmoothType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingSimpleSmoothModifierSmoothType_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.SimpleSmoothModifier.SmoothType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.SimpleSmoothModifier.SmoothType");
                }
				val = (Pathfinding.SimpleSmoothModifier.SmoothType)e;
                
            }
            else
            {
                val = (Pathfinding.SimpleSmoothModifier.SmoothType)objectCasters.GetCaster(typeof(Pathfinding.SimpleSmoothModifier.SmoothType))(L, index, null);
            }
        }
		
        public void UpdatePathfindingSimpleSmoothModifierSmoothType(RealStatePtr L, int index, Pathfinding.SimpleSmoothModifier.SmoothType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingSimpleSmoothModifierSmoothType_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.SimpleSmoothModifier.SmoothType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.SimpleSmoothModifier.SmoothType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingStartEndModifierExactness_TypeID = -1;
		int PathfindingStartEndModifierExactness_EnumRef = -1;
        
        public void PushPathfindingStartEndModifierExactness(RealStatePtr L, Pathfinding.StartEndModifier.Exactness val)
        {
            if (PathfindingStartEndModifierExactness_TypeID == -1)
            {
			    bool is_first;
                PathfindingStartEndModifierExactness_TypeID = getTypeId(L, typeof(Pathfinding.StartEndModifier.Exactness), out is_first);
				
				if (PathfindingStartEndModifierExactness_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.StartEndModifier.Exactness));
				    PathfindingStartEndModifierExactness_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingStartEndModifierExactness_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingStartEndModifierExactness_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.StartEndModifier.Exactness ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingStartEndModifierExactness_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.StartEndModifier.Exactness val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingStartEndModifierExactness_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.StartEndModifier.Exactness");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.StartEndModifier.Exactness");
                }
				val = (Pathfinding.StartEndModifier.Exactness)e;
                
            }
            else
            {
                val = (Pathfinding.StartEndModifier.Exactness)objectCasters.GetCaster(typeof(Pathfinding.StartEndModifier.Exactness))(L, index, null);
            }
        }
		
        public void UpdatePathfindingStartEndModifierExactness(RealStatePtr L, int index, Pathfinding.StartEndModifier.Exactness val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingStartEndModifierExactness_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.StartEndModifier.Exactness");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.StartEndModifier.Exactness ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingBlockManagerBlockMode_TypeID = -1;
		int PathfindingBlockManagerBlockMode_EnumRef = -1;
        
        public void PushPathfindingBlockManagerBlockMode(RealStatePtr L, Pathfinding.BlockManager.BlockMode val)
        {
            if (PathfindingBlockManagerBlockMode_TypeID == -1)
            {
			    bool is_first;
                PathfindingBlockManagerBlockMode_TypeID = getTypeId(L, typeof(Pathfinding.BlockManager.BlockMode), out is_first);
				
				if (PathfindingBlockManagerBlockMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.BlockManager.BlockMode));
				    PathfindingBlockManagerBlockMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingBlockManagerBlockMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingBlockManagerBlockMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.BlockManager.BlockMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingBlockManagerBlockMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.BlockManager.BlockMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingBlockManagerBlockMode_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.BlockManager.BlockMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.BlockManager.BlockMode");
                }
				val = (Pathfinding.BlockManager.BlockMode)e;
                
            }
            else
            {
                val = (Pathfinding.BlockManager.BlockMode)objectCasters.GetCaster(typeof(Pathfinding.BlockManager.BlockMode))(L, index, null);
            }
        }
		
        public void UpdatePathfindingBlockManagerBlockMode(RealStatePtr L, int index, Pathfinding.BlockManager.BlockMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingBlockManagerBlockMode_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.BlockManager.BlockMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.BlockManager.BlockMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int PathfindingRVORVOObstacleObstacleVertexWinding_TypeID = -1;
		int PathfindingRVORVOObstacleObstacleVertexWinding_EnumRef = -1;
        
        public void PushPathfindingRVORVOObstacleObstacleVertexWinding(RealStatePtr L, Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding val)
        {
            if (PathfindingRVORVOObstacleObstacleVertexWinding_TypeID == -1)
            {
			    bool is_first;
                PathfindingRVORVOObstacleObstacleVertexWinding_TypeID = getTypeId(L, typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding), out is_first);
				
				if (PathfindingRVORVOObstacleObstacleVertexWinding_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding));
				    PathfindingRVORVOObstacleObstacleVertexWinding_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, PathfindingRVORVOObstacleObstacleVertexWinding_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, PathfindingRVORVOObstacleObstacleVertexWinding_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding ,value="+val);
            }
			
			LuaAPI.lua_getref(L, PathfindingRVORVOObstacleObstacleVertexWinding_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRVORVOObstacleObstacleVertexWinding_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding");
                }
				val = (Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding)e;
                
            }
            else
            {
                val = (Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding)objectCasters.GetCaster(typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding))(L, index, null);
            }
        }
		
        public void UpdatePathfindingRVORVOObstacleObstacleVertexWinding(RealStatePtr L, int index, Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != PathfindingRVORVOObstacleObstacleVertexWinding_TypeID)
				{
				    throw new Exception("invalid userdata for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIBlendMode_TypeID = -1;
		int FairyGUIBlendMode_EnumRef = -1;
        
        public void PushFairyGUIBlendMode(RealStatePtr L, FairyGUI.BlendMode val)
        {
            if (FairyGUIBlendMode_TypeID == -1)
            {
			    bool is_first;
                FairyGUIBlendMode_TypeID = getTypeId(L, typeof(FairyGUI.BlendMode), out is_first);
				
				if (FairyGUIBlendMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.BlendMode));
				    FairyGUIBlendMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIBlendMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIBlendMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.BlendMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIBlendMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.BlendMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIBlendMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.BlendMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.BlendMode");
                }
				val = (FairyGUI.BlendMode)e;
                
            }
            else
            {
                val = (FairyGUI.BlendMode)objectCasters.GetCaster(typeof(FairyGUI.BlendMode))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIBlendMode(RealStatePtr L, int index, FairyGUI.BlendMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIBlendMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.BlendMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.BlendMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIHitTestMode_TypeID = -1;
		int FairyGUIHitTestMode_EnumRef = -1;
        
        public void PushFairyGUIHitTestMode(RealStatePtr L, FairyGUI.HitTestMode val)
        {
            if (FairyGUIHitTestMode_TypeID == -1)
            {
			    bool is_first;
                FairyGUIHitTestMode_TypeID = getTypeId(L, typeof(FairyGUI.HitTestMode), out is_first);
				
				if (FairyGUIHitTestMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.HitTestMode));
				    FairyGUIHitTestMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIHitTestMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIHitTestMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.HitTestMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIHitTestMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.HitTestMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIHitTestMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.HitTestMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.HitTestMode");
                }
				val = (FairyGUI.HitTestMode)e;
                
            }
            else
            {
                val = (FairyGUI.HitTestMode)objectCasters.GetCaster(typeof(FairyGUI.HitTestMode))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIHitTestMode(RealStatePtr L, int index, FairyGUI.HitTestMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIHitTestMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.HitTestMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.HitTestMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIDestroyMethod_TypeID = -1;
		int FairyGUIDestroyMethod_EnumRef = -1;
        
        public void PushFairyGUIDestroyMethod(RealStatePtr L, FairyGUI.DestroyMethod val)
        {
            if (FairyGUIDestroyMethod_TypeID == -1)
            {
			    bool is_first;
                FairyGUIDestroyMethod_TypeID = getTypeId(L, typeof(FairyGUI.DestroyMethod), out is_first);
				
				if (FairyGUIDestroyMethod_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.DestroyMethod));
				    FairyGUIDestroyMethod_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIDestroyMethod_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIDestroyMethod_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.DestroyMethod ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIDestroyMethod_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.DestroyMethod val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIDestroyMethod_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.DestroyMethod");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.DestroyMethod");
                }
				val = (FairyGUI.DestroyMethod)e;
                
            }
            else
            {
                val = (FairyGUI.DestroyMethod)objectCasters.GetCaster(typeof(FairyGUI.DestroyMethod))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIDestroyMethod(RealStatePtr L, int index, FairyGUI.DestroyMethod val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIDestroyMethod_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.DestroyMethod");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.DestroyMethod ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIEaseType_TypeID = -1;
		int FairyGUIEaseType_EnumRef = -1;
        
        public void PushFairyGUIEaseType(RealStatePtr L, FairyGUI.EaseType val)
        {
            if (FairyGUIEaseType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIEaseType_TypeID = getTypeId(L, typeof(FairyGUI.EaseType), out is_first);
				
				if (FairyGUIEaseType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.EaseType));
				    FairyGUIEaseType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIEaseType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIEaseType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.EaseType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIEaseType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.EaseType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIEaseType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.EaseType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.EaseType");
                }
				val = (FairyGUI.EaseType)e;
                
            }
            else
            {
                val = (FairyGUI.EaseType)objectCasters.GetCaster(typeof(FairyGUI.EaseType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIEaseType(RealStatePtr L, int index, FairyGUI.EaseType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIEaseType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.EaseType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.EaseType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUITweenPropType_TypeID = -1;
		int FairyGUITweenPropType_EnumRef = -1;
        
        public void PushFairyGUITweenPropType(RealStatePtr L, FairyGUI.TweenPropType val)
        {
            if (FairyGUITweenPropType_TypeID == -1)
            {
			    bool is_first;
                FairyGUITweenPropType_TypeID = getTypeId(L, typeof(FairyGUI.TweenPropType), out is_first);
				
				if (FairyGUITweenPropType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.TweenPropType));
				    FairyGUITweenPropType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUITweenPropType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUITweenPropType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.TweenPropType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUITweenPropType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.TweenPropType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUITweenPropType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.TweenPropType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.TweenPropType");
                }
				val = (FairyGUI.TweenPropType)e;
                
            }
            else
            {
                val = (FairyGUI.TweenPropType)objectCasters.GetCaster(typeof(FairyGUI.TweenPropType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUITweenPropType(RealStatePtr L, int index, FairyGUI.TweenPropType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUITweenPropType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.TweenPropType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.TweenPropType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIPackageItemType_TypeID = -1;
		int FairyGUIPackageItemType_EnumRef = -1;
        
        public void PushFairyGUIPackageItemType(RealStatePtr L, FairyGUI.PackageItemType val)
        {
            if (FairyGUIPackageItemType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIPackageItemType_TypeID = getTypeId(L, typeof(FairyGUI.PackageItemType), out is_first);
				
				if (FairyGUIPackageItemType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.PackageItemType));
				    FairyGUIPackageItemType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIPackageItemType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIPackageItemType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.PackageItemType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIPackageItemType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.PackageItemType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIPackageItemType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.PackageItemType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.PackageItemType");
                }
				val = (FairyGUI.PackageItemType)e;
                
            }
            else
            {
                val = (FairyGUI.PackageItemType)objectCasters.GetCaster(typeof(FairyGUI.PackageItemType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIPackageItemType(RealStatePtr L, int index, FairyGUI.PackageItemType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIPackageItemType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.PackageItemType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.PackageItemType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIObjectType_TypeID = -1;
		int FairyGUIObjectType_EnumRef = -1;
        
        public void PushFairyGUIObjectType(RealStatePtr L, FairyGUI.ObjectType val)
        {
            if (FairyGUIObjectType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIObjectType_TypeID = getTypeId(L, typeof(FairyGUI.ObjectType), out is_first);
				
				if (FairyGUIObjectType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ObjectType));
				    FairyGUIObjectType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIObjectType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIObjectType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ObjectType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIObjectType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ObjectType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIObjectType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ObjectType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ObjectType");
                }
				val = (FairyGUI.ObjectType)e;
                
            }
            else
            {
                val = (FairyGUI.ObjectType)objectCasters.GetCaster(typeof(FairyGUI.ObjectType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIObjectType(RealStatePtr L, int index, FairyGUI.ObjectType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIObjectType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ObjectType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ObjectType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIAlignType_TypeID = -1;
		int FairyGUIAlignType_EnumRef = -1;
        
        public void PushFairyGUIAlignType(RealStatePtr L, FairyGUI.AlignType val)
        {
            if (FairyGUIAlignType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIAlignType_TypeID = getTypeId(L, typeof(FairyGUI.AlignType), out is_first);
				
				if (FairyGUIAlignType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.AlignType));
				    FairyGUIAlignType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIAlignType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIAlignType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.AlignType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIAlignType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.AlignType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIAlignType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.AlignType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.AlignType");
                }
				val = (FairyGUI.AlignType)e;
                
            }
            else
            {
                val = (FairyGUI.AlignType)objectCasters.GetCaster(typeof(FairyGUI.AlignType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIAlignType(RealStatePtr L, int index, FairyGUI.AlignType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIAlignType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.AlignType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.AlignType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIVertAlignType_TypeID = -1;
		int FairyGUIVertAlignType_EnumRef = -1;
        
        public void PushFairyGUIVertAlignType(RealStatePtr L, FairyGUI.VertAlignType val)
        {
            if (FairyGUIVertAlignType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIVertAlignType_TypeID = getTypeId(L, typeof(FairyGUI.VertAlignType), out is_first);
				
				if (FairyGUIVertAlignType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.VertAlignType));
				    FairyGUIVertAlignType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIVertAlignType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIVertAlignType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.VertAlignType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIVertAlignType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.VertAlignType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIVertAlignType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.VertAlignType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.VertAlignType");
                }
				val = (FairyGUI.VertAlignType)e;
                
            }
            else
            {
                val = (FairyGUI.VertAlignType)objectCasters.GetCaster(typeof(FairyGUI.VertAlignType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIVertAlignType(RealStatePtr L, int index, FairyGUI.VertAlignType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIVertAlignType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.VertAlignType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.VertAlignType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIOverflowType_TypeID = -1;
		int FairyGUIOverflowType_EnumRef = -1;
        
        public void PushFairyGUIOverflowType(RealStatePtr L, FairyGUI.OverflowType val)
        {
            if (FairyGUIOverflowType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIOverflowType_TypeID = getTypeId(L, typeof(FairyGUI.OverflowType), out is_first);
				
				if (FairyGUIOverflowType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.OverflowType));
				    FairyGUIOverflowType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIOverflowType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIOverflowType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.OverflowType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIOverflowType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.OverflowType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOverflowType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.OverflowType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.OverflowType");
                }
				val = (FairyGUI.OverflowType)e;
                
            }
            else
            {
                val = (FairyGUI.OverflowType)objectCasters.GetCaster(typeof(FairyGUI.OverflowType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIOverflowType(RealStatePtr L, int index, FairyGUI.OverflowType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOverflowType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.OverflowType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.OverflowType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIFillType_TypeID = -1;
		int FairyGUIFillType_EnumRef = -1;
        
        public void PushFairyGUIFillType(RealStatePtr L, FairyGUI.FillType val)
        {
            if (FairyGUIFillType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIFillType_TypeID = getTypeId(L, typeof(FairyGUI.FillType), out is_first);
				
				if (FairyGUIFillType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.FillType));
				    FairyGUIFillType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIFillType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIFillType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.FillType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIFillType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.FillType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFillType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FillType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.FillType");
                }
				val = (FairyGUI.FillType)e;
                
            }
            else
            {
                val = (FairyGUI.FillType)objectCasters.GetCaster(typeof(FairyGUI.FillType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIFillType(RealStatePtr L, int index, FairyGUI.FillType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFillType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FillType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.FillType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIAutoSizeType_TypeID = -1;
		int FairyGUIAutoSizeType_EnumRef = -1;
        
        public void PushFairyGUIAutoSizeType(RealStatePtr L, FairyGUI.AutoSizeType val)
        {
            if (FairyGUIAutoSizeType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIAutoSizeType_TypeID = getTypeId(L, typeof(FairyGUI.AutoSizeType), out is_first);
				
				if (FairyGUIAutoSizeType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.AutoSizeType));
				    FairyGUIAutoSizeType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIAutoSizeType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIAutoSizeType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.AutoSizeType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIAutoSizeType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.AutoSizeType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIAutoSizeType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.AutoSizeType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.AutoSizeType");
                }
				val = (FairyGUI.AutoSizeType)e;
                
            }
            else
            {
                val = (FairyGUI.AutoSizeType)objectCasters.GetCaster(typeof(FairyGUI.AutoSizeType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIAutoSizeType(RealStatePtr L, int index, FairyGUI.AutoSizeType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIAutoSizeType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.AutoSizeType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.AutoSizeType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIScrollType_TypeID = -1;
		int FairyGUIScrollType_EnumRef = -1;
        
        public void PushFairyGUIScrollType(RealStatePtr L, FairyGUI.ScrollType val)
        {
            if (FairyGUIScrollType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIScrollType_TypeID = getTypeId(L, typeof(FairyGUI.ScrollType), out is_first);
				
				if (FairyGUIScrollType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ScrollType));
				    FairyGUIScrollType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIScrollType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIScrollType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ScrollType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIScrollType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ScrollType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIScrollType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ScrollType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ScrollType");
                }
				val = (FairyGUI.ScrollType)e;
                
            }
            else
            {
                val = (FairyGUI.ScrollType)objectCasters.GetCaster(typeof(FairyGUI.ScrollType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIScrollType(RealStatePtr L, int index, FairyGUI.ScrollType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIScrollType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ScrollType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ScrollType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIScrollBarDisplayType_TypeID = -1;
		int FairyGUIScrollBarDisplayType_EnumRef = -1;
        
        public void PushFairyGUIScrollBarDisplayType(RealStatePtr L, FairyGUI.ScrollBarDisplayType val)
        {
            if (FairyGUIScrollBarDisplayType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIScrollBarDisplayType_TypeID = getTypeId(L, typeof(FairyGUI.ScrollBarDisplayType), out is_first);
				
				if (FairyGUIScrollBarDisplayType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ScrollBarDisplayType));
				    FairyGUIScrollBarDisplayType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIScrollBarDisplayType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIScrollBarDisplayType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ScrollBarDisplayType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIScrollBarDisplayType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ScrollBarDisplayType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIScrollBarDisplayType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ScrollBarDisplayType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ScrollBarDisplayType");
                }
				val = (FairyGUI.ScrollBarDisplayType)e;
                
            }
            else
            {
                val = (FairyGUI.ScrollBarDisplayType)objectCasters.GetCaster(typeof(FairyGUI.ScrollBarDisplayType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIScrollBarDisplayType(RealStatePtr L, int index, FairyGUI.ScrollBarDisplayType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIScrollBarDisplayType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ScrollBarDisplayType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ScrollBarDisplayType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIRelationType_TypeID = -1;
		int FairyGUIRelationType_EnumRef = -1;
        
        public void PushFairyGUIRelationType(RealStatePtr L, FairyGUI.RelationType val)
        {
            if (FairyGUIRelationType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIRelationType_TypeID = getTypeId(L, typeof(FairyGUI.RelationType), out is_first);
				
				if (FairyGUIRelationType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.RelationType));
				    FairyGUIRelationType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIRelationType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIRelationType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.RelationType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIRelationType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.RelationType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIRelationType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.RelationType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.RelationType");
                }
				val = (FairyGUI.RelationType)e;
                
            }
            else
            {
                val = (FairyGUI.RelationType)objectCasters.GetCaster(typeof(FairyGUI.RelationType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIRelationType(RealStatePtr L, int index, FairyGUI.RelationType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIRelationType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.RelationType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.RelationType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIListLayoutType_TypeID = -1;
		int FairyGUIListLayoutType_EnumRef = -1;
        
        public void PushFairyGUIListLayoutType(RealStatePtr L, FairyGUI.ListLayoutType val)
        {
            if (FairyGUIListLayoutType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIListLayoutType_TypeID = getTypeId(L, typeof(FairyGUI.ListLayoutType), out is_first);
				
				if (FairyGUIListLayoutType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ListLayoutType));
				    FairyGUIListLayoutType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIListLayoutType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIListLayoutType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ListLayoutType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIListLayoutType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ListLayoutType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIListLayoutType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ListLayoutType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ListLayoutType");
                }
				val = (FairyGUI.ListLayoutType)e;
                
            }
            else
            {
                val = (FairyGUI.ListLayoutType)objectCasters.GetCaster(typeof(FairyGUI.ListLayoutType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIListLayoutType(RealStatePtr L, int index, FairyGUI.ListLayoutType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIListLayoutType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ListLayoutType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ListLayoutType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIListSelectionMode_TypeID = -1;
		int FairyGUIListSelectionMode_EnumRef = -1;
        
        public void PushFairyGUIListSelectionMode(RealStatePtr L, FairyGUI.ListSelectionMode val)
        {
            if (FairyGUIListSelectionMode_TypeID == -1)
            {
			    bool is_first;
                FairyGUIListSelectionMode_TypeID = getTypeId(L, typeof(FairyGUI.ListSelectionMode), out is_first);
				
				if (FairyGUIListSelectionMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ListSelectionMode));
				    FairyGUIListSelectionMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIListSelectionMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIListSelectionMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ListSelectionMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIListSelectionMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ListSelectionMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIListSelectionMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ListSelectionMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ListSelectionMode");
                }
				val = (FairyGUI.ListSelectionMode)e;
                
            }
            else
            {
                val = (FairyGUI.ListSelectionMode)objectCasters.GetCaster(typeof(FairyGUI.ListSelectionMode))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIListSelectionMode(RealStatePtr L, int index, FairyGUI.ListSelectionMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIListSelectionMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ListSelectionMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ListSelectionMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIProgressTitleType_TypeID = -1;
		int FairyGUIProgressTitleType_EnumRef = -1;
        
        public void PushFairyGUIProgressTitleType(RealStatePtr L, FairyGUI.ProgressTitleType val)
        {
            if (FairyGUIProgressTitleType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIProgressTitleType_TypeID = getTypeId(L, typeof(FairyGUI.ProgressTitleType), out is_first);
				
				if (FairyGUIProgressTitleType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ProgressTitleType));
				    FairyGUIProgressTitleType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIProgressTitleType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIProgressTitleType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ProgressTitleType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIProgressTitleType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ProgressTitleType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIProgressTitleType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ProgressTitleType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ProgressTitleType");
                }
				val = (FairyGUI.ProgressTitleType)e;
                
            }
            else
            {
                val = (FairyGUI.ProgressTitleType)objectCasters.GetCaster(typeof(FairyGUI.ProgressTitleType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIProgressTitleType(RealStatePtr L, int index, FairyGUI.ProgressTitleType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIProgressTitleType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ProgressTitleType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ProgressTitleType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIButtonMode_TypeID = -1;
		int FairyGUIButtonMode_EnumRef = -1;
        
        public void PushFairyGUIButtonMode(RealStatePtr L, FairyGUI.ButtonMode val)
        {
            if (FairyGUIButtonMode_TypeID == -1)
            {
			    bool is_first;
                FairyGUIButtonMode_TypeID = getTypeId(L, typeof(FairyGUI.ButtonMode), out is_first);
				
				if (FairyGUIButtonMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ButtonMode));
				    FairyGUIButtonMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIButtonMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIButtonMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ButtonMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIButtonMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ButtonMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIButtonMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ButtonMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ButtonMode");
                }
				val = (FairyGUI.ButtonMode)e;
                
            }
            else
            {
                val = (FairyGUI.ButtonMode)objectCasters.GetCaster(typeof(FairyGUI.ButtonMode))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIButtonMode(RealStatePtr L, int index, FairyGUI.ButtonMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIButtonMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ButtonMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ButtonMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUITransitionActionType_TypeID = -1;
		int FairyGUITransitionActionType_EnumRef = -1;
        
        public void PushFairyGUITransitionActionType(RealStatePtr L, FairyGUI.TransitionActionType val)
        {
            if (FairyGUITransitionActionType_TypeID == -1)
            {
			    bool is_first;
                FairyGUITransitionActionType_TypeID = getTypeId(L, typeof(FairyGUI.TransitionActionType), out is_first);
				
				if (FairyGUITransitionActionType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.TransitionActionType));
				    FairyGUITransitionActionType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUITransitionActionType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUITransitionActionType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.TransitionActionType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUITransitionActionType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.TransitionActionType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUITransitionActionType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.TransitionActionType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.TransitionActionType");
                }
				val = (FairyGUI.TransitionActionType)e;
                
            }
            else
            {
                val = (FairyGUI.TransitionActionType)objectCasters.GetCaster(typeof(FairyGUI.TransitionActionType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUITransitionActionType(RealStatePtr L, int index, FairyGUI.TransitionActionType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUITransitionActionType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.TransitionActionType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.TransitionActionType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIGroupLayoutType_TypeID = -1;
		int FairyGUIGroupLayoutType_EnumRef = -1;
        
        public void PushFairyGUIGroupLayoutType(RealStatePtr L, FairyGUI.GroupLayoutType val)
        {
            if (FairyGUIGroupLayoutType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIGroupLayoutType_TypeID = getTypeId(L, typeof(FairyGUI.GroupLayoutType), out is_first);
				
				if (FairyGUIGroupLayoutType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.GroupLayoutType));
				    FairyGUIGroupLayoutType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIGroupLayoutType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIGroupLayoutType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.GroupLayoutType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIGroupLayoutType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.GroupLayoutType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIGroupLayoutType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.GroupLayoutType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.GroupLayoutType");
                }
				val = (FairyGUI.GroupLayoutType)e;
                
            }
            else
            {
                val = (FairyGUI.GroupLayoutType)objectCasters.GetCaster(typeof(FairyGUI.GroupLayoutType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIGroupLayoutType(RealStatePtr L, int index, FairyGUI.GroupLayoutType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIGroupLayoutType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.GroupLayoutType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.GroupLayoutType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIChildrenRenderOrder_TypeID = -1;
		int FairyGUIChildrenRenderOrder_EnumRef = -1;
        
        public void PushFairyGUIChildrenRenderOrder(RealStatePtr L, FairyGUI.ChildrenRenderOrder val)
        {
            if (FairyGUIChildrenRenderOrder_TypeID == -1)
            {
			    bool is_first;
                FairyGUIChildrenRenderOrder_TypeID = getTypeId(L, typeof(FairyGUI.ChildrenRenderOrder), out is_first);
				
				if (FairyGUIChildrenRenderOrder_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ChildrenRenderOrder));
				    FairyGUIChildrenRenderOrder_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIChildrenRenderOrder_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIChildrenRenderOrder_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ChildrenRenderOrder ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIChildrenRenderOrder_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ChildrenRenderOrder val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIChildrenRenderOrder_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ChildrenRenderOrder");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ChildrenRenderOrder");
                }
				val = (FairyGUI.ChildrenRenderOrder)e;
                
            }
            else
            {
                val = (FairyGUI.ChildrenRenderOrder)objectCasters.GetCaster(typeof(FairyGUI.ChildrenRenderOrder))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIChildrenRenderOrder(RealStatePtr L, int index, FairyGUI.ChildrenRenderOrder val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIChildrenRenderOrder_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ChildrenRenderOrder");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ChildrenRenderOrder ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIPopupDirection_TypeID = -1;
		int FairyGUIPopupDirection_EnumRef = -1;
        
        public void PushFairyGUIPopupDirection(RealStatePtr L, FairyGUI.PopupDirection val)
        {
            if (FairyGUIPopupDirection_TypeID == -1)
            {
			    bool is_first;
                FairyGUIPopupDirection_TypeID = getTypeId(L, typeof(FairyGUI.PopupDirection), out is_first);
				
				if (FairyGUIPopupDirection_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.PopupDirection));
				    FairyGUIPopupDirection_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIPopupDirection_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIPopupDirection_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.PopupDirection ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIPopupDirection_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.PopupDirection val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIPopupDirection_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.PopupDirection");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.PopupDirection");
                }
				val = (FairyGUI.PopupDirection)e;
                
            }
            else
            {
                val = (FairyGUI.PopupDirection)objectCasters.GetCaster(typeof(FairyGUI.PopupDirection))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIPopupDirection(RealStatePtr L, int index, FairyGUI.PopupDirection val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIPopupDirection_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.PopupDirection");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.PopupDirection ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIFlipType_TypeID = -1;
		int FairyGUIFlipType_EnumRef = -1;
        
        public void PushFairyGUIFlipType(RealStatePtr L, FairyGUI.FlipType val)
        {
            if (FairyGUIFlipType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIFlipType_TypeID = getTypeId(L, typeof(FairyGUI.FlipType), out is_first);
				
				if (FairyGUIFlipType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.FlipType));
				    FairyGUIFlipType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIFlipType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIFlipType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.FlipType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIFlipType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.FlipType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFlipType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FlipType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.FlipType");
                }
				val = (FairyGUI.FlipType)e;
                
            }
            else
            {
                val = (FairyGUI.FlipType)objectCasters.GetCaster(typeof(FairyGUI.FlipType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIFlipType(RealStatePtr L, int index, FairyGUI.FlipType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFlipType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FlipType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.FlipType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIFillMethod_TypeID = -1;
		int FairyGUIFillMethod_EnumRef = -1;
        
        public void PushFairyGUIFillMethod(RealStatePtr L, FairyGUI.FillMethod val)
        {
            if (FairyGUIFillMethod_TypeID == -1)
            {
			    bool is_first;
                FairyGUIFillMethod_TypeID = getTypeId(L, typeof(FairyGUI.FillMethod), out is_first);
				
				if (FairyGUIFillMethod_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.FillMethod));
				    FairyGUIFillMethod_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIFillMethod_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIFillMethod_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.FillMethod ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIFillMethod_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.FillMethod val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFillMethod_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FillMethod");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.FillMethod");
                }
				val = (FairyGUI.FillMethod)e;
                
            }
            else
            {
                val = (FairyGUI.FillMethod)objectCasters.GetCaster(typeof(FairyGUI.FillMethod))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIFillMethod(RealStatePtr L, int index, FairyGUI.FillMethod val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFillMethod_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FillMethod");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.FillMethod ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIOriginHorizontal_TypeID = -1;
		int FairyGUIOriginHorizontal_EnumRef = -1;
        
        public void PushFairyGUIOriginHorizontal(RealStatePtr L, FairyGUI.OriginHorizontal val)
        {
            if (FairyGUIOriginHorizontal_TypeID == -1)
            {
			    bool is_first;
                FairyGUIOriginHorizontal_TypeID = getTypeId(L, typeof(FairyGUI.OriginHorizontal), out is_first);
				
				if (FairyGUIOriginHorizontal_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.OriginHorizontal));
				    FairyGUIOriginHorizontal_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIOriginHorizontal_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIOriginHorizontal_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.OriginHorizontal ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIOriginHorizontal_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.OriginHorizontal val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOriginHorizontal_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.OriginHorizontal");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.OriginHorizontal");
                }
				val = (FairyGUI.OriginHorizontal)e;
                
            }
            else
            {
                val = (FairyGUI.OriginHorizontal)objectCasters.GetCaster(typeof(FairyGUI.OriginHorizontal))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIOriginHorizontal(RealStatePtr L, int index, FairyGUI.OriginHorizontal val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOriginHorizontal_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.OriginHorizontal");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.OriginHorizontal ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIOriginVertical_TypeID = -1;
		int FairyGUIOriginVertical_EnumRef = -1;
        
        public void PushFairyGUIOriginVertical(RealStatePtr L, FairyGUI.OriginVertical val)
        {
            if (FairyGUIOriginVertical_TypeID == -1)
            {
			    bool is_first;
                FairyGUIOriginVertical_TypeID = getTypeId(L, typeof(FairyGUI.OriginVertical), out is_first);
				
				if (FairyGUIOriginVertical_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.OriginVertical));
				    FairyGUIOriginVertical_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIOriginVertical_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIOriginVertical_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.OriginVertical ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIOriginVertical_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.OriginVertical val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOriginVertical_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.OriginVertical");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.OriginVertical");
                }
				val = (FairyGUI.OriginVertical)e;
                
            }
            else
            {
                val = (FairyGUI.OriginVertical)objectCasters.GetCaster(typeof(FairyGUI.OriginVertical))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIOriginVertical(RealStatePtr L, int index, FairyGUI.OriginVertical val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOriginVertical_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.OriginVertical");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.OriginVertical ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIOrigin90_TypeID = -1;
		int FairyGUIOrigin90_EnumRef = -1;
        
        public void PushFairyGUIOrigin90(RealStatePtr L, FairyGUI.Origin90 val)
        {
            if (FairyGUIOrigin90_TypeID == -1)
            {
			    bool is_first;
                FairyGUIOrigin90_TypeID = getTypeId(L, typeof(FairyGUI.Origin90), out is_first);
				
				if (FairyGUIOrigin90_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.Origin90));
				    FairyGUIOrigin90_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIOrigin90_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIOrigin90_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.Origin90 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIOrigin90_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.Origin90 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOrigin90_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Origin90");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.Origin90");
                }
				val = (FairyGUI.Origin90)e;
                
            }
            else
            {
                val = (FairyGUI.Origin90)objectCasters.GetCaster(typeof(FairyGUI.Origin90))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIOrigin90(RealStatePtr L, int index, FairyGUI.Origin90 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOrigin90_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Origin90");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.Origin90 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIOrigin180_TypeID = -1;
		int FairyGUIOrigin180_EnumRef = -1;
        
        public void PushFairyGUIOrigin180(RealStatePtr L, FairyGUI.Origin180 val)
        {
            if (FairyGUIOrigin180_TypeID == -1)
            {
			    bool is_first;
                FairyGUIOrigin180_TypeID = getTypeId(L, typeof(FairyGUI.Origin180), out is_first);
				
				if (FairyGUIOrigin180_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.Origin180));
				    FairyGUIOrigin180_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIOrigin180_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIOrigin180_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.Origin180 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIOrigin180_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.Origin180 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOrigin180_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Origin180");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.Origin180");
                }
				val = (FairyGUI.Origin180)e;
                
            }
            else
            {
                val = (FairyGUI.Origin180)objectCasters.GetCaster(typeof(FairyGUI.Origin180))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIOrigin180(RealStatePtr L, int index, FairyGUI.Origin180 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOrigin180_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Origin180");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.Origin180 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIOrigin360_TypeID = -1;
		int FairyGUIOrigin360_EnumRef = -1;
        
        public void PushFairyGUIOrigin360(RealStatePtr L, FairyGUI.Origin360 val)
        {
            if (FairyGUIOrigin360_TypeID == -1)
            {
			    bool is_first;
                FairyGUIOrigin360_TypeID = getTypeId(L, typeof(FairyGUI.Origin360), out is_first);
				
				if (FairyGUIOrigin360_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.Origin360));
				    FairyGUIOrigin360_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIOrigin360_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIOrigin360_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.Origin360 ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIOrigin360_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.Origin360 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOrigin360_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Origin360");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.Origin360");
                }
				val = (FairyGUI.Origin360)e;
                
            }
            else
            {
                val = (FairyGUI.Origin360)objectCasters.GetCaster(typeof(FairyGUI.Origin360))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIOrigin360(RealStatePtr L, int index, FairyGUI.Origin360 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIOrigin360_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Origin360");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.Origin360 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIFitScreen_TypeID = -1;
		int FairyGUIFitScreen_EnumRef = -1;
        
        public void PushFairyGUIFitScreen(RealStatePtr L, FairyGUI.FitScreen val)
        {
            if (FairyGUIFitScreen_TypeID == -1)
            {
			    bool is_first;
                FairyGUIFitScreen_TypeID = getTypeId(L, typeof(FairyGUI.FitScreen), out is_first);
				
				if (FairyGUIFitScreen_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.FitScreen));
				    FairyGUIFitScreen_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIFitScreen_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIFitScreen_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.FitScreen ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIFitScreen_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.FitScreen val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFitScreen_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FitScreen");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.FitScreen");
                }
				val = (FairyGUI.FitScreen)e;
                
            }
            else
            {
                val = (FairyGUI.FitScreen)objectCasters.GetCaster(typeof(FairyGUI.FitScreen))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIFitScreen(RealStatePtr L, int index, FairyGUI.FitScreen val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIFitScreen_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.FitScreen");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.FitScreen ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIUtilsHtmlElementType_TypeID = -1;
		int FairyGUIUtilsHtmlElementType_EnumRef = -1;
        
        public void PushFairyGUIUtilsHtmlElementType(RealStatePtr L, FairyGUI.Utils.HtmlElementType val)
        {
            if (FairyGUIUtilsHtmlElementType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIUtilsHtmlElementType_TypeID = getTypeId(L, typeof(FairyGUI.Utils.HtmlElementType), out is_first);
				
				if (FairyGUIUtilsHtmlElementType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.Utils.HtmlElementType));
				    FairyGUIUtilsHtmlElementType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIUtilsHtmlElementType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIUtilsHtmlElementType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.Utils.HtmlElementType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIUtilsHtmlElementType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.Utils.HtmlElementType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUtilsHtmlElementType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Utils.HtmlElementType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.Utils.HtmlElementType");
                }
				val = (FairyGUI.Utils.HtmlElementType)e;
                
            }
            else
            {
                val = (FairyGUI.Utils.HtmlElementType)objectCasters.GetCaster(typeof(FairyGUI.Utils.HtmlElementType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIUtilsHtmlElementType(RealStatePtr L, int index, FairyGUI.Utils.HtmlElementType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUtilsHtmlElementType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Utils.HtmlElementType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.Utils.HtmlElementType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIUtilsXMLTagType_TypeID = -1;
		int FairyGUIUtilsXMLTagType_EnumRef = -1;
        
        public void PushFairyGUIUtilsXMLTagType(RealStatePtr L, FairyGUI.Utils.XMLTagType val)
        {
            if (FairyGUIUtilsXMLTagType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIUtilsXMLTagType_TypeID = getTypeId(L, typeof(FairyGUI.Utils.XMLTagType), out is_first);
				
				if (FairyGUIUtilsXMLTagType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.Utils.XMLTagType));
				    FairyGUIUtilsXMLTagType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIUtilsXMLTagType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIUtilsXMLTagType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.Utils.XMLTagType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIUtilsXMLTagType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.Utils.XMLTagType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUtilsXMLTagType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Utils.XMLTagType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.Utils.XMLTagType");
                }
				val = (FairyGUI.Utils.XMLTagType)e;
                
            }
            else
            {
                val = (FairyGUI.Utils.XMLTagType)objectCasters.GetCaster(typeof(FairyGUI.Utils.XMLTagType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIUtilsXMLTagType(RealStatePtr L, int index, FairyGUI.Utils.XMLTagType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUtilsXMLTagType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.Utils.XMLTagType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.Utils.XMLTagType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIRTLSupportDirectionType_TypeID = -1;
		int FairyGUIRTLSupportDirectionType_EnumRef = -1;
        
        public void PushFairyGUIRTLSupportDirectionType(RealStatePtr L, FairyGUI.RTLSupport.DirectionType val)
        {
            if (FairyGUIRTLSupportDirectionType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIRTLSupportDirectionType_TypeID = getTypeId(L, typeof(FairyGUI.RTLSupport.DirectionType), out is_first);
				
				if (FairyGUIRTLSupportDirectionType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.RTLSupport.DirectionType));
				    FairyGUIRTLSupportDirectionType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIRTLSupportDirectionType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIRTLSupportDirectionType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.RTLSupport.DirectionType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIRTLSupportDirectionType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.RTLSupport.DirectionType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIRTLSupportDirectionType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.RTLSupport.DirectionType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.RTLSupport.DirectionType");
                }
				val = (FairyGUI.RTLSupport.DirectionType)e;
                
            }
            else
            {
                val = (FairyGUI.RTLSupport.DirectionType)objectCasters.GetCaster(typeof(FairyGUI.RTLSupport.DirectionType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIRTLSupportDirectionType(RealStatePtr L, int index, FairyGUI.RTLSupport.DirectionType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIRTLSupportDirectionType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.RTLSupport.DirectionType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.RTLSupport.DirectionType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUITextFormatSpecialStyle_TypeID = -1;
		int FairyGUITextFormatSpecialStyle_EnumRef = -1;
        
        public void PushFairyGUITextFormatSpecialStyle(RealStatePtr L, FairyGUI.TextFormat.SpecialStyle val)
        {
            if (FairyGUITextFormatSpecialStyle_TypeID == -1)
            {
			    bool is_first;
                FairyGUITextFormatSpecialStyle_TypeID = getTypeId(L, typeof(FairyGUI.TextFormat.SpecialStyle), out is_first);
				
				if (FairyGUITextFormatSpecialStyle_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.TextFormat.SpecialStyle));
				    FairyGUITextFormatSpecialStyle_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUITextFormatSpecialStyle_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUITextFormatSpecialStyle_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.TextFormat.SpecialStyle ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUITextFormatSpecialStyle_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.TextFormat.SpecialStyle val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUITextFormatSpecialStyle_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.TextFormat.SpecialStyle");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.TextFormat.SpecialStyle");
                }
				val = (FairyGUI.TextFormat.SpecialStyle)e;
                
            }
            else
            {
                val = (FairyGUI.TextFormat.SpecialStyle)objectCasters.GetCaster(typeof(FairyGUI.TextFormat.SpecialStyle))(L, index, null);
            }
        }
		
        public void UpdateFairyGUITextFormatSpecialStyle(RealStatePtr L, int index, FairyGUI.TextFormat.SpecialStyle val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUITextFormatSpecialStyle_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.TextFormat.SpecialStyle");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.TextFormat.SpecialStyle ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIGPathPointCurveType_TypeID = -1;
		int FairyGUIGPathPointCurveType_EnumRef = -1;
        
        public void PushFairyGUIGPathPointCurveType(RealStatePtr L, FairyGUI.GPathPoint.CurveType val)
        {
            if (FairyGUIGPathPointCurveType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIGPathPointCurveType_TypeID = getTypeId(L, typeof(FairyGUI.GPathPoint.CurveType), out is_first);
				
				if (FairyGUIGPathPointCurveType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.GPathPoint.CurveType));
				    FairyGUIGPathPointCurveType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIGPathPointCurveType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIGPathPointCurveType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.GPathPoint.CurveType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIGPathPointCurveType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.GPathPoint.CurveType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIGPathPointCurveType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.GPathPoint.CurveType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.GPathPoint.CurveType");
                }
				val = (FairyGUI.GPathPoint.CurveType)e;
                
            }
            else
            {
                val = (FairyGUI.GPathPoint.CurveType)objectCasters.GetCaster(typeof(FairyGUI.GPathPoint.CurveType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIGPathPointCurveType(RealStatePtr L, int index, FairyGUI.GPathPoint.CurveType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIGPathPointCurveType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.GPathPoint.CurveType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.GPathPoint.CurveType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIControllerActionActionType_TypeID = -1;
		int FairyGUIControllerActionActionType_EnumRef = -1;
        
        public void PushFairyGUIControllerActionActionType(RealStatePtr L, FairyGUI.ControllerAction.ActionType val)
        {
            if (FairyGUIControllerActionActionType_TypeID == -1)
            {
			    bool is_first;
                FairyGUIControllerActionActionType_TypeID = getTypeId(L, typeof(FairyGUI.ControllerAction.ActionType), out is_first);
				
				if (FairyGUIControllerActionActionType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.ControllerAction.ActionType));
				    FairyGUIControllerActionActionType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIControllerActionActionType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIControllerActionActionType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.ControllerAction.ActionType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIControllerActionActionType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.ControllerAction.ActionType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIControllerActionActionType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ControllerAction.ActionType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.ControllerAction.ActionType");
                }
				val = (FairyGUI.ControllerAction.ActionType)e;
                
            }
            else
            {
                val = (FairyGUI.ControllerAction.ActionType)objectCasters.GetCaster(typeof(FairyGUI.ControllerAction.ActionType))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIControllerActionActionType(RealStatePtr L, int index, FairyGUI.ControllerAction.ActionType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIControllerActionActionType_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.ControllerAction.ActionType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.ControllerAction.ActionType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIUIConfigConfigKey_TypeID = -1;
		int FairyGUIUIConfigConfigKey_EnumRef = -1;
        
        public void PushFairyGUIUIConfigConfigKey(RealStatePtr L, FairyGUI.UIConfig.ConfigKey val)
        {
            if (FairyGUIUIConfigConfigKey_TypeID == -1)
            {
			    bool is_first;
                FairyGUIUIConfigConfigKey_TypeID = getTypeId(L, typeof(FairyGUI.UIConfig.ConfigKey), out is_first);
				
				if (FairyGUIUIConfigConfigKey_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.UIConfig.ConfigKey));
				    FairyGUIUIConfigConfigKey_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIUIConfigConfigKey_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIUIConfigConfigKey_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.UIConfig.ConfigKey ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIUIConfigConfigKey_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.UIConfig.ConfigKey val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUIConfigConfigKey_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.UIConfig.ConfigKey");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.UIConfig.ConfigKey");
                }
				val = (FairyGUI.UIConfig.ConfigKey)e;
                
            }
            else
            {
                val = (FairyGUI.UIConfig.ConfigKey)objectCasters.GetCaster(typeof(FairyGUI.UIConfig.ConfigKey))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIUIConfigConfigKey(RealStatePtr L, int index, FairyGUI.UIConfig.ConfigKey val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUIConfigConfigKey_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.UIConfig.ConfigKey");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.UIConfig.ConfigKey ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIUIContentScalerScaleMode_TypeID = -1;
		int FairyGUIUIContentScalerScaleMode_EnumRef = -1;
        
        public void PushFairyGUIUIContentScalerScaleMode(RealStatePtr L, FairyGUI.UIContentScaler.ScaleMode val)
        {
            if (FairyGUIUIContentScalerScaleMode_TypeID == -1)
            {
			    bool is_first;
                FairyGUIUIContentScalerScaleMode_TypeID = getTypeId(L, typeof(FairyGUI.UIContentScaler.ScaleMode), out is_first);
				
				if (FairyGUIUIContentScalerScaleMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.UIContentScaler.ScaleMode));
				    FairyGUIUIContentScalerScaleMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIUIContentScalerScaleMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIUIContentScalerScaleMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.UIContentScaler.ScaleMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIUIContentScalerScaleMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.UIContentScaler.ScaleMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUIContentScalerScaleMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.UIContentScaler.ScaleMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.UIContentScaler.ScaleMode");
                }
				val = (FairyGUI.UIContentScaler.ScaleMode)e;
                
            }
            else
            {
                val = (FairyGUI.UIContentScaler.ScaleMode)objectCasters.GetCaster(typeof(FairyGUI.UIContentScaler.ScaleMode))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIUIContentScalerScaleMode(RealStatePtr L, int index, FairyGUI.UIContentScaler.ScaleMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUIContentScalerScaleMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.UIContentScaler.ScaleMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.UIContentScaler.ScaleMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int FairyGUIUIContentScalerScreenMatchMode_TypeID = -1;
		int FairyGUIUIContentScalerScreenMatchMode_EnumRef = -1;
        
        public void PushFairyGUIUIContentScalerScreenMatchMode(RealStatePtr L, FairyGUI.UIContentScaler.ScreenMatchMode val)
        {
            if (FairyGUIUIContentScalerScreenMatchMode_TypeID == -1)
            {
			    bool is_first;
                FairyGUIUIContentScalerScreenMatchMode_TypeID = getTypeId(L, typeof(FairyGUI.UIContentScaler.ScreenMatchMode), out is_first);
				
				if (FairyGUIUIContentScalerScreenMatchMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(FairyGUI.UIContentScaler.ScreenMatchMode));
				    FairyGUIUIContentScalerScreenMatchMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, FairyGUIUIContentScalerScreenMatchMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, FairyGUIUIContentScalerScreenMatchMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for FairyGUI.UIContentScaler.ScreenMatchMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, FairyGUIUIContentScalerScreenMatchMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out FairyGUI.UIContentScaler.ScreenMatchMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUIContentScalerScreenMatchMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.UIContentScaler.ScreenMatchMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for FairyGUI.UIContentScaler.ScreenMatchMode");
                }
				val = (FairyGUI.UIContentScaler.ScreenMatchMode)e;
                
            }
            else
            {
                val = (FairyGUI.UIContentScaler.ScreenMatchMode)objectCasters.GetCaster(typeof(FairyGUI.UIContentScaler.ScreenMatchMode))(L, index, null);
            }
        }
		
        public void UpdateFairyGUIUIContentScalerScreenMatchMode(RealStatePtr L, int index, FairyGUI.UIContentScaler.ScreenMatchMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != FairyGUIUIContentScalerScreenMatchMode_TypeID)
				{
				    throw new Exception("invalid userdata for FairyGUI.UIContentScaler.ScreenMatchMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for FairyGUI.UIContentScaler.ScreenMatchMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_TypeID = -1;
		int MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_EnumRef = -1;
        
        public void PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType(RealStatePtr L, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType val)
        {
            if (MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_TypeID == -1)
            {
			    bool is_first;
                MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_TypeID = getTypeId(L, typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType), out is_first);
				
				if (MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType));
				    MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_TypeID)
				{
				    throw new Exception("invalid userdata for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType");
                }
				val = (Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType)e;
                
            }
            else
            {
                val = (Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType)objectCasters.GetCaster(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType))(L, index, null);
            }
        }
		
        public void UpdateMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType(RealStatePtr L, int index, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType_TypeID)
				{
				    throw new Exception("invalid userdata for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_TypeID = -1;
		int MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_EnumRef = -1;
        
        public void PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason(RealStatePtr L, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason val)
        {
            if (MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_TypeID == -1)
            {
			    bool is_first;
                MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_TypeID = getTypeId(L, typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason), out is_first);
				
				if (MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason));
				    MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_TypeID)
				{
				    throw new Exception("invalid userdata for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason");
                }
				val = (Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason)e;
                
            }
            else
            {
                val = (Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason)objectCasters.GetCaster(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason))(L, index, null);
            }
        }
		
        public void UpdateMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason(RealStatePtr L, int index, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason_TypeID)
				{
				    throw new Exception("invalid userdata for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        
		// table cast optimze
		
        
    }
	
	public partial class StaticLuaCallbacks
    {
	    internal static bool __tryArrayGet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int index)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.PushUnityEngineVector2(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.PushUnityEngineVector3(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.PushUnityEngineVector4(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.PushUnityEngineColor(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.PushUnityEngineQuaternion(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.PushUnityEngineRay(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.PushUnityEngineBounds(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.PushUnityEngineRay2D(L, array[index]);
				return true;
			}
			else if (type == typeof(System.Net.Sockets.AddressFamily[]))
			{
			    System.Net.Sockets.AddressFamily[] array = obj as System.Net.Sockets.AddressFamily[];
				translator.PushSystemNetSocketsAddressFamily(L, array[index]);
				return true;
			}
			else if (type == typeof(System.Net.Sockets.SocketType[]))
			{
			    System.Net.Sockets.SocketType[] array = obj as System.Net.Sockets.SocketType[];
				translator.PushSystemNetSocketsSocketType(L, array[index]);
				return true;
			}
			else if (type == typeof(System.Net.Sockets.ProtocolType[]))
			{
			    System.Net.Sockets.ProtocolType[] array = obj as System.Net.Sockets.ProtocolType[];
				translator.PushSystemNetSocketsProtocolType(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.HeuristicOptimizationMode[]))
			{
			    PF.HeuristicOptimizationMode[] array = obj as PF.HeuristicOptimizationMode[];
				translator.PushPFHeuristicOptimizationMode(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.GraphUpdateThreading[]))
			{
			    PF.GraphUpdateThreading[] array = obj as PF.GraphUpdateThreading[];
				translator.PushPFGraphUpdateThreading(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.ThreadCount[]))
			{
			    PF.ThreadCount[] array = obj as PF.ThreadCount[];
				translator.PushPFThreadCount(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.PathState[]))
			{
			    PF.PathState[] array = obj as PF.PathState[];
				translator.PushPFPathState(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.PathCompleteState[]))
			{
			    PF.PathCompleteState[] array = obj as PF.PathCompleteState[];
				translator.PushPFPathCompleteState(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.CloseToDestinationMode[]))
			{
			    PF.CloseToDestinationMode[] array = obj as PF.CloseToDestinationMode[];
				translator.PushPFCloseToDestinationMode(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.Side[]))
			{
			    PF.Side[] array = obj as PF.Side[];
				translator.PushPFSide(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.InspectorGridMode[]))
			{
			    PF.InspectorGridMode[] array = obj as PF.InspectorGridMode[];
				translator.PushPFInspectorGridMode(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.GraphDebugMode[]))
			{
			    PF.GraphDebugMode[] array = obj as PF.GraphDebugMode[];
				translator.PushPFGraphDebugMode(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.PathLog[]))
			{
			    PF.PathLog[] array = obj as PF.PathLog[];
				translator.PushPFPathLog(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.Heuristic[]))
			{
			    PF.Heuristic[] array = obj as PF.Heuristic[];
				translator.PushPFHeuristic(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.RVO.MovementPlane[]))
			{
			    Pathfinding.RVO.MovementPlane[] array = obj as Pathfinding.RVO.MovementPlane[];
				translator.PushPathfindingRVOMovementPlane(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.RVO.RVOLayer[]))
			{
			    Pathfinding.RVO.RVOLayer[] array = obj as Pathfinding.RVO.RVOLayer[];
				translator.PushPathfindingRVORVOLayer(L, array[index]);
				return true;
			}
			else if (type == typeof(AstarPath.AstarDistribution[]))
			{
			    AstarPath.AstarDistribution[] array = obj as AstarPath.AstarDistribution[];
				translator.PushAstarPathAstarDistribution(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.MultiTargetPath.HeuristicMode[]))
			{
			    PF.MultiTargetPath.HeuristicMode[] array = obj as PF.MultiTargetPath.HeuristicMode[];
				translator.PushPFMultiTargetPathHeuristicMode(L, array[index]);
				return true;
			}
			else if (type == typeof(PF.RecastGraph.RelevantGraphSurfaceMode[]))
			{
			    PF.RecastGraph.RelevantGraphSurfaceMode[] array = obj as PF.RecastGraph.RelevantGraphSurfaceMode[];
				translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.Seeker.ModifierPass[]))
			{
			    Pathfinding.Seeker.ModifierPass[] array = obj as Pathfinding.Seeker.ModifierPass[];
				translator.PushPathfindingSeekerModifierPass(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.GraphModifier.EventType[]))
			{
			    Pathfinding.GraphModifier.EventType[] array = obj as Pathfinding.GraphModifier.EventType[];
				translator.PushPathfindingGraphModifierEventType(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.RaycastModifier.Quality[]))
			{
			    Pathfinding.RaycastModifier.Quality[] array = obj as Pathfinding.RaycastModifier.Quality[];
				translator.PushPathfindingRaycastModifierQuality(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.SimpleSmoothModifier.SmoothType[]))
			{
			    Pathfinding.SimpleSmoothModifier.SmoothType[] array = obj as Pathfinding.SimpleSmoothModifier.SmoothType[];
				translator.PushPathfindingSimpleSmoothModifierSmoothType(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.StartEndModifier.Exactness[]))
			{
			    Pathfinding.StartEndModifier.Exactness[] array = obj as Pathfinding.StartEndModifier.Exactness[];
				translator.PushPathfindingStartEndModifierExactness(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.BlockManager.BlockMode[]))
			{
			    Pathfinding.BlockManager.BlockMode[] array = obj as Pathfinding.BlockManager.BlockMode[];
				translator.PushPathfindingBlockManagerBlockMode(L, array[index]);
				return true;
			}
			else if (type == typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding[]))
			{
			    Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding[] array = obj as Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding[];
				translator.PushPathfindingRVORVOObstacleObstacleVertexWinding(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.BlendMode[]))
			{
			    FairyGUI.BlendMode[] array = obj as FairyGUI.BlendMode[];
				translator.PushFairyGUIBlendMode(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.HitTestMode[]))
			{
			    FairyGUI.HitTestMode[] array = obj as FairyGUI.HitTestMode[];
				translator.PushFairyGUIHitTestMode(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.DestroyMethod[]))
			{
			    FairyGUI.DestroyMethod[] array = obj as FairyGUI.DestroyMethod[];
				translator.PushFairyGUIDestroyMethod(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.EaseType[]))
			{
			    FairyGUI.EaseType[] array = obj as FairyGUI.EaseType[];
				translator.PushFairyGUIEaseType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.TweenPropType[]))
			{
			    FairyGUI.TweenPropType[] array = obj as FairyGUI.TweenPropType[];
				translator.PushFairyGUITweenPropType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.PackageItemType[]))
			{
			    FairyGUI.PackageItemType[] array = obj as FairyGUI.PackageItemType[];
				translator.PushFairyGUIPackageItemType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ObjectType[]))
			{
			    FairyGUI.ObjectType[] array = obj as FairyGUI.ObjectType[];
				translator.PushFairyGUIObjectType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.AlignType[]))
			{
			    FairyGUI.AlignType[] array = obj as FairyGUI.AlignType[];
				translator.PushFairyGUIAlignType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.VertAlignType[]))
			{
			    FairyGUI.VertAlignType[] array = obj as FairyGUI.VertAlignType[];
				translator.PushFairyGUIVertAlignType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.OverflowType[]))
			{
			    FairyGUI.OverflowType[] array = obj as FairyGUI.OverflowType[];
				translator.PushFairyGUIOverflowType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.FillType[]))
			{
			    FairyGUI.FillType[] array = obj as FairyGUI.FillType[];
				translator.PushFairyGUIFillType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.AutoSizeType[]))
			{
			    FairyGUI.AutoSizeType[] array = obj as FairyGUI.AutoSizeType[];
				translator.PushFairyGUIAutoSizeType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ScrollType[]))
			{
			    FairyGUI.ScrollType[] array = obj as FairyGUI.ScrollType[];
				translator.PushFairyGUIScrollType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ScrollBarDisplayType[]))
			{
			    FairyGUI.ScrollBarDisplayType[] array = obj as FairyGUI.ScrollBarDisplayType[];
				translator.PushFairyGUIScrollBarDisplayType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.RelationType[]))
			{
			    FairyGUI.RelationType[] array = obj as FairyGUI.RelationType[];
				translator.PushFairyGUIRelationType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ListLayoutType[]))
			{
			    FairyGUI.ListLayoutType[] array = obj as FairyGUI.ListLayoutType[];
				translator.PushFairyGUIListLayoutType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ListSelectionMode[]))
			{
			    FairyGUI.ListSelectionMode[] array = obj as FairyGUI.ListSelectionMode[];
				translator.PushFairyGUIListSelectionMode(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ProgressTitleType[]))
			{
			    FairyGUI.ProgressTitleType[] array = obj as FairyGUI.ProgressTitleType[];
				translator.PushFairyGUIProgressTitleType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ButtonMode[]))
			{
			    FairyGUI.ButtonMode[] array = obj as FairyGUI.ButtonMode[];
				translator.PushFairyGUIButtonMode(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.TransitionActionType[]))
			{
			    FairyGUI.TransitionActionType[] array = obj as FairyGUI.TransitionActionType[];
				translator.PushFairyGUITransitionActionType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.GroupLayoutType[]))
			{
			    FairyGUI.GroupLayoutType[] array = obj as FairyGUI.GroupLayoutType[];
				translator.PushFairyGUIGroupLayoutType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ChildrenRenderOrder[]))
			{
			    FairyGUI.ChildrenRenderOrder[] array = obj as FairyGUI.ChildrenRenderOrder[];
				translator.PushFairyGUIChildrenRenderOrder(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.PopupDirection[]))
			{
			    FairyGUI.PopupDirection[] array = obj as FairyGUI.PopupDirection[];
				translator.PushFairyGUIPopupDirection(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.FlipType[]))
			{
			    FairyGUI.FlipType[] array = obj as FairyGUI.FlipType[];
				translator.PushFairyGUIFlipType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.FillMethod[]))
			{
			    FairyGUI.FillMethod[] array = obj as FairyGUI.FillMethod[];
				translator.PushFairyGUIFillMethod(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.OriginHorizontal[]))
			{
			    FairyGUI.OriginHorizontal[] array = obj as FairyGUI.OriginHorizontal[];
				translator.PushFairyGUIOriginHorizontal(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.OriginVertical[]))
			{
			    FairyGUI.OriginVertical[] array = obj as FairyGUI.OriginVertical[];
				translator.PushFairyGUIOriginVertical(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.Origin90[]))
			{
			    FairyGUI.Origin90[] array = obj as FairyGUI.Origin90[];
				translator.PushFairyGUIOrigin90(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.Origin180[]))
			{
			    FairyGUI.Origin180[] array = obj as FairyGUI.Origin180[];
				translator.PushFairyGUIOrigin180(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.Origin360[]))
			{
			    FairyGUI.Origin360[] array = obj as FairyGUI.Origin360[];
				translator.PushFairyGUIOrigin360(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.FitScreen[]))
			{
			    FairyGUI.FitScreen[] array = obj as FairyGUI.FitScreen[];
				translator.PushFairyGUIFitScreen(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.Utils.HtmlElementType[]))
			{
			    FairyGUI.Utils.HtmlElementType[] array = obj as FairyGUI.Utils.HtmlElementType[];
				translator.PushFairyGUIUtilsHtmlElementType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.Utils.XMLTagType[]))
			{
			    FairyGUI.Utils.XMLTagType[] array = obj as FairyGUI.Utils.XMLTagType[];
				translator.PushFairyGUIUtilsXMLTagType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.RTLSupport.DirectionType[]))
			{
			    FairyGUI.RTLSupport.DirectionType[] array = obj as FairyGUI.RTLSupport.DirectionType[];
				translator.PushFairyGUIRTLSupportDirectionType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.TextFormat.SpecialStyle[]))
			{
			    FairyGUI.TextFormat.SpecialStyle[] array = obj as FairyGUI.TextFormat.SpecialStyle[];
				translator.PushFairyGUITextFormatSpecialStyle(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.GPathPoint.CurveType[]))
			{
			    FairyGUI.GPathPoint.CurveType[] array = obj as FairyGUI.GPathPoint.CurveType[];
				translator.PushFairyGUIGPathPointCurveType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.ControllerAction.ActionType[]))
			{
			    FairyGUI.ControllerAction.ActionType[] array = obj as FairyGUI.ControllerAction.ActionType[];
				translator.PushFairyGUIControllerActionActionType(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.UIConfig.ConfigKey[]))
			{
			    FairyGUI.UIConfig.ConfigKey[] array = obj as FairyGUI.UIConfig.ConfigKey[];
				translator.PushFairyGUIUIConfigConfigKey(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.UIContentScaler.ScaleMode[]))
			{
			    FairyGUI.UIContentScaler.ScaleMode[] array = obj as FairyGUI.UIContentScaler.ScaleMode[];
				translator.PushFairyGUIUIContentScalerScaleMode(L, array[index]);
				return true;
			}
			else if (type == typeof(FairyGUI.UIContentScaler.ScreenMatchMode[]))
			{
			    FairyGUI.UIContentScaler.ScreenMatchMode[] array = obj as FairyGUI.UIContentScaler.ScreenMatchMode[];
				translator.PushFairyGUIUIContentScalerScreenMatchMode(L, array[index]);
				return true;
			}
			else if (type == typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType[]))
			{
			    Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType[] array = obj as Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType[];
				translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType(L, array[index]);
				return true;
			}
			else if (type == typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason[]))
			{
			    Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason[] array = obj as Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason[];
				translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason(L, array[index]);
				return true;
			}
            return false;
		}
		
		internal static bool __tryArraySet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(System.Net.Sockets.AddressFamily[]))
			{
			    System.Net.Sockets.AddressFamily[] array = obj as System.Net.Sockets.AddressFamily[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(System.Net.Sockets.SocketType[]))
			{
			    System.Net.Sockets.SocketType[] array = obj as System.Net.Sockets.SocketType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(System.Net.Sockets.ProtocolType[]))
			{
			    System.Net.Sockets.ProtocolType[] array = obj as System.Net.Sockets.ProtocolType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.HeuristicOptimizationMode[]))
			{
			    PF.HeuristicOptimizationMode[] array = obj as PF.HeuristicOptimizationMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.GraphUpdateThreading[]))
			{
			    PF.GraphUpdateThreading[] array = obj as PF.GraphUpdateThreading[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.ThreadCount[]))
			{
			    PF.ThreadCount[] array = obj as PF.ThreadCount[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.PathState[]))
			{
			    PF.PathState[] array = obj as PF.PathState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.PathCompleteState[]))
			{
			    PF.PathCompleteState[] array = obj as PF.PathCompleteState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.CloseToDestinationMode[]))
			{
			    PF.CloseToDestinationMode[] array = obj as PF.CloseToDestinationMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.Side[]))
			{
			    PF.Side[] array = obj as PF.Side[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.InspectorGridMode[]))
			{
			    PF.InspectorGridMode[] array = obj as PF.InspectorGridMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.GraphDebugMode[]))
			{
			    PF.GraphDebugMode[] array = obj as PF.GraphDebugMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.PathLog[]))
			{
			    PF.PathLog[] array = obj as PF.PathLog[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.Heuristic[]))
			{
			    PF.Heuristic[] array = obj as PF.Heuristic[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.RVO.MovementPlane[]))
			{
			    Pathfinding.RVO.MovementPlane[] array = obj as Pathfinding.RVO.MovementPlane[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.RVO.RVOLayer[]))
			{
			    Pathfinding.RVO.RVOLayer[] array = obj as Pathfinding.RVO.RVOLayer[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(AstarPath.AstarDistribution[]))
			{
			    AstarPath.AstarDistribution[] array = obj as AstarPath.AstarDistribution[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.MultiTargetPath.HeuristicMode[]))
			{
			    PF.MultiTargetPath.HeuristicMode[] array = obj as PF.MultiTargetPath.HeuristicMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(PF.RecastGraph.RelevantGraphSurfaceMode[]))
			{
			    PF.RecastGraph.RelevantGraphSurfaceMode[] array = obj as PF.RecastGraph.RelevantGraphSurfaceMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.Seeker.ModifierPass[]))
			{
			    Pathfinding.Seeker.ModifierPass[] array = obj as Pathfinding.Seeker.ModifierPass[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.GraphModifier.EventType[]))
			{
			    Pathfinding.GraphModifier.EventType[] array = obj as Pathfinding.GraphModifier.EventType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.RaycastModifier.Quality[]))
			{
			    Pathfinding.RaycastModifier.Quality[] array = obj as Pathfinding.RaycastModifier.Quality[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.SimpleSmoothModifier.SmoothType[]))
			{
			    Pathfinding.SimpleSmoothModifier.SmoothType[] array = obj as Pathfinding.SimpleSmoothModifier.SmoothType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.StartEndModifier.Exactness[]))
			{
			    Pathfinding.StartEndModifier.Exactness[] array = obj as Pathfinding.StartEndModifier.Exactness[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.BlockManager.BlockMode[]))
			{
			    Pathfinding.BlockManager.BlockMode[] array = obj as Pathfinding.BlockManager.BlockMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding[]))
			{
			    Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding[] array = obj as Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.BlendMode[]))
			{
			    FairyGUI.BlendMode[] array = obj as FairyGUI.BlendMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.HitTestMode[]))
			{
			    FairyGUI.HitTestMode[] array = obj as FairyGUI.HitTestMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.DestroyMethod[]))
			{
			    FairyGUI.DestroyMethod[] array = obj as FairyGUI.DestroyMethod[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.EaseType[]))
			{
			    FairyGUI.EaseType[] array = obj as FairyGUI.EaseType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.TweenPropType[]))
			{
			    FairyGUI.TweenPropType[] array = obj as FairyGUI.TweenPropType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.PackageItemType[]))
			{
			    FairyGUI.PackageItemType[] array = obj as FairyGUI.PackageItemType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ObjectType[]))
			{
			    FairyGUI.ObjectType[] array = obj as FairyGUI.ObjectType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.AlignType[]))
			{
			    FairyGUI.AlignType[] array = obj as FairyGUI.AlignType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.VertAlignType[]))
			{
			    FairyGUI.VertAlignType[] array = obj as FairyGUI.VertAlignType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.OverflowType[]))
			{
			    FairyGUI.OverflowType[] array = obj as FairyGUI.OverflowType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.FillType[]))
			{
			    FairyGUI.FillType[] array = obj as FairyGUI.FillType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.AutoSizeType[]))
			{
			    FairyGUI.AutoSizeType[] array = obj as FairyGUI.AutoSizeType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ScrollType[]))
			{
			    FairyGUI.ScrollType[] array = obj as FairyGUI.ScrollType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ScrollBarDisplayType[]))
			{
			    FairyGUI.ScrollBarDisplayType[] array = obj as FairyGUI.ScrollBarDisplayType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.RelationType[]))
			{
			    FairyGUI.RelationType[] array = obj as FairyGUI.RelationType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ListLayoutType[]))
			{
			    FairyGUI.ListLayoutType[] array = obj as FairyGUI.ListLayoutType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ListSelectionMode[]))
			{
			    FairyGUI.ListSelectionMode[] array = obj as FairyGUI.ListSelectionMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ProgressTitleType[]))
			{
			    FairyGUI.ProgressTitleType[] array = obj as FairyGUI.ProgressTitleType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ButtonMode[]))
			{
			    FairyGUI.ButtonMode[] array = obj as FairyGUI.ButtonMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.TransitionActionType[]))
			{
			    FairyGUI.TransitionActionType[] array = obj as FairyGUI.TransitionActionType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.GroupLayoutType[]))
			{
			    FairyGUI.GroupLayoutType[] array = obj as FairyGUI.GroupLayoutType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ChildrenRenderOrder[]))
			{
			    FairyGUI.ChildrenRenderOrder[] array = obj as FairyGUI.ChildrenRenderOrder[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.PopupDirection[]))
			{
			    FairyGUI.PopupDirection[] array = obj as FairyGUI.PopupDirection[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.FlipType[]))
			{
			    FairyGUI.FlipType[] array = obj as FairyGUI.FlipType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.FillMethod[]))
			{
			    FairyGUI.FillMethod[] array = obj as FairyGUI.FillMethod[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.OriginHorizontal[]))
			{
			    FairyGUI.OriginHorizontal[] array = obj as FairyGUI.OriginHorizontal[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.OriginVertical[]))
			{
			    FairyGUI.OriginVertical[] array = obj as FairyGUI.OriginVertical[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.Origin90[]))
			{
			    FairyGUI.Origin90[] array = obj as FairyGUI.Origin90[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.Origin180[]))
			{
			    FairyGUI.Origin180[] array = obj as FairyGUI.Origin180[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.Origin360[]))
			{
			    FairyGUI.Origin360[] array = obj as FairyGUI.Origin360[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.FitScreen[]))
			{
			    FairyGUI.FitScreen[] array = obj as FairyGUI.FitScreen[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.Utils.HtmlElementType[]))
			{
			    FairyGUI.Utils.HtmlElementType[] array = obj as FairyGUI.Utils.HtmlElementType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.Utils.XMLTagType[]))
			{
			    FairyGUI.Utils.XMLTagType[] array = obj as FairyGUI.Utils.XMLTagType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.RTLSupport.DirectionType[]))
			{
			    FairyGUI.RTLSupport.DirectionType[] array = obj as FairyGUI.RTLSupport.DirectionType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.TextFormat.SpecialStyle[]))
			{
			    FairyGUI.TextFormat.SpecialStyle[] array = obj as FairyGUI.TextFormat.SpecialStyle[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.GPathPoint.CurveType[]))
			{
			    FairyGUI.GPathPoint.CurveType[] array = obj as FairyGUI.GPathPoint.CurveType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.ControllerAction.ActionType[]))
			{
			    FairyGUI.ControllerAction.ActionType[] array = obj as FairyGUI.ControllerAction.ActionType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.UIConfig.ConfigKey[]))
			{
			    FairyGUI.UIConfig.ConfigKey[] array = obj as FairyGUI.UIConfig.ConfigKey[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.UIContentScaler.ScaleMode[]))
			{
			    FairyGUI.UIContentScaler.ScaleMode[] array = obj as FairyGUI.UIContentScaler.ScaleMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(FairyGUI.UIContentScaler.ScreenMatchMode[]))
			{
			    FairyGUI.UIContentScaler.ScreenMatchMode[] array = obj as FairyGUI.UIContentScaler.ScreenMatchMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType[]))
			{
			    Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType[] array = obj as Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason[]))
			{
			    Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason[] array = obj as Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
            return false;
		}
	}
}