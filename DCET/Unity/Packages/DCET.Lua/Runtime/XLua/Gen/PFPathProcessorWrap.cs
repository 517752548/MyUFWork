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
    public class PFPathProcessorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.PathProcessor);
			Utils.BeginObjectRegister(type, L, translator, 0, 19, 2, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PausePathfinding", _m_PausePathfinding);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TickNonMultithreaded", _m_TickNonMultithreaded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "JoinThreads", _m_JoinThreads);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AbortThreads", _m_AbortThreads);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNewNodeIndex", _m_GetNewNodeIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitializeNode", _m_InitializeNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DestroyNode", _m_DestroyNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculatePaths", _m_CalculatePaths);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getNumThreads", _g_get_NumThreads);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getIsUsingMultithreading", _g_get_IsUsingMultithreading);
            
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addOnPathPreSearch", _e_add_OnPathPreSearch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addOnPathPostSearch", _e_add_OnPathPostSearch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "addOnQueueUnblocked", _e_add_OnQueueUnblocked);
						
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeOnPathPreSearch", _e_remove_OnPathPreSearch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeOnPathPostSearch", _e_remove_OnPathPostSearch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "removeOnQueueUnblocked", _e_remove_OnQueueUnblocked);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPathPreSearch", _e_OnPathPreSearch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPathPostSearch", _e_OnPathPostSearch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnQueueUnblocked", _e_OnQueueUnblocked);
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "NumThreads", _g_get_NumThreads);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsUsingMultithreading", _g_get_IsUsingMultithreading);
            
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.PathProcessor does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PausePathfinding(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _block = LuaAPI.lua_toboolean(L, 2);
                    
                        PF.PathProcessor.GraphUpdateLock gen_ret = gen_to_be_invoked.PausePathfinding( 
                        _block );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TickNonMultithreaded(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.TickNonMultithreaded(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JoinThreads(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.JoinThreads(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AbortThreads(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.AbortThreads(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNewNodeIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetNewNodeIndex(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.InitializeNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.DestroyNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculatePaths(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.IEnumerator gen_ret = gen_to_be_invoked.CalculatePaths(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NumThreads(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.NumThreads);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUsingMultithreading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsUsingMultithreading);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnPathPreSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
                System.Action<PF.Path> gen_delegate = translator.GetDelegate<System.Action<PF.Path>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<PF.Path>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnPathPreSearch += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnPathPreSearch -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnPathPreSearch!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnPathPostSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
                System.Action<PF.Path> gen_delegate = translator.GetDelegate<System.Action<PF.Path>>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action<PF.Path>!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnPathPostSearch += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnPathPostSearch -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnPathPostSearch!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnQueueUnblocked(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
                System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 3);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need System.Action!");
                }
				
				if (gen_param_count == 3)
				{
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "+")) {
						gen_to_be_invoked.OnQueueUnblocked += gen_delegate;
						return 0;
					} 
					
					
					if (LuaAPI.xlua_is_eq_str(L, 2, "-")) {
						gen_to_be_invoked.OnQueueUnblocked -= gen_delegate;
						return 0;
					} 
					
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnQueueUnblocked!");
            return 0;
        }
        
		
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_OnPathPreSearch(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
				System.Action<PF.Path> gen_delegate = translator.GetDelegate<System.Action<PF.Path>>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need System.Action<PF.Path>!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.OnPathPreSearch += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnPathPreSearch!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_OnPathPostSearch(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
				System.Action<PF.Path> gen_delegate = translator.GetDelegate<System.Action<PF.Path>>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need System.Action<PF.Path>!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.OnPathPostSearch += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnPathPostSearch!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_add_OnQueueUnblocked(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
				System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need System.Action!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.OnQueueUnblocked += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnQueueUnblocked!");
			return 0;
		}
		

		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_OnPathPreSearch(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
				System.Action<PF.Path> gen_delegate = translator.GetDelegate<System.Action<PF.Path>>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need System.Action<PF.Path>!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.OnPathPreSearch -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnPathPreSearch!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_OnPathPostSearch(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
				System.Action<PF.Path> gen_delegate = translator.GetDelegate<System.Action<PF.Path>>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need System.Action<PF.Path>!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.OnPathPostSearch -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnPathPostSearch!");
			return 0;
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static int _e_remove_OnQueueUnblocked(RealStatePtr L)
		{
			try {
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				int gen_param_count = LuaAPI.lua_gettop(L);
			PF.PathProcessor gen_to_be_invoked = (PF.PathProcessor)translator.FastGetCSObj(L, 1);
				System.Action gen_delegate = translator.GetDelegate<System.Action>(L, 2);
				if (gen_delegate == null) {
					return LuaAPI.luaL_error(L, "#2 need System.Action!");
				}
				
				if (gen_param_count == 2)
				{
					gen_to_be_invoked.OnQueueUnblocked -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			LuaAPI.luaL_error(L, "invalid arguments to PF.PathProcessor.OnQueueUnblocked!");
			return 0;
		}
		
		
		
		
		
		
		
    }
}
