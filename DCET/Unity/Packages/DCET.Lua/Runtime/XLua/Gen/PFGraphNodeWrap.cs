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
    public class PFGraphNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.GraphNode);
			Utils.BeginObjectRegister(type, L, translator, 0, 33, 9, 7);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateRecursiveG", _m_UpdateRecursiveG);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FloodFill", _m_FloodFill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetConnections", _m_GetConnections);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddConnection", _m_AddConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveConnection", _m_RemoveConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearConnections", _m_ClearConnections);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContainsConnection", _m_ContainsConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RecalculateConnectionCosts", _m_RecalculateConnectionCosts);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPortal", _m_GetPortal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Open", _m_Open);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SurfaceArea", _m_SurfaceArea);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RandomPointOnSurface", _m_RandomPointOnSurface);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGizmoHashCode", _m_GetGizmoHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeNode", _m_SerializeNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeNode", _m_DeserializeNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeReferences", _m_SerializeReferences);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeReferences", _m_DeserializeReferences);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDestroyed", _g_get_Destroyed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getNodeIndex", _g_get_NodeIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getFlags", _g_get_Flags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPenalty", _g_get_Penalty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getWalkable", _g_get_Walkable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getArea", _g_get_Area);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getGraphIndex", _g_get_GraphIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTag", _g_get_Tag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getposition", _g_get_position);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setFlags", _s_set_Flags);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPenalty", _s_set_Penalty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setWalkable", _s_set_Walkable);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setArea", _s_set_Area);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setGraphIndex", _s_set_GraphIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setTag", _s_set_Tag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setposition", _s_set_position);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Destroyed", _g_get_Destroyed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "NodeIndex", _g_get_NodeIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Flags", _g_get_Flags);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Penalty", _g_get_Penalty);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Walkable", _g_get_Walkable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Area", _g_get_Area);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GraphIndex", _g_get_GraphIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Tag", _g_get_Tag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Flags", _s_set_Flags);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Penalty", _s_set_Penalty);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Walkable", _s_set_Walkable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Area", _s_set_Area);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "GraphIndex", _s_set_GraphIndex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Tag", _s_set_Tag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "position", _s_set_position);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getMaxAreaIndex", PF.GraphNode.MaxAreaIndex);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getMaxGraphIndex", PF.GraphNode.MaxGraphIndex);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MaxAreaIndex", PF.GraphNode.MaxAreaIndex);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MaxGraphIndex", PF.GraphNode.MaxGraphIndex);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.GraphNode does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateRecursiveG(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_FloodFill(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetConnections(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_AddConnection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    uint _cost = LuaAPI.xlua_touint(L, 3);
                    
                    gen_to_be_invoked.AddConnection( 
                        _node, 
                        _cost );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveConnection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_ClearConnections(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_ContainsConnection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_RecalculateConnectionCosts(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RecalculateConnectionCosts(  );
                    
                    
                    
                    return 0;
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
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _other = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    System.Collections.Generic.List<UnityEngine.Vector3> _left = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    System.Collections.Generic.List<UnityEngine.Vector3> _right = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    bool _backwards = LuaAPI.lua_toboolean(L, 5);
                    
                        bool gen_ret = gen_to_be_invoked.GetPortal( 
                        _other, 
                        _left, 
                        _right, 
                        _backwards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SurfaceArea(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_RandomPointOnSurface(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.RandomPointOnSurface(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
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
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SerializeNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SerializeReferences(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_Destroyed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.Destroyed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NodeIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.NodeIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Flags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.Flags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Penalty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.Penalty);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Walkable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.Walkable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.Area);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GraphIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.GraphIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.Tag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Flags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Flags = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Penalty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Penalty = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Walkable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Walkable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Area(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Area = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GraphIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GraphIndex = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Tag = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphNode gen_to_be_invoked = (PF.GraphNode)translator.FastGetCSObj(L, 1);
                PF.Int3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.position = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
