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
    public class PFGraphMetaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.GraphMeta);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 4, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGraphType", _m_GetGraphType);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getversion", _g_get_version);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getguids", _g_get_guids);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettypeNames", _g_get_typeNames);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setversion", _s_set_version);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphs", _s_set_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setguids", _s_set_guids);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settypeNames", _s_set_typeNames);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "version", _g_get_version);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "guids", _g_get_guids);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "typeNames", _g_get_typeNames);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "version", _s_set_version);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphs", _s_set_graphs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "guids", _s_set_guids);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "typeNames", _s_set_typeNames);
            
			
			
			
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
					
					PF.GraphMeta gen_ret = new PF.GraphMeta();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.GraphMeta constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGraphType(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Type gen_ret = gen_to_be_invoked.GetGraphType( 
                        _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.version);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.graphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_guids(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.guids);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_typeNames(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.typeNames);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.version = (System.Version)translator.GetObject(L, 2, typeof(System.Version));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphs = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_guids(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.guids = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_typeNames(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphMeta gen_to_be_invoked = (PF.GraphMeta)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.typeNames = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
