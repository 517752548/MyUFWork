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
    public class PFAstarSerializerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.AstarSerializer);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetGraphIndexOffset", _m_SetGraphIndexOffset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChecksum", _m_GetChecksum);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OpenSerialize", _m_OpenSerialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseSerialize", _m_CloseSerialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeGraphs", _m_SerializeGraphs);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Serialize", _m_Serialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeExtraInfo", _m_SerializeExtraInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OpenDeserialize", _m_OpenDeserialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseDeserialize", _m_CloseDeserialize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeGraphs", _m_DeserializeGraphs);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeExtraInfo", _m_DeserializeExtraInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PostDeserialization", _m_PostDeserialization);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeEditorSettingsCompatibility", _m_DeserializeEditorSettingsCompatibility);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 9, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SaveToFile", _m_SaveToFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadFromFile", _m_LoadFromFile_xlua_st_);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getV3_8_3", PF.AstarSerializer.V3_8_3);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getV3_9_0", PF.AstarSerializer.V3_9_0);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getV4_1_0", PF.AstarSerializer.V4_1_0);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "V3_8_3", PF.AstarSerializer.V3_8_3);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "V3_9_0", PF.AstarSerializer.V3_9_0);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "V4_1_0", PF.AstarSerializer.V4_1_0);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.AstarSerializer gen_ret = new PF.AstarSerializer();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<PF.SerializeSettings>(L, 2))
				{
					PF.SerializeSettings _settings = (PF.SerializeSettings)translator.GetObject(L, 2, typeof(PF.SerializeSettings));
					
					PF.AstarSerializer gen_ret = new PF.AstarSerializer(_settings);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.AstarSerializer constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGraphIndexOffset(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _offset = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetGraphIndexOffset( 
                        _offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChecksum(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        uint gen_ret = gen_to_be_invoked.GetChecksum(  );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenSerialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OpenSerialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseSerialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.CloseSerialize(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeGraphs(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavGraph[] __graphs = (PF.NavGraph[])translator.GetObject(L, 2, typeof(PF.NavGraph[]));
                    
                    gen_to_be_invoked.SerializeGraphs( 
                        __graphs );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Serialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavGraph _graph = (PF.NavGraph)translator.GetObject(L, 2, typeof(PF.NavGraph));
                    
                        byte[] gen_ret = gen_to_be_invoked.Serialize( 
                        _graph );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SerializeExtraInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenDeserialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.OpenDeserialize( 
                        _bytes );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseDeserialize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CloseDeserialize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeGraphs(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.NavGraph[] gen_ret = gen_to_be_invoked.DeserializeGraphs(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
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
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DeserializeExtraInfo(  );
                    
                    
                    
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
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.PostDeserialization(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeEditorSettingsCompatibility(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.AstarSerializer gen_to_be_invoked = (PF.AstarSerializer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DeserializeEditorSettingsCompatibility(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveToFile_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    
                    PF.AstarSerializer.SaveToFile( 
                        _path, 
                        _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadFromFile_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        byte[] gen_ret = PF.AstarSerializer.LoadFromFile( 
                        _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
