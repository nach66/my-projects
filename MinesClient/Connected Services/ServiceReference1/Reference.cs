﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinesClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageInfo", Namespace="http://schemas.datacontract.org/2004/07/WcfMinesService")]
    [System.SerializableAttribute()]
    public partial class MessageInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromCLientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> ToClientsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FromCLient {
            get {
                return this.FromCLientField;
            }
            set {
                if ((object.ReferenceEquals(this.FromCLientField, value) != true)) {
                    this.FromCLientField = value;
                    this.RaisePropertyChanged("FromCLient");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> ToClients {
            get {
                return this.ToClientsField;
            }
            set {
                if ((object.ReferenceEquals(this.ToClientsField, value) != true)) {
                    this.ToClientsField = value;
                    this.RaisePropertyChanged("ToClients");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserExistsFault", Namespace="http://schemas.datacontract.org/2004/07/WcfMinesService")]
    [System.SerializableAttribute()]
    public partial class UserExistsFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IGameService", CallbackContract=typeof(MinesClient.ServiceReference1.IGameServiceCallback))]
    public interface IGameService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/SendMessage", ReplyAction="http://tempuri.org/IGameService/SendMessageResponse")]
        void SendMessage(MinesClient.ServiceReference1.MessageInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/SendMessage", ReplyAction="http://tempuri.org/IGameService/SendMessageResponse")]
        System.Threading.Tasks.Task SendMessageAsync(MinesClient.ServiceReference1.MessageInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ClientConnected", ReplyAction="http://tempuri.org/IGameService/ClientConnectedResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MinesClient.ServiceReference1.UserExistsFault), Action="http://tempuri.org/IGameService/ClientConnectedUserExistsFaultFault", Name="UserExistsFault", Namespace="http://schemas.datacontract.org/2004/07/WcfMinesService")]
        void ClientConnected(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ClientConnected", ReplyAction="http://tempuri.org/IGameService/ClientConnectedResponse")]
        System.Threading.Tasks.Task ClientConnectedAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ClientDisconnected", ReplyAction="http://tempuri.org/IGameService/ClientDisconnectedResponse")]
        void ClientDisconnected(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ClientDisconnected", ReplyAction="http://tempuri.org/IGameService/ClientDisconnectedResponse")]
        System.Threading.Tasks.Task ClientDisconnectedAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/PutMessage")]
        void PutMessage(string message, string fromClient);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/UpdateClientsList")]
        void UpdateClientsList(System.Collections.Generic.List<string> clients);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : MinesClient.ServiceReference1.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.DuplexClientBase<MinesClient.ServiceReference1.IGameService>, MinesClient.ServiceReference1.IGameService {
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SendMessage(MinesClient.ServiceReference1.MessageInfo info) {
            base.Channel.SendMessage(info);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(MinesClient.ServiceReference1.MessageInfo info) {
            return base.Channel.SendMessageAsync(info);
        }
        
        public void ClientConnected(string username) {
            base.Channel.ClientConnected(username);
        }
        
        public System.Threading.Tasks.Task ClientConnectedAsync(string username) {
            return base.Channel.ClientConnectedAsync(username);
        }
        
        public void ClientDisconnected(string username) {
            base.Channel.ClientDisconnected(username);
        }
        
        public System.Threading.Tasks.Task ClientDisconnectedAsync(string username) {
            return base.Channel.ClientDisconnectedAsync(username);
        }
    }
}