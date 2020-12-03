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
    public class FairyGUIGScrollBarWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.GScrollBar);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 1, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetScrollPane", _m_SetScrollPane);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getminSize", _g_get_minSize);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdisplayPerc", _s_set_displayPerc);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setscrollPerc", _s_set_scrollPerc);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "minSize", _g_get_minSize);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "displayPerc", _s_set_displayPerc);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scrollPerc", _s_set_scrollPerc);
            
			
			
			
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
					
					FairyGUI.GScrollBar gen_ret = new FairyGUI.GScrollBar();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.GScrollBar constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetScrollPane(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.GScrollBar gen_to_be_invoked = (FairyGUI.GScrollBar)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.ScrollPane _target = (FairyGUI.ScrollPane)translator.GetObject(L, 2, typeof(FairyGUI.ScrollPane));
                    bool _vertical = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetScrollPane( 
                        _target, 
                        _vertical );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GScrollBar gen_to_be_invoked = (FairyGUI.GScrollBar)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.minSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_displayPerc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GScrollBar gen_to_be_invoked = (FairyGUI.GScrollBar)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.displayPerc = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scrollPerc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GScrollBar gen_to_be_invoked = (FairyGUI.GScrollBar)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.scrollPerc = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
