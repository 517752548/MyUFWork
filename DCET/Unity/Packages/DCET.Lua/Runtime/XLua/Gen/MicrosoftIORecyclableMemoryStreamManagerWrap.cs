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
    public class MicrosoftIORecyclableMemoryStreamManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Microsoft.IO.RecyclableMemoryStreamManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 50, 14, 5);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetStream", _m_GetStream);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getBlockSize", _g_get_BlockSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLargeBufferMultiple", _g_get_LargeBufferMultiple);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMaximumBufferSize", _g_get_MaximumBufferSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getSmallPoolFreeSize", _g_get_SmallPoolFreeSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getSmallPoolInUseSize", _g_get_SmallPoolInUseSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLargePoolFreeSize", _g_get_LargePoolFreeSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLargePoolInUseSize", _g_get_LargePoolInUseSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getSmallBlocksFree", _g_get_SmallBlocksFree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getLargeBuffersFree", _g_get_LargeBuffersFree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMaximumFreeSmallPoolBytes", _g_get_MaximumFreeSmallPoolBytes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMaximumFreeLargePoolBytes", _g_get_MaximumFreeLargePoolBytes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getMaximumStreamCapacity", _g_get_MaximumStreamCapacity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getGenerateCallStacks", _g_get_GenerateCallStacks);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getAggressiveBufferReturn", _g_get_AggressiveBufferReturn);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setMaximumFreeSmallPoolBytes", _s_set_MaximumFreeSmallPoolBytes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setMaximumFreeLargePoolBytes", _s_set_MaximumFreeLargePoolBytes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setMaximumStreamCapacity", _s_set_MaximumStreamCapacity);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setGenerateCallStacks", _s_set_GenerateCallStacks);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setAggressiveBufferReturn", _s_set_AggressiveBufferReturn);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addBlockCreated", _e_add_BlockCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addBlockDiscarded", _e_add_BlockDiscarded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addLargeBufferCreated", _e_add_LargeBufferCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addStreamCreated", _e_add_StreamCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addStreamDisposed", _e_add_StreamDisposed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addStreamFinalized", _e_add_StreamFinalized);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addStreamLength", _e_add_StreamLength);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addStreamConvertedToArray", _e_add_StreamConvertedToArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addLargeBufferDiscarded", _e_add_LargeBufferDiscarded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addUsageReport", _e_add_UsageReport);
						
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeBlockCreated", _e_remove_BlockCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeBlockDiscarded", _e_remove_BlockDiscarded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeLargeBufferCreated", _e_remove_LargeBufferCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeStreamCreated", _e_remove_StreamCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeStreamDisposed", _e_remove_StreamDisposed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeStreamFinalized", _e_remove_StreamFinalized);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeStreamLength", _e_remove_StreamLength);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeStreamConvertedToArray", _e_remove_StreamConvertedToArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeLargeBufferDiscarded", _e_remove_LargeBufferDiscarded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeUsageReport", _e_remove_UsageReport);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BlockCreated", _e_BlockCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BlockDiscarded", _e_BlockDiscarded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LargeBufferCreated", _e_LargeBufferCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StreamCreated", _e_StreamCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StreamDisposed", _e_StreamDisposed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StreamFinalized", _e_StreamFinalized);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StreamLength", _e_StreamLength);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StreamConvertedToArray", _e_StreamConvertedToArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LargeBufferDiscarded", _e_LargeBufferDiscarded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UsageReport", _e_UsageReport);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "BlockSize", _g_get_BlockSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LargeBufferMultiple", _g_get_LargeBufferMultiple);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaximumBufferSize", _g_get_MaximumBufferSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SmallPoolFreeSize", _g_get_SmallPoolFreeSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SmallPoolInUseSize", _g_get_SmallPoolInUseSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LargePoolFreeSize", _g_get_LargePoolFreeSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LargePoolInUseSize", _g_get_LargePoolInUseSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SmallBlocksFree", _g_get_SmallBlocksFree);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LargeBuffersFree", _g_get_LargeBuffersFree);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaximumFreeSmallPoolBytes", _g_get_MaximumFreeSmallPoolBytes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaximumFreeLargePoolBytes", _g_get_MaximumFreeLargePoolBytes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaximumStreamCapacity", _g_get_MaximumStreamCapacity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GenerateCallStacks", _g_get_GenerateCallStacks);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AggressiveBufferReturn", _g_get_AggressiveBufferReturn);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaximumFreeSmallPoolBytes", _s_set_MaximumFreeSmallPoolBytes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaximumFreeLargePoolBytes", _s_set_MaximumFreeLargePoolBytes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaximumStreamCapacity", _s_set_MaximumStreamCapacity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "GenerateCallStacks", _s_set_GenerateCallStacks);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AggressiveBufferReturn", _s_set_AggressiveBufferReturn);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 0, 0);
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getDefaultBlockSize", Microsoft.IO.RecyclableMemoryStreamManager.DefaultBlockSize);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getDefaultLargeBufferMultiple", Microsoft.IO.RecyclableMemoryStreamManager.DefaultLargeBufferMultiple);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getDefaultMaximumBufferSize", Microsoft.IO.RecyclableMemoryStreamManager.DefaultMaximumBufferSize);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultBlockSize", Microsoft.IO.RecyclableMemoryStreamManager.DefaultBlockSize);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultLargeBufferMultiple", Microsoft.IO.RecyclableMemoryStreamManager.DefaultLargeBufferMultiple);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultMaximumBufferSize", Microsoft.IO.RecyclableMemoryStreamManager.DefaultMaximumBufferSize);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Microsoft.IO.RecyclableMemoryStreamManager gen_ret = new Microsoft.IO.RecyclableMemoryStreamManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					int _blockSize = LuaAPI.xlua_tointeger(L, 2);
					int _largeBufferMultiple = LuaAPI.xlua_tointeger(L, 3);
					int _maximumBufferSize = LuaAPI.xlua_tointeger(L, 4);
					
					Microsoft.IO.RecyclableMemoryStreamManager gen_ret = new Microsoft.IO.RecyclableMemoryStreamManager(_blockSize, _largeBufferMultiple, _maximumBufferSize);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStream(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        System.IO.MemoryStream gen_ret = gen_to_be_invoked.GetStream(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _tag = LuaAPI.lua_tostring(L, 2);
                    
                        System.IO.MemoryStream gen_ret = gen_to_be_invoked.GetStream( 
                        _tag );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _tag = LuaAPI.lua_tostring(L, 2);
                    int _requiredSize = LuaAPI.xlua_tointeger(L, 3);
                    
                        System.IO.MemoryStream gen_ret = gen_to_be_invoked.GetStream( 
                        _tag, 
                        _requiredSize );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _tag = LuaAPI.lua_tostring(L, 2);
                    int _requiredSize = LuaAPI.xlua_tointeger(L, 3);
                    bool _asContiguousBuffer = LuaAPI.lua_toboolean(L, 4);
                    
                        System.IO.MemoryStream gen_ret = gen_to_be_invoked.GetStream( 
                        _tag, 
                        _requiredSize, 
                        _asContiguousBuffer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    string _tag = LuaAPI.lua_tostring(L, 2);
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 3);
                    int _offset = LuaAPI.xlua_tointeger(L, 4);
                    int _count = LuaAPI.xlua_tointeger(L, 5);
                    
                        System.IO.MemoryStream gen_ret = gen_to_be_invoked.GetStream( 
                        _tag, 
                        _buffer, 
                        _offset, 
                        _count );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.GetStream!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BlockSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BlockSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LargeBufferMultiple(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LargeBufferMultiple);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaximumBufferSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaximumBufferSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SmallPoolFreeSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.SmallPoolFreeSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SmallPoolInUseSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.SmallPoolInUseSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LargePoolFreeSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.LargePoolFreeSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LargePoolInUseSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.LargePoolInUseSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SmallBlocksFree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.SmallBlocksFree);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LargeBuffersFree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.LargeBuffersFree);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaximumFreeSmallPoolBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.MaximumFreeSmallPoolBytes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaximumFreeLargePoolBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.MaximumFreeLargePoolBytes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaximumStreamCapacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.MaximumStreamCapacity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GenerateCallStacks(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.GenerateCallStacks);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AggressiveBufferReturn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.AggressiveBufferReturn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaximumFreeSmallPoolBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaximumFreeSmallPoolBytes = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaximumFreeLargePoolBytes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaximumFreeLargePoolBytes = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaximumStreamCapacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaximumStreamCapacity = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GenerateCallStacks(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GenerateCallStacks = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AggressiveBufferReturn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AggressiveBufferReturn = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_BlockCreated(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.BlockCreated += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.BlockCreated -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.BlockCreated!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_BlockDiscarded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.BlockDiscarded += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.BlockDiscarded -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.BlockDiscarded!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_LargeBufferCreated(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.LargeBufferCreated += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.LargeBufferCreated -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferCreated!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_StreamCreated(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.StreamCreated += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.StreamCreated -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamCreated!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_StreamDisposed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.StreamDisposed += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.StreamDisposed -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamDisposed!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_StreamFinalized(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.StreamFinalized += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.StreamFinalized -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamFinalized!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_StreamLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.StreamLength += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.StreamLength -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamLength!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_StreamConvertedToArray(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.StreamConvertedToArray += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.StreamConvertedToArray -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamConvertedToArray!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_LargeBufferDiscarded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.LargeBufferDiscarded += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.LargeBufferDiscarded -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscarded!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_UsageReport(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
                Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.UsageReport += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.UsageReport -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.UsageReport!");
            return 0;
        }
        
		
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_BlockCreated(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.BlockCreated += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.BlockCreated!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_BlockDiscarded(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.BlockDiscarded += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.BlockDiscarded!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_LargeBufferCreated(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.LargeBufferCreated += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferCreated!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_StreamCreated(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamCreated += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamCreated!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_StreamDisposed(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamDisposed += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamDisposed!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_StreamFinalized(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamFinalized += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamFinalized!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_StreamLength(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamLength += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamLength!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_StreamConvertedToArray(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamConvertedToArray += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamConvertedToArray!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_LargeBufferDiscarded(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.LargeBufferDiscarded += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscarded!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_UsageReport(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.UsageReport += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.UsageReport!");
			return 0;
		}
		

		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_BlockCreated(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.BlockCreated -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.BlockCreated!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_BlockDiscarded(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.BlockDiscarded -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.BlockDiscarded!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_LargeBufferCreated(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.LargeBufferCreated -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferCreated!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_StreamCreated(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamCreated -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamCreated!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_StreamDisposed(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamDisposed -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamDisposed!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_StreamFinalized(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamFinalized -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamFinalized!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_StreamLength(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.StreamLengthReportHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamLength -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamLength!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_StreamConvertedToArray(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.EventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.EventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.EventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.StreamConvertedToArray -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.StreamConvertedToArray!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_LargeBufferDiscarded(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscardedEventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.LargeBufferDiscarded -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.LargeBufferDiscarded!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_UsageReport(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			Microsoft.IO.RecyclableMemoryStreamManager gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager)translator.FastGetCSObj(L, 1);
				Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler gen_delegate = translator.GetDelegate<Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need Microsoft.IO.RecyclableMemoryStreamManager.UsageReportEventHandler!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.UsageReport -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.UsageReport!");
			return 0;
		}
		
		
		
		
		
		
		
    }
}
