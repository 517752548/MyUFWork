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
    public class MicrosoftIORecyclableMemoryStreamManagerEventsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events);
			Utils.BeginObjectRegister(type, L, translator, 0, 11, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamCreated", _m_MemoryStreamCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamDisposed", _m_MemoryStreamDisposed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamDoubleDispose", _m_MemoryStreamDoubleDispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamFinalized", _m_MemoryStreamFinalized);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamToArray", _m_MemoryStreamToArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamManagerInitialized", _m_MemoryStreamManagerInitialized);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamNewBlockCreated", _m_MemoryStreamNewBlockCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamNewLargeBufferCreated", _m_MemoryStreamNewLargeBufferCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamNonPooledLargeBufferCreated", _m_MemoryStreamNonPooledLargeBufferCreated);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamDiscardBuffer", _m_MemoryStreamDiscardBuffer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MemoryStreamOverCapacity", _m_MemoryStreamOverCapacity);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 1, 1);
			
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getWriter", _g_get_Writer);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setWriter", _s_set_Writer);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Writer", _g_get_Writer);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Writer", _s_set_Writer);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Microsoft.IO.RecyclableMemoryStreamManager.Events gen_ret = new Microsoft.IO.RecyclableMemoryStreamManager.Events();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Microsoft.IO.RecyclableMemoryStreamManager.Events constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamCreated(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Guid _guid;translator.Get(L, 2, out _guid);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    int _requestedSize = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.MemoryStreamCreated( 
                        _guid, 
                        _tag, 
                        _requestedSize );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamDisposed(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Guid _guid;translator.Get(L, 2, out _guid);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.MemoryStreamDisposed( 
                        _guid, 
                        _tag );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamDoubleDispose(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Guid _guid;translator.Get(L, 2, out _guid);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    string _allocationStack = LuaAPI.lua_tostring(L, 4);
                    string _disposeStack1 = LuaAPI.lua_tostring(L, 5);
                    string _disposeStack2 = LuaAPI.lua_tostring(L, 6);
                    
                    gen_to_be_invoked.MemoryStreamDoubleDispose( 
                        _guid, 
                        _tag, 
                        _allocationStack, 
                        _disposeStack1, 
                        _disposeStack2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamFinalized(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Guid _guid;translator.Get(L, 2, out _guid);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    string _allocationStack = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.MemoryStreamFinalized( 
                        _guid, 
                        _tag, 
                        _allocationStack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamToArray(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Guid _guid;translator.Get(L, 2, out _guid);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    string _stack = LuaAPI.lua_tostring(L, 4);
                    int _size = LuaAPI.xlua_tointeger(L, 5);
                    
                    gen_to_be_invoked.MemoryStreamToArray( 
                        _guid, 
                        _tag, 
                        _stack, 
                        _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamManagerInitialized(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _blockSize = LuaAPI.xlua_tointeger(L, 2);
                    int _largeBufferMultiple = LuaAPI.xlua_tointeger(L, 3);
                    int _maximumBufferSize = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.MemoryStreamManagerInitialized( 
                        _blockSize, 
                        _largeBufferMultiple, 
                        _maximumBufferSize );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamNewBlockCreated(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _smallPoolInUseBytes = LuaAPI.lua_toint64(L, 2);
                    
                    gen_to_be_invoked.MemoryStreamNewBlockCreated( 
                        _smallPoolInUseBytes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamNewLargeBufferCreated(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _requiredSize = LuaAPI.xlua_tointeger(L, 2);
                    long _largePoolInUseBytes = LuaAPI.lua_toint64(L, 3);
                    
                    gen_to_be_invoked.MemoryStreamNewLargeBufferCreated( 
                        _requiredSize, 
                        _largePoolInUseBytes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamNonPooledLargeBufferCreated(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _requiredSize = LuaAPI.xlua_tointeger(L, 2);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    string _allocationStack = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.MemoryStreamNonPooledLargeBufferCreated( 
                        _requiredSize, 
                        _tag, 
                        _allocationStack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamDiscardBuffer(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType _bufferType;translator.Get(L, 2, out _bufferType);
                    string _tag = LuaAPI.lua_tostring(L, 3);
                    Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason _reason;translator.Get(L, 4, out _reason);
                    
                    gen_to_be_invoked.MemoryStreamDiscardBuffer( 
                        _bufferType, 
                        _tag, 
                        _reason );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MemoryStreamOverCapacity(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Microsoft.IO.RecyclableMemoryStreamManager.Events gen_to_be_invoked = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _requestedCapacity = LuaAPI.xlua_tointeger(L, 2);
                    long _maxCapacity = LuaAPI.lua_toint64(L, 3);
                    string _tag = LuaAPI.lua_tostring(L, 4);
                    string _allocationStack = LuaAPI.lua_tostring(L, 5);
                    
                    gen_to_be_invoked.MemoryStreamOverCapacity( 
                        _requestedCapacity, 
                        _maxCapacity, 
                        _tag, 
                        _allocationStack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Writer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Microsoft.IO.RecyclableMemoryStreamManager.Events.Writer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Writer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Microsoft.IO.RecyclableMemoryStreamManager.Events.Writer = (Microsoft.IO.RecyclableMemoryStreamManager.Events)translator.GetObject(L, 1, typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
