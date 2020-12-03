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
    public class MicrosoftIORecyclableMemoryStreamWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Microsoft.IO.RecyclableMemoryStream);
			Utils.BeginObjectRegister(type, L, translator, 0, 21, 7, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Close", _m_Close);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBuffer", _m_GetBuffer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Read", _m_Read);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SafeRead", _m_SafeRead);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Write", _m_Write);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteByte", _m_WriteByte);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadByte", _m_ReadByte);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SafeReadByte", _m_SafeReadByte);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLength", _m_SetLength);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Seek", _m_Seek);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteTo", _m_WriteTo);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCapacity", _g_get_Capacity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLength", _g_get_Length);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPosition", _g_get_Position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCanRead", _g_get_CanRead);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCanSeek", _g_get_CanSeek);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCanTimeout", _g_get_CanTimeout);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCanWrite", _g_get_CanWrite);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setCapacity", _s_set_Capacity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPosition", _s_set_Position);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Capacity", _g_get_Capacity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Length", _g_get_Length);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Position", _g_get_Position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CanRead", _g_get_CanRead);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CanSeek", _g_get_CanSeek);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CanTimeout", _g_get_CanTimeout);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CanWrite", _g_get_CanWrite);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Capacity", _s_set_Capacity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Position", _s_set_Position);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Microsoft.IO.RecyclableMemoryStreamManager>(L, 2))
				{
					Microsoft.IO.RecyclableMemoryStreamManager _memoryManager = (Microsoft.IO.RecyclableMemoryStreamManager)translator.GetObject(L, 2, typeof(Microsoft.IO.RecyclableMemoryStreamManager));
					
					Microsoft.IO.RecyclableMemoryStream gen_ret = new Microsoft.IO.RecyclableMemoryStream(_memoryManager);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<Microsoft.IO.RecyclableMemoryStreamManager>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					Microsoft.IO.RecyclableMemoryStreamManager _memoryManager = (Microsoft.IO.RecyclableMemoryStreamManager)translator.GetObject(L, 2, typeof(Microsoft.IO.RecyclableMemoryStreamManager));
					string _tag = LuaAPI.lua_tostring(L, 3);
					
					Microsoft.IO.RecyclableMemoryStream gen_ret = new Microsoft.IO.RecyclableMemoryStream(_memoryManager, _tag);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<Microsoft.IO.RecyclableMemoryStreamManager>(L, 2) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					Microsoft.IO.RecyclableMemoryStreamManager _memoryManager = (Microsoft.IO.RecyclableMemoryStreamManager)translator.GetObject(L, 2, typeof(Microsoft.IO.RecyclableMemoryStreamManager));
					string _tag = LuaAPI.lua_tostring(L, 3);
					int _requestedSize = LuaAPI.xlua_tointeger(L, 4);
					
					Microsoft.IO.RecyclableMemoryStream gen_ret = new Microsoft.IO.RecyclableMemoryStream(_memoryManager, _tag, _requestedSize);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStream constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBuffer(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.GetBuffer(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Read(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 2);
                    int _offset = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                        int gen_ret = gen_to_be_invoked.Read( 
                        _buffer, 
                        _offset, 
                        _count );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SafeRead(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 2);
                    int _offset = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    int _streamPosition = LuaAPI.xlua_tointeger(L, 5);
                    
                        int gen_ret = gen_to_be_invoked.SafeRead( 
                        _buffer, 
                        _offset, 
                        _count, 
                        ref _streamPosition );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _streamPosition);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Write(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 2);
                    int _offset = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.Write( 
                        _buffer, 
                        _offset, 
                        _count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteByte(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.WriteByte( 
                        _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadByte(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.ReadByte(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SafeReadByte(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _streamPosition = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.SafeReadByte( 
                        ref _streamPosition );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _streamPosition);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLength(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _value = LuaAPI.lua_toint64(L, 2);
                    
                    gen_to_be_invoked.SetLength( 
                        _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Seek(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _offset = LuaAPI.lua_toint64(L, 2);
                    System.IO.SeekOrigin _loc;translator.Get(L, 3, out _loc);
                    
                        long gen_ret = gen_to_be_invoked.Seek( 
                        _offset, 
                        _loc );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteTo(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
                    
                    gen_to_be_invoked.WriteTo( 
                        _stream );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Capacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Capacity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Length(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.Length);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.Position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanRead(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.CanRead);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanSeek(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.CanSeek);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanTimeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.CanTimeout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanWrite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.CanWrite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Capacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Capacity = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStream gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStream)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Position = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
