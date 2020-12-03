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
    public class PFGraphSerializationContextWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.GraphSerializationContext);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 4, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeNodeReference", _m_SerializeNodeReference);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeNodeReference", _m_DeserializeNodeReference);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeVector3", _m_SerializeVector3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeVector3", _m_DeserializeVector3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeInt3", _m_SerializeInt3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeInt3", _m_DeserializeInt3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeInt", _m_DeserializeInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeFloat", _m_DeserializeFloat);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getreader", _g_get_reader);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwriter", _g_get_writer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphIndex", _g_get_graphIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmeta", _g_get_meta);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "reader", _g_get_reader);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "writer", _g_get_writer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphIndex", _g_get_graphIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "meta", _g_get_meta);
            
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<System.IO.BinaryReader>(L, 2) && translator.Assignable<PF.GraphNode[]>(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && translator.Assignable<PF.GraphMeta>(L, 5))
				{
					System.IO.BinaryReader _reader = (System.IO.BinaryReader)translator.GetObject(L, 2, typeof(System.IO.BinaryReader));
					PF.GraphNode[] _id2NodeMapping = (PF.GraphNode[])translator.GetObject(L, 3, typeof(PF.GraphNode[]));
					uint _graphIndex = LuaAPI.xlua_touint(L, 4);
					PF.GraphMeta _meta = (PF.GraphMeta)translator.GetObject(L, 5, typeof(PF.GraphMeta));
					
					PF.GraphSerializationContext gen_ret = new PF.GraphSerializationContext(_reader, _id2NodeMapping, _graphIndex, _meta);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.IO.BinaryWriter>(L, 2))
				{
					System.IO.BinaryWriter _writer = (System.IO.BinaryWriter)translator.GetObject(L, 2, typeof(System.IO.BinaryWriter));
					
					PF.GraphSerializationContext gen_ret = new PF.GraphSerializationContext(_writer);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.GraphSerializationContext constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeNodeReference(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.SerializeNodeReference( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeNodeReference(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.GraphNode gen_ret = gen_to_be_invoked.DeserializeNodeReference(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeVector3(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _v;translator.Get(L, 2, out _v);
                    
                    gen_to_be_invoked.SerializeVector3( 
                        _v );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeVector3(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DeserializeVector3(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeInt3(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Int3 _v;translator.Get(L, 2, out _v);
                    
                    gen_to_be_invoked.SerializeInt3( 
                        _v );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeInt3(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.DeserializeInt3(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeInt(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _defaultValue = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.DeserializeInt( 
                        _defaultValue );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeFloat(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _defaultValue = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float gen_ret = gen_to_be_invoked.DeserializeFloat( 
                        _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.reader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_writer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.writer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.graphIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_meta(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.GraphSerializationContext gen_to_be_invoked = (PF.GraphSerializationContext)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.meta);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
