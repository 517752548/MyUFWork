using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace BaseFramework
{
    /// <summary>
    /// Event info.
    /// </summary>
    public class EventInfo
    {
        /// <summary>
        /// The event integer.
        /// </summary>
        public Dictionary<string, int> eventInteger;

        /// <summary>
        /// The event float.
        /// </summary>
        public Dictionary<string, float> eventFloat;

        /// <summary>
        /// The event string.
        /// </summary>
        public Dictionary<string, string> eventString;

        /// <summary>
        /// The event bool.
        /// </summary>
        public Dictionary<string, bool> eventBool;

        /// <summary>
        /// The event object.
        /// </summary>
        public GameObject eventObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventInfo"/> class.
        /// </summary>
        public AppflyerPurcherData AppflyerPurcherDataObject;

        public PurchaseEventArgs purchaseEventArgs;

        public EventInfo()
        {
            eventInteger = new Dictionary<string, int>();
            eventFloat = new Dictionary<string, float>();
            eventString = new Dictionary<string, string>();
            eventBool = new Dictionary<string, bool>();
            eventObject = null;
            purchaseEventArgs = null;
            AppflyerPurcherDataObject = null;
        }
    }
}