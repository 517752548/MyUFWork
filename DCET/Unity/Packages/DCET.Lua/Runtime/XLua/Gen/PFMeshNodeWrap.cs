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
    public class PFMeshNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.MeshNode);
			Utils.BeginObjectRegister(type, L, translator, 0, 18, 1, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertex", _m_GetVertex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexCount", _m_GetVertexCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClosestPointOnNode", _m_ClosestPointOnNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClosestPointOnNodeXZ", _m_ClosestPointOnNodeXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearConnections", _m_ClearConnections);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetConnections", _m_GetConnections);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FloodFill", _m_FloodFill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContainsConnection", _m_ContainsConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateRecursiveG", _m_UpdateRecursiveG);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddConnection", _m_AddConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveConnection", _m_RemoveConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContainsPoint", _m_ContainsPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContainsPointInGraphSpace", _m_ContainsPointInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGizmoHashCode", _m_GetGizmoHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeReferences", _m_SerializeReferences);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeReferences", _m_DeserializeReferences);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconnections", _g_get_connections);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconnections", _s_set_connections);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "connections", _g_get_connections);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "connections", _s_set_connections);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.MeshNode does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetVertexCount(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_ClearConnections(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _alsoReverse = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.ClearConnections( 
                        _alsoReverse );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConnections(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<PF.GraphNode> _action = translator.GetDelegate<System.Action<PF.GraphNode>>(L, 2);
                    
                    gen_to_be_invoked.GetConnections( 
                        _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FloodFill(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.Stack<PF.GraphNode> _stack = (System.Collections.Generic.Stack<PF.GraphNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Stack<PF.GraphNode>));
                    uint _region = LuaAPI.xlua_touint(L, 3);
                    
                    gen_to_be_invoked.FloodFill( 
                        _stack, 
                        _region );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsConnection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.ContainsConnection( 
                        _node );
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
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_AddConnection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<PF.GraphNode>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    uint _cost = LuaAPI.xlua_touint(L, 3);
                    
                    gen_to_be_invoked.AddConnection( 
                        _node, 
                        _cost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.GraphNode>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    uint _cost = LuaAPI.xlua_touint(L, 3);
                    int _shapeEdge = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.AddConnection( 
                        _node, 
                        _cost, 
                        _shapeEdge );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.MeshNode.AddConnection!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveConnection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.RemoveConnection( 
                        _node );
                    
                    
                    
                    return 0;
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
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<PF.Int3>(L, 2)) 
                {
                    PF.Int3 _point;translator.Get(L, 2, out _point);
                    
                        bool gen_ret = gen_to_be_invoked.ContainsPoint( 
                        _point );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        bool gen_ret = gen_to_be_invoked.ContainsPoint( 
                        _point );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.MeshNode.ContainsPoint!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsPointInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Int3 _point;translator.Get(L, 2, out _point);
                    
                        bool gen_ret = gen_to_be_invoked.ContainsPointInGraphSpace( 
                        _point );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGizmoHashCode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetGizmoHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeReferences(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.SerializeReferences( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeReferences(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.DeserializeReferences( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_connections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.connections);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_connections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MeshNode gen_to_be_invoked = (PF.MeshNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.connections = (PF.Connection[])translator.GetObject(L, 2, typeof(PF.Connection[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
