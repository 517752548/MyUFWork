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
    public class PathfindingAstarColorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AstarColor);
			Utils.BeginObjectRegister(type, L, translator, 0, 15, 7, 7);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnable", _m_OnEnable);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_NodeConnection", _g_get__NodeConnection);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_UnwalkableNode", _g_get__UnwalkableNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_BoundsHandles", _g_get__BoundsHandles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ConnectionLowLerp", _g_get__ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_ConnectionHighLerp", _g_get__ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_MeshEdgeColor", _g_get__MeshEdgeColor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_AreaColors", _g_get__AreaColors);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_NodeConnection", _s_set__NodeConnection);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_UnwalkableNode", _s_set__UnwalkableNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_BoundsHandles", _s_set__BoundsHandles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ConnectionLowLerp", _s_set__ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_ConnectionHighLerp", _s_set__ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_MeshEdgeColor", _s_set__MeshEdgeColor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "set_AreaColors", _s_set__AreaColors);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "_NodeConnection", _g_get__NodeConnection);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_UnwalkableNode", _g_get__UnwalkableNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_BoundsHandles", _g_get__BoundsHandles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ConnectionLowLerp", _g_get__ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_ConnectionHighLerp", _g_get__ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_MeshEdgeColor", _g_get__MeshEdgeColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_AreaColors", _g_get__AreaColors);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "_NodeConnection", _s_set__NodeConnection);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_UnwalkableNode", _s_set__UnwalkableNode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_BoundsHandles", _s_set__BoundsHandles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ConnectionLowLerp", _s_set__ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_ConnectionHighLerp", _s_set__ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_MeshEdgeColor", _s_set__MeshEdgeColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_AreaColors", _s_set__AreaColors);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 26, 6, 6);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAreaColor", _m_GetAreaColor_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getNodeConnection", _g_get_NodeConnection);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getUnwalkableNode", _g_get_UnwalkableNode);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getBoundsHandles", _g_get_BoundsHandles);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getConnectionLowLerp", _g_get_ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getConnectionHighLerp", _g_get_ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getMeshEdgeColor", _g_get_MeshEdgeColor);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setNodeConnection", _s_set_NodeConnection);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setUnwalkableNode", _s_set_UnwalkableNode);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setBoundsHandles", _s_set_BoundsHandles);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setConnectionLowLerp", _s_set_ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setConnectionHighLerp", _s_set_ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setMeshEdgeColor", _s_set_MeshEdgeColor);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "NodeConnection", _g_get_NodeConnection);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UnwalkableNode", _g_get_UnwalkableNode);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "BoundsHandles", _g_get_BoundsHandles);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ConnectionLowLerp", _g_get_ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ConnectionHighLerp", _g_get_ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MeshEdgeColor", _g_get_MeshEdgeColor);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "NodeConnection", _s_set_NodeConnection);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "UnwalkableNode", _s_set_UnwalkableNode);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "BoundsHandles", _s_set_BoundsHandles);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ConnectionLowLerp", _s_set_ConnectionLowLerp);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ConnectionHighLerp", _s_set_ConnectionHighLerp);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "MeshEdgeColor", _s_set_MeshEdgeColor);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.AstarColor gen_ret = new Pathfinding.AstarColor();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarColor constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAreaColor_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    uint _area = LuaAPI.xlua_touint(L, 1);
                    
                        UnityEngine.Color gen_ret = Pathfinding.AstarColor.GetAreaColor( 
                        _area );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnable(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__NodeConnection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked._NodeConnection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__UnwalkableNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked._UnwalkableNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__BoundsHandles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked._BoundsHandles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ConnectionLowLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked._ConnectionLowLerp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__ConnectionHighLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked._ConnectionHighLerp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__MeshEdgeColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked._MeshEdgeColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__AreaColors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._AreaColors);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NodeConnection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Pathfinding.AstarColor.NodeConnection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UnwalkableNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Pathfinding.AstarColor.UnwalkableNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BoundsHandles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Pathfinding.AstarColor.BoundsHandles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConnectionLowLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Pathfinding.AstarColor.ConnectionLowLerp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConnectionHighLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Pathfinding.AstarColor.ConnectionHighLerp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MeshEdgeColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Pathfinding.AstarColor.MeshEdgeColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__NodeConnection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked._NodeConnection = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__UnwalkableNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked._UnwalkableNode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__BoundsHandles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked._BoundsHandles = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ConnectionLowLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked._ConnectionLowLerp = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__ConnectionHighLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked._ConnectionHighLerp = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__MeshEdgeColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked._MeshEdgeColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__AreaColors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarColor gen_to_be_invoked = (Pathfinding.AstarColor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._AreaColors = (UnityEngine.Color[])translator.GetObject(L, 2, typeof(UnityEngine.Color[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NodeConnection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AstarColor.NodeConnection = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UnwalkableNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AstarColor.UnwalkableNode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BoundsHandles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AstarColor.BoundsHandles = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConnectionLowLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AstarColor.ConnectionLowLerp = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConnectionHighLerp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AstarColor.ConnectionHighLerp = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MeshEdgeColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Pathfinding.AstarColor.MeshEdgeColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
