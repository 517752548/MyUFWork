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
    public class PFTriangleMeshNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.TriangleMeshNode);
			Utils.BeginObjectRegister(type, L, translator, 0, 25, 3, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdatePositionFromVertices", _m_UpdatePositionFromVertices);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexIndex", _m_GetVertexIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexArrayIndex", _m_GetVertexArrayIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertices", _m_GetVertices);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVerticesInGraphSpace", _m_GetVerticesInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertex", _m_GetVertex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexInGraphSpace", _m_GetVertexInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexCount", _m_GetVertexCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClosestPointOnNode", _m_ClosestPointOnNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClosestPointOnNodeXZ", _m_ClosestPointOnNodeXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContainsPoint", _m_ContainsPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContainsPointInGraphSpace", _m_ContainsPointInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateRecursiveG", _m_UpdateRecursiveG);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Open", _m_Open);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SharedEdge", _m_SharedEdge);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPortal", _m_GetPortal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SurfaceArea", _m_SurfaceArea);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeNode", _m_SerializeNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeNode", _m_DeserializeNode);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getv0", _g_get_v0);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getv1", _g_get_v1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getv2", _g_get_v2);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setv0", _s_set_v0);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setv1", _s_set_v1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setv2", _s_set_v2);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "v0", _g_get_v0);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "v1", _g_get_v1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "v2", _g_get_v2);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "v0", _s_set_v0);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "v1", _s_set_v1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "v2", _s_set_v2);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetNavmeshHolder", _m_GetNavmeshHolder_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetNavmeshHolder", _m_SetNavmeshHolder_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.TriangleMeshNode gen_ret = new PF.TriangleMeshNode();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.TriangleMeshNode constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNavmeshHolder_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    uint _graphIndex = LuaAPI.xlua_touint(L, 1);
                    
                        PF.INavmeshHolder gen_ret = PF.TriangleMeshNode.GetNavmeshHolder( 
                        _graphIndex );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNavmeshHolder_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _graphIndex = LuaAPI.xlua_tointeger(L, 1);
                    PF.INavmeshHolder _graph = (PF.INavmeshHolder)translator.GetObject(L, 2, typeof(PF.INavmeshHolder));
                    
                    PF.TriangleMeshNode.SetNavmeshHolder( 
                        _graphIndex, 
                        _graph );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePositionFromVertices(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdatePositionFromVertices(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertexIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetVertexIndex( 
                        _i );
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
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetVertexArrayIndex( 
                        _i );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertices(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Int3 _v0;
                    PF.Int3 _v1;
                    PF.Int3 _v2;
                    
                    gen_to_be_invoked.GetVertices( 
                        out _v0, 
                        out _v1, 
                        out _v2 );
                    translator.Push(L, _v0);
                        
                    translator.Push(L, _v1);
                        
                    translator.Push(L, _v2);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVerticesInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Int3 _v0;
                    PF.Int3 _v1;
                    PF.Int3 _v2;
                    
                    gen_to_be_invoked.GetVerticesInGraphSpace( 
                        out _v0, 
                        out _v1, 
                        out _v2 );
                    translator.Push(L, _v0);
                        
                    translator.Push(L, _v1);
                        
                    translator.Push(L, _v2);
                        
                    
                    
                    
                    return 3;
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
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.GetVertex( 
                        _i );
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
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.GetVertexInGraphSpace( 
                        _i );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertexCount(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetVertexCount(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.ClosestPointOnNode( 
                        _p );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPointOnNodeXZ(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.ClosestPointOnNodeXZ( 
                        _p );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsPoint(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        bool gen_ret = gen_to_be_invoked.ContainsPoint( 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsPointInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Int3 _p;translator.Get(L, 2, out _p);
                    
                        bool gen_ret = gen_to_be_invoked.ContainsPointInGraphSpace( 
                        _p );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateRecursiveG(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    PF.PathNode _pathNode = (PF.PathNode)translator.GetObject(L, 3, typeof(PF.PathNode));
                    PF.PathHandler _handler = (PF.PathHandler)translator.GetObject(L, 4, typeof(PF.PathHandler));
                    
                    gen_to_be_invoked.UpdateRecursiveG( 
                        _path, 
                        _pathNode, 
                        _handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Open(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    PF.PathNode _pathNode = (PF.PathNode)translator.GetObject(L, 3, typeof(PF.PathNode));
                    PF.PathHandler _handler = (PF.PathHandler)translator.GetObject(L, 4, typeof(PF.PathHandler));
                    
                    gen_to_be_invoked.Open( 
                        _path, 
                        _pathNode, 
                        _handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SharedEdge(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _other = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        int gen_ret = gen_to_be_invoked.SharedEdge( 
                        _other );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPortal(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.GraphNode>(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Vector3>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Vector3>>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    PF.GraphNode _toNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    System.Collections.Generic.List<UnityEngine.Vector3> _left = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    System.Collections.Generic.List<UnityEngine.Vector3> _right = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    bool _backwards = LuaAPI.lua_toboolean(L, 5);
                    
                        bool gen_ret = gen_to_be_invoked.GetPortal( 
                        _toNode, 
                        _left, 
                        _right, 
                        _backwards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& translator.Assignable<PF.GraphNode>(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Vector3>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Vector3>>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    PF.GraphNode _toNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    System.Collections.Generic.List<UnityEngine.Vector3> _left = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    System.Collections.Generic.List<UnityEngine.Vector3> _right = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    bool _backwards = LuaAPI.lua_toboolean(L, 5);
                    int _aIndex;
                    int _bIndex;
                    
                        bool gen_ret = gen_to_be_invoked.GetPortal( 
                        _toNode, 
                        _left, 
                        _right, 
                        _backwards, 
                        out _aIndex, 
                        out _bIndex );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _aIndex);
                        
                    LuaAPI.xlua_pushinteger(L, _bIndex);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.TriangleMeshNode.GetPortal!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SurfaceArea(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.SurfaceArea(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.SerializeNode( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.DeserializeNode( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_v0(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.v0);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_v1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.v1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_v2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.v2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_v0(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.v0 = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_v1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.v1 = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_v2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.TriangleMeshNode gen_to_be_invoked = (PF.TriangleMeshNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.v2 = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
