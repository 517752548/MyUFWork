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
    public class PathfindingGraphUpdateUtilitiesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.GraphUpdateUtilities);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "UpdateGraphsNoBlock", _m_UpdateGraphsNoBlock_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.GraphUpdateUtilities does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGraphsNoBlock_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Pathfinding.GraphUpdateObject>(L, 1)&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Pathfinding.GraphUpdateObject _guo = (Pathfinding.GraphUpdateObject)translator.GetObject(L, 1, typeof(Pathfinding.GraphUpdateObject));
                    System.Collections.Generic.List<PF.GraphNode> _nodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    bool _alwaysRevert = LuaAPI.lua_toboolean(L, 3);
                    
                        bool gen_ret = Pathfinding.GraphUpdateUtilities.UpdateGraphsNoBlock( 
                        _guo, 
                        _nodes, 
                        _alwaysRevert );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Pathfinding.GraphUpdateObject>(L, 1)&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 2)) 
                {
                    Pathfinding.GraphUpdateObject _guo = (Pathfinding.GraphUpdateObject)translator.GetObject(L, 1, typeof(Pathfinding.GraphUpdateObject));
                    System.Collections.Generic.List<PF.GraphNode> _nodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    
                        bool gen_ret = Pathfinding.GraphUpdateUtilities.UpdateGraphsNoBlock( 
                        _guo, 
                        _nodes );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<Pathfinding.GraphUpdateObject>(L, 1)&& translator.Assignable<PF.GraphNode>(L, 2)&& translator.Assignable<PF.GraphNode>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    Pathfinding.GraphUpdateObject _guo = (Pathfinding.GraphUpdateObject)translator.GetObject(L, 1, typeof(Pathfinding.GraphUpdateObject));
                    PF.GraphNode _node1 = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    PF.GraphNode _node2 = (PF.GraphNode)translator.GetObject(L, 3, typeof(PF.GraphNode));
                    bool _alwaysRevert = LuaAPI.lua_toboolean(L, 4);
                    
                        bool gen_ret = Pathfinding.GraphUpdateUtilities.UpdateGraphsNoBlock( 
                        _guo, 
                        _node1, 
                        _node2, 
                        _alwaysRevert );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Pathfinding.GraphUpdateObject>(L, 1)&& translator.Assignable<PF.GraphNode>(L, 2)&& translator.Assignable<PF.GraphNode>(L, 3)) 
                {
                    Pathfinding.GraphUpdateObject _guo = (Pathfinding.GraphUpdateObject)translator.GetObject(L, 1, typeof(Pathfinding.GraphUpdateObject));
                    PF.GraphNode _node1 = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    PF.GraphNode _node2 = (PF.GraphNode)translator.GetObject(L, 3, typeof(PF.GraphNode));
                    
                        bool gen_ret = Pathfinding.GraphUpdateUtilities.UpdateGraphsNoBlock( 
                        _guo, 
                        _node1, 
                        _node2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.GraphUpdateUtilities.UpdateGraphsNoBlock!");
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
