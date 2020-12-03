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
    
    public class SystemNetSocketsAddressFamilyWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(System.Net.Sockets.AddressFamily), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(System.Net.Sockets.AddressFamily), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(System.Net.Sockets.AddressFamily), L, null, 32, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unknown", System.Net.Sockets.AddressFamily.Unknown);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unspecified", System.Net.Sockets.AddressFamily.Unspecified);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unix", System.Net.Sockets.AddressFamily.Unix);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InterNetwork", System.Net.Sockets.AddressFamily.InterNetwork);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ImpLink", System.Net.Sockets.AddressFamily.ImpLink);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Pup", System.Net.Sockets.AddressFamily.Pup);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Chaos", System.Net.Sockets.AddressFamily.Chaos);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NS", System.Net.Sockets.AddressFamily.NS);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ipx", System.Net.Sockets.AddressFamily.Ipx);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Iso", System.Net.Sockets.AddressFamily.Iso);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Osi", System.Net.Sockets.AddressFamily.Osi);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ecma", System.Net.Sockets.AddressFamily.Ecma);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DataKit", System.Net.Sockets.AddressFamily.DataKit);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ccitt", System.Net.Sockets.AddressFamily.Ccitt);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sna", System.Net.Sockets.AddressFamily.Sna);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DecNet", System.Net.Sockets.AddressFamily.DecNet);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DataLink", System.Net.Sockets.AddressFamily.DataLink);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Lat", System.Net.Sockets.AddressFamily.Lat);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HyperChannel", System.Net.Sockets.AddressFamily.HyperChannel);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AppleTalk", System.Net.Sockets.AddressFamily.AppleTalk);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NetBios", System.Net.Sockets.AddressFamily.NetBios);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "VoiceView", System.Net.Sockets.AddressFamily.VoiceView);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FireFox", System.Net.Sockets.AddressFamily.FireFox);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Banyan", System.Net.Sockets.AddressFamily.Banyan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Atm", System.Net.Sockets.AddressFamily.Atm);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InterNetworkV6", System.Net.Sockets.AddressFamily.InterNetworkV6);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Cluster", System.Net.Sockets.AddressFamily.Cluster);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ieee12844", System.Net.Sockets.AddressFamily.Ieee12844);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Irda", System.Net.Sockets.AddressFamily.Irda);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NetworkDesigners", System.Net.Sockets.AddressFamily.NetworkDesigners);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Max", System.Net.Sockets.AddressFamily.Max);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(System.Net.Sockets.AddressFamily), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushSystemNetSocketsAddressFamily(L, (System.Net.Sockets.AddressFamily)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Unknown"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Unknown);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unspecified"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Unspecified);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unix"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Unix);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InterNetwork"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.InterNetwork);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ImpLink"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.ImpLink);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pup"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Pup);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Chaos"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Chaos);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NS"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.NS);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ipx"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Ipx);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Iso"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Iso);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Osi"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Osi);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ecma"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Ecma);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DataKit"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.DataKit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ccitt"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Ccitt);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sna"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Sna);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DecNet"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.DecNet);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DataLink"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.DataLink);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Lat"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Lat);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HyperChannel"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.HyperChannel);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AppleTalk"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.AppleTalk);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NetBios"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.NetBios);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "VoiceView"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.VoiceView);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FireFox"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.FireFox);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Banyan"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Banyan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Atm"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Atm);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InterNetworkV6"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.InterNetworkV6);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Cluster"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Cluster);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ieee12844"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Ieee12844);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Irda"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Irda);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NetworkDesigners"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.NetworkDesigners);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Max"))
                {
                    translator.PushSystemNetSocketsAddressFamily(L, System.Net.Sockets.AddressFamily.Max);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for System.Net.Sockets.AddressFamily!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for System.Net.Sockets.AddressFamily! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class SystemNetSocketsSocketTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(System.Net.Sockets.SocketType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(System.Net.Sockets.SocketType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(System.Net.Sockets.SocketType), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Stream", System.Net.Sockets.SocketType.Stream);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Dgram", System.Net.Sockets.SocketType.Dgram);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Raw", System.Net.Sockets.SocketType.Raw);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rdm", System.Net.Sockets.SocketType.Rdm);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Seqpacket", System.Net.Sockets.SocketType.Seqpacket);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unknown", System.Net.Sockets.SocketType.Unknown);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(System.Net.Sockets.SocketType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushSystemNetSocketsSocketType(L, (System.Net.Sockets.SocketType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Stream"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Stream);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Dgram"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Dgram);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Raw"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Raw);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Rdm"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Rdm);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Seqpacket"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Seqpacket);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unknown"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Unknown);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for System.Net.Sockets.SocketType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for System.Net.Sockets.SocketType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class SystemNetSocketsProtocolTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(System.Net.Sockets.ProtocolType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(System.Net.Sockets.ProtocolType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(System.Net.Sockets.ProtocolType), L, null, 26, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IP", System.Net.Sockets.ProtocolType.IP);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv6HopByHopOptions", System.Net.Sockets.ProtocolType.IPv6HopByHopOptions);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Icmp", System.Net.Sockets.ProtocolType.Icmp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Igmp", System.Net.Sockets.ProtocolType.Igmp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ggp", System.Net.Sockets.ProtocolType.Ggp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv4", System.Net.Sockets.ProtocolType.IPv4);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Tcp", System.Net.Sockets.ProtocolType.Tcp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Pup", System.Net.Sockets.ProtocolType.Pup);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Udp", System.Net.Sockets.ProtocolType.Udp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Idp", System.Net.Sockets.ProtocolType.Idp);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv6", System.Net.Sockets.ProtocolType.IPv6);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv6RoutingHeader", System.Net.Sockets.ProtocolType.IPv6RoutingHeader);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv6FragmentHeader", System.Net.Sockets.ProtocolType.IPv6FragmentHeader);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPSecEncapsulatingSecurityPayload", System.Net.Sockets.ProtocolType.IPSecEncapsulatingSecurityPayload);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPSecAuthenticationHeader", System.Net.Sockets.ProtocolType.IPSecAuthenticationHeader);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IcmpV6", System.Net.Sockets.ProtocolType.IcmpV6);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv6NoNextHeader", System.Net.Sockets.ProtocolType.IPv6NoNextHeader);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IPv6DestinationOptions", System.Net.Sockets.ProtocolType.IPv6DestinationOptions);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ND", System.Net.Sockets.ProtocolType.ND);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Raw", System.Net.Sockets.ProtocolType.Raw);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unspecified", System.Net.Sockets.ProtocolType.Unspecified);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ipx", System.Net.Sockets.ProtocolType.Ipx);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Spx", System.Net.Sockets.ProtocolType.Spx);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SpxII", System.Net.Sockets.ProtocolType.SpxII);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unknown", System.Net.Sockets.ProtocolType.Unknown);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(System.Net.Sockets.ProtocolType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushSystemNetSocketsProtocolType(L, (System.Net.Sockets.ProtocolType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "IP"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv6HopByHopOptions"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv6HopByHopOptions);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Icmp"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Icmp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Igmp"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Igmp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ggp"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Ggp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv4"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv4);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Tcp"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Tcp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pup"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Pup);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Udp"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Udp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Idp"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Idp);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv6"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv6);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv6RoutingHeader"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv6RoutingHeader);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv6FragmentHeader"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv6FragmentHeader);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPSecEncapsulatingSecurityPayload"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPSecEncapsulatingSecurityPayload);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPSecAuthenticationHeader"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPSecAuthenticationHeader);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IcmpV6"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IcmpV6);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv6NoNextHeader"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv6NoNextHeader);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IPv6DestinationOptions"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.IPv6DestinationOptions);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ND"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.ND);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Raw"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Raw);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unspecified"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Unspecified);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Ipx"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Ipx);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Spx"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Spx);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SpxII"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.SpxII);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unknown"))
                {
                    translator.PushSystemNetSocketsProtocolType(L, System.Net.Sockets.ProtocolType.Unknown);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for System.Net.Sockets.ProtocolType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for System.Net.Sockets.ProtocolType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFHeuristicOptimizationModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.HeuristicOptimizationMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.HeuristicOptimizationMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.HeuristicOptimizationMode), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", PF.HeuristicOptimizationMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Random", PF.HeuristicOptimizationMode.Random);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RandomSpreadOut", PF.HeuristicOptimizationMode.RandomSpreadOut);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.HeuristicOptimizationMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFHeuristicOptimizationMode(L, (PF.HeuristicOptimizationMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushPFHeuristicOptimizationMode(L, PF.HeuristicOptimizationMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Random"))
                {
                    translator.PushPFHeuristicOptimizationMode(L, PF.HeuristicOptimizationMode.Random);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RandomSpreadOut"))
                {
                    translator.PushPFHeuristicOptimizationMode(L, PF.HeuristicOptimizationMode.RandomSpreadOut);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.HeuristicOptimizationMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.HeuristicOptimizationMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFGraphUpdateThreadingWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.GraphUpdateThreading), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.GraphUpdateThreading), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.GraphUpdateThreading), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnityThread", PF.GraphUpdateThreading.UnityThread);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SeparateThread", PF.GraphUpdateThreading.SeparateThread);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnityInit", PF.GraphUpdateThreading.UnityInit);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnityPost", PF.GraphUpdateThreading.UnityPost);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SeparateAndUnityInit", PF.GraphUpdateThreading.SeparateAndUnityInit);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.GraphUpdateThreading), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFGraphUpdateThreading(L, (PF.GraphUpdateThreading)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "UnityThread"))
                {
                    translator.PushPFGraphUpdateThreading(L, PF.GraphUpdateThreading.UnityThread);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SeparateThread"))
                {
                    translator.PushPFGraphUpdateThreading(L, PF.GraphUpdateThreading.SeparateThread);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UnityInit"))
                {
                    translator.PushPFGraphUpdateThreading(L, PF.GraphUpdateThreading.UnityInit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UnityPost"))
                {
                    translator.PushPFGraphUpdateThreading(L, PF.GraphUpdateThreading.UnityPost);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SeparateAndUnityInit"))
                {
                    translator.PushPFGraphUpdateThreading(L, PF.GraphUpdateThreading.SeparateAndUnityInit);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.GraphUpdateThreading!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.GraphUpdateThreading! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFThreadCountWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.ThreadCount), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.ThreadCount), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.ThreadCount), L, null, 12, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutomaticLowLoad", PF.ThreadCount.AutomaticLowLoad);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutomaticHighLoad", PF.ThreadCount.AutomaticHighLoad);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", PF.ThreadCount.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "One", PF.ThreadCount.One);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Two", PF.ThreadCount.Two);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Three", PF.ThreadCount.Three);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Four", PF.ThreadCount.Four);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Five", PF.ThreadCount.Five);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Six", PF.ThreadCount.Six);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Seven", PF.ThreadCount.Seven);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Eight", PF.ThreadCount.Eight);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.ThreadCount), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFThreadCount(L, (PF.ThreadCount)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "AutomaticLowLoad"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.AutomaticLowLoad);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutomaticHighLoad"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.AutomaticHighLoad);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "One"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.One);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Two"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Two);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Three"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Three);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Four"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Four);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Five"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Five);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Six"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Six);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Seven"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Seven);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Eight"))
                {
                    translator.PushPFThreadCount(L, PF.ThreadCount.Eight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.ThreadCount!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.ThreadCount! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFPathStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.PathState), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.PathState), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.PathState), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Created", PF.PathState.Created);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PathQueue", PF.PathState.PathQueue);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Processing", PF.PathState.Processing);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ReturnQueue", PF.PathState.ReturnQueue);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Returned", PF.PathState.Returned);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.PathState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFPathState(L, (PF.PathState)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Created"))
                {
                    translator.PushPFPathState(L, PF.PathState.Created);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PathQueue"))
                {
                    translator.PushPFPathState(L, PF.PathState.PathQueue);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Processing"))
                {
                    translator.PushPFPathState(L, PF.PathState.Processing);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ReturnQueue"))
                {
                    translator.PushPFPathState(L, PF.PathState.ReturnQueue);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Returned"))
                {
                    translator.PushPFPathState(L, PF.PathState.Returned);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.PathState!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.PathState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFPathCompleteStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.PathCompleteState), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.PathCompleteState), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.PathCompleteState), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NotCalculated", PF.PathCompleteState.NotCalculated);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Error", PF.PathCompleteState.Error);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Complete", PF.PathCompleteState.Complete);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Partial", PF.PathCompleteState.Partial);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.PathCompleteState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFPathCompleteState(L, (PF.PathCompleteState)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "NotCalculated"))
                {
                    translator.PushPFPathCompleteState(L, PF.PathCompleteState.NotCalculated);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Error"))
                {
                    translator.PushPFPathCompleteState(L, PF.PathCompleteState.Error);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Complete"))
                {
                    translator.PushPFPathCompleteState(L, PF.PathCompleteState.Complete);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Partial"))
                {
                    translator.PushPFPathCompleteState(L, PF.PathCompleteState.Partial);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.PathCompleteState!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.PathCompleteState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFCloseToDestinationModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.CloseToDestinationMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.CloseToDestinationMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.CloseToDestinationMode), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Stop", PF.CloseToDestinationMode.Stop);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ContinueToExactDestination", PF.CloseToDestinationMode.ContinueToExactDestination);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.CloseToDestinationMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFCloseToDestinationMode(L, (PF.CloseToDestinationMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Stop"))
                {
                    translator.PushPFCloseToDestinationMode(L, PF.CloseToDestinationMode.Stop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ContinueToExactDestination"))
                {
                    translator.PushPFCloseToDestinationMode(L, PF.CloseToDestinationMode.ContinueToExactDestination);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.CloseToDestinationMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.CloseToDestinationMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFSideWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.Side), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.Side), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.Side), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Colinear", PF.Side.Colinear);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", PF.Side.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", PF.Side.Right);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.Side), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFSide(L, (PF.Side)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Colinear"))
                {
                    translator.PushPFSide(L, PF.Side.Colinear);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushPFSide(L, PF.Side.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushPFSide(L, PF.Side.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.Side!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.Side! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFInspectorGridModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.InspectorGridMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.InspectorGridMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.InspectorGridMode), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Grid", PF.InspectorGridMode.Grid);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IsometricGrid", PF.InspectorGridMode.IsometricGrid);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Hexagonal", PF.InspectorGridMode.Hexagonal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Advanced", PF.InspectorGridMode.Advanced);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.InspectorGridMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFInspectorGridMode(L, (PF.InspectorGridMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Grid"))
                {
                    translator.PushPFInspectorGridMode(L, PF.InspectorGridMode.Grid);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IsometricGrid"))
                {
                    translator.PushPFInspectorGridMode(L, PF.InspectorGridMode.IsometricGrid);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Hexagonal"))
                {
                    translator.PushPFInspectorGridMode(L, PF.InspectorGridMode.Hexagonal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Advanced"))
                {
                    translator.PushPFInspectorGridMode(L, PF.InspectorGridMode.Advanced);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.InspectorGridMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.InspectorGridMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFGraphDebugModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.GraphDebugMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.GraphDebugMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.GraphDebugMode), L, null, 8, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Areas", PF.GraphDebugMode.Areas);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "G", PF.GraphDebugMode.G);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "H", PF.GraphDebugMode.H);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "F", PF.GraphDebugMode.F);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Penalty", PF.GraphDebugMode.Penalty);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Connections", PF.GraphDebugMode.Connections);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Tags", PF.GraphDebugMode.Tags);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.GraphDebugMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFGraphDebugMode(L, (PF.GraphDebugMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Areas"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.Areas);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "G"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.G);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "H"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.H);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "F"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.F);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Penalty"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.Penalty);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Connections"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.Connections);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Tags"))
                {
                    translator.PushPFGraphDebugMode(L, PF.GraphDebugMode.Tags);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.GraphDebugMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.GraphDebugMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFPathLogWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.PathLog), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.PathLog), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.PathLog), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", PF.PathLog.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Normal", PF.PathLog.Normal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Heavy", PF.PathLog.Heavy);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InGame", PF.PathLog.InGame);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OnlyErrors", PF.PathLog.OnlyErrors);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.PathLog), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFPathLog(L, (PF.PathLog)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushPFPathLog(L, PF.PathLog.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushPFPathLog(L, PF.PathLog.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Heavy"))
                {
                    translator.PushPFPathLog(L, PF.PathLog.Heavy);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InGame"))
                {
                    translator.PushPFPathLog(L, PF.PathLog.InGame);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OnlyErrors"))
                {
                    translator.PushPFPathLog(L, PF.PathLog.OnlyErrors);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.PathLog!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.PathLog! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFHeuristicWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.Heuristic), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.Heuristic), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.Heuristic), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Manhattan", PF.Heuristic.Manhattan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DiagonalManhattan", PF.Heuristic.DiagonalManhattan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Euclidean", PF.Heuristic.Euclidean);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", PF.Heuristic.None);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.Heuristic), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFHeuristic(L, (PF.Heuristic)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Manhattan"))
                {
                    translator.PushPFHeuristic(L, PF.Heuristic.Manhattan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DiagonalManhattan"))
                {
                    translator.PushPFHeuristic(L, PF.Heuristic.DiagonalManhattan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Euclidean"))
                {
                    translator.PushPFHeuristic(L, PF.Heuristic.Euclidean);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushPFHeuristic(L, PF.Heuristic.None);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.Heuristic!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.Heuristic! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingRVOMovementPlaneWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.RVO.MovementPlane), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.RVO.MovementPlane), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.RVO.MovementPlane), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "XZ", Pathfinding.RVO.MovementPlane.XZ);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "XY", Pathfinding.RVO.MovementPlane.XY);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.RVO.MovementPlane), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingRVOMovementPlane(L, (Pathfinding.RVO.MovementPlane)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "XZ"))
                {
                    translator.PushPathfindingRVOMovementPlane(L, Pathfinding.RVO.MovementPlane.XZ);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "XY"))
                {
                    translator.PushPathfindingRVOMovementPlane(L, Pathfinding.RVO.MovementPlane.XY);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.RVO.MovementPlane!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.RVO.MovementPlane! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingRVORVOLayerWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.RVO.RVOLayer), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.RVO.RVOLayer), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.RVO.RVOLayer), L, null, 32, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultAgent", Pathfinding.RVO.RVOLayer.DefaultAgent);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultObstacle", Pathfinding.RVO.RVOLayer.DefaultObstacle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer2", Pathfinding.RVO.RVOLayer.Layer2);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer3", Pathfinding.RVO.RVOLayer.Layer3);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer4", Pathfinding.RVO.RVOLayer.Layer4);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer5", Pathfinding.RVO.RVOLayer.Layer5);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer6", Pathfinding.RVO.RVOLayer.Layer6);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer7", Pathfinding.RVO.RVOLayer.Layer7);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer8", Pathfinding.RVO.RVOLayer.Layer8);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer9", Pathfinding.RVO.RVOLayer.Layer9);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer10", Pathfinding.RVO.RVOLayer.Layer10);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer11", Pathfinding.RVO.RVOLayer.Layer11);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer12", Pathfinding.RVO.RVOLayer.Layer12);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer13", Pathfinding.RVO.RVOLayer.Layer13);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer14", Pathfinding.RVO.RVOLayer.Layer14);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer15", Pathfinding.RVO.RVOLayer.Layer15);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer16", Pathfinding.RVO.RVOLayer.Layer16);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer17", Pathfinding.RVO.RVOLayer.Layer17);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer18", Pathfinding.RVO.RVOLayer.Layer18);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer19", Pathfinding.RVO.RVOLayer.Layer19);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer20", Pathfinding.RVO.RVOLayer.Layer20);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer21", Pathfinding.RVO.RVOLayer.Layer21);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer22", Pathfinding.RVO.RVOLayer.Layer22);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer23", Pathfinding.RVO.RVOLayer.Layer23);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer24", Pathfinding.RVO.RVOLayer.Layer24);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer25", Pathfinding.RVO.RVOLayer.Layer25);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer26", Pathfinding.RVO.RVOLayer.Layer26);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer27", Pathfinding.RVO.RVOLayer.Layer27);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer28", Pathfinding.RVO.RVOLayer.Layer28);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer29", Pathfinding.RVO.RVOLayer.Layer29);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layer30", Pathfinding.RVO.RVOLayer.Layer30);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.RVO.RVOLayer), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingRVORVOLayer(L, (Pathfinding.RVO.RVOLayer)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultAgent"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.DefaultAgent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultObstacle"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.DefaultObstacle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer2"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer3"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer3);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer4"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer4);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer5"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer5);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer6"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer6);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer7"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer7);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer8"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer8);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer9"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer9);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer10"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer10);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer11"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer11);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer12"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer12);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer13"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer13);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer14"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer14);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer15"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer15);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer16"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer16);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer17"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer17);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer18"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer18);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer19"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer19);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer20"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer20);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer21"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer21);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer22"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer22);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer23"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer23);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer24"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer24);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer25"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer25);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer26"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer26);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer27"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer27);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer28"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer28);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer29"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer29);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Layer30"))
                {
                    translator.PushPathfindingRVORVOLayer(L, Pathfinding.RVO.RVOLayer.Layer30);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.RVO.RVOLayer!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.RVO.RVOLayer! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class AstarPathAstarDistributionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(AstarPath.AstarDistribution), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(AstarPath.AstarDistribution), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(AstarPath.AstarDistribution), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "WebsiteDownload", AstarPath.AstarDistribution.WebsiteDownload);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AssetStore", AstarPath.AstarDistribution.AssetStore);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(AstarPath.AstarDistribution), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushAstarPathAstarDistribution(L, (AstarPath.AstarDistribution)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "WebsiteDownload"))
                {
                    translator.PushAstarPathAstarDistribution(L, AstarPath.AstarDistribution.WebsiteDownload);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AssetStore"))
                {
                    translator.PushAstarPathAstarDistribution(L, AstarPath.AstarDistribution.AssetStore);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for AstarPath.AstarDistribution!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for AstarPath.AstarDistribution! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFMultiTargetPathHeuristicModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.MultiTargetPath.HeuristicMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.MultiTargetPath.HeuristicMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.MultiTargetPath.HeuristicMode), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", PF.MultiTargetPath.HeuristicMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Average", PF.MultiTargetPath.HeuristicMode.Average);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MovingAverage", PF.MultiTargetPath.HeuristicMode.MovingAverage);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Midpoint", PF.MultiTargetPath.HeuristicMode.Midpoint);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MovingMidpoint", PF.MultiTargetPath.HeuristicMode.MovingMidpoint);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sequential", PF.MultiTargetPath.HeuristicMode.Sequential);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.MultiTargetPath.HeuristicMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFMultiTargetPathHeuristicMode(L, (PF.MultiTargetPath.HeuristicMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushPFMultiTargetPathHeuristicMode(L, PF.MultiTargetPath.HeuristicMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Average"))
                {
                    translator.PushPFMultiTargetPathHeuristicMode(L, PF.MultiTargetPath.HeuristicMode.Average);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MovingAverage"))
                {
                    translator.PushPFMultiTargetPathHeuristicMode(L, PF.MultiTargetPath.HeuristicMode.MovingAverage);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Midpoint"))
                {
                    translator.PushPFMultiTargetPathHeuristicMode(L, PF.MultiTargetPath.HeuristicMode.Midpoint);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MovingMidpoint"))
                {
                    translator.PushPFMultiTargetPathHeuristicMode(L, PF.MultiTargetPath.HeuristicMode.MovingMidpoint);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sequential"))
                {
                    translator.PushPFMultiTargetPathHeuristicMode(L, PF.MultiTargetPath.HeuristicMode.Sequential);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.MultiTargetPath.HeuristicMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.MultiTargetPath.HeuristicMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PFRecastGraphRelevantGraphSurfaceModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(PF.RecastGraph.RelevantGraphSurfaceMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(PF.RecastGraph.RelevantGraphSurfaceMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(PF.RecastGraph.RelevantGraphSurfaceMode), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DoNotRequire", PF.RecastGraph.RelevantGraphSurfaceMode.DoNotRequire);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OnlyForCompletelyInsideTile", PF.RecastGraph.RelevantGraphSurfaceMode.OnlyForCompletelyInsideTile);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RequireForAll", PF.RecastGraph.RelevantGraphSurfaceMode.RequireForAll);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(PF.RecastGraph.RelevantGraphSurfaceMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, (PF.RecastGraph.RelevantGraphSurfaceMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "DoNotRequire"))
                {
                    translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, PF.RecastGraph.RelevantGraphSurfaceMode.DoNotRequire);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OnlyForCompletelyInsideTile"))
                {
                    translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, PF.RecastGraph.RelevantGraphSurfaceMode.OnlyForCompletelyInsideTile);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RequireForAll"))
                {
                    translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, PF.RecastGraph.RelevantGraphSurfaceMode.RequireForAll);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for PF.RecastGraph.RelevantGraphSurfaceMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for PF.RecastGraph.RelevantGraphSurfaceMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingSeekerModifierPassWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.Seeker.ModifierPass), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.Seeker.ModifierPass), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.Seeker.ModifierPass), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PreProcess", Pathfinding.Seeker.ModifierPass.PreProcess);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PostProcess", Pathfinding.Seeker.ModifierPass.PostProcess);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.Seeker.ModifierPass), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingSeekerModifierPass(L, (Pathfinding.Seeker.ModifierPass)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "PreProcess"))
                {
                    translator.PushPathfindingSeekerModifierPass(L, Pathfinding.Seeker.ModifierPass.PreProcess);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PostProcess"))
                {
                    translator.PushPathfindingSeekerModifierPass(L, Pathfinding.Seeker.ModifierPass.PostProcess);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.Seeker.ModifierPass!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.Seeker.ModifierPass! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingGraphModifierEventTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.GraphModifier.EventType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.GraphModifier.EventType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.GraphModifier.EventType), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PostScan", Pathfinding.GraphModifier.EventType.PostScan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PreScan", Pathfinding.GraphModifier.EventType.PreScan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LatePostScan", Pathfinding.GraphModifier.EventType.LatePostScan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PreUpdate", Pathfinding.GraphModifier.EventType.PreUpdate);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PostUpdate", Pathfinding.GraphModifier.EventType.PostUpdate);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PostCacheLoad", Pathfinding.GraphModifier.EventType.PostCacheLoad);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.GraphModifier.EventType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingGraphModifierEventType(L, (Pathfinding.GraphModifier.EventType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "PostScan"))
                {
                    translator.PushPathfindingGraphModifierEventType(L, Pathfinding.GraphModifier.EventType.PostScan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PreScan"))
                {
                    translator.PushPathfindingGraphModifierEventType(L, Pathfinding.GraphModifier.EventType.PreScan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LatePostScan"))
                {
                    translator.PushPathfindingGraphModifierEventType(L, Pathfinding.GraphModifier.EventType.LatePostScan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PreUpdate"))
                {
                    translator.PushPathfindingGraphModifierEventType(L, Pathfinding.GraphModifier.EventType.PreUpdate);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PostUpdate"))
                {
                    translator.PushPathfindingGraphModifierEventType(L, Pathfinding.GraphModifier.EventType.PostUpdate);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PostCacheLoad"))
                {
                    translator.PushPathfindingGraphModifierEventType(L, Pathfinding.GraphModifier.EventType.PostCacheLoad);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.GraphModifier.EventType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.GraphModifier.EventType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingRaycastModifierQualityWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.RaycastModifier.Quality), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.RaycastModifier.Quality), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.RaycastModifier.Quality), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Low", Pathfinding.RaycastModifier.Quality.Low);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Medium", Pathfinding.RaycastModifier.Quality.Medium);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "High", Pathfinding.RaycastModifier.Quality.High);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Highest", Pathfinding.RaycastModifier.Quality.Highest);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.RaycastModifier.Quality), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingRaycastModifierQuality(L, (Pathfinding.RaycastModifier.Quality)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Low"))
                {
                    translator.PushPathfindingRaycastModifierQuality(L, Pathfinding.RaycastModifier.Quality.Low);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Medium"))
                {
                    translator.PushPathfindingRaycastModifierQuality(L, Pathfinding.RaycastModifier.Quality.Medium);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "High"))
                {
                    translator.PushPathfindingRaycastModifierQuality(L, Pathfinding.RaycastModifier.Quality.High);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Highest"))
                {
                    translator.PushPathfindingRaycastModifierQuality(L, Pathfinding.RaycastModifier.Quality.Highest);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.RaycastModifier.Quality!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.RaycastModifier.Quality! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingSimpleSmoothModifierSmoothTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.SimpleSmoothModifier.SmoothType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.SimpleSmoothModifier.SmoothType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.SimpleSmoothModifier.SmoothType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Simple", Pathfinding.SimpleSmoothModifier.SmoothType.Simple);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bezier", Pathfinding.SimpleSmoothModifier.SmoothType.Bezier);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OffsetSimple", Pathfinding.SimpleSmoothModifier.SmoothType.OffsetSimple);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CurvedNonuniform", Pathfinding.SimpleSmoothModifier.SmoothType.CurvedNonuniform);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.SimpleSmoothModifier.SmoothType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingSimpleSmoothModifierSmoothType(L, (Pathfinding.SimpleSmoothModifier.SmoothType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Simple"))
                {
                    translator.PushPathfindingSimpleSmoothModifierSmoothType(L, Pathfinding.SimpleSmoothModifier.SmoothType.Simple);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bezier"))
                {
                    translator.PushPathfindingSimpleSmoothModifierSmoothType(L, Pathfinding.SimpleSmoothModifier.SmoothType.Bezier);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OffsetSimple"))
                {
                    translator.PushPathfindingSimpleSmoothModifierSmoothType(L, Pathfinding.SimpleSmoothModifier.SmoothType.OffsetSimple);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CurvedNonuniform"))
                {
                    translator.PushPathfindingSimpleSmoothModifierSmoothType(L, Pathfinding.SimpleSmoothModifier.SmoothType.CurvedNonuniform);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.SimpleSmoothModifier.SmoothType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.SimpleSmoothModifier.SmoothType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingStartEndModifierExactnessWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.StartEndModifier.Exactness), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.StartEndModifier.Exactness), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.StartEndModifier.Exactness), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SnapToNode", Pathfinding.StartEndModifier.Exactness.SnapToNode);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Original", Pathfinding.StartEndModifier.Exactness.Original);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Interpolate", Pathfinding.StartEndModifier.Exactness.Interpolate);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ClosestOnNode", Pathfinding.StartEndModifier.Exactness.ClosestOnNode);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NodeConnection", Pathfinding.StartEndModifier.Exactness.NodeConnection);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.StartEndModifier.Exactness), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingStartEndModifierExactness(L, (Pathfinding.StartEndModifier.Exactness)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "SnapToNode"))
                {
                    translator.PushPathfindingStartEndModifierExactness(L, Pathfinding.StartEndModifier.Exactness.SnapToNode);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Original"))
                {
                    translator.PushPathfindingStartEndModifierExactness(L, Pathfinding.StartEndModifier.Exactness.Original);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Interpolate"))
                {
                    translator.PushPathfindingStartEndModifierExactness(L, Pathfinding.StartEndModifier.Exactness.Interpolate);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ClosestOnNode"))
                {
                    translator.PushPathfindingStartEndModifierExactness(L, Pathfinding.StartEndModifier.Exactness.ClosestOnNode);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NodeConnection"))
                {
                    translator.PushPathfindingStartEndModifierExactness(L, Pathfinding.StartEndModifier.Exactness.NodeConnection);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.StartEndModifier.Exactness!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.StartEndModifier.Exactness! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingBlockManagerBlockModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.BlockManager.BlockMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.BlockManager.BlockMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.BlockManager.BlockMode), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AllExceptSelector", Pathfinding.BlockManager.BlockMode.AllExceptSelector);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OnlySelector", Pathfinding.BlockManager.BlockMode.OnlySelector);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.BlockManager.BlockMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingBlockManagerBlockMode(L, (Pathfinding.BlockManager.BlockMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "AllExceptSelector"))
                {
                    translator.PushPathfindingBlockManagerBlockMode(L, Pathfinding.BlockManager.BlockMode.AllExceptSelector);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OnlySelector"))
                {
                    translator.PushPathfindingBlockManagerBlockMode(L, Pathfinding.BlockManager.BlockMode.OnlySelector);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.BlockManager.BlockMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.BlockManager.BlockMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class PathfindingRVORVOObstacleObstacleVertexWindingWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "KeepOut", Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding.KeepOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "KeepIn", Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding.KeepIn);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushPathfindingRVORVOObstacleObstacleVertexWinding(L, (Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "KeepOut"))
                {
                    translator.PushPathfindingRVORVOObstacleObstacleVertexWinding(L, Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding.KeepOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "KeepIn"))
                {
                    translator.PushPathfindingRVORVOObstacleObstacleVertexWinding(L, Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding.KeepIn);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIBlendModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.BlendMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.BlendMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.BlendMode), L, null, 13, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Normal", FairyGUI.BlendMode.Normal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.BlendMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Add", FairyGUI.BlendMode.Add);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Multiply", FairyGUI.BlendMode.Multiply);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Screen", FairyGUI.BlendMode.Screen);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Erase", FairyGUI.BlendMode.Erase);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Mask", FairyGUI.BlendMode.Mask);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Below", FairyGUI.BlendMode.Below);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Off", FairyGUI.BlendMode.Off);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom1", FairyGUI.BlendMode.Custom1);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom2", FairyGUI.BlendMode.Custom2);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom3", FairyGUI.BlendMode.Custom3);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.BlendMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIBlendMode(L, (FairyGUI.BlendMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Add"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Add);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Multiply"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Multiply);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Screen"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Screen);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Erase"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Erase);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Mask"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Mask);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Below"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Below);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Off"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Off);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom1"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Custom1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom2"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Custom2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom3"))
                {
                    translator.PushFairyGUIBlendMode(L, FairyGUI.BlendMode.Custom3);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.BlendMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.BlendMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIHitTestModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.HitTestMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.HitTestMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.HitTestMode), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Default", FairyGUI.HitTestMode.Default);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Raycast", FairyGUI.HitTestMode.Raycast);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.HitTestMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIHitTestMode(L, (FairyGUI.HitTestMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Default"))
                {
                    translator.PushFairyGUIHitTestMode(L, FairyGUI.HitTestMode.Default);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Raycast"))
                {
                    translator.PushFairyGUIHitTestMode(L, FairyGUI.HitTestMode.Raycast);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.HitTestMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.HitTestMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIDestroyMethodWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.DestroyMethod), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.DestroyMethod), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.DestroyMethod), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Destroy", FairyGUI.DestroyMethod.Destroy);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unload", FairyGUI.DestroyMethod.Unload);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.DestroyMethod.None);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.DestroyMethod), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIDestroyMethod(L, (FairyGUI.DestroyMethod)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Destroy"))
                {
                    translator.PushFairyGUIDestroyMethod(L, FairyGUI.DestroyMethod.Destroy);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unload"))
                {
                    translator.PushFairyGUIDestroyMethod(L, FairyGUI.DestroyMethod.Unload);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIDestroyMethod(L, FairyGUI.DestroyMethod.None);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.DestroyMethod!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.DestroyMethod! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIEaseTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.EaseType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.EaseType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.EaseType), L, null, 33, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Linear", FairyGUI.EaseType.Linear);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SineIn", FairyGUI.EaseType.SineIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SineOut", FairyGUI.EaseType.SineOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SineInOut", FairyGUI.EaseType.SineInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuadIn", FairyGUI.EaseType.QuadIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuadOut", FairyGUI.EaseType.QuadOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuadInOut", FairyGUI.EaseType.QuadInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CubicIn", FairyGUI.EaseType.CubicIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CubicOut", FairyGUI.EaseType.CubicOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CubicInOut", FairyGUI.EaseType.CubicInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuartIn", FairyGUI.EaseType.QuartIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuartOut", FairyGUI.EaseType.QuartOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuartInOut", FairyGUI.EaseType.QuartInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuintIn", FairyGUI.EaseType.QuintIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuintOut", FairyGUI.EaseType.QuintOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "QuintInOut", FairyGUI.EaseType.QuintInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ExpoIn", FairyGUI.EaseType.ExpoIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ExpoOut", FairyGUI.EaseType.ExpoOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ExpoInOut", FairyGUI.EaseType.ExpoInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CircIn", FairyGUI.EaseType.CircIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CircOut", FairyGUI.EaseType.CircOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CircInOut", FairyGUI.EaseType.CircInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ElasticIn", FairyGUI.EaseType.ElasticIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ElasticOut", FairyGUI.EaseType.ElasticOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ElasticInOut", FairyGUI.EaseType.ElasticInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BackIn", FairyGUI.EaseType.BackIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BackOut", FairyGUI.EaseType.BackOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BackInOut", FairyGUI.EaseType.BackInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BounceIn", FairyGUI.EaseType.BounceIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BounceOut", FairyGUI.EaseType.BounceOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BounceInOut", FairyGUI.EaseType.BounceInOut);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom", FairyGUI.EaseType.Custom);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.EaseType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIEaseType(L, (FairyGUI.EaseType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Linear"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.Linear);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SineIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.SineIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SineOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.SineOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SineInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.SineInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuadIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuadIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuadOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuadOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuadInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuadInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CubicIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.CubicIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CubicOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.CubicOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CubicInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.CubicInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuartIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuartIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuartOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuartOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuartInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuartInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuintIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuintIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuintOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuintOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "QuintInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.QuintInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ExpoIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.ExpoIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ExpoOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.ExpoOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ExpoInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.ExpoInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CircIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.CircIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CircOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.CircOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CircInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.CircInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ElasticIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.ElasticIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ElasticOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.ElasticOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ElasticInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.ElasticInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BackIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.BackIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BackOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.BackOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BackInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.BackInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BounceIn"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.BounceIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BounceOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.BounceOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BounceInOut"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.BounceInOut);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom"))
                {
                    translator.PushFairyGUIEaseType(L, FairyGUI.EaseType.Custom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.EaseType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.EaseType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUITweenPropTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.TweenPropType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.TweenPropType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.TweenPropType), L, null, 18, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.TweenPropType.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "X", FairyGUI.TweenPropType.X);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Y", FairyGUI.TweenPropType.Y);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Z", FairyGUI.TweenPropType.Z);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "XY", FairyGUI.TweenPropType.XY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Position", FairyGUI.TweenPropType.Position);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Width", FairyGUI.TweenPropType.Width);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Height", FairyGUI.TweenPropType.Height);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Size", FairyGUI.TweenPropType.Size);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleX", FairyGUI.TweenPropType.ScaleX);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleY", FairyGUI.TweenPropType.ScaleY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Scale", FairyGUI.TweenPropType.Scale);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rotation", FairyGUI.TweenPropType.Rotation);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RotationX", FairyGUI.TweenPropType.RotationX);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RotationY", FairyGUI.TweenPropType.RotationY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Alpha", FairyGUI.TweenPropType.Alpha);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Progress", FairyGUI.TweenPropType.Progress);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.TweenPropType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUITweenPropType(L, (FairyGUI.TweenPropType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "X"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.X);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Y"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Y);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Z"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Z);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "XY"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.XY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Position"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Position);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Width"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Width);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Height"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Height);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Size"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Size);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleX"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.ScaleX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleY"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.ScaleY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Scale"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Scale);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Rotation"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Rotation);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RotationX"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.RotationX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RotationY"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.RotationY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Alpha"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Alpha);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Progress"))
                {
                    translator.PushFairyGUITweenPropType(L, FairyGUI.TweenPropType.Progress);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.TweenPropType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.TweenPropType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIPackageItemTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.PackageItemType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.PackageItemType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.PackageItemType), L, null, 10, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Image", FairyGUI.PackageItemType.Image);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MovieClip", FairyGUI.PackageItemType.MovieClip);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sound", FairyGUI.PackageItemType.Sound);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Component", FairyGUI.PackageItemType.Component);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Atlas", FairyGUI.PackageItemType.Atlas);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Font", FairyGUI.PackageItemType.Font);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Swf", FairyGUI.PackageItemType.Swf);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Misc", FairyGUI.PackageItemType.Misc);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unknown", FairyGUI.PackageItemType.Unknown);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.PackageItemType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIPackageItemType(L, (FairyGUI.PackageItemType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Image"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Image);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MovieClip"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.MovieClip);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sound"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Sound);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Component"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Component);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Atlas"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Atlas);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Font"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Font);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Swf"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Swf);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Misc"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Misc);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unknown"))
                {
                    translator.PushFairyGUIPackageItemType(L, FairyGUI.PackageItemType.Unknown);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.PackageItemType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.PackageItemType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIObjectTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ObjectType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ObjectType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ObjectType), L, null, 18, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Image", FairyGUI.ObjectType.Image);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MovieClip", FairyGUI.ObjectType.MovieClip);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Swf", FairyGUI.ObjectType.Swf);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Graph", FairyGUI.ObjectType.Graph);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Loader", FairyGUI.ObjectType.Loader);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Group", FairyGUI.ObjectType.Group);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Text", FairyGUI.ObjectType.Text);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RichText", FairyGUI.ObjectType.RichText);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InputText", FairyGUI.ObjectType.InputText);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Component", FairyGUI.ObjectType.Component);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "List", FairyGUI.ObjectType.List);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Label", FairyGUI.ObjectType.Label);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Button", FairyGUI.ObjectType.Button);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ComboBox", FairyGUI.ObjectType.ComboBox);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ProgressBar", FairyGUI.ObjectType.ProgressBar);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Slider", FairyGUI.ObjectType.Slider);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScrollBar", FairyGUI.ObjectType.ScrollBar);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ObjectType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIObjectType(L, (FairyGUI.ObjectType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Image"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Image);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MovieClip"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.MovieClip);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Swf"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Swf);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Graph"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Graph);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Loader"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Loader);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Group"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Group);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Text"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Text);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RichText"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.RichText);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InputText"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.InputText);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Component"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Component);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "List"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.List);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Label"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Label);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Button"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Button);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ComboBox"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.ComboBox);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ProgressBar"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.ProgressBar);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Slider"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.Slider);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScrollBar"))
                {
                    translator.PushFairyGUIObjectType(L, FairyGUI.ObjectType.ScrollBar);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ObjectType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ObjectType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIAlignTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.AlignType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.AlignType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.AlignType), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", FairyGUI.AlignType.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Center", FairyGUI.AlignType.Center);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", FairyGUI.AlignType.Right);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.AlignType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIAlignType(L, (FairyGUI.AlignType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushFairyGUIAlignType(L, FairyGUI.AlignType.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Center"))
                {
                    translator.PushFairyGUIAlignType(L, FairyGUI.AlignType.Center);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushFairyGUIAlignType(L, FairyGUI.AlignType.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.AlignType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.AlignType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIVertAlignTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.VertAlignType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.VertAlignType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.VertAlignType), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", FairyGUI.VertAlignType.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Middle", FairyGUI.VertAlignType.Middle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", FairyGUI.VertAlignType.Bottom);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.VertAlignType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIVertAlignType(L, (FairyGUI.VertAlignType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushFairyGUIVertAlignType(L, FairyGUI.VertAlignType.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Middle"))
                {
                    translator.PushFairyGUIVertAlignType(L, FairyGUI.VertAlignType.Middle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushFairyGUIVertAlignType(L, FairyGUI.VertAlignType.Bottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.VertAlignType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.VertAlignType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIOverflowTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.OverflowType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.OverflowType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.OverflowType), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Visible", FairyGUI.OverflowType.Visible);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Hidden", FairyGUI.OverflowType.Hidden);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Scroll", FairyGUI.OverflowType.Scroll);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.OverflowType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIOverflowType(L, (FairyGUI.OverflowType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Visible"))
                {
                    translator.PushFairyGUIOverflowType(L, FairyGUI.OverflowType.Visible);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Hidden"))
                {
                    translator.PushFairyGUIOverflowType(L, FairyGUI.OverflowType.Hidden);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Scroll"))
                {
                    translator.PushFairyGUIOverflowType(L, FairyGUI.OverflowType.Scroll);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.OverflowType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.OverflowType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIFillTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.FillType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.FillType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.FillType), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.FillType.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Scale", FairyGUI.FillType.Scale);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleMatchHeight", FairyGUI.FillType.ScaleMatchHeight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleMatchWidth", FairyGUI.FillType.ScaleMatchWidth);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleFree", FairyGUI.FillType.ScaleFree);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleNoBorder", FairyGUI.FillType.ScaleNoBorder);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.FillType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIFillType(L, (FairyGUI.FillType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIFillType(L, FairyGUI.FillType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Scale"))
                {
                    translator.PushFairyGUIFillType(L, FairyGUI.FillType.Scale);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleMatchHeight"))
                {
                    translator.PushFairyGUIFillType(L, FairyGUI.FillType.ScaleMatchHeight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleMatchWidth"))
                {
                    translator.PushFairyGUIFillType(L, FairyGUI.FillType.ScaleMatchWidth);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleFree"))
                {
                    translator.PushFairyGUIFillType(L, FairyGUI.FillType.ScaleFree);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleNoBorder"))
                {
                    translator.PushFairyGUIFillType(L, FairyGUI.FillType.ScaleNoBorder);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.FillType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.FillType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIAutoSizeTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.AutoSizeType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.AutoSizeType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.AutoSizeType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.AutoSizeType.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Both", FairyGUI.AutoSizeType.Both);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Height", FairyGUI.AutoSizeType.Height);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Shrink", FairyGUI.AutoSizeType.Shrink);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.AutoSizeType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIAutoSizeType(L, (FairyGUI.AutoSizeType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIAutoSizeType(L, FairyGUI.AutoSizeType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Both"))
                {
                    translator.PushFairyGUIAutoSizeType(L, FairyGUI.AutoSizeType.Both);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Height"))
                {
                    translator.PushFairyGUIAutoSizeType(L, FairyGUI.AutoSizeType.Height);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Shrink"))
                {
                    translator.PushFairyGUIAutoSizeType(L, FairyGUI.AutoSizeType.Shrink);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.AutoSizeType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.AutoSizeType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIScrollTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ScrollType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ScrollType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ScrollType), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", FairyGUI.ScrollType.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", FairyGUI.ScrollType.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Both", FairyGUI.ScrollType.Both);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ScrollType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIScrollType(L, (FairyGUI.ScrollType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushFairyGUIScrollType(L, FairyGUI.ScrollType.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushFairyGUIScrollType(L, FairyGUI.ScrollType.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Both"))
                {
                    translator.PushFairyGUIScrollType(L, FairyGUI.ScrollType.Both);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ScrollType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ScrollType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIScrollBarDisplayTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ScrollBarDisplayType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ScrollBarDisplayType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ScrollBarDisplayType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Default", FairyGUI.ScrollBarDisplayType.Default);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Visible", FairyGUI.ScrollBarDisplayType.Visible);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Auto", FairyGUI.ScrollBarDisplayType.Auto);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Hidden", FairyGUI.ScrollBarDisplayType.Hidden);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ScrollBarDisplayType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIScrollBarDisplayType(L, (FairyGUI.ScrollBarDisplayType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Default"))
                {
                    translator.PushFairyGUIScrollBarDisplayType(L, FairyGUI.ScrollBarDisplayType.Default);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Visible"))
                {
                    translator.PushFairyGUIScrollBarDisplayType(L, FairyGUI.ScrollBarDisplayType.Visible);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Auto"))
                {
                    translator.PushFairyGUIScrollBarDisplayType(L, FairyGUI.ScrollBarDisplayType.Auto);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Hidden"))
                {
                    translator.PushFairyGUIScrollBarDisplayType(L, FairyGUI.ScrollBarDisplayType.Hidden);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ScrollBarDisplayType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ScrollBarDisplayType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIRelationTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.RelationType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.RelationType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.RelationType), L, null, 26, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left_Left", FairyGUI.RelationType.Left_Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left_Center", FairyGUI.RelationType.Left_Center);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left_Right", FairyGUI.RelationType.Left_Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Center_Center", FairyGUI.RelationType.Center_Center);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right_Left", FairyGUI.RelationType.Right_Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right_Center", FairyGUI.RelationType.Right_Center);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right_Right", FairyGUI.RelationType.Right_Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top_Top", FairyGUI.RelationType.Top_Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top_Middle", FairyGUI.RelationType.Top_Middle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top_Bottom", FairyGUI.RelationType.Top_Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Middle_Middle", FairyGUI.RelationType.Middle_Middle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom_Top", FairyGUI.RelationType.Bottom_Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom_Middle", FairyGUI.RelationType.Bottom_Middle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom_Bottom", FairyGUI.RelationType.Bottom_Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Width", FairyGUI.RelationType.Width);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Height", FairyGUI.RelationType.Height);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LeftExt_Left", FairyGUI.RelationType.LeftExt_Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LeftExt_Right", FairyGUI.RelationType.LeftExt_Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RightExt_Left", FairyGUI.RelationType.RightExt_Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RightExt_Right", FairyGUI.RelationType.RightExt_Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopExt_Top", FairyGUI.RelationType.TopExt_Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopExt_Bottom", FairyGUI.RelationType.TopExt_Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomExt_Top", FairyGUI.RelationType.BottomExt_Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomExt_Bottom", FairyGUI.RelationType.BottomExt_Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Size", FairyGUI.RelationType.Size);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.RelationType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIRelationType(L, (FairyGUI.RelationType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left_Left"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Left_Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left_Center"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Left_Center);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left_Right"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Left_Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Center_Center"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Center_Center);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right_Left"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Right_Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right_Center"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Right_Center);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right_Right"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Right_Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top_Top"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Top_Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top_Middle"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Top_Middle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top_Bottom"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Top_Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Middle_Middle"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Middle_Middle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom_Top"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Bottom_Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom_Middle"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Bottom_Middle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom_Bottom"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Bottom_Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Width"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Width);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Height"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Height);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LeftExt_Left"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.LeftExt_Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LeftExt_Right"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.LeftExt_Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RightExt_Left"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.RightExt_Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RightExt_Right"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.RightExt_Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopExt_Top"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.TopExt_Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopExt_Bottom"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.TopExt_Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomExt_Top"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.BottomExt_Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomExt_Bottom"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.BottomExt_Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Size"))
                {
                    translator.PushFairyGUIRelationType(L, FairyGUI.RelationType.Size);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.RelationType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.RelationType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIListLayoutTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ListLayoutType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ListLayoutType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ListLayoutType), L, null, 6, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SingleColumn", FairyGUI.ListLayoutType.SingleColumn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SingleRow", FairyGUI.ListLayoutType.SingleRow);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FlowHorizontal", FairyGUI.ListLayoutType.FlowHorizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FlowVertical", FairyGUI.ListLayoutType.FlowVertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Pagination", FairyGUI.ListLayoutType.Pagination);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ListLayoutType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIListLayoutType(L, (FairyGUI.ListLayoutType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "SingleColumn"))
                {
                    translator.PushFairyGUIListLayoutType(L, FairyGUI.ListLayoutType.SingleColumn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SingleRow"))
                {
                    translator.PushFairyGUIListLayoutType(L, FairyGUI.ListLayoutType.SingleRow);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FlowHorizontal"))
                {
                    translator.PushFairyGUIListLayoutType(L, FairyGUI.ListLayoutType.FlowHorizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FlowVertical"))
                {
                    translator.PushFairyGUIListLayoutType(L, FairyGUI.ListLayoutType.FlowVertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pagination"))
                {
                    translator.PushFairyGUIListLayoutType(L, FairyGUI.ListLayoutType.Pagination);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ListLayoutType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ListLayoutType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIListSelectionModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ListSelectionMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ListSelectionMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ListSelectionMode), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Single", FairyGUI.ListSelectionMode.Single);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Multiple", FairyGUI.ListSelectionMode.Multiple);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Multiple_SingleClick", FairyGUI.ListSelectionMode.Multiple_SingleClick);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.ListSelectionMode.None);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ListSelectionMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIListSelectionMode(L, (FairyGUI.ListSelectionMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Single"))
                {
                    translator.PushFairyGUIListSelectionMode(L, FairyGUI.ListSelectionMode.Single);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Multiple"))
                {
                    translator.PushFairyGUIListSelectionMode(L, FairyGUI.ListSelectionMode.Multiple);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Multiple_SingleClick"))
                {
                    translator.PushFairyGUIListSelectionMode(L, FairyGUI.ListSelectionMode.Multiple_SingleClick);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIListSelectionMode(L, FairyGUI.ListSelectionMode.None);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ListSelectionMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ListSelectionMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIProgressTitleTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ProgressTitleType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ProgressTitleType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ProgressTitleType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Percent", FairyGUI.ProgressTitleType.Percent);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ValueAndMax", FairyGUI.ProgressTitleType.ValueAndMax);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Value", FairyGUI.ProgressTitleType.Value);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Max", FairyGUI.ProgressTitleType.Max);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ProgressTitleType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIProgressTitleType(L, (FairyGUI.ProgressTitleType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Percent"))
                {
                    translator.PushFairyGUIProgressTitleType(L, FairyGUI.ProgressTitleType.Percent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ValueAndMax"))
                {
                    translator.PushFairyGUIProgressTitleType(L, FairyGUI.ProgressTitleType.ValueAndMax);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Value"))
                {
                    translator.PushFairyGUIProgressTitleType(L, FairyGUI.ProgressTitleType.Value);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Max"))
                {
                    translator.PushFairyGUIProgressTitleType(L, FairyGUI.ProgressTitleType.Max);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ProgressTitleType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ProgressTitleType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIButtonModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ButtonMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ButtonMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ButtonMode), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Common", FairyGUI.ButtonMode.Common);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Check", FairyGUI.ButtonMode.Check);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radio", FairyGUI.ButtonMode.Radio);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ButtonMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIButtonMode(L, (FairyGUI.ButtonMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Common"))
                {
                    translator.PushFairyGUIButtonMode(L, FairyGUI.ButtonMode.Common);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Check"))
                {
                    translator.PushFairyGUIButtonMode(L, FairyGUI.ButtonMode.Check);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radio"))
                {
                    translator.PushFairyGUIButtonMode(L, FairyGUI.ButtonMode.Radio);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ButtonMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ButtonMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUITransitionActionTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.TransitionActionType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.TransitionActionType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.TransitionActionType), L, null, 18, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "XY", FairyGUI.TransitionActionType.XY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Size", FairyGUI.TransitionActionType.Size);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Scale", FairyGUI.TransitionActionType.Scale);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Pivot", FairyGUI.TransitionActionType.Pivot);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Alpha", FairyGUI.TransitionActionType.Alpha);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rotation", FairyGUI.TransitionActionType.Rotation);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Color", FairyGUI.TransitionActionType.Color);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Animation", FairyGUI.TransitionActionType.Animation);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Visible", FairyGUI.TransitionActionType.Visible);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sound", FairyGUI.TransitionActionType.Sound);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Transition", FairyGUI.TransitionActionType.Transition);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Shake", FairyGUI.TransitionActionType.Shake);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ColorFilter", FairyGUI.TransitionActionType.ColorFilter);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Skew", FairyGUI.TransitionActionType.Skew);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Text", FairyGUI.TransitionActionType.Text);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Icon", FairyGUI.TransitionActionType.Icon);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unknown", FairyGUI.TransitionActionType.Unknown);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.TransitionActionType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUITransitionActionType(L, (FairyGUI.TransitionActionType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "XY"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.XY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Size"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Size);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Scale"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Scale);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pivot"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Pivot);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Alpha"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Alpha);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Rotation"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Rotation);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Color"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Color);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Animation"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Animation);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Visible"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Visible);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sound"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Sound);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Transition"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Transition);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Shake"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Shake);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ColorFilter"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.ColorFilter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Skew"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Skew);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Text"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Text);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Icon"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Icon);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unknown"))
                {
                    translator.PushFairyGUITransitionActionType(L, FairyGUI.TransitionActionType.Unknown);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.TransitionActionType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.TransitionActionType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIGroupLayoutTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.GroupLayoutType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.GroupLayoutType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.GroupLayoutType), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.GroupLayoutType.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", FairyGUI.GroupLayoutType.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", FairyGUI.GroupLayoutType.Vertical);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.GroupLayoutType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIGroupLayoutType(L, (FairyGUI.GroupLayoutType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIGroupLayoutType(L, FairyGUI.GroupLayoutType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushFairyGUIGroupLayoutType(L, FairyGUI.GroupLayoutType.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushFairyGUIGroupLayoutType(L, FairyGUI.GroupLayoutType.Vertical);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.GroupLayoutType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.GroupLayoutType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIChildrenRenderOrderWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ChildrenRenderOrder), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ChildrenRenderOrder), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ChildrenRenderOrder), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ascent", FairyGUI.ChildrenRenderOrder.Ascent);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Descent", FairyGUI.ChildrenRenderOrder.Descent);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Arch", FairyGUI.ChildrenRenderOrder.Arch);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ChildrenRenderOrder), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIChildrenRenderOrder(L, (FairyGUI.ChildrenRenderOrder)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Ascent"))
                {
                    translator.PushFairyGUIChildrenRenderOrder(L, FairyGUI.ChildrenRenderOrder.Ascent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Descent"))
                {
                    translator.PushFairyGUIChildrenRenderOrder(L, FairyGUI.ChildrenRenderOrder.Descent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Arch"))
                {
                    translator.PushFairyGUIChildrenRenderOrder(L, FairyGUI.ChildrenRenderOrder.Arch);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ChildrenRenderOrder!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ChildrenRenderOrder! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIPopupDirectionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.PopupDirection), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.PopupDirection), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.PopupDirection), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Auto", FairyGUI.PopupDirection.Auto);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Up", FairyGUI.PopupDirection.Up);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Down", FairyGUI.PopupDirection.Down);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.PopupDirection), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIPopupDirection(L, (FairyGUI.PopupDirection)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Auto"))
                {
                    translator.PushFairyGUIPopupDirection(L, FairyGUI.PopupDirection.Auto);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Up"))
                {
                    translator.PushFairyGUIPopupDirection(L, FairyGUI.PopupDirection.Up);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Down"))
                {
                    translator.PushFairyGUIPopupDirection(L, FairyGUI.PopupDirection.Down);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.PopupDirection!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.PopupDirection! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIFlipTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.FlipType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.FlipType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.FlipType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.FlipType.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", FairyGUI.FlipType.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", FairyGUI.FlipType.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Both", FairyGUI.FlipType.Both);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.FlipType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIFlipType(L, (FairyGUI.FlipType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIFlipType(L, FairyGUI.FlipType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushFairyGUIFlipType(L, FairyGUI.FlipType.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushFairyGUIFlipType(L, FairyGUI.FlipType.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Both"))
                {
                    translator.PushFairyGUIFlipType(L, FairyGUI.FlipType.Both);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.FlipType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.FlipType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIFillMethodWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.FillMethod), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.FillMethod), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.FillMethod), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.FillMethod.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", FairyGUI.FillMethod.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", FairyGUI.FillMethod.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radial90", FairyGUI.FillMethod.Radial90);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radial180", FairyGUI.FillMethod.Radial180);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radial360", FairyGUI.FillMethod.Radial360);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.FillMethod), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIFillMethod(L, (FairyGUI.FillMethod)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIFillMethod(L, FairyGUI.FillMethod.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushFairyGUIFillMethod(L, FairyGUI.FillMethod.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushFairyGUIFillMethod(L, FairyGUI.FillMethod.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial90"))
                {
                    translator.PushFairyGUIFillMethod(L, FairyGUI.FillMethod.Radial90);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial180"))
                {
                    translator.PushFairyGUIFillMethod(L, FairyGUI.FillMethod.Radial180);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial360"))
                {
                    translator.PushFairyGUIFillMethod(L, FairyGUI.FillMethod.Radial360);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.FillMethod!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.FillMethod! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIOriginHorizontalWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.OriginHorizontal), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.OriginHorizontal), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.OriginHorizontal), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", FairyGUI.OriginHorizontal.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", FairyGUI.OriginHorizontal.Right);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.OriginHorizontal), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIOriginHorizontal(L, (FairyGUI.OriginHorizontal)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushFairyGUIOriginHorizontal(L, FairyGUI.OriginHorizontal.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushFairyGUIOriginHorizontal(L, FairyGUI.OriginHorizontal.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.OriginHorizontal!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.OriginHorizontal! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIOriginVerticalWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.OriginVertical), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.OriginVertical), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.OriginVertical), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", FairyGUI.OriginVertical.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", FairyGUI.OriginVertical.Bottom);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.OriginVertical), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIOriginVertical(L, (FairyGUI.OriginVertical)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushFairyGUIOriginVertical(L, FairyGUI.OriginVertical.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushFairyGUIOriginVertical(L, FairyGUI.OriginVertical.Bottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.OriginVertical!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.OriginVertical! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIOrigin90Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.Origin90), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.Origin90), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.Origin90), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopLeft", FairyGUI.Origin90.TopLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopRight", FairyGUI.Origin90.TopRight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomLeft", FairyGUI.Origin90.BottomLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomRight", FairyGUI.Origin90.BottomRight);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.Origin90), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIOrigin90(L, (FairyGUI.Origin90)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "TopLeft"))
                {
                    translator.PushFairyGUIOrigin90(L, FairyGUI.Origin90.TopLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopRight"))
                {
                    translator.PushFairyGUIOrigin90(L, FairyGUI.Origin90.TopRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomLeft"))
                {
                    translator.PushFairyGUIOrigin90(L, FairyGUI.Origin90.BottomLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomRight"))
                {
                    translator.PushFairyGUIOrigin90(L, FairyGUI.Origin90.BottomRight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.Origin90!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.Origin90! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIOrigin180Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.Origin180), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.Origin180), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.Origin180), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", FairyGUI.Origin180.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", FairyGUI.Origin180.Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", FairyGUI.Origin180.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", FairyGUI.Origin180.Right);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.Origin180), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIOrigin180(L, (FairyGUI.Origin180)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushFairyGUIOrigin180(L, FairyGUI.Origin180.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushFairyGUIOrigin180(L, FairyGUI.Origin180.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushFairyGUIOrigin180(L, FairyGUI.Origin180.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushFairyGUIOrigin180(L, FairyGUI.Origin180.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.Origin180!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.Origin180! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIOrigin360Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.Origin360), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.Origin360), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.Origin360), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", FairyGUI.Origin360.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", FairyGUI.Origin360.Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", FairyGUI.Origin360.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", FairyGUI.Origin360.Right);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.Origin360), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIOrigin360(L, (FairyGUI.Origin360)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushFairyGUIOrigin360(L, FairyGUI.Origin360.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushFairyGUIOrigin360(L, FairyGUI.Origin360.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushFairyGUIOrigin360(L, FairyGUI.Origin360.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushFairyGUIOrigin360(L, FairyGUI.Origin360.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.Origin360!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.Origin360! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIFitScreenWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.FitScreen), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.FitScreen), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.FitScreen), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.FitScreen.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FitSize", FairyGUI.FitScreen.FitSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FitWidthAndSetMiddle", FairyGUI.FitScreen.FitWidthAndSetMiddle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FitHeightAndSetCenter", FairyGUI.FitScreen.FitHeightAndSetCenter);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.FitScreen), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIFitScreen(L, (FairyGUI.FitScreen)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUIFitScreen(L, FairyGUI.FitScreen.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FitSize"))
                {
                    translator.PushFairyGUIFitScreen(L, FairyGUI.FitScreen.FitSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FitWidthAndSetMiddle"))
                {
                    translator.PushFairyGUIFitScreen(L, FairyGUI.FitScreen.FitWidthAndSetMiddle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FitHeightAndSetCenter"))
                {
                    translator.PushFairyGUIFitScreen(L, FairyGUI.FitScreen.FitHeightAndSetCenter);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.FitScreen!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.FitScreen! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIUtilsHtmlElementTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.Utils.HtmlElementType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.Utils.HtmlElementType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.Utils.HtmlElementType), L, null, 8, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Text", FairyGUI.Utils.HtmlElementType.Text);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Link", FairyGUI.Utils.HtmlElementType.Link);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Image", FairyGUI.Utils.HtmlElementType.Image);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Input", FairyGUI.Utils.HtmlElementType.Input);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Select", FairyGUI.Utils.HtmlElementType.Select);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Object", FairyGUI.Utils.HtmlElementType.Object);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LinkEnd", FairyGUI.Utils.HtmlElementType.LinkEnd);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.Utils.HtmlElementType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIUtilsHtmlElementType(L, (FairyGUI.Utils.HtmlElementType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Text"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.Text);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Link"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.Link);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Image"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.Image);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Input"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.Input);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Select"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.Select);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Object"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.Object);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LinkEnd"))
                {
                    translator.PushFairyGUIUtilsHtmlElementType(L, FairyGUI.Utils.HtmlElementType.LinkEnd);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.Utils.HtmlElementType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.Utils.HtmlElementType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIUtilsXMLTagTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.Utils.XMLTagType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.Utils.XMLTagType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.Utils.XMLTagType), L, null, 7, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Start", FairyGUI.Utils.XMLTagType.Start);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "End", FairyGUI.Utils.XMLTagType.End);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Void", FairyGUI.Utils.XMLTagType.Void);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CDATA", FairyGUI.Utils.XMLTagType.CDATA);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Comment", FairyGUI.Utils.XMLTagType.Comment);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Instruction", FairyGUI.Utils.XMLTagType.Instruction);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.Utils.XMLTagType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIUtilsXMLTagType(L, (FairyGUI.Utils.XMLTagType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Start"))
                {
                    translator.PushFairyGUIUtilsXMLTagType(L, FairyGUI.Utils.XMLTagType.Start);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "End"))
                {
                    translator.PushFairyGUIUtilsXMLTagType(L, FairyGUI.Utils.XMLTagType.End);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Void"))
                {
                    translator.PushFairyGUIUtilsXMLTagType(L, FairyGUI.Utils.XMLTagType.Void);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CDATA"))
                {
                    translator.PushFairyGUIUtilsXMLTagType(L, FairyGUI.Utils.XMLTagType.CDATA);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Comment"))
                {
                    translator.PushFairyGUIUtilsXMLTagType(L, FairyGUI.Utils.XMLTagType.Comment);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Instruction"))
                {
                    translator.PushFairyGUIUtilsXMLTagType(L, FairyGUI.Utils.XMLTagType.Instruction);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.Utils.XMLTagType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.Utils.XMLTagType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIRTLSupportDirectionTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.RTLSupport.DirectionType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.RTLSupport.DirectionType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.RTLSupport.DirectionType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UNKNOW", FairyGUI.RTLSupport.DirectionType.UNKNOW);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LTR", FairyGUI.RTLSupport.DirectionType.LTR);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RTL", FairyGUI.RTLSupport.DirectionType.RTL);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NEUTRAL", FairyGUI.RTLSupport.DirectionType.NEUTRAL);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.RTLSupport.DirectionType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIRTLSupportDirectionType(L, (FairyGUI.RTLSupport.DirectionType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "UNKNOW"))
                {
                    translator.PushFairyGUIRTLSupportDirectionType(L, FairyGUI.RTLSupport.DirectionType.UNKNOW);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LTR"))
                {
                    translator.PushFairyGUIRTLSupportDirectionType(L, FairyGUI.RTLSupport.DirectionType.LTR);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RTL"))
                {
                    translator.PushFairyGUIRTLSupportDirectionType(L, FairyGUI.RTLSupport.DirectionType.RTL);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "NEUTRAL"))
                {
                    translator.PushFairyGUIRTLSupportDirectionType(L, FairyGUI.RTLSupport.DirectionType.NEUTRAL);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.RTLSupport.DirectionType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.RTLSupport.DirectionType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUITextFormatSpecialStyleWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.TextFormat.SpecialStyle), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.TextFormat.SpecialStyle), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.TextFormat.SpecialStyle), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", FairyGUI.TextFormat.SpecialStyle.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Superscript", FairyGUI.TextFormat.SpecialStyle.Superscript);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Subscript", FairyGUI.TextFormat.SpecialStyle.Subscript);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.TextFormat.SpecialStyle), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUITextFormatSpecialStyle(L, (FairyGUI.TextFormat.SpecialStyle)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushFairyGUITextFormatSpecialStyle(L, FairyGUI.TextFormat.SpecialStyle.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Superscript"))
                {
                    translator.PushFairyGUITextFormatSpecialStyle(L, FairyGUI.TextFormat.SpecialStyle.Superscript);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Subscript"))
                {
                    translator.PushFairyGUITextFormatSpecialStyle(L, FairyGUI.TextFormat.SpecialStyle.Subscript);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.TextFormat.SpecialStyle!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.TextFormat.SpecialStyle! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIGPathPointCurveTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.GPathPoint.CurveType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.GPathPoint.CurveType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.GPathPoint.CurveType), L, null, 5, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CRSpline", FairyGUI.GPathPoint.CurveType.CRSpline);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bezier", FairyGUI.GPathPoint.CurveType.Bezier);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CubicBezier", FairyGUI.GPathPoint.CurveType.CubicBezier);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Straight", FairyGUI.GPathPoint.CurveType.Straight);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.GPathPoint.CurveType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIGPathPointCurveType(L, (FairyGUI.GPathPoint.CurveType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "CRSpline"))
                {
                    translator.PushFairyGUIGPathPointCurveType(L, FairyGUI.GPathPoint.CurveType.CRSpline);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bezier"))
                {
                    translator.PushFairyGUIGPathPointCurveType(L, FairyGUI.GPathPoint.CurveType.Bezier);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CubicBezier"))
                {
                    translator.PushFairyGUIGPathPointCurveType(L, FairyGUI.GPathPoint.CurveType.CubicBezier);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Straight"))
                {
                    translator.PushFairyGUIGPathPointCurveType(L, FairyGUI.GPathPoint.CurveType.Straight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.GPathPoint.CurveType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.GPathPoint.CurveType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIControllerActionActionTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.ControllerAction.ActionType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.ControllerAction.ActionType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.ControllerAction.ActionType), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PlayTransition", FairyGUI.ControllerAction.ActionType.PlayTransition);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ChangePage", FairyGUI.ControllerAction.ActionType.ChangePage);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.ControllerAction.ActionType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIControllerActionActionType(L, (FairyGUI.ControllerAction.ActionType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "PlayTransition"))
                {
                    translator.PushFairyGUIControllerActionActionType(L, FairyGUI.ControllerAction.ActionType.PlayTransition);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ChangePage"))
                {
                    translator.PushFairyGUIControllerActionActionType(L, FairyGUI.ControllerAction.ActionType.ChangePage);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.ControllerAction.ActionType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.ControllerAction.ActionType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIUIConfigConfigKeyWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.UIConfig.ConfigKey), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.UIConfig.ConfigKey), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.UIConfig.ConfigKey), L, null, 28, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultFont", FairyGUI.UIConfig.ConfigKey.DefaultFont);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ButtonSound", FairyGUI.UIConfig.ConfigKey.ButtonSound);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ButtonSoundVolumeScale", FairyGUI.UIConfig.ConfigKey.ButtonSoundVolumeScale);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HorizontalScrollBar", FairyGUI.UIConfig.ConfigKey.HorizontalScrollBar);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "VerticalScrollBar", FairyGUI.UIConfig.ConfigKey.VerticalScrollBar);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultScrollStep", FairyGUI.UIConfig.ConfigKey.DefaultScrollStep);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultScrollBarDisplay", FairyGUI.UIConfig.ConfigKey.DefaultScrollBarDisplay);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultScrollTouchEffect", FairyGUI.UIConfig.ConfigKey.DefaultScrollTouchEffect);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultScrollBounceEffect", FairyGUI.UIConfig.ConfigKey.DefaultScrollBounceEffect);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TouchScrollSensitivity", FairyGUI.UIConfig.ConfigKey.TouchScrollSensitivity);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "WindowModalWaiting", FairyGUI.UIConfig.ConfigKey.WindowModalWaiting);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "GlobalModalWaiting", FairyGUI.UIConfig.ConfigKey.GlobalModalWaiting);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PopupMenu", FairyGUI.UIConfig.ConfigKey.PopupMenu);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PopupMenu_seperator", FairyGUI.UIConfig.ConfigKey.PopupMenu_seperator);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LoaderErrorSign", FairyGUI.UIConfig.ConfigKey.LoaderErrorSign);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TooltipsWin", FairyGUI.UIConfig.ConfigKey.TooltipsWin);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DefaultComboBoxVisibleItemCount", FairyGUI.UIConfig.ConfigKey.DefaultComboBoxVisibleItemCount);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TouchDragSensitivity", FairyGUI.UIConfig.ConfigKey.TouchDragSensitivity);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ClickDragSensitivity", FairyGUI.UIConfig.ConfigKey.ClickDragSensitivity);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ModalLayerColor", FairyGUI.UIConfig.ConfigKey.ModalLayerColor);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RenderingTextBrighterOnDesktop", FairyGUI.UIConfig.ConfigKey.RenderingTextBrighterOnDesktop);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AllowSoftnessOnTopOrLeftSide", FairyGUI.UIConfig.ConfigKey.AllowSoftnessOnTopOrLeftSide);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InputCaretSize", FairyGUI.UIConfig.ConfigKey.InputCaretSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InputHighlightColor", FairyGUI.UIConfig.ConfigKey.InputHighlightColor);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EnhancedTextOutlineEffect", FairyGUI.UIConfig.ConfigKey.EnhancedTextOutlineEffect);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DepthSupportForPaintingMode", FairyGUI.UIConfig.ConfigKey.DepthSupportForPaintingMode);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PleaseSelect", FairyGUI.UIConfig.ConfigKey.PleaseSelect);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.UIConfig.ConfigKey), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIUIConfigConfigKey(L, (FairyGUI.UIConfig.ConfigKey)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultFont"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DefaultFont);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ButtonSound"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.ButtonSound);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ButtonSoundVolumeScale"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.ButtonSoundVolumeScale);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HorizontalScrollBar"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.HorizontalScrollBar);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "VerticalScrollBar"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.VerticalScrollBar);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultScrollStep"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DefaultScrollStep);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultScrollBarDisplay"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DefaultScrollBarDisplay);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultScrollTouchEffect"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DefaultScrollTouchEffect);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultScrollBounceEffect"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DefaultScrollBounceEffect);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TouchScrollSensitivity"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.TouchScrollSensitivity);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WindowModalWaiting"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.WindowModalWaiting);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "GlobalModalWaiting"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.GlobalModalWaiting);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PopupMenu"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.PopupMenu);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PopupMenu_seperator"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.PopupMenu_seperator);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LoaderErrorSign"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.LoaderErrorSign);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TooltipsWin"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.TooltipsWin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DefaultComboBoxVisibleItemCount"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DefaultComboBoxVisibleItemCount);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TouchDragSensitivity"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.TouchDragSensitivity);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ClickDragSensitivity"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.ClickDragSensitivity);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ModalLayerColor"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.ModalLayerColor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RenderingTextBrighterOnDesktop"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.RenderingTextBrighterOnDesktop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AllowSoftnessOnTopOrLeftSide"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.AllowSoftnessOnTopOrLeftSide);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InputCaretSize"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.InputCaretSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "InputHighlightColor"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.InputHighlightColor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EnhancedTextOutlineEffect"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.EnhancedTextOutlineEffect);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DepthSupportForPaintingMode"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.DepthSupportForPaintingMode);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PleaseSelect"))
                {
                    translator.PushFairyGUIUIConfigConfigKey(L, FairyGUI.UIConfig.ConfigKey.PleaseSelect);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.UIConfig.ConfigKey!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.UIConfig.ConfigKey! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIUIContentScalerScaleModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.UIContentScaler.ScaleMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.UIContentScaler.ScaleMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.UIContentScaler.ScaleMode), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ConstantPixelSize", FairyGUI.UIContentScaler.ScaleMode.ConstantPixelSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleWithScreenSize", FairyGUI.UIContentScaler.ScaleMode.ScaleWithScreenSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ConstantPhysicalSize", FairyGUI.UIContentScaler.ScaleMode.ConstantPhysicalSize);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.UIContentScaler.ScaleMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIUIContentScalerScaleMode(L, (FairyGUI.UIContentScaler.ScaleMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "ConstantPixelSize"))
                {
                    translator.PushFairyGUIUIContentScalerScaleMode(L, FairyGUI.UIContentScaler.ScaleMode.ConstantPixelSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleWithScreenSize"))
                {
                    translator.PushFairyGUIUIContentScalerScaleMode(L, FairyGUI.UIContentScaler.ScaleMode.ScaleWithScreenSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ConstantPhysicalSize"))
                {
                    translator.PushFairyGUIUIContentScalerScaleMode(L, FairyGUI.UIContentScaler.ScaleMode.ConstantPhysicalSize);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.UIContentScaler.ScaleMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.UIContentScaler.ScaleMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class FairyGUIUIContentScalerScreenMatchModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(FairyGUI.UIContentScaler.ScreenMatchMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(FairyGUI.UIContentScaler.ScreenMatchMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(FairyGUI.UIContentScaler.ScreenMatchMode), L, null, 4, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MatchWidthOrHeight", FairyGUI.UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MatchWidth", FairyGUI.UIContentScaler.ScreenMatchMode.MatchWidth);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MatchHeight", FairyGUI.UIContentScaler.ScreenMatchMode.MatchHeight);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(FairyGUI.UIContentScaler.ScreenMatchMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushFairyGUIUIContentScalerScreenMatchMode(L, (FairyGUI.UIContentScaler.ScreenMatchMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "MatchWidthOrHeight"))
                {
                    translator.PushFairyGUIUIContentScalerScreenMatchMode(L, FairyGUI.UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MatchWidth"))
                {
                    translator.PushFairyGUIUIContentScalerScreenMatchMode(L, FairyGUI.UIContentScaler.ScreenMatchMode.MatchWidth);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MatchHeight"))
                {
                    translator.PushFairyGUIUIContentScalerScreenMatchMode(L, FairyGUI.UIContentScaler.ScreenMatchMode.MatchHeight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for FairyGUI.UIContentScaler.ScreenMatchMode!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for FairyGUI.UIContentScaler.ScreenMatchMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Small", Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType.Small);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Large", Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType.Large);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType(L, (Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "Small"))
                {
                    translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType(L, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType.Small);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Large"))
                {
                    translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferType(L, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType.Large);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReasonWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason), L, null, 3, 0, 0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TooLarge", Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason.TooLarge);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EnoughFree", Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason.EnoughFree);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason(L, (Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {
			    if (LuaAPI.xlua_is_eq_str(L, 1, "TooLarge"))
                {
                    translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason(L, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason.TooLarge);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EnoughFree"))
                {
                    translator.PushMicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReason(L, Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason.EnoughFree);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason!");
                }
            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}