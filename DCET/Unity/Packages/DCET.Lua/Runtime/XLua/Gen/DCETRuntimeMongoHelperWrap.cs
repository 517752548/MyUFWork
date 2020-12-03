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
    public class DCETRuntimeMongoHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.MongoHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 8, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "LookupTypes", _m_LookupTypes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToJson", _m_ToJson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromJson", _m_FromJson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToBson", _m_ToBson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromBson", _m_FromBson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromStream", _m_FromStream_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AvoidAOT", _m_AvoidAOT_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "DCETRuntime.MongoHelper does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LookupTypes_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.IEnumerable<System.Type> _types = (System.Collections.Generic.IEnumerable<System.Type>)translator.GetObject(L, 1, typeof(System.Collections.Generic.IEnumerable<System.Type>));
                    
                    DCETRuntime.MongoHelper.LookupTypes( 
                        _types );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToJson_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _obj = translator.GetObject(L, 1, typeof(object));
                    
                        string gen_ret = DCETRuntime.MongoHelper.ToJson( 
                        _obj );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<MongoDB.Bson.IO.JsonWriterSettings>(L, 2)) 
                {
                    object _obj = translator.GetObject(L, 1, typeof(object));
                    MongoDB.Bson.IO.JsonWriterSettings _settings = (MongoDB.Bson.IO.JsonWriterSettings)translator.GetObject(L, 2, typeof(MongoDB.Bson.IO.JsonWriterSettings));
                    
                        string gen_ret = DCETRuntime.MongoHelper.ToJson( 
                        _obj, 
                        _settings );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.MongoHelper.ToJson!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromJson_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    string _str = LuaAPI.lua_tostring(L, 2);
                    
                        object gen_ret = DCETRuntime.MongoHelper.FromJson( 
                        _type, 
                        _str );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToBson_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _obj = translator.GetObject(L, 1, typeof(object));
                    
                        byte[] gen_ret = DCETRuntime.MongoHelper.ToBson( 
                        _obj );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IO.MemoryStream>(L, 2)) 
                {
                    object _obj = translator.GetObject(L, 1, typeof(object));
                    System.IO.MemoryStream _stream = (System.IO.MemoryStream)translator.GetObject(L, 2, typeof(System.IO.MemoryStream));
                    
                    DCETRuntime.MongoHelper.ToBson( 
                        _obj, 
                        _stream );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.MongoHelper.ToBson!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromBson_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    
                        object gen_ret = DCETRuntime.MongoHelper.FromBson( 
                        _type, 
                        _bytes );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IO.Stream>(L, 2)) 
                {
                    object _instance = translator.GetObject(L, 1, typeof(object));
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
                    
                        object gen_ret = DCETRuntime.MongoHelper.FromBson( 
                        _instance, 
                        _stream );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<System.Type>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                        object gen_ret = DCETRuntime.MongoHelper.FromBson( 
                        _type, 
                        _bytes, 
                        _index, 
                        _count );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<object>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    object _instance = translator.GetObject(L, 1, typeof(object));
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                        object gen_ret = DCETRuntime.MongoHelper.FromBson( 
                        _instance, 
                        _bytes, 
                        _index, 
                        _count );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.MongoHelper.FromBson!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromStream_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
                    
                        object gen_ret = DCETRuntime.MongoHelper.FromStream( 
                        _type, 
                        _stream );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AvoidAOT_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    DCETRuntime.MongoHelper.AvoidAOT(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
