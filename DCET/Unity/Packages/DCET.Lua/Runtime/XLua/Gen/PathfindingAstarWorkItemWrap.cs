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
    public class PathfindingAstarWorkItemWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AstarWorkItem);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 4, 4);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinit", _g_get_init);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinitWithContext", _g_get_initWithContext);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdate", _g_get_update);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getupdateWithContext", _g_get_updateWithContext);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setinit", _s_set_init);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setinitWithContext", _s_set_initWithContext);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdate", _s_set_update);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setupdateWithContext", _s_set_updateWithContext);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "init", _g_get_init);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "initWithContext", _g_get_initWithContext);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "update", _g_get_update);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "updateWithContext", _g_get_updateWithContext);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "init", _s_set_init);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "initWithContext", _s_set_initWithContext);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "update", _s_set_update);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "updateWithContext", _s_set_updateWithContext);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
				translator.Push(L, gen_to_be_invoked);
				return 1;
			}
			catch (System.Exception e)
			{
				return LuaAPI.luaL_error(L, "c# exception in StructClone:" + e);
			}
		}
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Func<bool, bool>>(L, 2))
				{
					System.Func<bool, bool> _update = translator.GetDelegate<System.Func<bool, bool>>(L, 2);
					
					Pathfinding.AstarWorkItem gen_ret = new Pathfinding.AstarWorkItem(_update);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Func<Pathfinding.IWorkItemContext, bool, bool>>(L, 2))
				{
					System.Func<Pathfinding.IWorkItemContext, bool, bool> _update = translator.GetDelegate<System.Func<Pathfinding.IWorkItemContext, bool, bool>>(L, 2);
					
					Pathfinding.AstarWorkItem gen_ret = new Pathfinding.AstarWorkItem(_update);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Action>(L, 2) && translator.Assignable<System.Func<bool, bool>>(L, 3))
				{
					System.Action _init = translator.GetDelegate<System.Action>(L, 2);
					System.Func<bool, bool> _update = translator.GetDelegate<System.Func<bool, bool>>(L, 3);
					
					Pathfinding.AstarWorkItem gen_ret = new Pathfinding.AstarWorkItem(_init, _update);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Action>(L, 2))
				{
					System.Action _init = translator.GetDelegate<System.Action>(L, 2);
					
					Pathfinding.AstarWorkItem gen_ret = new Pathfinding.AstarWorkItem(_init);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Action<Pathfinding.IWorkItemContext>>(L, 2) && translator.Assignable<System.Func<Pathfinding.IWorkItemContext, bool, bool>>(L, 3))
				{
					System.Action<Pathfinding.IWorkItemContext> _init = translator.GetDelegate<System.Action<Pathfinding.IWorkItemContext>>(L, 2);
					System.Func<Pathfinding.IWorkItemContext, bool, bool> _update = translator.GetDelegate<System.Func<Pathfinding.IWorkItemContext, bool, bool>>(L, 3);
					
					Pathfinding.AstarWorkItem gen_ret = new Pathfinding.AstarWorkItem(_init, _update);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Action<Pathfinding.IWorkItemContext>>(L, 2))
				{
					System.Action<Pathfinding.IWorkItemContext> _init = translator.GetDelegate<System.Action<Pathfinding.IWorkItemContext>>(L, 2);
					
					Pathfinding.AstarWorkItem gen_ret = new Pathfinding.AstarWorkItem(_init);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(Pathfinding.AstarWorkItem));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarWorkItem constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_init(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.init);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_initWithContext(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.initWithContext);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_update(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.update);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_updateWithContext(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.updateWithContext);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_init(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.init = translator.GetDelegate<System.Action>(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_initWithContext(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.initWithContext = translator.GetDelegate<System.Action<Pathfinding.IWorkItemContext>>(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_update(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.update = translator.GetDelegate<System.Func<bool, bool>>(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_updateWithContext(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarWorkItem gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.updateWithContext = translator.GetDelegate<System.Func<Pathfinding.IWorkItemContext, bool, bool>>(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
