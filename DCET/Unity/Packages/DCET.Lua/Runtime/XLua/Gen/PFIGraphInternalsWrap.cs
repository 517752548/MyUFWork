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
    public class PFIGraphInternalsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.IGraphInternals);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 1, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DestroyAllNodes", _m_DestroyAllNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeExtraInfo", _m_SerializeExtraInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeExtraInfo", _m_DeserializeExtraInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PostDeserialization", _m_PostDeserialization);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeSettingsCompatibility", _m_DeserializeSettingsCompatibility);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getSerializedEditorSettings", _g_get_SerializedEditorSettings);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setSerializedEditorSettings", _s_set_SerializedEditorSettings);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "SerializedEditorSettings", _g_get_SerializedEditorSettings);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "SerializedEditorSettings", _s_set_SerializedEditorSettings);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.IGraphInternals does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyAllNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DestroyAllNodes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeExtraInfo(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.SerializeExtraInfo( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeExtraInfo(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.DeserializeExtraInfo( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostDeserialization(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.PostDeserialization( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeSettingsCompatibility(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphSerializationContext _ctx = (PF.GraphSerializationContext)translator.GetObject(L, 2, typeof(PF.GraphSerializationContext));
                    
                    gen_to_be_invoked.DeserializeSettingsCompatibility( 
                        _ctx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SerializedEditorSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SerializedEditorSettings);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SerializedEditorSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IGraphInternals gen_to_be_invoked = (PF.IGraphInternals)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SerializedEditorSettings = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
