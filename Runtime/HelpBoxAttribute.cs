﻿using Naukri.InspectorMaid.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid
{
    public class HelpBoxAttribute : ItemAttribute, IBindingDataProvider
    {
        public HelpBoxAttribute(
            string message = "",
            HelpBoxMessageType messageType = HelpBoxMessageType.None,
            string binding = null,
            object[] args = null
            )
        {
            this.message = message;
            this.messageType = messageType;
            this.binding = binding;
            this.args = args;
        }

        public readonly string message;

        public readonly HelpBoxMessageType messageType;

        public object[] args { get; }

        public string binding { get; }
    }
}
