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
    public class PFRandomPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.RandomPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 4, 4);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsearchLength", _g_get_searchLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getspread", _g_get_spread);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getaimStrength", _g_get_aimStrength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getaim", _g_get_aim);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsearchLength", _s_set_searchLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setspread", _s_set_spread);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setaimStrength", _s_set_aimStrength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setaim", _s_set_aim);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "searchLength", _g_get_searchLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "spread", _g_get_spread);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "aimStrength", _g_get_aimStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "aim", _g_get_aim);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "searchLength", _s_set_searchLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "spread", _s_set_spread);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "aimStrength", _s_set_aimStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "aim", _s_set_aim);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Construct", _m_Construct_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.RandomPath gen_ret = new PF.RandomPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.RandomPath constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<PF.OnPathDelegate>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    int _length = LuaAPI.xlua_tointeger(L, 2);
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 3);
                    
                        PF.RandomPath gen_ret = PF.RandomPath.Construct( 
                        _start, 
                        _length, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    int _length = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.RandomPath gen_ret = PF.RandomPath.Construct( 
                        _start, 
                        _length );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.RandomPath.Construct!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_searchLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.searchLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spread(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.spread);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_aimStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.aimStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_aim(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.aim);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_searchLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.searchLength = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spread(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.spread = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_aimStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.aimStrength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_aim(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RandomPath gen_to_be_invoked = (PF.RandomPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.aim = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
