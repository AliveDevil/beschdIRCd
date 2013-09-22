using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace beschdIRC.Settings {
	[DataContract]
	public class IRCSettings : ISetting {
		public string Name {
			get {
				return "IRCSettings";
			}
		}

		[DataMember]
		public string ServerName {
			get;
			set;
		}
		[DataMember]
		public string WelcomeMessage {
			get;
			set;
		}
		[DataMember]
		public string ServerAddress {
			get;
			set;
		}
		[DataMember]
		public string Address {
			get;
			set;
		}
		[DataMember]
		public int Port {
			get;
			set;
		}


		public void Save() {
			FileInfo fI = new FileInfo(Name + ".xconf");

			if (fI.Exists)
				fI.Delete();

			using (FileStream fS = fI.Open(FileMode.Create, FileAccess.Write, FileShare.None)) {
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(this.GetType());
				serializer.WriteObject(fS, this);
			}
		}
		public void Load() {
			FileInfo fI = new FileInfo(Name + ".xconf");

			Default();
			if (!fI.Exists) {
				Save();
				return;
			}

			using (FileStream fS = fI.Open(FileMode.Open, FileAccess.Read, FileShare.None)) {
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(this.GetType());
				IRCSettings settings = (IRCSettings)serializer.ReadObject(fS);
				PropertyInfo[] properties = settings.GetType().GetProperties();
				for (int i = 0; i < properties.Length; ++i)
					if (properties[i].CanWrite)
						properties[i].SetValue(this, properties[i].GetValue(settings));
			}
		}
		public void Reset() {
			Default();
		}
		public void Default() {
			ServerName = "beschdIRC Daemon";
			WelcomeMessage = "Welcome to this IRC Server running beschdIRC Daemon.";
			ServerAddress = "localhost";
			Address = "0.0.0.0";
			Port = 6667;
		}
	}
}
