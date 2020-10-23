using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace init
{
    public class IAPPaymentHelper
    {
        #if !UNITY_EDITOR&&WINGLOONG&&UNITY_IOS
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void InitIAPManager();
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern bool IsIAPAvailable();
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void IAPBuyProduct(string id);
        #endif
        
		public static IAPPaymentHelper mIns = null;
        
		public static IAPPaymentHelper Instance
		{
			get
			{
				if (mIns == null)
                {
					mIns = new IAPPaymentHelper();
				}
                return mIns;
			}
		}

        public IAPPaymentHelper()
        {
            #if !UNITY_EDITOR&&WINGLOONG&&UNITY_IOS
            InitIAPManager();
            #endif
        }

        public bool CanPay()
        {
            #if !UNITY_EDITOR&&WINGLOONG&&UNITY_IOS
            return IsIAPAvailable();
            #endif
            return false;
        }

        public void BuyProduct(string id)
        {
            #if !UNITY_EDITOR&&WINGLOONG&&UNITY_IOS
            IAPBuyProduct(id);
            #endif
        }

    }
}

