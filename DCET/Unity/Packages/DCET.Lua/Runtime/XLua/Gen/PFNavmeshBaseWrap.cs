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
using Pathfinding;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PFNavmeshBaseWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.NavmeshBase);
			Utils.BeginObjectRegister(type, L, translator, 0, 43, 12, 10);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTile", _m_GetTile);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertex", _m_GetVertex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexInGraphSpace", _m_GetVertexInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexArrayIndex", _m_GetVertexArrayIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTileCoordinates", _m_GetTileCoordinates);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTiles", _m_GetTiles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNodes", _m_GetNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearest", _m_GetNearest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestForce", _m_GetNearestForce);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FillWithEmptyTiles", _m_FillWithEmptyTiles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ConnectTiles", _m_ConnectTiles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateNodes", _m_CreateNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Linecast", _m_Linecast);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateTransform", _m_CalculateTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTileBounds", _m_GetTileBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTileBoundsInGraphSpace", _m_GetTileBoundsInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateNavmeshSurfaceVisualization", _m_CreateNavmeshSurfaceVisualization);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawUnwalkableNodes", _m_DrawUnwalkableNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTouchingTiles", _m_GetTouchingTiles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTouchingTilesInGraphSpace", _m_GetTouchingTilesInGraphSpace);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTileWorldSizeX", _g_get_TileWorldSizeX);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTileWorldSizeZ", _g_get_TileWorldSizeZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getforcedBoundsSize", _g_get_forcedBoundsSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowMeshOutline", _g_get_showMeshOutline);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowNodeConnections", _g_get_showNodeConnections);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowMeshSurface", _g_get_showMeshSurface);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettileXCount", _g_get_tileXCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettileZCount", _g_get_tileZCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettiles", _g_get_tiles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnearestSearchOnlyXZ", _g_get_nearestSearchOnlyXZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettransform", _g_get_transform);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOnRecalculatedTiles", _g_get_OnRecalculatedTiles);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setforcedBoundsSize", _s_set_forcedBoundsSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowMeshOutline", _s_set_showMeshOutline);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowNodeConnections", _s_set_showNodeConnections);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowMeshSurface", _s_set_showMeshSurface);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settileXCount", _s_set_tileXCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settileZCount", _s_set_tileZCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settiles", _s_set_tiles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnearestSearchOnlyXZ", _s_set_nearestSearchOnlyXZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settransform", _s_set_transform);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setOnRecalculatedTiles", _s_set_OnRecalculatedTiles);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "TileWorldSizeX", _g_get_TileWorldSizeX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TileWorldSizeZ", _g_get_TileWorldSizeZ);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "forcedBoundsSize", _g_get_forcedBoundsSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showMeshOutline", _g_get_showMeshOutline);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showNodeConnections", _g_get_showNodeConnections);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showMeshSurface", _g_get_showMeshSurface);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tileXCount", _g_get_tileXCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tileZCount", _g_get_tileZCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tiles", _g_get_tiles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nearestSearchOnlyXZ", _g_get_nearestSearchOnlyXZ);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "transform", _g_get_transform);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnRecalculatedTiles", _g_get_OnRecalculatedTiles);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "forcedBoundsSize", _s_set_forcedBoundsSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showMeshOutline", _s_set_showMeshOutline);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showNodeConnections", _s_set_showNodeConnections);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showMeshSurface", _s_set_showMeshSurface);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tileXCount", _s_set_tileXCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tileZCount", _s_set_tileZCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tiles", _s_set_tiles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nearestSearchOnlyXZ", _s_set_nearestSearchOnlyXZ);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "transform", _s_set_transform);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnRecalculatedTiles", _s_set_OnRecalculatedTiles);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 10, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTileIndex", _m_GetTileIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateNodeConnections", _m_CreateNodeConnections_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Linecast", _m_Linecast_xlua_st_);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getVertexIndexMask", PF.NavmeshBase.VertexIndexMask);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getTileIndexMask", PF.NavmeshBase.TileIndexMask);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getTileIndexOffset", PF.NavmeshBase.TileIndexOffset);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "VertexIndexMask", PF.NavmeshBase.VertexIndexMask);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TileIndexMask", PF.NavmeshBase.TileIndexMask);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TileIndexOffset", PF.NavmeshBase.TileIndexOffset);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.NavmeshBase does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTile(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    
                        PF.NavmeshTile gen_ret = gen_to_be_invoked.GetTile( 
                        _x, 
                        _z );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.GetVertex( 
                        _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertexInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.GetVertexInGraphSpace( 
                        _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileIndex_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 1);
                    
                        int gen_ret = PF.NavmeshBase.GetTileIndex( 
                        _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertexArrayIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetVertexArrayIndex( 
                        _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileCoordinates(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _tileIndex = LuaAPI.xlua_tointeger(L, 2);
                    int _x;
                    int _z;
                    
                    gen_to_be_invoked.GetTileCoordinates( 
                        _tileIndex, 
                        out _x, 
                        out _z );
                    LuaAPI.xlua_pushinteger(L, _x);
                        
                    LuaAPI.xlua_pushinteger(L, _z);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    
                        PF.Int2 gen_ret = gen_to_be_invoked.GetTileCoordinates( 
                        _position );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavmeshBase.GetTileCoordinates!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.NavmeshTile[] gen_ret = gen_to_be_invoked.GetTiles(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<PF.GraphNode> _action = translator.GetDelegate<System.Action<PF.GraphNode>>(L, 2);
                    
                    gen_to_be_invoked.GetNodes( 
                        _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearest(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.GetNearest( 
                        _position, 
                        _constraint, 
                        _hint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestForce(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.GetNearestForce( 
                        _position, 
                        _constraint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FillWithEmptyTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FillWithEmptyTiles(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateNodeConnections_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.TriangleMeshNode[] _nodes = (PF.TriangleMeshNode[])translator.GetObject(L, 1, typeof(PF.TriangleMeshNode[]));
                    
                    PF.NavmeshBase.CreateNodeConnections( 
                        _nodes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConnectTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavmeshTile _tile1 = (PF.NavmeshTile)translator.GetObject(L, 2, typeof(PF.NavmeshTile));
                    PF.NavmeshTile _tile2 = (PF.NavmeshTile)translator.GetObject(L, 3, typeof(PF.NavmeshTile));
                    
                    gen_to_be_invoked.ConnectTiles( 
                        _tile1, 
                        _tile2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.TriangleMeshNode[] _buffer = (PF.TriangleMeshNode[])translator.GetObject(L, 2, typeof(PF.TriangleMeshNode[]));
                    int[] _tris = (int[])translator.GetObject(L, 3, typeof(int[]));
                    int _tileIndex = LuaAPI.xlua_tointeger(L, 4);
                    uint _graphIndex = LuaAPI.xlua_touint(L, 5);
                    
                    gen_to_be_invoked.CreateNodes( 
                        _buffer, 
                        _tris, 
                        _tileIndex, 
                        _graphIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Linecast(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _origin;translator.Get(L, 2, out _origin);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _origin, 
                        _end );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)) 
                {
                    UnityEngine.Vector3 _origin;translator.Get(L, 2, out _origin);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _origin, 
                        _end, 
                        _hint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)) 
                {
                    UnityEngine.Vector3 _origin;translator.Get(L, 2, out _origin);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    PF.GraphHitInfo _hit;
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _origin, 
                        _end, 
                        _hint, 
                        out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 6)) 
                {
                    UnityEngine.Vector3 _origin;translator.Get(L, 2, out _origin);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    PF.GraphHitInfo _hit;
                    System.Collections.Generic.List<PF.GraphNode> _trace = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _origin, 
                        _end, 
                        _hint, 
                        out _hit, 
                        _trace );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavmeshBase.Linecast!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Linecast_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)) 
                {
                    PF.NavmeshBase _graph = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    UnityEngine.Vector3 _origin;translator.Get(L, 2, out _origin);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    PF.GraphHitInfo _hit;
                    
                        bool gen_ret = PF.NavmeshBase.Linecast( 
                        _graph, 
                        _origin, 
                        _end, 
                        _hint, 
                        out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 6)) 
                {
                    PF.NavmeshBase _graph = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    UnityEngine.Vector3 _origin;translator.Get(L, 2, out _origin);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    PF.GraphHitInfo _hit;
                    System.Collections.Generic.List<PF.GraphNode> _trace = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    
                        bool gen_ret = PF.NavmeshBase.Linecast( 
                        _graph, 
                        _origin, 
                        _end, 
                        _hint, 
                        out _hit, 
                        _trace );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavmeshBase.Linecast!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateTransform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.GraphTransform gen_ret = gen_to_be_invoked.CalculateTransform(  );
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
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _width = LuaAPI.xlua_tointeger(L, 4);
                    int _depth = LuaAPI.xlua_tointeger(L, 5);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBounds( 
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
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBounds( 
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
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBounds( 
                        _x,  
                        _z );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<PF.IntRect>(L, 2)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    PF.IntRect _rect;translator.Get(L, 2, out _rect);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBounds( 
                        _rect );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavmeshBase.GetTileBounds!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileBoundsInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.NavmeshBase>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _width = LuaAPI.xlua_tointeger(L, 4);
                    int _depth = LuaAPI.xlua_tointeger(L, 5);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBoundsInGraphSpace( 
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
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBoundsInGraphSpace( 
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
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBoundsInGraphSpace( 
                        _x,  
                        _z );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.NavmeshBase>(L, 1)&& translator.Assignable<PF.IntRect>(L, 2)) 
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    PF.IntRect _rect;translator.Get(L, 2, out _rect);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.GetTileBoundsInGraphSpace( 
                        _rect );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavmeshBase.GetTileBoundsInGraphSpace!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmos(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    Pathfinding.Util.RetainedGizmos _gizmos = (Pathfinding.Util.RetainedGizmos)translator.GetObject(L, 2, typeof(Pathfinding.Util.RetainedGizmos));
                    bool _drawNodes = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.OnDrawGizmos( 
                        _gizmos,  
                        _drawNodes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateNavmeshSurfaceVisualization(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    PF.NavmeshTile _tile = (PF.NavmeshTile)translator.GetObject(L, 2, typeof(PF.NavmeshTile));
                    Pathfinding.Util.GraphGizmoHelper _helper = (Pathfinding.Util.GraphGizmoHelper)translator.GetObject(L, 3, typeof(Pathfinding.Util.GraphGizmoHelper));
                    
                    gen_to_be_invoked.CreateNavmeshSurfaceVisualization( 
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
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavmeshBase _navmeshBase = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    float _size = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.DrawUnwalkableNodes( 
                        _size );
                    
                    
                    
                    return 0;
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
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavmeshBase _self = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.GetTouchingTiles( 
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
            
            
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavmeshBase _self = (PF.NavmeshBase)translator.GetObject(L, 1, typeof(PF.NavmeshBase));
                    UnityEngine.Rect _rect;translator.Get(L, 2, out _rect);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.GetTouchingTilesInGraphSpace( 
                        _rect );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TileWorldSizeX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.TileWorldSizeX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TileWorldSizeZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.TileWorldSizeZ);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_forcedBoundsSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.forcedBoundsSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showMeshOutline(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showMeshOutline);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showNodeConnections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showNodeConnections);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showMeshSurface(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showMeshSurface);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tileXCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.tileXCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tileZCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.tileZCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tiles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nearestSearchOnlyXZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.nearestSearchOnlyXZ);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.transform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnRecalculatedTiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnRecalculatedTiles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_forcedBoundsSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.forcedBoundsSize = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showMeshOutline(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showMeshOutline = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showNodeConnections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showNodeConnections = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showMeshSurface(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showMeshSurface = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tileXCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tileXCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tileZCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tileZCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tiles = (PF.NavmeshTile[])translator.GetObject(L, 2, typeof(PF.NavmeshTile[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nearestSearchOnlyXZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nearestSearchOnlyXZ = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_transform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.transform = (PF.GraphTransform)translator.GetObject(L, 2, typeof(PF.GraphTransform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnRecalculatedTiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshBase gen_to_be_invoked = (PF.NavmeshBase)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnRecalculatedTiles = translator.GetDelegate<System.Action<PF.NavmeshTile[]>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
