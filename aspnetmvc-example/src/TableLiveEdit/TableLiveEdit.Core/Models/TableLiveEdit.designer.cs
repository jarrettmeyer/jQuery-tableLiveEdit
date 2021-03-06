﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TableLiveEdit.Core.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Sample")]
	public partial class TableLiveEditDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertContact(Contact instance);
    partial void UpdateContact(Contact instance);
    partial void DeleteContact(Contact instance);
    partial void InsertRequest(Request instance);
    partial void UpdateRequest(Request instance);
    partial void DeleteRequest(Request instance);
    #endregion
		
		public TableLiveEditDataContext() : 
				base(global::TableLiveEdit.Core.Properties.Settings.Default.TableLiveEditConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TableLiveEditDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TableLiveEditDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TableLiveEditDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TableLiveEditDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Contact> Contacts
		{
			get
			{
				return this.GetTable<Contact>();
			}
		}
		
		public System.Data.Linq.Table<Request> Requests
		{
			get
			{
				return this.GetTable<Request>();
			}
		}
	}
	
	[Table(Name="dbo.Contacts")]
	public partial class Contact : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ContactId;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _EmailAddress;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnContactIdChanging(int value);
    partial void OnContactIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnEmailAddressChanging(string value);
    partial void OnEmailAddressChanged();
    #endregion
		
		public Contact()
		{
			OnCreated();
		}
		
		[Column(Storage="_ContactId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ContactId
		{
			get
			{
				return this._ContactId;
			}
			set
			{
				if ((this._ContactId != value))
				{
					this.OnContactIdChanging(value);
					this.SendPropertyChanging();
					this._ContactId = value;
					this.SendPropertyChanged("ContactId");
					this.OnContactIdChanged();
				}
			}
		}
		
		[Column(Storage="_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[Column(Storage="_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[Column(Storage="_EmailAddress", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string EmailAddress
		{
			get
			{
				return this._EmailAddress;
			}
			set
			{
				if ((this._EmailAddress != value))
				{
					this.OnEmailAddressChanging(value);
					this.SendPropertyChanging();
					this._EmailAddress = value;
					this.SendPropertyChanged("EmailAddress");
					this.OnEmailAddressChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Requests")]
	public partial class Request : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _IpAddress;
		
		private int _Count;
		
		private string _HostName;
		
		private string _Browser;
		
		private string _Platform;
		
		private System.DateTime _FirstRequest;
		
		private System.DateTime _LastRequest;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnIpAddressChanging(string value);
    partial void OnIpAddressChanged();
    partial void OnCountChanging(int value);
    partial void OnCountChanged();
    partial void OnHostNameChanging(string value);
    partial void OnHostNameChanged();
    partial void OnBrowserChanging(string value);
    partial void OnBrowserChanged();
    partial void OnPlatformChanging(string value);
    partial void OnPlatformChanged();
    partial void OnFirstRequestChanging(System.DateTime value);
    partial void OnFirstRequestChanged();
    partial void OnLastRequestChanging(System.DateTime value);
    partial void OnLastRequestChanged();
    #endregion
		
		public Request()
		{
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_IpAddress", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
		public string IpAddress
		{
			get
			{
				return this._IpAddress;
			}
			set
			{
				if ((this._IpAddress != value))
				{
					this.OnIpAddressChanging(value);
					this.SendPropertyChanging();
					this._IpAddress = value;
					this.SendPropertyChanged("IpAddress");
					this.OnIpAddressChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="Int NOT NULL")]
		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				if ((this._Count != value))
				{
					this.OnCountChanging(value);
					this.SendPropertyChanging();
					this._Count = value;
					this.SendPropertyChanged("Count");
					this.OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_HostName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string HostName
		{
			get
			{
				return this._HostName;
			}
			set
			{
				if ((this._HostName != value))
				{
					this.OnHostNameChanging(value);
					this.SendPropertyChanging();
					this._HostName = value;
					this.SendPropertyChanged("HostName");
					this.OnHostNameChanged();
				}
			}
		}
		
		[Column(Storage="_Browser", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Browser
		{
			get
			{
				return this._Browser;
			}
			set
			{
				if ((this._Browser != value))
				{
					this.OnBrowserChanging(value);
					this.SendPropertyChanging();
					this._Browser = value;
					this.SendPropertyChanged("Browser");
					this.OnBrowserChanged();
				}
			}
		}
		
		[Column(Storage="_Platform", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Platform
		{
			get
			{
				return this._Platform;
			}
			set
			{
				if ((this._Platform != value))
				{
					this.OnPlatformChanging(value);
					this.SendPropertyChanging();
					this._Platform = value;
					this.SendPropertyChanged("Platform");
					this.OnPlatformChanged();
				}
			}
		}
		
		[Column(Storage="_FirstRequest", DbType="DateTime NOT NULL")]
		public System.DateTime FirstRequest
		{
			get
			{
				return this._FirstRequest;
			}
			set
			{
				if ((this._FirstRequest != value))
				{
					this.OnFirstRequestChanging(value);
					this.SendPropertyChanging();
					this._FirstRequest = value;
					this.SendPropertyChanged("FirstRequest");
					this.OnFirstRequestChanged();
				}
			}
		}
		
		[Column(Storage="_LastRequest", DbType="DateTime NOT NULL")]
		public System.DateTime LastRequest
		{
			get
			{
				return this._LastRequest;
			}
			set
			{
				if ((this._LastRequest != value))
				{
					this.OnLastRequestChanging(value);
					this.SendPropertyChanging();
					this._LastRequest = value;
					this.SendPropertyChanged("LastRequest");
					this.OnLastRequestChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
