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
    public class PathfindingBlockManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.BlockManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NodeContainsAnyOf", _m_NodeContainsAnyOf);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NodeContainsAnyExcept", _m_NodeContainsAnyExcept);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InternalBlock", _m_InternalBlock);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InternalUnblock", _m_InternalUnblock);
						
            
			
						
			
			
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.BlockManager gen_ret = new Pathfinding.BlockManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.BlockManager constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NodeContainsAnyOf(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.BlockManager gen_to_be_invoked = (Pathfinding.BlockManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    System.Collections.Generic.List<Pathfinding.SingleNodeBlocker> _selector = (System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>));
                    
                        bool gen_ret = gen_to_be_invoked.NodeContainsAnyOf( 
                        _node, 
                        _selector );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NodeContainsAnyExcept(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.BlockManager gen_to_be_invoked = (Pathfinding.BlockManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    System.Collections.Generic.List<Pathfinding.SingleNodeBlocker> _selector = (System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<Pathfinding.SingleNodeBlocker>));
                    
                        bool gen_ret = gen_to_be_invoked.NodeContainsAnyExcept( 
                        _node, 
                        _selector );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InternalBlock(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.BlockManager gen_to_be_invoked = (Pathfinding.BlockManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    Pathfinding.SingleNodeBlocker _blocker = (Pathfinding.SingleNodeBlocker)translator.GetObject(L, 3, typeof(Pathfinding.SingleNodeBlocker));
                    
                    gen_to_be_invoked.InternalBlock( 
                        _node, 
                        _blocker );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InternalUnblock(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.BlockManager gen_to_be_invoked = (Pathfinding.BlockManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    Pathfinding.SingleNodeBlocker _blocker = (Pathfinding.SingleNodeBlocker)translator.GetObject(L, 3, typeof(Pathfinding.SingleNodeBlocker));
                    
                    gen_to_be_invoked.InternalUnblock( 
                        _node, 
                        _blocker );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
