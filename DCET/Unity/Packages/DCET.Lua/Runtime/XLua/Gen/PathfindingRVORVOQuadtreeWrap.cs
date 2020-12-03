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
    public class PathfindingRVORVOQuadtreeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.RVOQuadtree);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBounds", _m_SetBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Insert", _m_Insert);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateSpeeds", _m_CalculateSpeeds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Query", _m_Query);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DebugDraw", _m_DebugDraw);
						
            
			
						
			
			
			
			
			
			
			
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
					
					Pathfinding.RVO.RVOQuadtree gen_ret = new Pathfinding.RVO.RVOQuadtree();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.RVOQuadtree constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOQuadtree gen_to_be_invoked = (Pathfinding.RVO.RVOQuadtree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBounds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOQuadtree gen_to_be_invoked = (Pathfinding.RVO.RVOQuadtree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rect _r;translator.Get(L, 2, out _r);
                    
                    gen_to_be_invoked.SetBounds( 
                        _r );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Insert(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOQuadtree gen_to_be_invoked = (Pathfinding.RVO.RVOQuadtree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.RVO.Sampled.Agent _agent = (Pathfinding.RVO.Sampled.Agent)translator.GetObject(L, 2, typeof(Pathfinding.RVO.Sampled.Agent));
                    
                    gen_to_be_invoked.Insert( 
                        _agent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateSpeeds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOQuadtree gen_to_be_invoked = (Pathfinding.RVO.RVOQuadtree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CalculateSpeeds(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Query(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOQuadtree gen_to_be_invoked = (Pathfinding.RVO.RVOQuadtree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _p;translator.Get(L, 2, out _p);
                    float _speed = (float)LuaAPI.lua_tonumber(L, 3);
                    float _timeHorizon = (float)LuaAPI.lua_tonumber(L, 4);
                    float _agentRadius = (float)LuaAPI.lua_tonumber(L, 5);
                    Pathfinding.RVO.Sampled.Agent _agent = (Pathfinding.RVO.Sampled.Agent)translator.GetObject(L, 6, typeof(Pathfinding.RVO.Sampled.Agent));
                    
                    gen_to_be_invoked.Query( 
                        _p, 
                        _speed, 
                        _timeHorizon, 
                        _agentRadius, 
                        _agent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugDraw(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOQuadtree gen_to_be_invoked = (Pathfinding.RVO.RVOQuadtree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DebugDraw(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
