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
    public class PFBinaryHeapWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.BinaryHeap);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 3, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Add", _m_Add);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Remove", _m_Remove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Rebuild", _m_Rebuild);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getisEmpty", _g_get_isEmpty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnumberOfItems", _g_get_numberOfItems);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgrowthFactor", _g_get_growthFactor);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnumberOfItems", _s_set_numberOfItems);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgrowthFactor", _s_set_growthFactor);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "isEmpty", _g_get_isEmpty);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "numberOfItems", _g_get_numberOfItems);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "growthFactor", _g_get_growthFactor);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "numberOfItems", _s_set_numberOfItems);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "growthFactor", _s_set_growthFactor);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getNotInHeap", PF.BinaryHeap.NotInHeap);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NotInHeap", PF.BinaryHeap.NotInHeap);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					int _capacity = LuaAPI.xlua_tointeger(L, 2);
					
					PF.BinaryHeap gen_ret = new PF.BinaryHeap(_capacity);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.BinaryHeap constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.PathNode _node = (PF.PathNode)translator.GetObject(L, 2, typeof(PF.PathNode));
                    
                    gen_to_be_invoked.Add( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.PathNode gen_ret = gen_to_be_invoked.Remove(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rebuild(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Rebuild(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isEmpty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isEmpty);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_numberOfItems(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.numberOfItems);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_growthFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.growthFactor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_numberOfItems(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.numberOfItems = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_growthFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.BinaryHeap gen_to_be_invoked = (PF.BinaryHeap)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.growthFactor = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
