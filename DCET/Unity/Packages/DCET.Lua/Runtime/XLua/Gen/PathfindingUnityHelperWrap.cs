#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PathfindingUnityHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.UnityHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 48, 6, 6);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Close", _m_Close_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetGraph", _m_GetGraph_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTileBounds", _m_GetTileBounds);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTileBoundsInGraphSpace", _m_GetTileBoundsInGraphSpace);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateNavmeshSurfaceVisualization", _m_CreateNavmeshSurfaceVisualization);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateNavmeshOutlineVisualization", _m_CreateNavmeshOutlineVisualization_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DrawUnwalkableNodes", _m_DrawUnwalkableNodes);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ScanAllTiles", _m_ScanAllTiles);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PutMeshesIntoTileBuckets", _m_PutMeshesIntoTileBuckets);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CollectMeshes", _m_CollectMeshes);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CalculateTileBoundsWithBorder", _m_CalculateTileBoundsWithBorder);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BuildTileMesh", _m_BuildTileMesh);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateTile", _m_CreateTile);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SnapForceBoundsToScene", _m_SnapForceBoundsToScene);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Transform", _m_Transform);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InverseTransform", _m_InverseTransform);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTouchingTiles", _m_GetTouchingTiles);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTouchingTilesInGraphSpace", _m_GetTouchingTilesInGraphSpace);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReversesFaceOrientations", _m_ReversesFaceOrientations_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReversesFaceOrientationsXZ", _m_ReversesFaceOrientationsXZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IntToColor", _m_IntToColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HSVToRGB", _m_HSVToRGB_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnGraphPreScan", _g_get_OnGraphPreScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnGraphPostScan", _g_get_OnGraphPostScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnPreScan", _g_get_OnPreScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnPostScan", _g_get_OnPostScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnLatePostScan", _g_get_OnLatePostScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnGraphsUpdated", _g_get_OnGraphsUpdated);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnGraphPreScan", _s_set_OnGraphPreScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnGraphPostScan", _s_set_OnGraphPostScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnPreScan", _s_set_OnPreScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnPostScan", _s_set_OnPostScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnLatePostScan", _s_set_OnLatePostScan);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnGraphsUpdated", _s_set_OnGraphsUpdated);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnGraphPreScan", _g_get_OnGraphPreScan);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnGraphPostScan", _g_get_OnGraphPostScan);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnPreScan", _g_get_OnPreScan);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnPostScan", _g_get_OnPostScan);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnLatePostScan", _g_get_OnLatePostScan);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnGraphsUpdated", _g_get_OnGraphsUpdated);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnGraphPreScan", _s_set_OnGraphPreScan);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnGraphPostScan", _s_set_OnGraphPostScan);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnPreScan", _s_set_OnPreScan);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnPostScan", _s_set_OnPostScan);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnLatePostScan", _s_set_OnLatePostScan);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnGraphsUpdated", _s_set_OnGraphsUpdated);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.UnityHelper does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.UnityHelper.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmos(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<PF.EuclideanEmbedding>(L, 1)) 
                {
                    PF.EuclideanEmbedding _embedding = (PF.EuclideanEmbedding)translator.GetObject(L, 1, typeof(PF.EuclideanEmbedding));
                    
                    Pathfinding.UnityHelper.OnDrawGizmos( 
                        _embedding );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<Pathfinding.Util.RetainedGizmos>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    Pathfinding.Util.RetainedGizmos _gizmos = (Pathfinding.Util.RetainedGizmos)translator.GetObject(L, 2, typeof(Pathfinding.Util.RetainedGizmos));
                    bool _drawNodes = LuaAPI.lua_toboolean(L, 3);
                    
                    Pathfinding.UnityHelper.OnDrawGizmos( 
                        _navmeshBase, 
                        _gizmos, 
                        _drawNodes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.UnityHelper.OnDrawGizmos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGraph_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    
                        PF.NavGraph gen_ret = Pathfinding.UnityHelper.GetGraph( 
                        _node );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileBounds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _width = LuaAPI.xlua_tointeger(L, 4);
                    int _depth = LuaAPI.xlua_tointeger(L, 5);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBounds( 
                        _navmeshBase, 
                        _x, 
                        _z, 
                        _width, 
                        _depth );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _width = LuaAPI.xlua_tointeger(L, 4);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBounds( 
                        _navmeshBase, 
                        _x, 
                        _z, 
                        _width );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBounds( 
                        _navmeshBase, 
                        _x, 
                        _z );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<PF.IntRect>(L, 2)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    PF.IntRect _rect;translator.Get(L, 2, out _rect);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBounds( 
                        _navmeshBase, 
                        _rect );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.UnityHelper.GetTileBounds!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileBoundsInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _width = LuaAPI.xlua_tointeger(L, 4);
                    int _depth = LuaAPI.xlua_tointeger(L, 5);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBoundsInGraphSpace( 
                        _navmeshBase, 
                        _x, 
                        _z, 
                        _width, 
                        _depth );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _width = LuaAPI.xlua_tointeger(L, 4);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBoundsInGraphSpace( 
                        _navmeshBase, 
                        _x, 
                        _z, 
                        _width );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBoundsInGraphSpace( 
                        _navmeshBase, 
                        _x, 
                        _z );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<PF.IntRect>(L, 2)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    PF.IntRect _rect;translator.Get(L, 2, out _rect);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.GetTileBoundsInGraphSpace( 
                        _navmeshBase, 
                        _rect );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.UnityHelper.GetTileBoundsInGraphSpace!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateNavmeshSurfaceVisualization(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    PF.NavmeshTile _tile = (PF.NavmeshTile)translator.GetObject(L, 2, typeof(PF.NavmeshTile));
                    Pathfinding.Util.GraphGizmoHelper _helper = (Pathfinding.Util.GraphGizmoHelper)translator.GetObject(L, 3, typeof(Pathfinding.Util.GraphGizmoHelper));
                    
                    Pathfinding.UnityHelper.CreateNavmeshSurfaceVisualization( 
                        _navmeshBase, 
                        _tile, 
                        _helper );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateNavmeshOutlineVisualization_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.NavmeshTile _tile = (PF.NavmeshTile)translator.GetObject(L, 1, typeof(PF.NavmeshTile));
                    Pathfinding.Util.GraphGizmoHelper _helper = (Pathfinding.Util.GraphGizmoHelper)translator.GetObject(L, 2, typeof(Pathfinding.Util.GraphGizmoHelper));
                    
                    Pathfinding.UnityHelper.CreateNavmeshOutlineVisualization( 
                        _tile, 
                        _helper );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawUnwalkableNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    float _size = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    Pathfinding.UnityHelper.DrawUnwalkableNodes( 
                        _navmeshBase, 
                        _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScanAllTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    
                        System.Collections.Generic.IEnumerable<Pathfinding.Progress> gen_ret = Pathfinding.UnityHelper.ScanAllTiles( 
                        _self );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PutMeshesIntoTileBuckets(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh> _meshes = (System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>));
                    
                        System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>[] gen_ret = Pathfinding.UnityHelper.PutMeshesIntoTileBuckets( 
                        _self, 
                        _meshes );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CollectMeshes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh> gen_ret = Pathfinding.UnityHelper.CollectMeshes( 
                        _self, 
                        _bounds );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateTileBoundsWithBorder(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.CalculateTileBoundsWithBorder( 
                        _self, 
                        _x, 
                        _z );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildTileMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.RecastGraph>(L, 1)&& translator.Assignable<Pathfinding.Voxels.Voxelize>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    Pathfinding.Voxels.Voxelize _vox = (Pathfinding.Voxels.Voxelize)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.Voxelize));
                    int _x = LuaAPI.xlua_tointeger(L, 3);
                    int _z = LuaAPI.xlua_tointeger(L, 4);
                    int _threadIndex = LuaAPI.xlua_tointeger(L, 5);
                    
                        PF.NavmeshTile gen_ret = Pathfinding.UnityHelper.BuildTileMesh( 
                        _self, 
                        _vox, 
                        _x, 
                        _z, 
                        _threadIndex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.RecastGraph>(L, 1)&& translator.Assignable<Pathfinding.Voxels.Voxelize>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    Pathfinding.Voxels.Voxelize _vox = (Pathfinding.Voxels.Voxelize)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.Voxelize));
                    int _x = LuaAPI.xlua_tointeger(L, 3);
                    int _z = LuaAPI.xlua_tointeger(L, 4);
                    
                        PF.NavmeshTile gen_ret = Pathfinding.UnityHelper.BuildTileMesh( 
                        _self, 
                        _vox, 
                        _x, 
                        _z );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.UnityHelper.BuildTileMesh!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateTile(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    Pathfinding.Voxels.Voxelize _vox = (Pathfinding.Voxels.Voxelize)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.Voxelize));
                    Pathfinding.Voxels.VoxelMesh _mesh;translator.Get(L, 3, out _mesh);
                    int _x = LuaAPI.xlua_tointeger(L, 4);
                    int _z = LuaAPI.xlua_tointeger(L, 5);
                    int _threadIndex = LuaAPI.xlua_tointeger(L, 6);
                    
                        PF.NavmeshTile gen_ret = Pathfinding.UnityHelper.CreateTile( 
                        _self, 
                        _vox, 
                        _mesh, 
                        _x, 
                        _z, 
                        _threadIndex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SnapForceBoundsToScene(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    
                    Pathfinding.UnityHelper.SnapForceBoundsToScene( 
                        _self );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Transform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.GraphTransform _self = (PF.GraphTransform)translator.GetObject(L, 1, typeof(PF.GraphTransform));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.Transform( 
                        _self, 
                        _bounds );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InverseTransform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.GraphTransform _self = (PF.GraphTransform)translator.GetObject(L, 1, typeof(PF.GraphTransform));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        UnityEngine.Bounds gen_ret = Pathfinding.UnityHelper.InverseTransform( 
                        _self, 
                        _bounds );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTouchingTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.NavmeshBase _self = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        PF.IntRect gen_ret = Pathfinding.UnityHelper.GetTouchingTiles( 
                        _self, 
                        _bounds );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTouchingTilesInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.NavmeshBase _self = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    UnityEngine.Rect _rect;translator.Get(L, 2, out _rect);
                    
                        PF.IntRect gen_ret = Pathfinding.UnityHelper.GetTouchingTilesInGraphSpace( 
                        _self, 
                        _rect );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReversesFaceOrientations_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 1, out _matrix);
                    
                        bool gen_ret = Pathfinding.UnityHelper.ReversesFaceOrientations( 
                        _matrix );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReversesFaceOrientationsXZ_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 1, out _matrix);
                    
                        bool gen_ret = Pathfinding.UnityHelper.ReversesFaceOrientationsXZ( 
                        _matrix );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IntToColor_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 1);
                    float _a = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Color gen_ret = Pathfinding.UnityHelper.IntToColor( 
                        _i, 
                        _a );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HSVToRGB_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _h = (float)LuaAPI.lua_tonumber(L, 1);
                    float _s = (float)LuaAPI.lua_tonumber(L, 2);
                    float _v = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Color gen_ret = Pathfinding.UnityHelper.HSVToRGB( 
                        _h, 
                        _s, 
                        _v );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnGraphPreScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.UnityHelper.OnGraphPreScan);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnGraphPostScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.UnityHelper.OnGraphPostScan);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnPreScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.UnityHelper.OnPreScan);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnPostScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.UnityHelper.OnPostScan);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnLatePostScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.UnityHelper.OnLatePostScan);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnGraphsUpdated(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.UnityHelper.OnGraphsUpdated);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnGraphPreScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.UnityHelper.OnGraphPreScan = translator.GetDelegate<Pathfinding.OnGraphDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnGraphPostScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.UnityHelper.OnGraphPostScan = translator.GetDelegate<Pathfinding.OnGraphDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnPreScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.UnityHelper.OnPreScan = translator.GetDelegate<Pathfinding.OnScanDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnPostScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.UnityHelper.OnPostScan = translator.GetDelegate<Pathfinding.OnScanDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnLatePostScan(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.UnityHelper.OnLatePostScan = translator.GetDelegate<Pathfinding.OnScanDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnGraphsUpdated(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Pathfinding.UnityHelper.OnGraphsUpdated = translator.GetDelegate<Pathfinding.OnScanDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
