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
    public class PathfindingBlockManagerTraversalProviderWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.BlockManager.TraversalProvider);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 1, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanTraverse", _m_CanTraverse);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTraversalCost", _m_GetTraversalCost);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmode", _g_get_mode);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "mode", _g_get_mode);
            
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<Pathfinding.BlockManager>(L, 2) && translator.Assignable<Pathfinding.BlockManager.BlockMode>(L, 3) && translator.Assignable<System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>>(L, 4))
				{
					Pathfinding.BlockManager _blockManager = (Pathfinding.BlockManager)translator.GetObject(L, 2, typeof(Pathfinding.BlockManager));
					Pathfinding.BlockManager.BlockMode _mode;translator.Get(L, 3, out _mode);
					System.Collections.Generic.List<Pathfinding.SingleNodeBlocker> _selector = (System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>));
					
					Pathfinding.BlockManager.TraversalProvider gen_ret = new Pathfinding.BlockManager.TraversalProvider(_blockManager, _mode, _selector);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.BlockManager.TraversalProvider constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanTraverse(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.BlockManager.TraversalProvider gen_to_be_invoked = (Pathfinding.BlockManager.TraversalProvider)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 3, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.CanTraverse( 
                        _path, 
                        _node );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTraversalCost(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.BlockManager.TraversalProvider gen_to_be_invoked = (Pathfinding.BlockManager.TraversalProvider)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 3, typeof(PF.GraphNode));
                    
                        uint gen_ret = gen_to_be_invoked.GetTraversalCost( 
                        _path, 
                        _node );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.BlockManager.TraversalProvider gen_to_be_invoked = (Pathfinding.BlockManager.TraversalProvider)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingBlockManagerBlockMode(L, gen_to_be_invoked.mode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
