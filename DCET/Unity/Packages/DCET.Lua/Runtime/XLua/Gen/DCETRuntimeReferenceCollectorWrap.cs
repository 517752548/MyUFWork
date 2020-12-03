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
    public class DCETRuntimeReferenceCollectorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.ReferenceCollector);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 1, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObject", _m_GetObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnBeforeSerialize", _m_OnBeforeSerialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnAfterDeserialize", _m_OnAfterDeserialize);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdata", _g_get_data);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdata", _s_set_data);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "data", _g_get_data);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "data", _s_set_data);
            
			
			
			
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
					
					DCETRuntime.ReferenceCollector gen_ret = new DCETRuntime.ReferenceCollector();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.ReferenceCollector constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObject(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.ReferenceCollector gen_to_be_invoked = (DCETRuntime.ReferenceCollector)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Object gen_ret = gen_to_be_invoked.GetObject( 
                        _key );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBeforeSerialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.ReferenceCollector gen_to_be_invoked = (DCETRuntime.ReferenceCollector)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnBeforeSerialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnAfterDeserialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.ReferenceCollector gen_to_be_invoked = (DCETRuntime.ReferenceCollector)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnAfterDeserialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.ReferenceCollector gen_to_be_invoked = (DCETRuntime.ReferenceCollector)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.ReferenceCollector gen_to_be_invoked = (DCETRuntime.ReferenceCollector)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.data = (System.Collections.Generic.List<DCETRuntime.ReferenceCollectorData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<DCETRuntime.ReferenceCollectorData>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
