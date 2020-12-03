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
    public class BehaviorDesignerRuntimeTasksRepeaterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(BehaviorDesigner.Runtime.Tasks.Repeater);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 3, 3);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanExecute", _m_CanExecute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnChildExecuted", _m_OnChildExecuted);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnd", _m_OnEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnReset", _m_OnReset);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcount", _g_get_count);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrepeatForever", _g_get_repeatForever);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getendOnFailure", _g_get_endOnFailure);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcount", _s_set_count);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrepeatForever", _s_set_repeatForever);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setendOnFailure", _s_set_endOnFailure);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "count", _g_get_count);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "repeatForever", _g_get_repeatForever);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endOnFailure", _g_get_endOnFailure);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "count", _s_set_count);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "repeatForever", _s_set_repeatForever);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endOnFailure", _s_set_endOnFailure);
            
			
			
			
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
					
					BehaviorDesigner.Runtime.Tasks.Repeater gen_ret = new BehaviorDesigner.Runtime.Tasks.Repeater();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to BehaviorDesigner.Runtime.Tasks.Repeater constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanExecute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.CanExecute(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnChildExecuted(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BehaviorDesigner.Runtime.Tasks.TaskStatus _childStatus;translator.Get(L, 2, out _childStatus);
                    
                    gen_to_be_invoked.OnChildExecuted( 
                        _childStatus );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnd(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnd(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnReset(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnReset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.count);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_repeatForever(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.repeatForever);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endOnFailure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.endOnFailure);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.count = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_repeatForever(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.repeatForever = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endOnFailure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                BehaviorDesigner.Runtime.Tasks.Repeater gen_to_be_invoked = (BehaviorDesigner.Runtime.Tasks.Repeater)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.endOnFailure = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
