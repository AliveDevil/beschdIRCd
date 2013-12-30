using System.Runtime.Serialization;

namespace EnumGenerator
{
	[DataContract]
	public class EnumModel
	{
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public EnumItemModel[] Items { get; set; }
	}

	/// <summary>
	/// Represents an Item in the enum.
	/// </summary>
	[DataContract]
	public class EnumItemModel
	{
		/// <summary>
		/// The Name of the object.
		/// </summary>
		[DataMember]
		public string Name { get; set; }
		/// <summary>
		/// Value for the entry.
		/// </summary>
		[DataMember]
		public int Value { get; set; }
		/// <summary>
		/// The commands which may return this result.
		/// </summary>
		[DataMember]
		public string[] Command { get; set; }
		/// <summary>
		/// What to know before using this?
		/// One item is one line.
		/// </summary>
		[DataMember]
		public string[] Remarks { get; set; }
		/// <summary>
		/// Short description
		/// </summary>
		[DataMember]
		public string Description { get; set; }
		/// <summary>
		/// ReplyCode or ErrorCode.
		/// </summary>
		[DataMember]
		public string[] Results { get; set; }
	}
}
