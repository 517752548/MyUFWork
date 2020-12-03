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
    public class PFGraphHitInfoWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.GraphHitInfo);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 6, 5);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdistance", _g_get_distance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getorigin", _g_get_origin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpoint", _g_get_point);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnode", _g_get_node);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettangentOrigin", _g_get_tangentOrigin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettangent", _g_get_tangent);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setorigin", _s_set_origin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpoint", _s_set_point);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnode", _s_set_node);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settangentOrigin", _s_set_tangentOrigin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settangent", _s_set_tangent);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "distance", _g_get_distance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "origin", _g_get_origin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "point", _g_get_point);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "node", _g_get_node);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tangentOrigin", _g_get_tangentOrigin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tangent", _g_get_tangent);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "origin", _s_set_origin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "point", _s_set_point);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "node", _s_set_node);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tangentOrigin", _s_set_tangentOrigin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tangent", _s_set_tangent);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
				translator.Push(L, gen_to_be_invoked);
				return 1;
			}
			catch (System.Exception e)
			{
				return LuaAPI.luaL_error(L, "c# exception in StructClone:" + e);
			}
		}
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.Vector3>(L, 2))
				{
					UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
					
					PF.GraphHitInfo gen_ret = new PF.GraphHitInfo(_point);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(PF.GraphHitInfo));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.GraphHitInfo constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_origin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.origin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_point(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.point);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_node(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.node);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tangentOrigin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.tangentOrigin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tangent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.tangent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_origin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.origin = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_point(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.point = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_node(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tangentOrigin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.tangentOrigin = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tangent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphHitInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.tangent = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
