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
    public class PathfindingUtilDrawWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Util.Draw);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Line", _m_Line);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CircleXZ", _m_CircleXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Cylinder", _m_Cylinder);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CrossXZ", _m_CrossXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Bezier", _m_Bezier);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getDebug", Pathfinding.Util.Draw.Debug);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getGizmos", Pathfinding.Util.Draw.Gizmos);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Debug", Pathfinding.Util.Draw.Debug);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Gizmos", Pathfinding.Util.Draw.Gizmos);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.Util.Draw gen_ret = new Pathfinding.Util.Draw();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.Draw constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Line(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.Draw gen_to_be_invoked = (Pathfinding.Util.Draw)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 2, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 3, out _b);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    gen_to_be_invoked.Line( 
                        _a, 
                        _b, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CircleXZ(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.Draw gen_to_be_invoked = (Pathfinding.Util.Draw)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Color>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    float _startAngle = (float)LuaAPI.lua_tonumber(L, 5);
                    float _endAngle = (float)LuaAPI.lua_tonumber(L, 6);
                    
                    gen_to_be_invoked.CircleXZ( 
                        _center, 
                        _radius, 
                        _color, 
                        _startAngle, 
                        _endAngle );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Color>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    float _startAngle = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    gen_to_be_invoked.CircleXZ( 
                        _center, 
                        _radius, 
                        _color, 
                        _startAngle );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Color>(L, 4)) 
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    gen_to_be_invoked.CircleXZ( 
                        _center, 
                        _radius, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.Draw.CircleXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cylinder(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.Draw gen_to_be_invoked = (Pathfinding.Util.Draw)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    UnityEngine.Vector3 _up;translator.Get(L, 3, out _up);
                    float _height = (float)LuaAPI.lua_tonumber(L, 4);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 5);
                    UnityEngine.Color _color;translator.Get(L, 6, out _color);
                    
                    gen_to_be_invoked.Cylinder( 
                        _position, 
                        _up, 
                        _height, 
                        _radius, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CrossXZ(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.Draw gen_to_be_invoked = (Pathfinding.Util.Draw)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Color>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    float _size = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.CrossXZ( 
                        _position, 
                        _color, 
                        _size );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Color>(L, 3)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    gen_to_be_invoked.CrossXZ( 
                        _position, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.Draw.CrossXZ!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Bezier(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.Draw gen_to_be_invoked = (Pathfinding.Util.Draw)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 2, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 3, out _b);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    gen_to_be_invoked.Bezier( 
                        _a, 
                        _b, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
