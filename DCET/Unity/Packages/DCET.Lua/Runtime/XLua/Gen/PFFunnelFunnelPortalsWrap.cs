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
    public class PFFunnelFunnelPortalsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.Funnel.FunnelPortals);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 2, 2);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getleft", _g_get_left);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getright", _g_get_right);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setleft", _s_set_left);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setright", _s_set_right);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "left", _g_get_left);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "right", _g_get_right);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "left", _s_set_left);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "right", _s_set_right);
            
			
			
			
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
				PF.Funnel.FunnelPortals gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
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
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(PF.Funnel.FunnelPortals));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Funnel.FunnelPortals constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_left(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Funnel.FunnelPortals gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.left);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_right(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Funnel.FunnelPortals gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.right);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_left(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Funnel.FunnelPortals gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.left = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_right(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Funnel.FunnelPortals gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.right = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
