using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace EnumGenerator {
	/// <summary>
	/// This will create a enum out of a json file.
	/// </summary>
	class Program {
		static void Main(string[] args) {
			if (args.Length == 0) {
				EnumModel model = new EnumModel();
				model.Name = "Template";
				model.Items = new[] {new EnumItemModel() {
					Command = new[] { "TEMPLATE"},
					Value = 1249,
					Description = "One Template",
					Name = "Template",
					Remarks = new[] { "Nothing" },
					Results = new[] { "Nothing" }
				}};
				serialize(model);
			} else {
				bool @class = false;
				bool assembly = false;
				string outputFile = "";
				string file = "";

				for (int i = 0; i < args.Length; ++i) {
					string arg = args[i].Replace("-", "").Replace("/", "");

					switch (arg) {
						case "c":
						case "class":
							@class = true;
							break;
						case "a":
						case "assembly":
							assembly = true;
							break;
						case "i":
						case "input":
							file = args[++i];
							break;
						case "o":
						case "output":
							outputFile = args[++i];
							break;
					}
				}

				if (string.IsNullOrWhiteSpace(file) | !(@class ^ assembly)) {
					Console.WriteLine("Input or (class|assembly) not specified. Review your command prompt and try again.");
					return;
				}
				FileInfo fileInfo = new FileInfo(file);
				if (!fileInfo.Exists) {
					Console.WriteLine("File {0} does not exist. Exiting.", fileInfo.FullName);
					return;
				}
				FileInfo outputFileInfo = new FileInfo(outputFile);
				if (outputFileInfo.Exists) {
					Console.WriteLine("Output already exists. Overwrite?");
					switch (Console.ReadLine()) {
						case "n":
							outputFile = null;
							outputFileInfo = null;
							break;
						case "y":
							outputFileInfo.Delete();
							break;
					}
				}
				if (@class) {
					EnumModel model = deserialize(fileInfo);
					if (model != null) {
						StringBuilder builder = new StringBuilder();

						// Create the enum.
						builder.AppendFormat("public enum {0} {{\n", model.Name);

						for (int i = 0; i < model.Items.Length; ++i) {
							// Create summary-entry for Documentation.
							// Have to be HTML-Encoded.
							builder.AppendFormat("/// <summary>\n" +
								"/// {0}\n" +
								"/// </summary>\n", HttpUtility.HtmlEncode(model.Items[i].Description));

							// Create remarks-section for Documentation.
							// Have to be HTML-Encoded
							builder.AppendLine("///<remarks>");
							for (int j = 0; j < model.Items[i].Remarks.Length; ++j) {
								builder.AppendFormat("/// <para>{0}</para>\n", HttpUtility.HtmlEncode(model.Items[i].Remarks[j]));
							}
							builder.AppendLine("/// <para>Can be invoked by:</para>");
							for (int j = 0; j < model.Items[i].Command.Length; ++j) {
								builder.AppendFormat("/// <para>{0}</para>\n", HttpUtility.HtmlEncode(model.Items[i].Command[j]));
							}
							builder.AppendLine("///</remarks>");

							// create the exceptions.
							for (int j = 0; j < model.Items[i].Results.Length; ++j) {
								builder.AppendFormat("/// <exception cref=\"{0}\" />\n", HttpUtility.HtmlEncode(model.Items[i].Results[j]));
							}

							builder.AppendFormat("{0} = {1},\n", model.Items[i].Name, model.Items[i].Value);
						}

						builder.Append("}");
						if (outputFileInfo != null)
							using (FileStream fileStream = outputFileInfo.OpenWrite())
							using (StreamWriter writer = new StreamWriter(fileStream))
								writer.WriteLine(builder);
						else
							Console.Out.WriteLine(builder);
					} else {
						Console.WriteLine("Error while reading file.");
						return;
					}
				}
				if (assembly) {
					Console.WriteLine("Assembly is not implemented. To be finished.");
					return;
				}
			}
		}

		static void serialize(EnumModel model) {
			FileInfo fileInfo = new FileInfo(model.Name + ".json");

			if (fileInfo.Exists)
				fileInfo.Delete();

			using (FileStream fileStream = fileInfo.OpenWrite()) {
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EnumModel));
				serializer.WriteObject(fileStream, model);
			}
		}
		static EnumModel deserialize(FileInfo fileInfo) {
			using (FileStream fileStream = fileInfo.OpenRead()) {
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EnumModel));
				return serializer.ReadObject(fileStream) as EnumModel;
			}
		}
	}
}
