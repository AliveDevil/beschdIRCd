using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Settings {
	public interface ISetting {
		string Name {
			get;
		}
		void Save();
		void Load();
		void Reset();
		void Default();
	}
}
