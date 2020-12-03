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
    public class PathfindingPathUtilitiesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.PathUtilities);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "IsPathPossible", _m_IsPathPossible_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetReachableNodes", _m_GetReachableNodes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BFS", _m_BFS_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSpiralPoints", _m_GetSpiralPoints_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetPointsAroundPointWorld", _m_GetPointsAroundPointWorld_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetPointsAroundPoint", _m_GetPointsAroundPoint_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.PathUtilities does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPathPossible_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 1)) 
                {
                    System.Collections.Generic.List<PF.GraphNode> _nodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    
                        bool gen_ret = Pathfinding.PathUtilities.IsPathPossible( 
                        _nodes );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Collections.Generic.List<PF.GraphNode> _nodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    int _tagMask = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool gen_ret = Pathfinding.PathUtilities.IsPathPossible( 
                        _nodes, 
                        _tagMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 1)&& translator.Assignable<PF.GraphNode>(L, 2)) 
                {
                    PF.GraphNode _node1 = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    PF.GraphNode _node2 = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        bool gen_ret = Pathfinding.PathUtilities.IsPathPossible( 
                        _node1, 
                        _node2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.PathUtilities.IsPathPossible!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetReachableNodes_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<PF.GraphNode>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Func<PF.GraphNode, bool>>(L, 3)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    int _tagMask = LuaAPI.xlua_tointeger(L, 2);
                    System.Func<PF.GraphNode, bool> _filter = translator.GetDelegate<System.Func<PF.GraphNode, bool>>(L, 3);
                    
                        System.Collections.Generic.List<PF.GraphNode> gen_ret = Pathfinding.PathUtilities.GetReachableNodes( 
                        _seed, 
                        _tagMask, 
                        _filter );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    int _tagMask = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Collections.Generic.List<PF.GraphNode> gen_ret = Pathfinding.PathUtilities.GetReachableNodes( 
                        _seed, 
                        _tagMask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<PF.GraphNode>(L, 1)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    
                        System.Collections.Generic.List<PF.GraphNode> gen_ret = Pathfinding.PathUtilities.GetReachableNodes( 
                        _seed );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.PathUtilities.GetReachableNodes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BFS_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<PF.GraphNode>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Func<PF.GraphNode, bool>>(L, 4)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    int _depth = LuaAPI.xlua_tointeger(L, 2);
                    int _tagMask = LuaAPI.xlua_tointeger(L, 3);
                    System.Func<PF.GraphNode, bool> _filter = translator.GetDelegate<System.Func<PF.GraphNode, bool>>(L, 4);
                    
                        System.Collections.Generic.List<PF.GraphNode> gen_ret = Pathfinding.PathUtilities.BFS( 
                        _seed, 
                        _depth, 
                        _tagMask, 
                        _filter );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.GraphNode>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    int _depth = LuaAPI.xlua_tointeger(L, 2);
                    int _tagMask = LuaAPI.xlua_tointeger(L, 3);
                    
                        System.Collections.Generic.List<PF.GraphNode> gen_ret = Pathfinding.PathUtilities.BFS( 
                        _seed, 
                        _depth, 
                        _tagMask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    int _depth = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Collections.Generic.List<PF.GraphNode> gen_ret = Pathfinding.PathUtilities.BFS( 
                        _seed, 
                        _depth );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.PathUtilities.BFS!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSpiralPoints_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _count = LuaAPI.xlua_tointeger(L, 1);
                    float _clearance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        System.Collections.Generic.List<UnityEngine.Vector3> gen_ret = Pathfinding.PathUtilities.GetSpiralPoints( 
                        _count, 
                        _clearance );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPointsAroundPointWorld_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 1, out _p);
                    PF.IRaycastableGraph _g = (PF.IRaycastableGraph)translator.GetObject(L, 2, typeof(PF.IRaycastableGraph));
                    System.Collections.Generic.List<UnityEngine.Vector3> _previousPoints = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    float _radius = (float)LuaAPI.lua_tonumber(L, 4);
                    float _clearanceRadius = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    Pathfinding.PathUtilities.GetPointsAroundPointWorld( 
                        _p, 
                        _g, 
                        _previousPoints, 
                        _radius, 
                        _clearanceRadius );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPointsAroundPoint_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 1, out _center);
                    PF.IRaycastableGraph _g = (PF.IRaycastableGraph)translator.GetObject(L, 2, typeof(PF.IRaycastableGraph));
                    System.Collections.Generic.List<UnityEngine.Vector3> _previousPoints = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    float _radius = (float)LuaAPI.lua_tonumber(L, 4);
                    float _clearanceRadius = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    Pathfinding.PathUtilities.GetPointsAroundPoint( 
                        _center, 
                        _g, 
                        _previousPoints, 
                        _radius, 
                        _clearanceRadius );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
