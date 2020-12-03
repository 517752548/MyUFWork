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
    public class PathfindingFunnelModifierWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.FunnelModifier);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 3, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOrder", _g_get_Order);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getunwrap", _g_get_unwrap);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsplitAtEveryPortal", _g_get_splitAtEveryPortal);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setunwrap", _s_set_unwrap);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsplitAtEveryPortal", _s_set_splitAtEveryPortal);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Order", _g_get_Order);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "unwrap", _g_get_unwrap);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "splitAtEveryPortal", _g_get_splitAtEveryPortal);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "unwrap", _s_set_unwrap);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "splitAtEveryPortal", _s_set_splitAtEveryPortal);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.FunnelModifier gen_ret = new Pathfinding.FunnelModifier();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.FunnelModifier constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.FunnelModifier gen_to_be_invoked = (Pathfinding.FunnelModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.Apply( 
                        _p );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Order(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.FunnelModifier gen_to_be_invoked = (Pathfinding.FunnelModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Order);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unwrap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.FunnelModifier gen_to_be_invoked = (Pathfinding.FunnelModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.unwrap);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_splitAtEveryPortal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.FunnelModifier gen_to_be_invoked = (Pathfinding.FunnelModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.splitAtEveryPortal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_unwrap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.FunnelModifier gen_to_be_invoked = (Pathfinding.FunnelModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.unwrap = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_splitAtEveryPortal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.FunnelModifier gen_to_be_invoked = (Pathfinding.FunnelModifier)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.splitAtEveryPortal = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
